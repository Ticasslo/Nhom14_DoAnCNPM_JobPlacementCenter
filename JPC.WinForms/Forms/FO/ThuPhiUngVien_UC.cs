using JPC.Business.Services.Implementations.FO;
using JPC.Business.Services.Interfaces.FO;
using JPC.Models;
using JPC.WinForms.Common.UI;
using Nhom14_DoAnCNPM_JobPlacementCenter_Code.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.FO
{
    public partial class ThuPhiUngVien_UC : UserControl
    {
        private IThuPhiUngVienService _service;
        private decimal _donGiaCoDinh = 30000m;
        private bool _binding = false;

        public ThuPhiUngVien_UC()
        {
            InitializeComponent();

            UiKit.TuneCombo(cbbIdUngVien);
            UiKit.TuneCombo(cbbIdUngTuyen);
            UiKit.TuneCombo(cbbDonViTien, visibleItems: 6);

            btnLamMoi.Click += (_, __) => ResetForm();
            cbbIdUngVien.SelectedIndexChanged += cbbIdUngVien_SelectedIndexChanged;
            cbbIdUngTuyen.SelectedIndexChanged += (s, e2) =>
            {
                if (cbbIdUngTuyen.SelectedIndex >= 0)
                {
                    txtSoTien.Text = string.Format("{0:#,0}", _donGiaCoDinh);
                    txtVietBangChu.Text = VietnameseNumber.ToCurrencyWords(_donGiaCoDinh) + " đồng";
                }
            };

            txtSoTien.ReadOnly = true;
            _service = new ThuPhiUngVienService();
            
        }

        private void ResetForm()
        {
            _binding = true; // <-- chặn event khi clear UI

            foreach (var tb in grpBoxLapHoaDon.Controls.OfType<Guna.UI2.WinForms.Guna2TextBox>())
                tb.Text = string.Empty;

            cbDaNhanDuSoTien.Checked = false;
            txtSoTien.Text = string.Format("{0:#,0}", _donGiaCoDinh);
            txtLyDo.Text = "Phí ứng tuyển (cố định)";

            cbbIdUngTuyen.DataSource = null;

            dtpNgayLapPhieu.Value = DateTime.Now;
            dtpNgayKy.Value = DateTime.Now;

            _binding = false;
        }

        private void cbbIdUngVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_binding || _service == null || cbbIdUngVien.SelectedIndex < 0) return;

            var drv = cbbIdUngVien.SelectedItem as DataRowView;
            if (drv == null) return;

            var uvId = Convert.ToInt32(drv["uv_id"]);
            var hoTen = drv["ho_ten"].ToString();
            var diaChi = drv["dia_chi"].ToString();

            txtHoVaTenNguoiNop.Text = hoTen;
            txtDiaChi.Text = diaChi;

            _binding = true;
            var ut = _service.GetHoSoUngTuyenChuaThuPhi(uvId);
            cbbIdUngTuyen.ValueMember = "ut_id";
            cbbIdUngTuyen.DisplayMember = "display";
            cbbIdUngTuyen.DataSource = ut;

            // chọn mục đầu nếu có
            cbbIdUngTuyen.SelectedIndex = ut.Rows.Count > 0 ? 0 : -1;
            _binding = false;

            txtSoTien.Text = $"{_donGiaCoDinh:#,0}";
            txtVietBangChu.Text = VietnameseNumber.ToCurrencyWords(_donGiaCoDinh) + " đồng";

            if (ut.Rows.Count == 0)
            {
                MessageBox.Show("Ứng viên này không có hồ sơ ứng tuyển nào chưa thu phí.");
            }
        }
        private void txtVietBangChu_Leave(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtSoTien.Text.Replace(",", ""), out var v) && v > 0)
            {
                txtSoTien.Text = $"{v:#,0}";
                txtVietBangChu.Text = VietnameseNumber.ToCurrencyWords(v) + " đồng";
            }
        }

        private void ThuPhiUngVien_UC_Load(object sender, EventArgs e)
        {
            try
            {
                _binding = true;

                // đơn giá cố định
                _donGiaCoDinh = _service.GetDonGiaCoDinh();
                if (_donGiaCoDinh <= 0) _donGiaCoDinh = 30000m;
                txtSoTien.Text = string.Format("{0:#,0}", _donGiaCoDinh);

                // ứng viên
                var uv = _service.GetUngVien();
                cbbIdUngVien.ValueMember = "uv_id";
                cbbIdUngVien.DisplayMember = "ho_ten";
                cbbIdUngVien.DataSource = uv;

                cbbIdUngVien.SelectedIndex = uv.Rows.Count > 0 ? 0 : -1;

                // tiền tệ
                cbbDonViTien.Items.Clear();
                cbbDonViTien.Items.Add("VND");
                cbbDonViTien.SelectedIndex = 0;

                dtpNgayLapPhieu.Value = DateTime.Now;
                dtpNgayKy.Value = DateTime.Now;

                _binding = false;
                
            }
            catch (Exception ex)
            {
                _binding = false;
                MessageBox.Show("Không nạp được dữ liệu (UV/NV): " + ex.Message);
            }
        }

        private void btnXuatPhieuThu_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            if (cbbIdUngVien.SelectedIndex < 0) sb.AppendLine("• Chưa chọn Ứng viên.");
            if (cbbIdUngTuyen.SelectedIndex < 0) sb.AppendLine("• Chưa chọn hồ sơ Ứng tuyển.");
            if (sb.Length > 0) { MessageBox.Show(sb.ToString()); return; }

            var rUv = (DataRowView)cbbIdUngVien.SelectedItem;
            var uvId = (int)rUv["uv_id"];
            var tenUv = rUv["ho_ten"].ToString();
            var diaChi = txtDiaChi.Text?.Trim() ?? "";
            var ngayLap = dtpNgayLapPhieu.Value;
            var rUt = (DataRowView)cbbIdUngTuyen.SelectedItem;
            var utId = (int)rUt["ut_id"];

            var maNv = UserSession.NhanVien.MaNhanVien; // giữ nguyên cách dùng của bạn

            try
            {
                var result = _service.LapHoaDonPhiUngVien(uvId, utId, tenUv, maNv);

                var ps = new Dictionary<string, string>
                {
                    ["DonVi"] = "Trung tâm Giới thiệu Việc làm SV",
                    ["DiaChiDonVi"] = "TP. HCM",
                    ["SoPhieu"] = string.IsNullOrWhiteSpace(txtSo.Text) ? "HD-" + result.maHoaDon : txtSo.Text.Trim(),
                    ["NgayLap"] = $"Ngày {ngayLap.Day} tháng {ngayLap.Month} năm {ngayLap.Year}",

                    ["TenNguoiNop"] = tenUv,
                    ["DiaChiNguoiNop"] = diaChi,
                    ["LyDoNop"] = string.IsNullOrWhiteSpace(txtLyDo.Text) ? "Phí ứng tuyển (cố định)" : txtLyDo.Text.Trim(),
                    ["SoTien"] = string.Format("{0:#,0}", result.soTien),
                    ["SoTienBangChu"] = VietnameseNumber.ToCurrencyWords(result.soTien) + " đồng",

                    ["KemTheo"] = txtKemTheo.Text,
                    ["ChungTuGoc"] = txtChungTuGoc.Text,

                    ["QuyenSo"] = txtQuyenSo.Text,
                    ["No"] = txtNo.Text,
                    ["Co"] = txtCo.Text
                };

                using (var f = new reportForm(ps)) f.ShowDialog();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lập hóa đơn: " + ex.Message);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}
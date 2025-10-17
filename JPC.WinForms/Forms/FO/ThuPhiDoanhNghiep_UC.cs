using JPC.Business.Services.Interfaces.FO;
using JPC.Models;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
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
    public partial class ThuPhiDoanhNghiep_UC : UserControl
    {
        private IThuPhiDoanhNghiepService _service;
        private int _soNgay = 0;
        private decimal _soTien = 0;

        public ThuPhiDoanhNghiep_UC()
        {
            InitializeComponent();

            this.Load += ThuPhiDoanhNghiep_Load;
            iconBtnReload.Click += (_, __) => ResetForm();
            btnXuatPhieuThu.Click += btnXuatPhieuThu_Click;

            cbbIdDoanhNghiep.SelectedIndexChanged += cbbIdDoanhNghiep_SelectedIndexChanged;
            cbbIdTinTuyenDung.SelectedIndexChanged += cbbIdTinTuyenDung_SelectedIndexChanged_1;

            txtSoTien.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
            };
        }

        public void BindService(IThuPhiDoanhNghiepService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));

            // Doanh nghiệp
            var dn = _service.GetDoanhNghieps(); // DataTable
            cbbIdDoanhNghiep.ValueMember = "dn_id";
            cbbIdDoanhNghiep.DisplayMember = "ten_doanh_nghiep";
            cbbIdDoanhNghiep.DataSource = dn;

            // Nhân viên
            var nv = _service.GetNhanViens(); // DataTable
            void BindNV(ComboBox cb)
            {
                cb.DataSource = nv.Copy();
                cb.ValueMember = "ma_nhan_vien";
                cb.DisplayMember = "ho_ten";
                cb.SelectedIndex = -1;
            }
            BindNV(cbbGiamDoc); BindNV(cbbKeToanTruong); BindNV(cbbThuQuy);

            // Tiền tệ + reset
            cbbDonViTien.Items.Clear(); cbbDonViTien.Items.Add("VND"); cbbDonViTien.SelectedIndex = 0;
            ResetForm();
        }

        private void ResetForm()
        {
            // Clear textboxes trong group
            foreach (var tb in this.grpBoxLapHoaDon.Controls.OfType<Guna.UI2.WinForms.Guna2TextBox>())
                tb.Text = string.Empty;

            // dates
            dtpNgayLapPhieu.Value = DateTime.Now;
            dtpNgayKy.Value = DateTime.Now;

            // default
            txtLyDo.Text = "Phí đăng tin tuyển dụng theo số ngày tồn tại tin";
            cbDaNhanDuSoTien.Checked = false;

            // combos
            cbbIdDoanhNghiep.SelectedIndex = -1;
            cbbIdTinTuyenDung.DataSource = null;
            cbbGiamDoc.SelectedIndex = -1;
            cbbKeToanTruong.SelectedIndex = -1;
            cbbThuQuy.SelectedIndex = -1;

            _soNgay = 0; _soTien = 0;
        }
        private void ThuPhiDoanhNghiep_Load(object sender, EventArgs e)
        {
            if (_service == null)
            {
                // để trống – bạn đã gán service từ TrangChuFO_Form
                return;
            }
        }
        private bool ValidateInput(out string msg)
        {
            var sb = new StringBuilder();
            if (cbbIdDoanhNghiep.SelectedIndex < 0) sb.AppendLine("• Chưa chọn Doanh nghiệp.");
            if (cbbIdTinTuyenDung.SelectedIndex < 0) sb.AppendLine("• Chưa chọn Tin tuyển dụng.");
            if (!decimal.TryParse(txtSoTien.Text.Replace(",", ""), out var st) || st <= 0)
                sb.AppendLine("• Số tiền không hợp lệ (>0).");
            msg = sb.ToString();
            return msg.Length == 0;
        }

        private void cbbIdDoanhNghiep_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbIdDoanhNghiep.SelectedIndex < 0) return;
            int dnId = Convert.ToInt32((cbbIdDoanhNghiep.SelectedItem as DataRowView)["dn_id"]);

            var tins = _service.GetTinByDoanhNghiep_ForCbb(dnId); // DataTable: tin_id, ngay_dang, han_nop_ho_so, ma_hoa_don, so_tien_hd, display
            cbbIdTinTuyenDung.DataSource = null;
            cbbIdTinTuyenDung.ValueMember = "tin_id";
            cbbIdTinTuyenDung.DisplayMember = "display";
            cbbIdTinTuyenDung.DataSource = tins;

            // clear
            txtSoNgayDangTin.Text = ""; txtSoTien.Text = ""; txtVietBangChu.Text = "";
            _soNgay = 0; _soTien = 0;
        }

        private void cbbIdTinTuyenDung_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbbIdTinTuyenDung.SelectedIndex < 0) return;

            var r = (DataRowView)cbbIdTinTuyenDung.SelectedItem;
            var ngayDang = Convert.ToDateTime(r["ngay_dang"]);
            var hanNop = Convert.ToDateTime(r["han_nop_ho_so"]);

            _soNgay = Math.Max(1, (hanNop.Date - ngayDang.Date).Days + 1);
            txtSoNgayDangTin.Text = _soNgay.ToString();

            if (r["ma_hoa_don"] != DBNull.Value)
            {
                _soTien = Convert.ToDecimal(r["so_tien_hd"]);
                txtSoTien.Text = $"{_soTien:#,0}";
                txtVietBangChu.Text = VietnameseNumber.ToCurrencyWords(_soTien) + " đồng";
                txtSoTien.ReadOnly = true;
                txtSoTien.BackColor = Color.Gainsboro;
            }
            else
            {
                var donGia = _service.GetDonGiaNgay();
                _soTien = _soNgay * donGia;
                txtSoTien.Text = $"{_soTien:#,0}";
                txtVietBangChu.Text = VietnameseNumber.ToCurrencyWords(_soTien) + " đồng";
                txtSoTien.ReadOnly = false;
                txtSoTien.BackColor = SystemColors.Window;
            }
        }
        private void btnXuatPhieuThu_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(out var msg)) { MessageBox.Show(msg); return; }

            var rTin = (DataRowView)cbbIdTinTuyenDung.SelectedItem;
            int tinId = (int)rTin["tin_id"];
            int maNv = UserSession.NhanVien.MaNhanVien;

            if (!decimal.TryParse(txtSoTien.Text.Replace(",", ""), out var soTienNhap) || soTienNhap <= 0)
            {
                MessageBox.Show("Số tiền không hợp lệ."); return;
            }

            try
            {
                int maHd, soNgay; decimal soTien;

                // Nếu combobox đang chứa ma_hoa_don → chỉ in lại
                if (rTin["ma_hoa_don"] != DBNull.Value)
                {
                    maHd = Convert.ToInt32(rTin["ma_hoa_don"]);
                    soTien = Convert.ToDecimal(rTin["so_tien_hd"]);
                    soNgay = _soNgay;
                }
                else
                {
                    // Lập hóa đơn mới qua service (có mark paid & activate tin)
                    var result = _service.LapHoaDonThuPhiDN(
                        tinId,
                        maNv,
                        soTienNhap != _soTien ? (decimal?)soTienNhap : null
                    );
                    maHd = result.maHoaDon; soNgay = result.soNgay; soTien = result.soTien;
                }

                var ps = BuildReportParams(maHd, soNgay, soTien);
                using (var f = new reportForm(ps)) f.ShowDialog();

                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lập/ in hóa đơn: " + ex.Message);
            }
        }
        private Dictionary<string, string> BuildReportParams(int maHd, int soNgay, decimal soTien)
        {
            // Fix: Replace VB-style string concatenation (&) and Parameters!NgayLap.Value with C# DateTime.Now
            // Use DateTime.Now for "NgayLap" as context does not provide a NgayLap variable
            var ngayLap = DateTime.Now;
            return new Dictionary<string, string>
            {
                ["DonVi"] = txtDonVi.Text,
                ["DiaChiDonVi"] = txtDiaChi1.Text,
                ["QuyenSo"] = txtQuyenSo.Text,
                ["SoPhieu"] = string.IsNullOrWhiteSpace(txtSo.Text) ? "HD-" + maHd : txtSo.Text.Trim(),
                ["No"] = txtNo.Text,
                ["Co"] = txtCo.Text,
                ["NgayLap"] = $"Ngày {ngayLap.Day} tháng {ngayLap.Month} năm {ngayLap.Year}",
                ["TenNguoiNop"] = txtHoVaTenNguoiNop.Text,
                ["DiaChiNguoiNop"] = txtDiaChi2.Text,
                ["LyDoNop"] = string.IsNullOrWhiteSpace(txtLyDo.Text) ? $"Phí đăng tin tuyển dụng ({soNgay} ngày)" : txtLyDo.Text.Trim(),
                ["SoTien"] = string.Format("{0:#,0}", soTien),
                ["SoTienBangChu"] = string.Format("{0:#,0} đồng", soTien),
                ["KemTheo"] = txtKemTheo.Text,
                ["ChungTuGoc"] = txtChungTuGoc.Text

            };
        }

        private void txtVietBangChu_Leave(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtSoTien.Text.Replace(",", ""), out var v) && v > 0)
            {
                txtSoTien.Text = $"{v:#,0}";
                txtVietBangChu.Text = VietnameseNumber.ToCurrencyWords(v) + " đồng";
            }
        }
    }
}
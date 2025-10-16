using JPC.Models;
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
    public partial class ThuPhiUngVien : UserControl
    {
        private static string Cnn => ConfigurationManager.ConnectionStrings["JobPlacementCenter"].ConnectionString;
        private const int PHI_UNG_TUYEN_ID = 1;
        private decimal _donGiaCoDinh = 30000m;

        public ThuPhiUngVien()
        {
            InitializeComponent();

            // wiring
            this.Load += ThuPhiUngVien_Load;
            iconBtnReload.Click += (s, e) => ResetForm();
            btnXuatPhieuThu.Click += btnXuatPhieuThu_Click;

            cbbIdUngVien.SelectedIndexChanged += cbbIdUngVien_SelectedIndexChanged;
            cbbIdUngTuyen.SelectedIndexChanged += (s, e) =>
            {
                if (cbbIdUngTuyen.SelectedIndex >= 0)
                {
                    txtSoTien.Text = string.Format("{0:#,0}", _donGiaCoDinh);
                    txtVietBangChu.Text = string.Format("{0:#,0} đồng", _donGiaCoDinh);
                }
            };

            // khóa nhập tay số tiền (cố định)
            txtSoTien.ReadOnly = true;
            txtSoTien.KeyPress += (s, e2) => e2.Handled = true;
        }

        // ===== ADO helpers =====
        private DataTable Query(string sql, params SqlParameter[] prms)
        {
            var dt = new DataTable();
            using (var con = new SqlConnection(Cnn))
            using (var cmd = new SqlCommand(sql, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                if (prms?.Length > 0) cmd.Parameters.AddRange(prms);
                da.Fill(dt);
            }
            return dt;
        }
        private object Scalar(string sql, params SqlParameter[] prms)
        {
            using (var con = new SqlConnection(Cnn))
            using (var cmd = new SqlCommand(sql, con))
            {
                if (prms?.Length > 0) cmd.Parameters.AddRange(prms);
                con.Open();
                return cmd.ExecuteScalar();
            }
        }

        // ===== Load form =====
        private void ThuPhiUngVien_Load(object sender, EventArgs e)
        {
            try
            {
                // Đơn giá cố định từ DB (nếu có)
                var o = Scalar("SELECT so_tien FROM PhiDichVu WHERE phi_id=@p",
                               new SqlParameter("@p", PHI_UNG_TUYEN_ID));
                if (o != null && o != DBNull.Value) _donGiaCoDinh = Convert.ToDecimal(o);
                txtSoTien.Text = string.Format("{0:#,0}", _donGiaCoDinh);

                // Danh sách Ứng viên
                var uv = Query(@"SELECT uv_id, ho_ten, ISNULL(que_quan,'') AS dia_chi
                                 FROM UngVien ORDER BY ho_ten");
                cbbIdUngVien.DataSource = null;
                cbbIdUngVien.Items.Clear();
                cbbIdUngVien.ValueMember = "uv_id";
                cbbIdUngVien.DisplayMember = "ho_ten";
                cbbIdUngVien.DataSource = uv;

                // Combobox ký tên = nhân viên
                var nv = Query(@"SELECT ma_nhan_vien, ho_ten 
                                 FROM NhanVien WHERE trang_thai='active' ORDER BY ho_ten");
                void BindNV(ComboBox cb)
                {
                    cb.DataSource = nv.Copy();
                    cb.ValueMember = "ma_nhan_vien";
                    cb.DisplayMember = "ho_ten";
                    cb.SelectedIndex = -1;
                }
                BindNV(cbbGiamDoc);
                BindNV(cbbKeToanTruong);
                BindNV(cbbThuQuy);

                // Tiền tệ
                cbbDonViTien.Items.Clear();
                cbbDonViTien.Items.Add("VND");
                cbbDonViTien.SelectedIndex = 0;

                // Mặc định
                dtpNgayLapPhieu.Value = DateTime.Now;
                dtpNgayKy.Value = DateTime.Now;
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không nạp được dữ liệu (UV/NV). " + ex.Message);
            }
        }

        private void ResetForm()
        {
            foreach (var tb in grpBoxLapHoaDon.Controls.OfType<Guna.UI2.WinForms.Guna2TextBox>())
                tb.Text = string.Empty;

            cbDaNhanDuSoTien.Checked = false;
            txtSoTien.Text = string.Format("{0:#,0}", _donGiaCoDinh);
            txtLyDo.Text = "Phí ứng tuyển (cố định)";

            cbbIdUngVien.SelectedIndex = -1;
            cbbIdUngTuyen.DataSource = null;

            cbbGiamDoc.SelectedIndex = cbbKeToanTruong.SelectedIndex = cbbThuQuy.SelectedIndex = -1;

            dtpNgayLapPhieu.Value = DateTime.Now;
            dtpNgayKy.Value = DateTime.Now;
        }

        // ===== Khi chọn Ứng viên =====
        private void cbbIdUngVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbIdUngVien.SelectedIndex < 0) return;

            var r = (cbbIdUngVien.SelectedItem as DataRowView);
            int uvId = Convert.ToInt32(r["uv_id"]);
            string hoTen = r["ho_ten"].ToString();
            string diaChi = r["dia_chi"].ToString();

            txtHoVaTenNguoiNop.Text = hoTen;
            txtNguoiNopTien.Text = hoTen;
            txtDiaChi.Text = diaChi;

            // Nạp các UT CHƯA THU PHÍ & tin đã active
            var ut = Query(@"
                SELECT ut.ut_id,
                       'UT#' + CONVERT(varchar,ut.ut_id) + ' - Tin ' + CONVERT(varchar,ut.tin_id) AS display
                FROM UngTuyen ut
                INNER JOIN TinTuyenDung t ON t.tin_id = ut.tin_id
                WHERE ut.uv_id=@uv 
                      AND ISNULL(ut.da_thanh_toan_phi,0)=0
                      AND ISNULL(t.da_thanh_toan,0)=1
                ORDER BY ut.ut_id DESC",
                new SqlParameter("@uv", uvId));

            cbbIdUngTuyen.DataSource = null;
            cbbIdUngTuyen.Items.Clear();
            cbbIdUngTuyen.ValueMember = "ut_id";
            cbbIdUngTuyen.DisplayMember = "display";
            cbbIdUngTuyen.DataSource = ut;

            txtVietBangChu.Text = string.Format("{0:#,0} đồng", _donGiaCoDinh);
        }

        // ===== Lưu/in hóa đơn =====
        private bool HasInvoiceForUt(int utId)
        {
            var o = Scalar("SELECT 1 FROM HoaDon WHERE loai_khach_hang='ung_vien' AND ut_id=@u",
                           new SqlParameter("@u", utId));
            return o != null;
        }
        private int InsertHoaDon_UngVien(int uvId, int utId, string tenUv, decimal soTien, int maNv)
        {
            const string sql = @"
                INSERT INTO HoaDon(loai_khach_hang, uv_id, ut_id, dn_id, tin_id, ten_khach_hang, phi_id, so_tien, ngay_lap_hoa_don, ma_nhan_vien_lap)
                VALUES ('ung_vien', @uv, @ut, NULL, NULL, @ten, @phi, @tien, GETDATE(), @nv);
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using (var con = new SqlConnection(Cnn))
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@uv", uvId);
                cmd.Parameters.AddWithValue("@ut", utId);
                cmd.Parameters.AddWithValue("@ten", tenUv ?? "");
                cmd.Parameters.AddWithValue("@phi", PHI_UNG_TUYEN_ID);
                cmd.Parameters.AddWithValue("@tien", soTien);
                cmd.Parameters.AddWithValue("@nv", maNv);
                con.Open();
                return (int)cmd.ExecuteScalar();
            }
        }
        private void MarkUngTuyenPaid(int utId)
        {
            using (var con = new SqlConnection(Cnn))
            using (var cmd = new SqlCommand("UPDATE UngTuyen SET da_thanh_toan_phi=1 WHERE ut_id=@id", con))
            {
                cmd.Parameters.AddWithValue("@id", utId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void btnXuatPhieuThu_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            if (cbbIdUngVien.SelectedIndex < 0) sb.AppendLine("• Chưa chọn Ứng viên.");
            if (cbbIdUngTuyen.SelectedIndex < 0) sb.AppendLine("• Chưa chọn hồ sơ Ứng tuyển.");
            if (sb.Length > 0) { MessageBox.Show(sb.ToString()); return; }

            var uv = (DataRowView)cbbIdUngVien.SelectedItem;
            var ut = (DataRowView)cbbIdUngTuyen.SelectedItem;
            int uvId = (int)uv["uv_id"];
            int utId = (int)ut["ut_id"];
            string tenUv = uv["ho_ten"].ToString();
            string diaChiUv = txtDiaChi.Text?.Trim() ?? "";
            decimal soTien = _donGiaCoDinh;
            int maNv = UserSession.NhanVien.MaNhanVien;

            int maHd;
            if (HasInvoiceForUt(utId))
            {
                var o = Scalar(@"SELECT TOP(1) ma_hoa_don FROM HoaDon 
                                 WHERE loai_khach_hang='ung_vien' AND ut_id=@u
                                 ORDER BY ma_hoa_don DESC", new SqlParameter("@u", utId));
                maHd = Convert.ToInt32(o);
            }
            else
            {
                maHd = InsertHoaDon_UngVien(uvId, utId, tenUv, soTien, maNv);
                MarkUngTuyenPaid(utId);
            }

            // Tham số report – dùng chung reportForm bạn đã chạy OK với DN
            var ps = new Dictionary<string, string>
            {
                ["DonVi"] = "Trung tâm Giới thiệu Việc làm SV",
                ["DiaChiDonVi"] = "TP. HCM",
                ["SoPhieu"] = string.IsNullOrWhiteSpace(txtSo.Text) ? "HD-" + maHd : txtSo.Text.Trim(),
                ["NgayLap"] = dtpNgayLapPhieu.Value.ToString("dd/MM/yyyy"),

                ["TenNguoiNop"] = tenUv,
                ["DiaChiNguoiNop"] = diaChiUv,
                ["LyDoNop"] = string.IsNullOrWhiteSpace(txtLyDo.Text) ? "Phí ứng tuyển (cố định)" : txtLyDo.Text.Trim(),
                ["SoTien"] = string.Format("{0:#,0}", soTien),
                ["SoTienBangChu"] = string.Format("{0:#,0} đồng", soTien),

                ["KemTheo"] = txtKemTheo.Text,
                ["ChungTuGoc"] = txtChungTuGoc.Text,

                ["QuyenSo"] = txtQuyenSo.Text,
                ["No"] = txtNo.Text,
                ["Co"] = txtCo.Text
            };

            using (var f = new reportForm(ps)) f.ShowDialog();
            ResetForm();
        }
    }
}


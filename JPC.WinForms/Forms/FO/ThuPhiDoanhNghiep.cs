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
    public partial class ThuPhiDoanhNghiep : UserControl
    {
        private IThuPhiDoanhNghiepService _service;
        private int _soNgay = 0;
        private decimal _soTien = 0;
        private static string Cnn => ConfigurationManager.ConnectionStrings["JobPlacementCenter"].ConnectionString;

        public ThuPhiDoanhNghiep()
        {
            InitializeComponent();
            this.Load += ThuPhiDoanhNghiep_Load;
            cbbIdDoanhNghiep.SelectedIndexChanged += cbbIdDoanhNghiep_SelectedIndexChanged;
            cbbIdTinTuyenDung.SelectedIndexChanged += cbbIdTinTuyenDung_SelectedIndexChanged_1;

            iconBtnReload.Click += iconBtnReload_Click_1;
            btnXuatPhieuThu.Click += btnXuatPhieuThu_Click;

            // (khuyến nghị) chống nhập ký tự không phải số cho txtSoTien
            txtSoTien.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
            };
        }

        private DataTable Query(string sql, params SqlParameter[] prms)
        {
            var dt = new DataTable();
            using (var con = new SqlConnection(Cnn))
            using (var cmd = new SqlCommand(sql, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                if (prms != null && prms.Length > 0) cmd.Parameters.AddRange(prms);
                da.Fill(dt);
            }
            return dt;
        }
        public void BindService(IThuPhiDoanhNghiepService service)
        {
            _service = service;

            // load DN
            var dsDn = _service.GetDoanhNghieps().ToList();
            cbbIdDoanhNghiep.ValueMember = "dn_id";
            cbbIdDoanhNghiep.DisplayMember = "ten_doanh_nghiep";
            cbbIdDoanhNghiep.DataSource = dsDn;

            // load 3 combobox ký tên
            var dsNv = _service.GetNhanViens().ToList();
            cbbGiamDoc.ValueMember = cbbKeToanTruong.ValueMember = cbbThuQuy.ValueMember = "ma_nhan_vien";
            cbbGiamDoc.DisplayMember = cbbKeToanTruong.DisplayMember = cbbThuQuy.DisplayMember = "ho_ten";
            cbbGiamDoc.DataSource = dsNv.ToList();
            cbbKeToanTruong.DataSource = dsNv.ToList();
            cbbThuQuy.DataSource = dsNv.ToList();

            // đơn vị tiền
            cbbDonViTien.Items.Clear();
            cbbDonViTien.Items.Add("VND");
            cbbDonViTien.SelectedIndex = 0;

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

        private (int soNgay, decimal soTien) GetPreviewAmount(int tinId)
        {
            // copy logic: số ngày * đơn giá (phi_id=2)
            // nên tạm dùng các repository hoặc viết 1 API riêng; để ngắn gọn giả sử có _previewProvider
            // Ở đây bạn có thể tái sử dụng ITinTuyenDungRepository + IPhiDichVuRepository như trong service.
            throw new NotImplementedException();
        }


        private void OpenReport(int maHd, int soNgay, decimal soTien)
        {
            // Lấy lại hóa đơn & info tin để fill report param (hoặc bạn truyền đủ param ở đây)
            // Giản lược: điền các tham số chính
            var ps = new Dictionary<string, string>
            {
                ["DonVi"] = "Trung tâm Giới thiệu Việc làm SV",
                ["DiaChiDonVi"] = "TP. HCM",
                ["SoPhieu"] = "HD-" + maHd,
                ["NgayLap"] = DateTime.Now.ToString("dd/MM/yyyy"),
                ["LyDoNop"] = $"Phí đăng tin tuyển dụng ({soNgay} ngày)",
                ["SoTien"] = string.Format("{0:#,0}", soTien),
                ["SoTienBangChu"] = string.Format("{0:#,0} đồng", soTien),
                ["NguoiLap"] = UserSession.NhanVien.HoTen
            };
            using (var f = new reportForm (ps))
            {
                f.ShowDialog();
            }
            ; // form nhận Dictionary params

        }
        private void iconBtnReload_Click_1(object sender, EventArgs e)
        {
            ResetForm();
        }
        // Chèn hóa đơn trực tiếp 
        private int InsertHoaDon_Direct(int tinId, int dnId, string tenDn, decimal soTien, int maNv)
        {
            const string sql = @"
                INSERT INTO HoaDon(loai_khach_hang, uv_id, ut_id, dn_id, tin_id, ten_khach_hang, phi_id, so_tien, ngay_lap_hoa_don, ma_nhan_vien_lap)
                VALUES ('doanh_nghiep', NULL, NULL, @dn, @tin, @ten, 2, @tien, GETDATE(), @nv);
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using (var con = new SqlConnection(Cnn))
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@dn", dnId);
                cmd.Parameters.AddWithValue("@tin", tinId);
                cmd.Parameters.AddWithValue("@ten", tenDn ?? "");
                cmd.Parameters.AddWithValue("@tien", soTien);
                cmd.Parameters.AddWithValue("@nv", maNv);
                con.Open();
                return (int)cmd.ExecuteScalar();
            }
        }
        private void MarkTinPaid(int tinId)
        {
            using (var con = new SqlConnection(Cnn))
            using (var cmd = new SqlCommand("UPDATE TinTuyenDung SET da_thanh_toan=1, trang_thai='active' WHERE tin_id=@id", con))
            {
                cmd.Parameters.AddWithValue("@id", tinId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        private bool HasInvoiceForTin(int tinId)
        {
            const string sql = "SELECT 1 FROM HoaDon WHERE loai_khach_hang='doanh_nghiep' AND tin_id=@id";
            using (var con = new SqlConnection(Cnn))
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", tinId);
                con.Open();
                var o = cmd.ExecuteScalar();
                return o != null;
            }
        }

        private void btnXuatPhieuThu_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(out string msg)) { MessageBox.Show(msg); return; }

            int tinId = (int)cbbIdTinTuyenDung.SelectedValue;
            int maNv = UserSession.NhanVien.MaNhanVien;

            if (!decimal.TryParse(txtSoTien.Text.Replace(",", ""), out var soTienNhap) || soTienNhap <= 0)
            {
                MessageBox.Show("Số tiền không hợp lệ."); return;
            }

            try
            {
                var rTin = (DataRowView)cbbIdTinTuyenDung.SelectedItem;
                var rDn = (DataRowView)cbbIdDoanhNghiep.SelectedItem;

                int maHd, soNgay; decimal soTien;
                soNgay = _soNgay; // đã tính ở SelectedIndexChanged

                // ĐÃ CÓ HÓA ĐƠN? → chỉ in lại
                if (rTin["ma_hoa_don"] != DBNull.Value)
                {
                    maHd = Convert.ToInt32(rTin["ma_hoa_don"]);
                    soTien = Convert.ToDecimal(rTin["so_tien"]);

                    // Mở report dùng dữ liệu đã có
                    var ps = BuildReportParams(maHd, soNgay, soTien);
                    using (var f = new reportForm(ps)) f.ShowDialog();
                    return;
                }

                // CHƯA CÓ HÓA ĐƠN → Lưu + Active + in
                int dnId = (int)rDn["dn_id"];
                string tenDn = rDn["ten_doanh_nghiep"].ToString();

                // Nếu bạn có _service → ưu tiên gọi service để đi qua transaction
                if (_service != null)
                {
                    var result = _service.LapHoaDonThuPhiDN(tinId, maNv,
                                   soTienNhap != _soTien ? soTienNhap : (decimal?)null);
                    maHd = result.maHoaDon;
                    soNgay = result.soNgay;
                    soTien = result.soTien;
                }
                else
                {
                    // Fallback ADO.NET trực tiếp
                    maHd = InsertHoaDon_Direct(tinId, dnId, tenDn, soTienNhap, maNv);
                    MarkTinPaid(tinId);
                    soTien = soTienNhap;
                }

                var psNew = BuildReportParams(maHd, soNgay, soTien);
                using (var f = new reportForm(psNew)) f.ShowDialog();

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


        private void cbbIdDoanhNghiep_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbIdDoanhNghiep.SelectedIndex < 0) return;

            var drv = (cbbIdDoanhNghiep.SelectedItem as DataRowView);
            var tenDN = drv?["ten_doanh_nghiep"]?.ToString() ?? "";
            var diaChi = drv?["dia_chi"]?.ToString() ?? "";

            txtDonVi.Text = tenDN;
            txtDiaChi1.Text = diaChi;
            txtDiaChi2.Text = diaChi;
            txtHoVaTenNguoiNop.Text = tenDN;
            txtNguoiNopTien.Text = tenDN;

            int dnId = Convert.ToInt32(drv["dn_id"]);

            // Lấy danh sách TIN + hóa đơn gần nhất (nếu có)
            var tin = Query(@"
        SELECT  t.tin_id,
                t.tieu_de,
                t.ngay_dang,
                t.han_nop_ho_so,
                hd.ma_hoa_don,
                hd.so_tien,
                CASE WHEN hd.ma_hoa_don IS NULL THEN N'[CHƯA THU]' ELSE N'[ĐÃ THU]' END AS status,
                (t.tieu_de + ' ' + 
                 CASE WHEN hd.ma_hoa_don IS NULL 
                      THEN N'[CHƯA THU]' 
                      ELSE N'[ĐÃ THU] (#' + CONVERT(varchar(10), hd.ma_hoa_don) + N')' END
                 + ' (' + CONVERT(varchar(10), t.ngay_dang, 103) + ' → ' + CONVERT(varchar(10), t.han_nop_ho_so, 103) + ')'
                ) AS display
        FROM TinTuyenDung t
        OUTER APPLY (
            SELECT TOP(1) h.ma_hoa_don, h.so_tien
            FROM HoaDon h 
            WHERE h.tin_id = t.tin_id AND h.loai_khach_hang = 'doanh_nghiep'
            ORDER BY h.ma_hoa_don DESC
        ) hd
        WHERE t.dn_id=@dn
        ORDER BY t.tin_id DESC",
                new SqlParameter("@dn", dnId));

            cbbIdTinTuyenDung.DataSource = null;
            cbbIdTinTuyenDung.Items.Clear();
            cbbIdTinTuyenDung.ValueMember = "tin_id";
            cbbIdTinTuyenDung.DisplayMember = "display";
            cbbIdTinTuyenDung.DataSource = tin;

            // clear phần liên quan tin
            txtSoNgayDangTin.Text = "";
            txtSoTien.Text = "";
            txtVietBangChu.Text = "";
            _soNgay = 0; _soTien = 0;
        }

        private void cbbIdTinTuyenDung_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbbIdTinTuyenDung.SelectedIndex < 0) return;

            var r = (cbbIdTinTuyenDung.SelectedItem as DataRowView);
            var ngayDang = Convert.ToDateTime(r["ngay_dang"]);
            var hanNop = Convert.ToDateTime(r["han_nop_ho_so"]);

            _soNgay = Math.Max(1, (int)(hanNop.Date - ngayDang.Date).TotalDays + 1);
            txtSoNgayDangTin.Text = _soNgay.ToString();

            // Nếu đã có hóa đơn → dùng số tiền trong hóa đơn & khóa textbox tiền
            if (r["ma_hoa_don"] != DBNull.Value)
            {
                decimal soTienDaThu = Convert.ToDecimal(r["so_tien"]);
                _soTien = soTienDaThu;
                txtSoTien.Text = string.Format("{0:#,0}", _soTien);
                txtVietBangChu.Text = string.Format("{0:#,0} đồng", _soTien);
                txtSoTien.ReadOnly = true;
                txtSoTien.FillColor = Color.Gainsboro; // visual (tùy ý)
            }
            else
            {
                // Chưa có hóa đơn → tính theo đơn giá
                var dtPhi = Query("SELECT so_tien FROM PhiDichVu WHERE phi_id=2");
                if (dtPhi.Rows.Count == 0)
                {
                    MessageBox.Show("Chưa cấu hình đơn giá (PhiDichVu.phi_id=2).");
                    return;
                }
                var donGia = Convert.ToDecimal(dtPhi.Rows[0]["so_tien"]);
                _soTien = _soNgay * donGia;

                txtSoTien.Text = string.Format("{0:#,0}", _soTien);
                txtVietBangChu.Text = string.Format("{0:#,0} đồng", _soTien);
                txtSoTien.ReadOnly = false;
                txtSoTien.FillColor = Color.White;
            }
        }

        private string VietBangChu(decimal v) => $"{string.Format("{0:#,0}", v)} đồng";

        private void ThuPhiDoanhNghiep_Load(object sender, EventArgs e)
        {
            try
            {
                // Doanh nghiệp
                var dn = Query(@"SELECT dn_id, ten_doanh_nghiep, ISNULL(dia_chi,'') dia_chi
                         FROM DoanhNghiep ORDER BY ten_doanh_nghiep");
                cbbIdDoanhNghiep.DataSource = null;          // clear Items nếu đã add tay
                cbbIdDoanhNghiep.Items.Clear();
                cbbIdDoanhNghiep.ValueMember = "dn_id";
                cbbIdDoanhNghiep.DisplayMember = "ten_doanh_nghiep";
                cbbIdDoanhNghiep.DataSource = dn;

                // 3 combobox ký tên = danh sách nhân viên
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

                // đơn vị tiền
                cbbDonViTien.Items.Clear();
                cbbDonViTien.Items.Add("VND");
                cbbDonViTien.SelectedIndex = 0;

                // mặc định
                dtpNgayLapPhieu.Value = DateTime.Now;
                dtpNgayKy.Value = DateTime.Now;
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không nạp được dữ liệu combobox.\n" + ex.Message);
            }
        }
    }
}

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
    public partial class DanhSachHoaDon : UserControl
    {
        private static string Cnn => ConfigurationManager.ConnectionStrings["JobPlacementCenter"].ConnectionString;

        private DataTable _dtHoaDon;   // nguồn cho DGV
        private bool _ignoreDate = false;

        public DanhSachHoaDon()
        {
            InitializeComponent();

            // Gắn event
            this.Load += DanhSachHoaDon_Load;

            dtpThoiGian.ValueChanged += (_, __) => ReloadWithFilters();
            cbbIdDoanhNghiep.SelectedIndexChanged += (_, __) => ReloadWithFilters();
            cbbIdNhanVien.SelectedIndexChanged += (_, __) => ReloadWithFilters();

            btnLocKhongCoThoiGian.Click += (_, __) => { _ignoreDate = true; ReloadWithFilters(); };
            btnBoLoc.Click += (_, __) => ResetFilters();

            btnCapNhatHoaDon.Click += BtnCapNhatHoaDon_Click;
            btnXuaHoaDon.Click += BtnXuatHoaDon_Click;

            // DGV behaviour
            dgvBangDanhSachHoaDon.MultiSelect = false;
            dgvBangDanhSachHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBangDanhSachHoaDon.AllowUserToAddRows = false;
            dgvBangDanhSachHoaDon.AutoGenerateColumns = true;
        }

        #region DB helpers
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

        private int Exec(string sql, params SqlParameter[] prms)
        {
            using (var con = new SqlConnection(Cnn))
            using (var cmd = new SqlCommand(sql, con))
            {
                if (prms != null && prms.Length > 0) cmd.Parameters.AddRange(prms);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        private object Scalar(string sql, params SqlParameter[] prms)
        {
            using (var con = new SqlConnection(Cnn))
            using (var cmd = new SqlCommand(sql, con))
            {
                if (prms != null && prms.Length > 0) cmd.Parameters.AddRange(prms);
                con.Open();
                return cmd.ExecuteScalar();
            }
        }
        #endregion

        private void DanhSachHoaDon_Load(object sender, EventArgs e)
        {
            LoadCombos();
            LoadAllHoaDon();
        }

        private void LoadCombos()
        {
            // DN
            var dn = Query(@"SELECT dn_id, ten_doanh_nghiep FROM DoanhNghiep ORDER BY ten_doanh_nghiep");
            cbbIdDoanhNghiep.DisplayMember = "ten_doanh_nghiep";
            cbbIdDoanhNghiep.ValueMember = "dn_id";
            cbbIdDoanhNghiep.DataSource = dn;
            cbbIdDoanhNghiep.SelectedIndex = -1;

            // NV
            var nv = Query(@"SELECT ma_nhan_vien, ho_ten FROM NhanVien WHERE trang_thai='active' ORDER BY ho_ten");
            cbbIdNhanVien.DisplayMember = "ho_ten";
            cbbIdNhanVien.ValueMember = "ma_nhan_vien";
            cbbIdNhanVien.DataSource = nv;
            cbbIdNhanVien.SelectedIndex = -1;

            // mặc định lọc theo ngày
            _ignoreDate = false;
            dtpThoiGian.Value = DateTime.Now;
        }

        private void LoadAllHoaDon()
        {
            string sql = @"
SELECT h.ma_hoa_don, h.loai_khach_hang, h.dn_id, dn.ten_doanh_nghiep,
       h.uv_id, uv.ho_ten AS ten_ung_vien,
       h.ut_id, h.tin_id, h.ten_khach_hang, h.phi_id, h.so_tien, 
       CAST(h.ngay_lap_hoa_don AS DATE) AS ngay_lap_hoa_don,
       h.ma_nhan_vien_lap, nv.ho_ten AS ten_nv_lap
FROM HoaDon h
LEFT JOIN DoanhNghiep dn ON dn.dn_id = h.dn_id
LEFT JOIN UngVien uv ON uv.uv_id = h.uv_id
LEFT JOIN NhanVien nv ON nv.ma_nhan_vien = h.ma_nhan_vien_lap
ORDER BY h.ma_hoa_don DESC";
            _dtHoaDon = Query(sql);
            BindGrid(_dtHoaDon);
        }

        private void BindGrid(DataTable dt)
        {
            dgvBangDanhSachHoaDon.DataSource = dt;

            // Cho phép sửa 4 cột dưới
            foreach (DataGridViewColumn c in dgvBangDanhSachHoaDon.Columns) c.ReadOnly = true;

            SetReadWrite("ten_khach_hang");
            SetReadWrite("so_tien");
            SetReadWrite("ngay_lap_hoa_don");
            SetReadWrite("ma_nhan_vien_lap");

            dgvBangDanhSachHoaDon.Columns["ma_hoa_don"].HeaderText = "Mã HĐ";
            dgvBangDanhSachHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void SetReadWrite(string col)
        {
            if (dgvBangDanhSachHoaDon.Columns.Contains(col))
                dgvBangDanhSachHoaDon.Columns[col].ReadOnly = false;
        }

        private void ResetFilters()
        {
            cbbIdDoanhNghiep.SelectedIndex = -1;
            cbbIdNhanVien.SelectedIndex = -1;
            _ignoreDate = false;
            LoadAllHoaDon();
        }

        private void ReloadWithFilters()
        {
            var sb = new StringBuilder();
            sb.Append(@"
SELECT h.ma_hoa_don, h.loai_khach_hang, h.dn_id, dn.ten_doanh_nghiep,
       h.uv_id, uv.ho_ten AS ten_ung_vien,
       h.ut_id, h.tin_id, h.ten_khach_hang, h.phi_id, h.so_tien,
       CAST(h.ngay_lap_hoa_don AS DATE) AS ngay_lap_hoa_don,
       h.ma_nhan_vien_lap, nv.ho_ten AS ten_nv_lap
FROM HoaDon h
LEFT JOIN DoanhNghiep dn ON dn.dn_id = h.dn_id
LEFT JOIN UngVien uv ON uv.uv_id = h.uv_id
LEFT JOIN NhanVien nv ON nv.ma_nhan_vien = h.ma_nhan_vien_lap
WHERE 1=1");

            var prms = new System.Collections.Generic.List<SqlParameter>();

            if (!_ignoreDate)
            {
                sb.Append(" AND CAST(h.ngay_lap_hoa_don AS DATE) = @d");
                prms.Add(new SqlParameter("@d", dtpThoiGian.Value.Date));
            }

            if (cbbIdDoanhNghiep.SelectedIndex >= 0)
            {
                sb.Append(" AND h.dn_id=@dn");
                prms.Add(new SqlParameter("@dn", (int)cbbIdDoanhNghiep.SelectedValue));
            }

            if (cbbIdNhanVien.SelectedIndex >= 0)
            {
                sb.Append(" AND h.ma_nhan_vien_lap=@nv");
                prms.Add(new SqlParameter("@nv", (int)cbbIdNhanVien.SelectedValue));
            }

            sb.Append(" ORDER BY h.ma_hoa_don DESC");

            _dtHoaDon = Query(sb.ToString(), prms.ToArray());
            BindGrid(_dtHoaDon);
        }

        private void BtnCapNhatHoaDon_Click(object sender, EventArgs e)
        {
            dgvBangDanhSachHoaDon.EndEdit();

            if (_dtHoaDon == null) return;

            int updated = 0;
            foreach (DataRow r in _dtHoaDon.Rows)
            {
                if (r.RowState != DataRowState.Modified) continue;

                int id = (int)r["ma_hoa_don"];
                string tenKh = r["ten_khach_hang"]?.ToString() ?? "";
                decimal soTien = Convert.ToDecimal(r["so_tien"]);
                DateTime ngay = Convert.ToDateTime(r["ngay_lap_hoa_don"]);
                int maNv = Convert.ToInt32(r["ma_nhan_vien_lap"]);

                const string sql = @"
UPDATE HoaDon
SET ten_khach_hang=@ten, so_tien=@tien, ngay_lap_hoa_don=@ngay, ma_nhan_vien_lap=@nv
WHERE ma_hoa_don=@id";

                updated += Exec(sql,
                    new SqlParameter("@ten", tenKh),
                    new SqlParameter("@tien", soTien),
                    new SqlParameter("@ngay", ngay),
                    new SqlParameter("@nv", maNv),
                    new SqlParameter("@id", id));

                r.AcceptChanges();
            }

            MessageBox.Show(updated > 0 ? $"Đã cập nhật {updated} hóa đơn." : "Không có thay đổi.");
            ReloadWithFilters();
        }

        private void BtnXuatHoaDon_Click(object sender, EventArgs e)
        {
            if (dgvBangDanhSachHoaDon.CurrentRow == null)
            {
                MessageBox.Show("Hãy chọn một dòng hóa đơn để xuất."); return;
            }

            var r = ((DataRowView)dgvBangDanhSachHoaDon.CurrentRow.DataBoundItem).Row;
            int maHd = (int)r["ma_hoa_don"];
            string loai = r["loai_khach_hang"].ToString();

            // Lấy thêm địa chỉ KH (nếu DN) để in report
            string tenNguoiNop = r["ten_khach_hang"]?.ToString() ?? "";
            string diaChiNguoiNop = "";

            if (loai == "doanh_nghiep" && r["dn_id"] != DBNull.Value)
            {
                var dt = Query("SELECT ISNULL(dia_chi,'') dia_chi FROM DoanhNghiep WHERE dn_id=@id",
                               new SqlParameter("@id", (int)r["dn_id"]));
                if (dt.Rows.Count > 0) diaChiNguoiNop = dt.Rows[0]["dia_chi"].ToString();
            }
            else if (loai == "ung_vien" && r["uv_id"] != DBNull.Value)
            {
                var dt = Query("SELECT ISNULL(que_quan,'') dia_chi FROM UngVien WHERE uv_id=@id",
                               new SqlParameter("@id", (int)r["uv_id"]));
                if (dt.Rows.Count > 0) diaChiNguoiNop = dt.Rows[0]["dia_chi"].ToString();
            }

            decimal soTien = Convert.ToDecimal(r["so_tien"]);
            string soTienChu = $"{soTien:#,0} đồng";

            var ps = new System.Collections.Generic.Dictionary<string, string>
            {
                ["DonVi"] = "Trung tâm Giới thiệu Việc làm SV",
                ["DiaChiDonVi"] = "TP. HCM",
                ["SoPhieu"] = "HD-" + maHd,
                ["NgayLap"] = Convert.ToDateTime(r["ngay_lap_hoa_don"]).ToString("dd/MM/yyyy"),

                ["TenNguoiNop"] = tenNguoiNop,
                ["DiaChiNguoiNop"] = diaChiNguoiNop,
                ["LyDoNop"] = loai == "doanh_nghiep" ? "Phí đăng tin tuyển dụng" : "Phí ứng tuyển",
                ["SoTien"] = $"{soTien:#,0}",
                ["SoTienBangChu"] = soTienChu,

                ["KemTheo"] = "",
                ["ChungTuGoc"] = "",
                ["QuyenSo"] = "",
                ["No"] = "",
                ["Co"] = ""
            };

            using (var f = new reportForm(ps))
                f.ShowDialog();
        }
    }
}

using JPC.Business.Services.Interfaces.FO;
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
    public partial class DanhSachHoaDon_UC : UserControl
    {
        private static string Cnn => ConfigurationManager.ConnectionStrings["JobPlacementCenter"].ConnectionString;
        private IQuanLyHoaDonService _svc;
        private DataTable _dtHoaDon;   // nguồn cho DGV
        private bool _ignoreDate = false;

        public DanhSachHoaDon_UC()
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
        public void BindService(IQuanLyHoaDonService service)
        {
            _svc = service ?? throw new ArgumentNullException(nameof(service));
        }
            
        private void DanhSachHoaDon_Load(object sender, EventArgs e)
        {
            if (_svc == null) { MessageBox.Show("Chưa gán service cho Danh sách hóa đơn."); return; }

            LoadCombos();
            LoadAllHoaDon();
        }

        private void LoadCombos()
        {
            // DN
            var dnList = _svc.GetDoanhNghiepBasic()
                             .Select(x => new { dn_id = x.dn_id, ten_doanh_nghiep = x.ten_doanh_nghiep })
                             .ToList();
            cbbIdDoanhNghiep.DisplayMember = "ten_doanh_nghiep";
            cbbIdDoanhNghiep.ValueMember = "dn_id";
            cbbIdDoanhNghiep.DataSource = dnList;
            cbbIdDoanhNghiep.SelectedIndex = -1;

            // NV
            var nv = _svc.GetNhanVienActive();
            cbbIdNhanVien.DisplayMember = "ho_ten";
            cbbIdNhanVien.ValueMember = "ma_nhan_vien";
            cbbIdNhanVien.DataSource = nv;
            cbbIdNhanVien.SelectedIndex = -1;

            _ignoreDate = false;
            dtpThoiGian.Value = DateTime.Now;
        }

        private void LoadAllHoaDon()
        {
            _dtHoaDon = _svc.GetAllHoaDon();
            BindGrid(_dtHoaDon);

        }

        private void BindGrid(DataTable dt)
        {
            dgvBangDanhSachHoaDon.DataSource = dt;
            foreach (DataGridViewColumn c in dgvBangDanhSachHoaDon.Columns) c.ReadOnly = true;

            SetReadWrite("ten_khach_hang");
            SetReadWrite("so_tien");
            SetReadWrite("ngay_lap_hoa_don");
            SetReadWrite("ma_nhan_vien_lap");

            //if (dgvBangDanhSachHoaDon.Columns.Contains("ma_hoa_don"))
            //    dgvBangDanhSachHoaDon.Columns["ma_hoa_don"].HeaderText = "Mã HĐ";
            ApplyHeadersFromCaptions(dt);
            dgvBangDanhSachHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foreach (DataGridViewColumn c in dgvBangDanhSachHoaDon.Columns)
            {
                if (c.Name == "so_tien") c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                if (c.Name == "ngay_lap_hoa_don") c.DefaultCellStyle.Format = "dd/MM/yyyy";
                if (c.Name == "so_tien") c.DefaultCellStyle.Format = "#,0";
            }


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
            _ignoreDate = true;
            //dtpThoiGian.Value = DateTime.Now;
            LoadAllHoaDon();
        }

        private void ReloadWithFilters()
        {
            if (_svc == null) return;

            DateTime? d = _ignoreDate ? (DateTime?)null : dtpThoiGian.Value.Date;
            int? dnId = (cbbIdDoanhNghiep.SelectedIndex >= 0) ? (int?)Convert.ToInt32(cbbIdDoanhNghiep.SelectedValue) : null;
            int? maNv = (cbbIdNhanVien.SelectedIndex >= 0) ? (int?)Convert.ToInt32(cbbIdNhanVien.SelectedValue) : null;

            _dtHoaDon = _svc.GetHoaDonFiltered(d, dnId, maNv);
            BindGrid(_dtHoaDon);

        }
        private void ApplyHeadersFromCaptions(DataTable dt)
        {
            if (dt == null) return;
            foreach (DataGridViewColumn col in dgvBangDanhSachHoaDon.Columns)
            {
                var dc = dt.Columns[col.DataPropertyName ?? col.Name];
                if (dc != null && !string.IsNullOrEmpty(dc.Caption))
                    col.HeaderText = dc.Caption;
            }
        }


        private void BtnCapNhatHoaDon_Click(object sender, EventArgs e)
        {
            dgvBangDanhSachHoaDon.EndEdit();
            if (_dtHoaDon == null) return;

            int updated = 0;
            foreach (DataRow r in _dtHoaDon.Rows)
            {
                if (r.RowState != DataRowState.Modified) continue;

                int id = r.Field<int>("ma_hoa_don");
                string tenKh = r.Field<string>("ten_khach_hang") ?? "";
                decimal soTien = r.Field<decimal?>("so_tien") ?? 0m;
                DateTime ngay = r.Field<DateTime>("ngay_lap_hoa_don");
                int maNv = r.Field<int>("ma_nhan_vien_lap");


                updated += _svc.UpdateHoaDonBasic(id, tenKh, soTien, ngay, maNv);
                r.AcceptChanges();
            }

            MessageBox.Show(updated > 0 ? $"Đã cập nhật {updated} hóa đơn." : "Không có thay đổi.");
            ReloadWithFilters();
        }

        private void BtnXuatHoaDon_Click(object sender, EventArgs e)
        {
            if (dgvBangDanhSachHoaDon.CurrentRow == null)
            {
                MessageBox.Show("Hãy chọn một dòng hóa đơn để xuất.");
                return;
            }

            var r = ((DataRowView)dgvBangDanhSachHoaDon.CurrentRow.DataBoundItem).Row;
            int maHd = (int)r["ma_hoa_don"];
            string loai = r["loai_khach_hang"]?.ToString();
            string tenNguoiNop = r["ten_khach_hang"]?.ToString() ?? "";
            string diaChiNguoiNop = "";

            if (loai == "doanh_nghiep" && r["dn_id"] != DBNull.Value)
                diaChiNguoiNop = _svc.GetDiaChiDoanhNghiep(Convert.ToInt32(r["dn_id"]));
            else if (loai == "ung_vien" && r["uv_id"] != DBNull.Value)
                diaChiNguoiNop = _svc.GetDiaChiUngVien(Convert.ToInt32(r["uv_id"]));

            decimal soTien = Convert.ToDecimal(r["so_tien"]);
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
                ["SoTienBangChu"] = $"{soTien:#,0} đồng",
                ["KemTheo"] = "",
                ["ChungTuGoc"] = "",
                ["QuyenSo"] = "",
                ["No"] = "",
                ["Co"] = ""
            };

            using (var f = new reportForm(ps)) f.ShowDialog();
        }
    }
}

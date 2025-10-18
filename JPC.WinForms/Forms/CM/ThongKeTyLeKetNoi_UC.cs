using JPC.Business.Services.Implementations.CM;
using JPC.Business.Services.Interfaces.CM;
using JPC.Models;
using Microsoft.Reporting.WinForms;
using Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.CM.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.CM
{
    public partial class ThongKeTyLeKetNoi_UC : UserControl
    {
        private readonly ICMStatisticsService _svc = new CMStatisticsService();
        private DataTable _cache;

        public ThongKeTyLeKetNoi_UC()
        {
            InitializeComponent();
            // Lưới 5 cột: STT | Danh mục | Tổng ứng viên | Số trúng tuyển | Tỷ lệ (%)
            SetupGrid();

            this.Load += (s, e) =>
            {
                InitFilters();   // set năm/tháng/quý mặc định
                RefreshData();   // <-- tự tải dữ liệu ngay khi mở màn
            };

            // Đổi THÁNG/QUÝ/NĂM -> bind lại cbThangQuy
            rdThang.CheckedChanged += (s, e) => { if (rdThang.Checked) BindMonths(); };
            rdQuy.CheckedChanged += (s, e) => { if (rdQuy.Checked) BindQuarters(); };
            rdNam.CheckedChanged += (s, e) => { if (rdNam.Checked) BindYearWhole(); };

            // Nút tải lại
            //btnTaiLai.Click += btnTaiLai_Click;
        }
        private void SetupGrid()
        {
            dgvTyLe.AutoGenerateColumns = false;
            dgvTyLe.RowHeadersVisible = false;
            dgvTyLe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTyLe.ReadOnly = true;
            dgvTyLe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTyLe.MultiSelect = false;

            dgvTyLe.Columns.Clear();

            var colSTT = new DataGridViewTextBoxColumn { Name = "colSTT", HeaderText = "STT", FillWeight = 8, ReadOnly = true };
            var colDM = new DataGridViewTextBoxColumn { Name = "DanhMuc", HeaderText = "Nhóm nghề / Nghề / Vị trí", DataPropertyName = "DanhMuc", FillWeight = 45, ReadOnly = true };
            var colTong = new DataGridViewTextBoxColumn
            {
                Name = "TongUngVien",
                HeaderText = "Tổng ứng viên",
                DataPropertyName = "TongUngVien",
                FillWeight = 18,
                ReadOnly = true,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N0" }
            };
            var colOK = new DataGridViewTextBoxColumn
            {
                Name = "SoTrungTuyen",
                HeaderText = "Số trúng tuyển",
                DataPropertyName = "SoTrungTuyen",
                FillWeight = 18,
                ReadOnly = true,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N0" }
            };
            var colTL = new DataGridViewTextBoxColumn
            {
                Name = "TyLe",
                HeaderText = "Tỷ lệ (%)",
                DataPropertyName = "TyLe",
                FillWeight = 11,
                ReadOnly = true,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight }
            };

            dgvTyLe.Columns.AddRange(colSTT, colDM, colTong, colOK, colTL);

            // Đánh số STT
            dgvTyLe.DataBindingComplete += (s, e) =>
            {
                for (int i = 0; i < dgvTyLe.Rows.Count; i++)
                    dgvTyLe.Rows[i].Cells["colSTT"].Value = (i + 1);
            };

            // Hiển thị "xx.xx %"
            dgvTyLe.CellFormatting += (s, e) =>
            {
                if (dgvTyLe.Columns[e.ColumnIndex].Name == "TyLe" &&
                    e.Value != null && e.Value != DBNull.Value &&
                    decimal.TryParse(e.Value.ToString(), out var v))
                {
                    e.Value = $"{v:0.##} %";
                    e.FormattingApplied = true;
                }
            };
        }

        private void InitFilters()
        {
            cbNam.DropDownStyle = ComboBoxStyle.DropDownList;
            cbNam.DisplayMember = "Text"; cbNam.ValueMember = "Value";
            cbNam.DataSource = Enumerable.Range(DateTime.Now.Year - 5, 6)
                                         .Select(y => new { Value = y, Text = y.ToString() })
                                         .ToList();
            cbNam.SelectedValue = DateTime.Now.Year;

            rdThang.Checked = true; // mặc định
            rdViTri.Checked = true;
            BindMonths();
        }
        private void BindMonths()
        {
            cbThangQuy.Enabled = true;
            cbThangQuy.DropDownStyle = ComboBoxStyle.DropDownList;
            cbThangQuy.DisplayMember = "Text"; cbThangQuy.ValueMember = "Value";
            cbThangQuy.DataSource = Enumerable.Range(1, 12)
                .Select(m => new { Value = m, Text = $"Tháng {m}" }).ToList();
            cbThangQuy.SelectedValue = DateTime.Now.Month;
        }
        private void BindQuarters()
        {
            cbThangQuy.Enabled = true;
            cbThangQuy.DropDownStyle = ComboBoxStyle.DropDownList;
            cbThangQuy.DisplayMember = "Text"; cbThangQuy.ValueMember = "Value";
            cbThangQuy.DataSource = Enumerable.Range(1, 4)
                .Select(q => new { Value = q, Text = $"Quý {q}" }).ToList();
            cbThangQuy.SelectedValue = (int)Math.Ceiling(DateTime.Now.Month / 3.0);
        }
        private void BindYearWhole()
        {
            cbThangQuy.Enabled = false;
            cbThangQuy.DropDownStyle = ComboBoxStyle.DropDownList;
            cbThangQuy.DisplayMember = "Text"; cbThangQuy.ValueMember = "Value";
            cbThangQuy.DataSource = new[] { new { Value = 1, Text = "Cả năm" } };
            cbThangQuy.SelectedValue = 1;
        }
        private void RefreshData()
        {
            try
            {
                // 1) Thời gian
                string bucket = rdThang.Checked ? "THANG" : rdQuy.Checked ? "QUY" : "NAM";
                int per = Convert.ToInt32(cbThangQuy.SelectedValue ?? 1);
                int year = Convert.ToInt32(cbNam.SelectedValue ?? DateTime.Now.Year);
                if (bucket == "NAM") per = 1;

                var (from, to) = DateRangeHelper.Build(bucket, per, year);

                // 2) Phân tích theo
                string group = rdNhomNghe.Checked ? "NHOM"
                             : rdNghe.Checked ? "NGHE"
                             : "VITRI";

                // 3) Truy vấn & bind
                var dt = _svc.TyLeKetNoi(from, to, group);
                _cache = dt;
                dgvTyLe.DataSource = dt;

                // 4) Tổng quan
                int tong = dt.Rows.Count == 0 ? 0
                    : Convert.ToInt32(dt.Compute("SUM(TongUngVien)", ""));
                int ok = dt.Rows.Count == 0 ? 0
                    : Convert.ToInt32(dt.Compute("SUM(SoTrungTuyen)", ""));
                decimal tyle = tong == 0 ? 0 : Math.Round(100m * ok / tong, 2);

                txtTongUngVien.Text = tong.ToString("N0");
                txtCoViecLam.Text = ok.ToString("N0");
                txtTyLeThanhCong.Text = $"{tyle:0.##} %";
                //chua co chon danh gia
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }
        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            try
            {
                // 1) Thời gian
                string bucket = rdThang.Checked ? "THANG" : rdQuy.Checked ? "QUY" : "NAM";
                int per = Convert.ToInt32(cbThangQuy.SelectedValue ?? 1);
                int year = Convert.ToInt32(cbNam.SelectedValue ?? DateTime.Now.Year);
                if (bucket == "NAM") per = 1;

                var (from, to) = DateRangeHelper.Build(bucket, per, year);

                // 2) Phân tích theo
                string group = rdNhomNghe.Checked ? "NHOM"
                             : rdNghe.Checked ? "NGHE"
                             : "VITRI";

                // 3) Truy vấn & bind
                var dt = _svc.TyLeKetNoi(from, to, group);
                _cache = dt;
                dgvTyLe.DataSource = dt;

                //kiemtra du lieu
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu cho kỳ đã chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Xoá số liệu tổng quan
                    txtTongUngVien.Text = "0";
                    txtCoViecLam.Text = "0";
                    txtTyLeThanhCong.Text = "0 %";
                  ;
                    rdoCanCaiThien.Checked = false;
                    rdoKha.Checked = false;
                    rdoTot.Checked = false;
                }
                else {
                    // 4) Tổng quan
                    int tong = dt.Rows.Count == 0 ? 0
                        : Convert.ToInt32(dt.Compute("SUM(TongUngVien)", ""));
                int ok = dt.Rows.Count == 0 ? 0
                    : Convert.ToInt32(dt.Compute("SUM(SoTrungTuyen)", ""));
                decimal tyle = tong == 0 ? 0 : Math.Round(100m * ok / tong, 2);

                txtTongUngVien.Text = tong.ToString("N0");
                txtCoViecLam.Text = ok.ToString("N0");
                txtTyLeThanhCong.Text = $"{tyle:0.##} %";

                // Nếu bạn có 3 radio đánh giá tổng thể (tuỳ form):
                rdoTot.Checked = tyle >= 60;
                rdoKha.Checked = tyle >= 30 && tyle < 60;
                rdoCanCaiThien.Checked = tyle < 30;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }


        private void ThongKeTyLeKetNoi_UC_Load(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }



        // Khoá nhóm hiện tại => "NHOM"/"NGHE"/"VITRI"
        private string CurrentGroupKey()
            => rdNhomNghe.Checked ? "NHOM" : rdNghe.Checked ? "NGHE" : "VITRI";

        private string GroupTextFromKey(string key)
            => key == "NHOM" ? "2. PHÂN TÍCH THEO NHÓM NGHỀ" : key == "NGHE" ? "2. PHÂN TÍCH THEO NGHỀ" : "2. PHÂN TÍCH THEO VỊ TRÍ CHUYÊN MÔN";

        private static string PeriodText(string bucket, int per, int year)
            => bucket == "THANG" ? $"Tháng {per}/{year}"
             : bucket == "QUY" ? $"Quý {per}/{year}"
             : $"Năm {year}";

        // Xếp hạng chất lượng theo tỷ lệ %
        private string GradeKey(decimal pct)
        {
            if (pct >= 70m) return "TOT";      // Tốt
            if (pct >= 50m) return "KHA";      // Khá
            return "CAITHIEN";                 // Cần cải thiện
        }

        // An toàn cộng cột số (int/long/double/decimal chuỗi…)
        private static decimal SumDecimal(DataTable t, string col)
        {
            if (t == null || !t.Columns.Contains(col)) return 0m;
            return t.AsEnumerable()
                    .Where(r => r[col] != DBNull.Value)
                    .Sum(r =>
                    {
                        object v = r[col];
                        if (v is decimal d) return d;
                        if (v is double db) return (decimal)db;
                        if (v is int i) return i;
                        if (v is long l) return l;
                        decimal x; return decimal.TryParse(Convert.ToString(v), out x) ? x : 0m;
                    });
        }

        // Đổi tên cột nếu có – để chuẩn hoá schema
        private static void RenameIfExists(DataTable t, string oldName, string newName)
        {
            if (t.Columns.Contains(oldName) && !t.Columns.Contains(newName))
                t.Columns[oldName].ColumnName = newName;
        }

        // Chuẩn hoá bảng BM2 => luôn có: DanhMuc, Tong, CoViec, TyLe
        private DataTable NormalizeBm2(DataTable src)
        {
            var t = src.Copy();

            foreach (DataColumn c in t.Columns) c.ColumnName = c.ColumnName.Trim();

            // Tổng ứng viên
            RenameIfExists(t, "TongUngVien", "Tong");

            // Có việc làm
            RenameIfExists(t, "SoTrungTuyen", "CoViec");
     
            if (!t.Columns.Contains("Tong")) t.Columns.Add("Tong", typeof(int));
            if (!t.Columns.Contains("CoViec")) t.Columns.Add("CoViec", typeof(int));
            if (!t.Columns.Contains("TyLe")) t.Columns.Add("TyLe", typeof(decimal));

            return t;
        }

        // Thêm cột STT cho report
        private DataTable BuildTyLeReport(DataTable src)
        {
            var dt = src.Copy();
            if (!dt.Columns.Contains("STT")) dt.Columns.Add("STT", typeof(int));
            for (int i = 0; i < dt.Rows.Count; i++) dt.Rows[i]["STT"] = i + 1;
            dt.Columns["STT"].SetOrdinal(0);
            return dt;
        }

        // Lấy dữ liệu BM2 theo bộ lọc hiện tại và chuẩn hoá schema
        private DataTable QueryCurrent_BM2()
        {
            var (bucket, per, year, group) = GetCurrentFilters(); // bạn đã có sẵn hàm này như BM1
            var (from, to) = DateRangeHelper.Build(bucket, per, year);
            var raw = _svc.TyLeKetNoi(from, to, group);          // service hiện có
            return NormalizeBm2(raw);
        }


        private (string bucket, int per, int year, string group) GetCurrentFilters()
        {
            string bucket = rdThang.Checked ? "THANG" : rdQuy.Checked ? "QUY" : "NAM";
            int per = Convert.ToInt32(cbThangQuy.SelectedValue ?? 1);
            int year = Convert.ToInt32(cbNam.SelectedValue ?? DateTime.Now.Year);
            if (bucket == "NAM") per = 1;

            string group = rdNhomNghe.Checked ? "NHOM" : rdNghe.Checked ? "NGHE" : "VITRI";
            return (bucket, per, year, group);
        }

        private static string CurrentCreatedBy()
        {
            // Ưu tiên họ tên -> username -> tên Windows
            var name = UserSession.NhanVien?.HoTen;
            if (string.IsNullOrWhiteSpace(name))
                name = UserSession.Username;
            if (string.IsNullOrWhiteSpace(name))
                name = Environment.UserName;
            return name;
        }

        private void btnTaoBaoCao_Click(object sender, EventArgs e)
        {
            var dt = QueryCurrent_BM2();
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu cho kỳ đã chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var (bucket, per, year, _) = GetCurrentFilters();
            var groupKey = CurrentGroupKey();

            // Tính tổng – KHÔNG còn lỗi “Column 'Tong'…”
            decimal tong = SumDecimal(dt, "Tong");
            decimal coViec = SumDecimal(dt, "CoViec");
            decimal pct = tong == 0 ? 0 : Math.Round(coViec * 100m / tong, 2);
            string grade = GradeKey(pct);

            var dtReport = BuildTyLeReport(dt);
            var createdBy = CurrentCreatedBy();

            var ps = new[]
            {
        new ReportParameter("pTitle",       "BÁO CÁO TỶ LỆ KẾT NỐI THÀNH CÔNG"),
        new ReportParameter("pPeriod",      PeriodText(bucket, per, year)),
        new ReportParameter("pGroup",       GroupTextFromKey(groupKey)),
        new ReportParameter("pGroupKey",    groupKey),
        new ReportParameter("pTotalUV",     tong.ToString("N0")),
        new ReportParameter("pCoViec",      coViec.ToString("N0")),
        new ReportParameter("pTyLeTC",      pct.ToString("0.##")), // RDLC có thể format thêm %
        new ReportParameter("pGradeKey",    grade),                 // TOT/KHA/CAITHIEN
         new ReportParameter("pCreatedBy", createdBy),
        new ReportParameter("pGeneratedAt", DateTime.Now.ToString("dd/MM/yyyy HH:mm"))
    };

            using (var frm = new FrmReportPreview())
            {
                frm.LoadReport(
                    "Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.CM.Reports.CM_BM2_TyLeKetNoi.rdlc",
                    "dsTyLe",           // dataset name trong RDLC
                    dtReport,
                    ps);
                frm.ShowDialog(this);
            }
        }

        private void btnXuatBaoCao_Click(object sender, EventArgs e)
        {
            var dt = QueryCurrent_BM2();
            if (dt == null || dt.Rows.Count == 0) { MessageBox.Show("Không có dữ liệu để xuất báo cáo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            var (bucket, per, year, _) = GetCurrentFilters();
            var groupKey = CurrentGroupKey();
            var dtReport = BuildTyLeReport(dt);

            decimal tong = SumDecimal(dtReport, "Tong");
            decimal coViec = SumDecimal(dtReport, "CoViec");
            decimal pct = tong == 0 ? 0 : (coViec * 100m / tong);
            string grade = GradeKey(pct);
            var createdBy = CurrentCreatedBy();

            var ps = new[]
            {
        new ReportParameter("pTitle",    "BÁO CÁO TỶ LỆ KẾT NỐI THÀNH CÔNG"),
        new ReportParameter("pPeriod",   PeriodText(bucket, per, year)),
        new ReportParameter("pGroup",    GroupTextFromKey(groupKey)),
        new ReportParameter("pGroupKey", groupKey),
        new ReportParameter("pTotalUV",  tong.ToString("N0")),
        new ReportParameter("pCoViec",   coViec.ToString("N0")),
        new ReportParameter("pTyLeTC",   pct.ToString("0.##")),
        new ReportParameter("pGradeKey", grade),
        new ReportParameter("pCreatedBy", createdBy),
        new ReportParameter("pGeneratedAt", DateTime.Now.ToString("dd/MM/yyyy HH:mm")),
    };

            using (var sfd = new SaveFileDialog
            {
                Title = "Xuất báo cáo",
                Filter = "PDF (*.pdf)|*.pdf|Excel (*.xlsx)|*.xlsx",
                FileName = $"CM-BM2_{DateTime.Now:yyyyMMdd_HHmm}"
            })
            {
                if (sfd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    if (sfd.FilterIndex == 1)
                    {
                        var lr = new LocalReport();
                        var asm = typeof(ThongKeSoLuongUngVien_UC).Assembly;
                        var res = asm.GetManifestResourceNames()
                                     .FirstOrDefault(n => n.EndsWith("CM_BM2_TyLeKetNoi.rdlc", StringComparison.OrdinalIgnoreCase));
                        if (res == null) { MessageBox.Show("Không tìm thấy RDLC BM2."); return; }
                        using (var st = asm.GetManifestResourceStream(res)) lr.LoadReportDefinition(st);

                        lr.DataSources.Clear();
                        lr.DataSources.Add(new ReportDataSource("dsTyLe", dtReport));
                        lr.SetParameters(ps);

                        string mime, enc, ext; Warning[] warn; string[] streams;
                        var bytes = lr.Render("PDF", null, out mime, out enc, out ext, out streams, out warn);
                        lr.ReleaseSandboxAppDomain();
                        System.IO.File.WriteAllBytes(sfd.FileName, bytes);
                    }
                    else
                    {
                        // (Tuỳ bạn) Xuất Excel bằng ClosedXML – bỏ AutoFit để tránh lỗi SixLabors.Fonts
                    }

                    MessageBox.Show("Xuất báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xuất báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void dgvTyLe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

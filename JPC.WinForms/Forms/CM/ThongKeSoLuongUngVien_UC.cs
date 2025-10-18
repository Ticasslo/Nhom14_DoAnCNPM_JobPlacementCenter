using JPC.Business.Services.Implementations.CM;
using JPC.Business.Services.Interfaces.CM;
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
using ClosedXML.Excel;
using System.Globalization;
using System.Diagnostics;
using JPC.Models;


namespace Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.CM
{
    public partial class ThongKeSoLuongUngVien_UC : UserControl
    {
        private readonly ICMStatisticsService _svc = new CMStatisticsService();
        private DataTable _cache;
        public ThongKeSoLuongUngVien_UC()
        {
            InitializeComponent();
            SetupGrid(); // <— thêm dòng này

            // Khởi tạo bộ lọc & events như bạn đã có
            // Đăng ký sự kiện
            this.Load += (s, e) =>
            {
                InitFilters();   // set năm/tháng/quý mặc định
                RefreshData();   // <-- tự tải dữ liệu ngay khi mở màn
            };
            rdThang.CheckedChanged += (s, e) => { if (rdThang.Checked) BindMonths(); };
            rdQuy.CheckedChanged += (s, e) => { if (rdQuy.Checked) BindQuarters(); };
            rdNam.CheckedChanged += (s, e) => { if (rdNam.Checked) BindYearWhole(); };
            //btnTaiLai.Click += btnTaiLai_Click;

        }
        public string AuthorDisplayName { get; set; } = Environment.UserName;

        private void RefreshData()
        {
            try
            {
                // 1) THỜI GIAN
                string bucket = rdThang.Checked ? "THANG" : rdQuy.Checked ? "QUY" : "NAM";
                int per = Convert.ToInt32(cbThangQuy.SelectedValue ?? 1);
                int year = Convert.ToInt32(cbNam.SelectedValue ?? DateTime.Now.Year);
                if (bucket == "NAM") per = 1;

                var (from, to) = DateRangeHelper.Build(bucket, per, year);

                // 2) PHÂN TÍCH THEO
                string group = rdNhomNghe.Checked ? "NHOM"
                             : rdNghe.Checked ? "NGHE"
                             : "VITRI";

                // 3) TRUY VẤN
                // 3) Truy vấn
                var dt = _svc.ThongKeSoLuong(from, to, group);
                _cache = dt;

                // BIND LƯỚI (đã khai báo cột sẵn ở SetupGrid)
                dgvThongKe.DataSource = dt;

                // 4) Tổng quan
                txtTongUngVien.Text = dt.Rows.Count == 0 ? "0"
                    : Convert.ToString(dt.Compute("SUM(SoLuong)", null));
                txtNoiBatNhat.Text = dt.Rows.Count == 0 ? ""
                    : dt.Rows[0]["DanhMuc"].ToString();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void SetupGrid()
        {
            dgvThongKe.AutoGenerateColumns = false;
            dgvThongKe.RowHeadersVisible = false;
            dgvThongKe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvThongKe.ReadOnly = true;
            dgvThongKe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvThongKe.MultiSelect = false;

            dgvThongKe.Columns.Clear();

            var colSTT = new DataGridViewTextBoxColumn
            {
                Name = "colSTT",
                HeaderText = "STT",
                FillWeight = 8,
                ReadOnly = true
            };
            var colDM = new DataGridViewTextBoxColumn
            {
                Name = "DanhMuc",
                HeaderText = "Nhóm nghề / Nghề / Vị trí",
                DataPropertyName = "DanhMuc",
                FillWeight = 60,
                ReadOnly = true
            };
            var colSL = new DataGridViewTextBoxColumn
            {
                Name = "SoLuong",
                HeaderText = "Số lượng",
                DataPropertyName = "SoLuong",
                FillWeight = 22,
                ReadOnly = true,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N0" }
            };
            var colTL = new DataGridViewTextBoxColumn
            {
                Name = "TyLe",
                HeaderText = "Tỷ lệ (%)",
                DataPropertyName = "TyLe",
                FillWeight = 10,
                ReadOnly = true,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight }
            };

            dgvThongKe.Columns.AddRange(colSTT, colDM, colSL, colTL);

            // Đánh số STT sau khi bind
            dgvThongKe.DataBindingComplete += (s, e) =>
            {
                for (int i = 0; i < dgvThongKe.Rows.Count; i++)
                    dgvThongKe.Rows[i].Cells["colSTT"].Value = (i + 1);
            };

            // “xx.xx %” cho cột Tỷ lệ
            dgvThongKe.CellFormatting += (s, e) =>
            {
                if (dgvThongKe.Columns[e.ColumnIndex].Name == "TyLe"
                    && e.Value != null && e.Value != DBNull.Value
                    && decimal.TryParse(e.Value.ToString(), out var v))
                {
                    e.Value = $"{v:0.##} %";
                    e.FormattingApplied = true;
                }
            };
        }

        private void InitFilters()
        {
            // Năm: 6 năm gần nhất
            cbNam.DropDownStyle = ComboBoxStyle.DropDownList;
            cbNam.DisplayMember = "Text"; cbNam.ValueMember = "Value";
            cbNam.DataSource = Enumerable.Range(DateTime.Now.Year - 5, 6)
                                         .Select(y => new { Value = y, Text = y.ToString() })
                                         .ToList();
            cbNam.SelectedValue = DateTime.Now.Year;

            // Mặc định THÁNG
            rdThang.Checked = true;
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
            cbThangQuy.Enabled = false; // vẫn giữ control, chỉ khoá chọn
            cbThangQuy.DropDownStyle = ComboBoxStyle.DropDownList;
            cbThangQuy.DisplayMember = "Text"; cbThangQuy.ValueMember = "Value";
            cbThangQuy.DataSource = new[] { new { Value = 1, Text = "Cả năm" } };
            cbThangQuy.SelectedValue = 1;
        }
     

        private void ThongKeSoLuongUngVien_UC_Load(object sender, EventArgs e)
        {

        }

    
        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            try
            {
                // 1) THỜI GIAN
                string bucket = rdThang.Checked ? "THANG" : rdQuy.Checked ? "QUY" : "NAM";
                int per = Convert.ToInt32(cbThangQuy.SelectedValue ?? 1);
                int year = Convert.ToInt32(cbNam.SelectedValue ?? DateTime.Now.Year);
                if (bucket == "NAM") per = 1;

                var (from, to) = DateRangeHelper.Build(bucket, per, year);

                // 2) PHÂN TÍCH THEO
                string group = rdNhomNghe.Checked ? "NHOM"
                             : rdNghe.Checked ? "NGHE"
                             : "VITRI";

                // 3) TRUY VẤN         
                var dt = _svc.ThongKeSoLuong(from, to, group);
                _cache = dt;

                //kiemtra du lieu
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu cho kỳ đã chọn.","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvThongKe.DataSource = null;
                    txtTongUngVien.Text = "0";
                    txtNoiBatNhat.Text = "";

                }
                else
                {
                    // BIND LƯỚI (đã khai báo cột sẵn ở SetupGrid)
                    dgvThongKe.DataSource = dt;
              
                // 4) Tổng quan
                txtTongUngVien.Text = dt.Rows.Count == 0 ? "0"
                    : Convert.ToString(dt.Compute("SUM(SoLuong)", null));
                txtNoiBatNhat.Text = dt.Rows.Count == 0 ? ""
                    : dt.Rows[0]["DanhMuc"].ToString();
                    //checkmacdinh
                    //rdOnDinh.Checked = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
      

        }
        private DataTable BuildReportTable(DataTable src)
        {
            var dt = src.Copy();
            if (!dt.Columns.Contains("STT"))
                dt.Columns.Add("STT", typeof(int));
            for (int i = 0; i < dt.Rows.Count; i++)
                dt.Rows[i]["STT"] = i + 1;
            dt.Columns["STT"].SetOrdinal(0);
            return dt;
        }
        private static string PeriodText(string bucket, int per, int year)
            => bucket == "THANG" ? $"Tháng {per}/{year}" : bucket == "QUY" ? $"Quý {per}/{year}" : $"Năm {year}";
        private static string GroupText(string group)
            => group == "NHOM" ? "2. PHÂN TÍCH THEO NHÓM NGHỀ" : group == "NGHE" ? "2. PHÂN TÍCH THEO NGHỀ" : "2. PHÂN TÍCH THEO VỊ TRÍ CHUYÊN MÔN";
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
            // 1) Lấy dữ liệu đang hiển thị
            var dt = (_cache != null && _cache.Rows.Count > 0) ? _cache : QueryCurrent();
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu ứng viên cho kỳ đã chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 2) Đọc bộ lọc hiện tại
            var (bucket, per, year, group) = GetCurrentFilters();
            var dtReport = BuildReportTable(dt);           // thêm cột STT

            // 3) Khóa phân nhóm & xu hướng để truyền vào RDLC
            string groupKey = rdNhomNghe.Checked ? "NHOM"
                             : rdNghe.Checked ? "NGHE"
                             : "VITRI"; //mặc định

            string trendKey = rdTang.Checked ? "TANG"
                             : rdGiam.Checked ? "GIAM"
                             : "ONDINH"; // mặc định
            var createdBy = CurrentCreatedBy();
            // 4) Tham số cho RDLC (đúng tên param trong report)
            var ps = new ReportParameter[]
            {
        new ReportParameter("pTitle",        "THỐNG KÊ SỐ LƯỢNG ỨNG VIÊN"),
        new ReportParameter("pPeriod",       PeriodText(bucket, per, year)),
        new ReportParameter("pGroup",        GroupText(group)),
        new ReportParameter("pGroupKey",     groupKey),
        new ReportParameter("pTotal",        Convert.ToString(dt.Compute("SUM(SoLuong)", null))),
        new ReportParameter("pHighlight",    dt.Rows[0]["DanhMuc"].ToString()),
        new ReportParameter("pTrend",        trendKey),
       new ReportParameter("pCreatedBy", createdBy),
        new ReportParameter("pGeneratedAt",  DateTime.Now.ToString("dd/MM/yyyy HH:mm")),
            };

            // 5) Mở form preview
            using (var frm = new FrmReportPreview())
            {
                frm.LoadReport(
                    "Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.CM.Reports.CM_BM1_ThongKeSoLuong.rdlc",
                    dtReport,
                    ps);
                frm.ShowDialog(this);
            }
        }
        private (string bucket, int per, int year, string group) GetCurrentFilters()
        {
            string bucket = rdThang.Checked ? "THANG" : rdQuy.Checked ? "QUY" : "NAM";
            int per = Convert.ToInt32(cbThangQuy.SelectedValue ?? 1);
            int year = Convert.ToInt32(cbNam.SelectedValue ?? DateTime.Now.Year);
            if (bucket == "NAM") per = 1;

            string group = rdNhomNghe.Checked ? "NHOM"
                         : rdNghe.Checked ? "NGHE"
                         : "VITRI";
            return (bucket, per, year, group);
        }

        private DataTable QueryCurrent()
        {
            var (bucket, per, year, group) = GetCurrentFilters();
            var (from, to) = DateRangeHelper.Build(bucket, per, year);
            return _svc.ThongKeSoLuong(from, to, group);        // hoặc TyLeKetNoi(...) ở màn tỷ lệ
        }
       

        private void btnXuatBaoCao_Click(object sender, EventArgs e)
        {
            // 1) Lấy dữ liệu
            var dt = (_cache != null && _cache.Rows.Count > 0) ? _cache : QueryCurrent();
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất báo cáo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _cache = dt;

            // 2) Đọc bộ lọc hiện tại
            var (bucket, per, year, group) = GetCurrentFilters();
            var dtReport = BuildReportTable(dt);              // thêm cột STT

            // Khóa phân nhóm và xu hướng để truyền vào RDLC
            string groupKey = rdNhomNghe.Checked ? "NHOM"
                              : rdNghe.Checked ? "NGHE"
                              : "VITRI";

            string trendKey = rdTang.Checked ? "TANG"
                            : rdOnDinh.Checked ? "ONDINH"
                            : "GIAM";
            var createdBy = CurrentCreatedBy();
            // 3) Tạo bộ tham số cho RDLC
            var ps = new[]
            {
        new ReportParameter("pTitle",       "THỐNG KÊ SỐ LƯỢNG ỨNG VIÊN"),
        new ReportParameter("pPeriod",      PeriodText(bucket, per, year)),
        new ReportParameter("pGroup",       GroupText(group)),
        new ReportParameter("pGroupKey",    groupKey),
        new ReportParameter("pTotal",       Convert.ToString(dt.Compute("SUM(SoLuong)", null))),
        new ReportParameter("pHighlight",   dt.Rows[0]["DanhMuc"].ToString()),
        new ReportParameter("pTrend",       trendKey),
         new ReportParameter("pCreatedBy", createdBy),
        new ReportParameter("pGeneratedAt", DateTime.Now.ToString("dd/MM/yyyy HH:mm"))
    };

            // 4) Hộp thoại chọn định dạng và nơi lưu
            using (var sfd = new SaveFileDialog
            {
                Title = "Xuất báo cáo",
                Filter = "PDF (*.pdf)|*.pdf",
                FileName = $"CM-BM1_{DateTime.Now:yyyyMMdd_HHmm}"
            })
            {
                if (sfd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    if (sfd.FilterIndex == 1) // === PDF bằng RDLC ===
                    {
                        var lr = new LocalReport();

                        // Nạp RDLC từ Embedded Resource (không phụ thuộc đường dẫn)
                        var asm = typeof(ThongKeSoLuongUngVien_UC).Assembly;
                        var resName = asm.GetManifestResourceNames()
                                         .FirstOrDefault(n => n.EndsWith("CM_BM1_ThongKeSoLuong.rdlc",
                                                         StringComparison.OrdinalIgnoreCase));
                        if (resName == null)
                        {
                            MessageBox.Show("Không tìm thấy mẫu RDLC trong project.");
                            return;
                        }
                        using (var rs = asm.GetManifestResourceStream(resName))
                            lr.LoadReportDefinition(rs);

                        lr.DataSources.Clear();
                        lr.DataSources.Add(new ReportDataSource("dsThongKe", dtReport)); // tên dataset trong RDLC
                        lr.SetParameters(ps);

                        string mime, enc, ext; Warning[] warn; string[] streams;
                        var bytes = lr.Render("PDF", null, out mime, out enc, out ext, out streams, out warn);
                        lr.ReleaseSandboxAppDomain();

                        System.IO.File.WriteAllBytes(sfd.FileName, bytes);
                    }
                    else                       // === Excel bằng ClosedXML ===
                    {
                        // Header phụ trong file Excel
                        //var sub1 = $"Kỳ: {PeriodText(bucket, per, year)}   |   Phân tích theo: {GroupText(group)}";
                        //var sub2 = $"Tổng: {dt.Compute("SUM(SoLuong)", null)}   |   Nổi bật: {dt.Rows[0]["DanhMuc"]}";
                        //ExportExcel(dtReport, sfd.FileName, "THỐNG KÊ SỐ LƯỢNG ỨNG VIÊN", sub1, sub2);
                    }

                    MessageBox.Show("Xuất báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (TypeInitializationException ex) when (ex.TypeName?.Contains("SixLabors.Fonts") == true)
                {
                    // Nếu lỡ gặp lỗi font của ClosedXML, báo gọn và gợi ý lưu lại bằng PDF
                    MessageBox.Show("Không tạo được Excel do lỗi font hệ thống. Hãy thử xuất PDF.", "Xuất báo cáo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xuất báo cáo: " + ex.Message, "Lỗi",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

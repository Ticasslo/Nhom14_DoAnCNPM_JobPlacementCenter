using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.FO
{
    public partial class BaoCaoDoanhThuThang : UserControl
    {
        private static string Cnn => ConfigurationManager.ConnectionStrings["JobPlacementCenter"].ConnectionString;
        private DataTable _dtInvoices = new DataTable();

        public BaoCaoDoanhThuThang()
        {
            InitializeComponent();
            this.Load += BaoCaoDoanhThuThang_Load;
            dtpTuNgay.ValueChanged += (_, __) => LoadInvoices();
            dtpDenNgay.ValueChanged += (_, __) => LoadInvoices();
            btnXuatPhieuThu.Click += (_, __) => ExportExcel();
        }

        #region Helpers
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

        private static DateTime FirstDayOfMonth(DateTime d) => new DateTime(d.Year, d.Month, 1);
        private static DateTime LastDayOfMonth(DateTime d) => new DateTime(d.Year, d.Month, DateTime.DaysInMonth(d.Year, d.Month));

        private void BindGrid()
        {
            dgvBangCaoDoanhThuThang.AutoGenerateColumns = false;
            dgvBangCaoDoanhThuThang.ReadOnly = true;
            dgvBangCaoDoanhThuThang.AllowUserToAddRows = false;
            dgvBangCaoDoanhThuThang.AllowUserToDeleteRows = false;
            dgvBangCaoDoanhThuThang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (dgvBangCaoDoanhThuThang.Columns.Count == 0)
            {
                dgvBangCaoDoanhThuThang.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "ma_hoa_don",
                    HeaderText = "Mã hóa đơn",
                    Width = 110
                });
                dgvBangCaoDoanhThuThang.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "ten_khach_hang",
                    HeaderText = "Tên người đóng",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });
                dgvBangCaoDoanhThuThang.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "doi_tuong",
                    HeaderText = "Sinh viên / Doanh nghiệp",
                    Width = 200
                });
                dgvBangCaoDoanhThuThang.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "so_tien",
                    HeaderText = "Số tiền",
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "#,0" },
                    Width = 120
                });
                dgvBangCaoDoanhThuThang.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "ngay_thu",
                    HeaderText = "Ngày thu",
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" },
                    Width = 110
                });
            }

            dgvBangCaoDoanhThuThang.DataSource = _dtInvoices;
        }

        private void RecalcTotal()
        {
            decimal total = 0m;
            if (_dtInvoices != null && _dtInvoices.Rows.Count > 0)
                total = _dtInvoices.AsEnumerable().Sum(r => r.Field<decimal>("so_tien"));

            txtTongTien.Text = string.Format(CultureInfo.InvariantCulture, "{0:#,0}", total);
        }
        #endregion
        private static string CurrentUserName()
        {
            try
            {
                return (JPC.Models.UserSession.NhanVien != null)
                       ? JPC.Models.UserSession.NhanVien.HoTen
                       : string.Empty;
            }
            catch { return string.Empty; }
        }
        private void BaoCaoDoanhThuThang_Load(object sender, EventArgs e)
        {
            // mặc định đầu/cuối tháng hiện tại
            var now = DateTime.Now;
            dtpTuNgay.Value = FirstDayOfMonth(now);
            dtpDenNgay.Value = LastDayOfMonth(now);

            // tên người lập lấy từ phiên đăng nhập
            txtNguoiLapBaoCao.Text = CurrentUserName();

            LoadInvoices();
        }

        private void LoadInvoices()
        {
            var from = dtpTuNgay.Value.Date;
            var to = dtpDenNgay.Value.Date;

            const string sql = @"
SELECT 
    h.ma_hoa_don,
    h.ten_khach_hang,
    CASE WHEN h.loai_khach_hang='ung_vien' THEN N'Ứng viên' ELSE N'Doanh nghiệp' END AS doi_tuong,
    h.so_tien,
    CAST(h.ngay_lap_hoa_don AS date) AS ngay_thu
FROM HoaDon h
WHERE CAST(h.ngay_lap_hoa_don AS date) BETWEEN @from AND @to
ORDER BY h.ngay_lap_hoa_don DESC, h.ma_hoa_don DESC;";

            _dtInvoices = Query(sql,
                new SqlParameter("@from", SqlDbType.Date) { Value = from },
                new SqlParameter("@to", SqlDbType.Date) { Value = to });

            BindGrid();
            RecalcTotal();
        }

        private void ExportExcel()
        {
            if (_dtInvoices == null || _dtInvoices.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.");
                return;
            }

            var sfd = new SaveFileDialog
            {
                Title = "Lưu báo cáo doanh thu",
                Filter = "Excel Workbook (*.xlsx)|*.xlsx",
                FileName = $"BaoCaoDoanhThu_{dtpTuNgay.Value:yyyyMMdd}_{dtpDenNgay.Value:yyyyMMdd}.xlsx"
            };
            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                using (var wb = new XLWorkbook())
                {
                    var ws = wb.AddWorksheet("BaoCao");

                    int row = 1;

                    // Tiêu đề
                    ws.Cell(row, 1).Value = "BÁO CÁO DOANH THU THEO THÁNG";
                    ws.Range(row, 1, row, 5).Merge().Style
                        .Font.SetBold().Font.SetFontSize(16)
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    row += 2;

                    // Dòng thời gian (in nghiêng)
                    var timeLine = $"Từ ngày {dtpTuNgay.Value:dd/MM/yyyy} đến ngày {dtpDenNgay.Value:dd/MM/yyyy}";
                    ws.Cell(row, 1).Value = timeLine;
                    ws.Range(row, 1, row, 5).Merge().Style
                        .Font.SetItalic()
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    row += 2;

                    // Header bảng
                    ws.Cell(row, 1).Value = "Mã hóa đơn";
                    ws.Cell(row, 2).Value = "Tên người đóng";
                    ws.Cell(row, 3).Value = "Sinh viên / Doanh nghiệp";
                    ws.Cell(row, 4).Value = "Số tiền";
                    ws.Cell(row, 5).Value = "Ngày thu";
                    ws.Range(row, 1, row, 5).Style
                        .Font.SetBold()
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Border.OutsideBorder = XLBorderStyleValues.Thin;
                    ws.Range(row, 1, row, 5).Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                    // Dữ liệu
                    int startDataRow = ++row;
                    foreach (DataRow dr in _dtInvoices.Rows)
                    {
                        ws.Cell(row, 1).Value = dr["ma_hoa_don"]?.ToString();                 // hoặc Convert.ToInt32(...)
                        ws.Cell(row, 2).Value = dr["ten_khach_hang"]?.ToString();
                        ws.Cell(row, 3).Value = dr["doi_tuong"]?.ToString();

                        ws.Cell(row, 4).Value = dr.Field<decimal>("so_tien");
                        ws.Cell(row, 4).Style.NumberFormat.Format = "#,##0";
                        ws.Cell(row, 5).Value = Convert.ToDateTime(dr["ngay_thu"]);
                        ws.Cell(row, 5).Style.DateFormat.Format = "dd/MM/yyyy";
                        row++;
                    }

                    // Kẻ bảng
                    ws.Range(startDataRow - 1, 1, row - 1, 5).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    ws.Range(startDataRow - 1, 1, row - 1, 5).Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                    // Tổng tiền
                    decimal total = _dtInvoices.AsEnumerable().Sum(r => r.Field<decimal>("so_tien"));
                    ws.Cell(row, 1).Value = "Tổng tiền:";
                    ws.Range(row, 1, row, 3).Merge().Style
                        .Font.SetBold()
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
                    ws.Cell(row, 4).Value = total;
                    ws.Cell(row, 4).Style.NumberFormat.Format = "#,##0";
                    ws.Range(row, 4, row, 5).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    row += 2;

                    // Người lập báo cáo
                    ws.Cell(row, 4).Value = "Người lập báo cáo";
                    ws.Cell(row, 4).Style.Font.SetBold();
                    row++;
                    ws.Cell(row, 4).Value = "(Ký tên)";
                    ws.Cell(row, 4).Style.Font.SetItalic();
                    row += 2;
                    ws.Cell(row, 4).Value = string.IsNullOrWhiteSpace(txtNguoiLapBaoCao.Text)
                        ? CurrentUserName()
                        : txtNguoiLapBaoCao.Text.Trim();

                    // Auto fit
                    ws.Columns(1, 5).AdjustToContents();

                    wb.SaveAs(sfd.FileName);
                }

                MessageBox.Show("Đã xuất báo cáo thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất Excel: " + ex.Message);
            }
        }
    }
}

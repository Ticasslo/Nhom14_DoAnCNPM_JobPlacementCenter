using ClosedXML.Excel;
using JPC.Business.Services.Implementations.FO;
using JPC.Business.Services.Interfaces.FO;
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
namespace Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.FO
{
    public partial class BaoCaoDoanhThuThang_UC : UserControl
    {
        private bool _isInit = true;
        private bool _suppressEvents = false;
        private DataTable _dtInvoices = new DataTable();
        private readonly IBaoCaoDoanhThuThangService _svc;

        private static DateTime FirstDayOfMonth(DateTime d) => new DateTime(d.Year, d.Month, 1);
        private static DateTime LastDayOfMonth(DateTime d) => new DateTime(d.Year, d.Month, DateTime.DaysInMonth(d.Year, d.Month));

        public BaoCaoDoanhThuThang_UC()
        {
            InitializeComponent();
            _svc = new BaoCaoDoanhThuThangService();   // Service tự new Repo bên trong
            this.Load += BaoCaoDoanhThuThang_UC_Load;

            dtpTuNgay.ValueChanged += dtpTuNgay_ValueChanged;
            dtpDenNgay.ValueChanged += dtpDenNgay_ValueChanged;
            btnXuatBaoCao.Click += (_, __) => ExportExcel();
        }

        private void BaoCaoDoanhThuThang_UC_Load(object sender, EventArgs e)
        {
            _isInit = true;

            // Mặc định khóa theo tháng hiện tại
            SnapToMonth(DateTime.Now);
            txtNguoiLapBaoCao.Text = CurrentUserName();

            _isInit = false;
            LoadInvoices();
        }

        #region Helpers

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

            if (dgvBangCaoDoanhThuThang.Columns["so_tien"] != null)
                dgvBangCaoDoanhThuThang.Columns["so_tien"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight;

            FixGridHeader(dgvBangCaoDoanhThuThang);
        }

        private static string CurrentUserName()
        {
            try { return JPC.Models.UserSession.NhanVien?.HoTen ?? string.Empty; }
            catch { return string.Empty; }
        }

        private void SnapToMonth(DateTime anchor)
        {
            _suppressEvents = true;
            dtpTuNgay.Value = FirstDayOfMonth(anchor);
            dtpDenNgay.Value = LastDayOfMonth(anchor);
            _suppressEvents = false;
        }

        #endregion

        private void dtpTuNgay_ValueChanged(object sender, EventArgs e)
        {
            if (_isInit || _suppressEvents) return;
            SnapToMonth(dtpTuNgay.Value);   // khóa theo tháng của “Từ ngày”
            LoadInvoices();
        }

        private void dtpDenNgay_ValueChanged(object sender, EventArgs e)
        {
            if (_isInit || _suppressEvents) return;

            if (dtpDenNgay.Value.Date < dtpTuNgay.Value.Date)
            {
                _suppressEvents = true;
                dtpDenNgay.Value = dtpTuNgay.Value.Date;
                _suppressEvents = false;
            }
            LoadInvoices();
        }

        private void LoadInvoices()
        {
            if (_isInit) return;

            if (dtpTuNgay.Value.Date > dtpDenNgay.Value.Date)
            {
                _suppressEvents = true;
                dtpDenNgay.Value = dtpTuNgay.Value.Date;
                _suppressEvents = false;
                ShowOwnedMessage("Từ ngày không được lớn hơn Đến ngày.");
            }

            _dtInvoices = _svc.GetBaoCao(dtpTuNgay.Value.Date, dtpDenNgay.Value.Date);
            BindGrid();

            var tong = _svc.TinhTongTien(_dtInvoices);
            txtTongTien.Text = $"{tong:#,0}";
        }

        private void ShowOwnedMessage(string text, string title = "Thông báo")
        {
            var owner = this.FindForm();
            if (owner != null) MessageBox.Show(owner, text, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                    ws.Cell(row, 1).Value = "BÁO CÁO DOANH THU THEO THÁNG";
                    ws.Range(row, 1, row, 5).Merge().Style
                        .Font.SetBold().Font.SetFontSize(16)
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    row += 2;

                    var timeLine = $"Từ ngày {dtpTuNgay.Value:dd/MM/yyyy} đến ngày {dtpDenNgay.Value:dd/MM/yyyy}";
                    ws.Cell(row, 1).Value = timeLine;
                    ws.Range(row, 1, row, 5).Merge().Style
                        .Font.SetItalic()
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    row += 2;

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

                    int startDataRow = ++row;
                    foreach (DataRow dr in _dtInvoices.Rows)
                    {
                        ws.Cell(row, 1).Value = dr["ma_hoa_don"]?.ToString();
                        ws.Cell(row, 2).Value = dr["ten_khach_hang"]?.ToString();
                        ws.Cell(row, 3).Value = dr["doi_tuong"]?.ToString();
                        ws.Cell(row, 4).Value = dr.Field<decimal>("so_tien");
                        ws.Cell(row, 4).Style.NumberFormat.Format = "#,##0";
                        ws.Cell(row, 5).Value = Convert.ToDateTime(dr["ngay_thu"]);
                        ws.Cell(row, 5).Style.DateFormat.Format = "dd/MM/yyyy";
                        row++;
                    }

                    ws.Range(startDataRow - 1, 1, row - 1, 5).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    ws.Range(startDataRow - 1, 1, row - 1, 5).Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                    decimal total = _dtInvoices.AsEnumerable().Sum(r => r.Field<decimal>("so_tien"));
                    ws.Cell(row, 1).Value = "Tổng tiền:";
                    ws.Range(row, 1, row, 3).Merge().Style
                        .Font.SetBold()
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
                    ws.Cell(row, 4).Value = total;
                    ws.Cell(row, 4).Style.NumberFormat.Format = "#,##0";
                    ws.Range(row, 4, row, 5).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    row += 2;

                    ws.Cell(row, 4).Value = "Người lập báo cáo";
                    ws.Cell(row, 4).Style.Font.SetBold();
                    row++;
                    ws.Cell(row, 4).Value = "(Ký tên)";
                    ws.Cell(row, 4).Style.Font.SetItalic();
                    row += 2;
                    ws.Cell(row, 4).Value = string.IsNullOrWhiteSpace(txtNguoiLapBaoCao.Text)
                        ? CurrentUserName()
                        : txtNguoiLapBaoCao.Text.Trim();

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

        // fix header guna datagridview
        void FixGridHeader(Guna.UI2.WinForms.Guna2DataGridView dgv)
        {
            dgv.ColumnHeadersVisible = true;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv.ColumnHeadersHeight = 36;

            dgv.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv.ThemeStyle.HeaderStyle.Height = 36;

            dgv.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgv.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgv.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 10.5f, FontStyle.Bold);

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AutoResizeColumns();

            dgv.SuspendLayout();
            dgv.ResumeLayout(true);
            dgv.PerformLayout();
            dgv.Invalidate();
            dgv.Refresh();
        }
    }
}

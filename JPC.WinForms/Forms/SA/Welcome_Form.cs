using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using JPC.Business.Services.Interfaces.SA;
using JPC.Business.Services.Implementations.SA;
using JPC.Models;

namespace Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.SA
{
    public partial class Welcome_Form : Form
    {
        private INhomNgheService _nhomNgheService;
        private INgheService _ngheService;
        private IViTriChuyenMonService _viTriChuyenMonService;
        private INhanVienService _nhanVienService;
        public Welcome_Form()
        {
            InitializeComponent();
            InitializeServices();
            SetupResponsiveLayout();
            this.Resize += (s, e) => AdjustLayout();
        }

        private void InitializeServices()
        {
            _nhomNgheService = new NhomNgheService();
            _ngheService = new NgheService();
            _viTriChuyenMonService = new ViTriChuyenMonService();
            _nhanVienService = new NhanVienService();
        }

        private void SetupResponsiveLayout()
        {
            // Header panel dock top
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Height = 135;

            // Setup panel
            panelTongNhomNghe.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            panelTongNghe.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            panelTongViTriChuyenMon.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            panelTongNhanVien.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            panelPhanBoVaiTro.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pic1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pic2.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            pic3.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;

            // Đảm bảo tất cả PictureBox có cùng SizeMode để hiển thị đều
            pic1.SizeMode = PictureBoxSizeMode.StretchImage;
            pic2.SizeMode = PictureBoxSizeMode.StretchImage;
            pic3.SizeMode = PictureBoxSizeMode.StretchImage;

            // Double buffer for smooth rendering
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();
        }

        private void AdjustLayout()
        {
            if (this.Width < 1200) return; // Minimum width
            int padding = 12;
            int cardWidth = 394;
            int cardHeight = 150;
            int gap = 12;
            // Tính tổng chiều cao của 4 KPI cards
            int totalLeftHeight = (cardHeight + gap) * 4 - gap;
            // Left column (4 KPI cards) - căn chỉnh đều
            panelTongNhomNghe.Location = new Point(padding, padding);
            panelTongNhomNghe.Size = new Size(cardWidth, cardHeight);
            
            panelTongNghe.Location = new Point(padding, padding + cardHeight + gap);
            panelTongNghe.Size = new Size(cardWidth, cardHeight);
            
            panelTongViTriChuyenMon.Location = new Point(padding, padding + (cardHeight + gap) * 2);
            panelTongViTriChuyenMon.Size = new Size(cardWidth, cardHeight);
            
            panelTongNhanVien.Location = new Point(padding, padding + (cardHeight + gap) * 3);
            panelTongNhanVien.Size = new Size(cardWidth, cardHeight);

            // Middle column (Phân bố vai trò) - cùng chiều cao với cột trái
            int middleX = padding + cardWidth + gap;
            int middleWidth = 386;
            panelPhanBoVaiTro.Location = new Point(middleX, padding);
            panelPhanBoVaiTro.Size = new Size(middleWidth, totalLeftHeight);

            // Right column (Images) pic1, pic2 trên, pic3 dưới panel chart
            int rightX = middleX + middleWidth + gap;
            int rightWidth = this.Width - rightX - padding;
            
            // pic1 và pic2 chia đều phần trên
            int topHeight = totalLeftHeight / 2;
            int imageHeight = topHeight;
            
            pic1.Location = new Point(rightX, padding);
            pic1.Size = new Size(rightWidth, imageHeight);
            
            pic2.Location = new Point(rightX, padding + imageHeight);
            pic2.Size = new Size(rightWidth, imageHeight);
            
            // pic3 ở dưới panel chart
            pic3.Location = new Point(rightX, padding + totalLeftHeight);
            pic3.Size = new Size(rightWidth, imageHeight);
        }

        private void Welcome_Form_Load(object sender, EventArgs e)
        {
            AdjustLayout();
            LoadDashboardData();
            UpdateUserInfo();
        }

        private void UpdateUserInfo()
        {
            try
            {
                // Cập nhật tên người dùng từ UserSession
                if (lblXinChao != null)
                {
                    if (UserSession.NhanVien != null)
                    {
                        lblXinChao.Text = $"Xin chào: {UserSession.NhanVien.HoTen} ({UserSession.Username})";
                    }
                    else
                    {
                        lblXinChao.Text = "Xin chào: System Administrator";
                    }
                }
                
                // Cập nhật thời gian hiện tại (thứ, ngày tháng năm)
                if (lblThoiGian != null)
                {
                    var now = DateTime.Now;
                    string thu = GetDayOfWeekVietnamese(now.DayOfWeek);
                    lblThoiGian.Text = $"{thu}, ngày {now.Day} tháng {now.Month} năm {now.Year}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật thông tin người dùng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetDayOfWeekVietnamese(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Sunday: return "Chủ nhật";
                case DayOfWeek.Monday: return "Thứ hai";
                case DayOfWeek.Tuesday: return "Thứ ba";
                case DayOfWeek.Wednesday: return "Thứ tư";
                case DayOfWeek.Thursday: return "Thứ năm";
                case DayOfWeek.Friday: return "Thứ sáu";
                case DayOfWeek.Saturday: return "Thứ bảy";
                default: return "";
            }
        }

        private void LoadDashboardData()
        {
            try
            {
                LoadKPIData();
                LoadRoleDistributionChart();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu dashboard: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadKPIData()
        {
            // Tổng nhóm nghề
            var totalNhomNghe = _nhomNgheService.GetAllNhomNghe().Rows.Count;
            lblSLNhomNghe.Text = totalNhomNghe.ToString();
            
            // Tổng nghề
            var totalNghe = _ngheService.GetAllNghe().Rows.Count;
            lblSLNghe.Text = totalNghe.ToString();
            
            // Tổng vị trí chuyên môn
            var totalViTri = _viTriChuyenMonService.GetAllViTriChuyenMon().Rows.Count;
            lblSLViTriChuyenMon.Text = totalViTri.ToString();
            
            // Tổng nhân viên
            var totalNhanVien = _nhanVienService.GetAllNhanVien().Rows.Count;
            lblSLNhanVien.Text = totalNhanVien.ToString();
        }

        private void LoadRoleDistributionChart()
        {
            try
            {
                var roleDistributionData = _nhanVienService.GetRoleDistribution();
                var roleCounts = new Dictionary<string, int>
                {
                    { "SA", 0 },
                    { "CM", 0 },
                    { "CSS", 0 },
                    { "ERS", 0 },
                    { "FO", 0 },
                    { "SSS", 0 }
                };

                foreach (DataRow row in roleDistributionData.Rows)
                {
                    if (row["vai_tro_id"] != null && row["vai_tro_id"] != DBNull.Value)
                    {
                        string vaiTro = row["vai_tro_id"].ToString();
                        int soLuong = Convert.ToInt32(row["so_luong"]);
                        
                        if (roleCounts.ContainsKey(vaiTro))
                        {
                            roleCounts[vaiTro] = soLuong;
                        }
                    }
                }

                // Tính tổng và hiển thị thông tin chi tiết
                int totalEmployees = roleCounts.Values.Sum();
                
                if (totalEmployees > 0)
                {
                    CreateRoleDistributionChart(roleCounts, totalEmployees);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu phân bố vai trò: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateRoleDistributionChart(Dictionary<string, int> roleCounts, int totalEmployees)
        {
            try
            {
                if (chartPhanBoVaiTro != null)
                {
                    // Xóa dữ liệu cũ
                    chartPhanBoVaiTro.Series.Clear();
                    
                    // Tạo series mới
                    var series = new Series("Phân bổ vai trò");
                    series.ChartType = SeriesChartType.Pie;
                    series.IsValueShownAsLabel = true;
                    
                    // Màu sắc cho từng vai trò - đảm bảo đồng nhất
                    var roleColors = new Dictionary<string, Color>
                    {
                        { "SA", Color.FromArgb(231, 76, 60) },    // Đỏ
                        { "CM", Color.FromArgb(230, 126, 34) },   // Cam  
                        { "CSS", Color.FromArgb(241, 196, 15) },  // Vàng
                        { "ERS", Color.FromArgb(46, 204, 113) },  // Xanh lá
                        { "FO", Color.FromArgb(52, 152, 219) },   // Xanh dương
                        { "SSS", Color.FromArgb(155, 89, 182) }  // Tím
                    };
                    series.Palette = ChartColorPalette.None;
                    
                    // Thêm dữ liệu vào chart
                    foreach (var role in roleCounts.OrderByDescending(x => x.Value))
                    {
                        if (role.Value > 0)
                        {
                            var dataPoint = new DataPoint();
                            dataPoint.SetValueXY(role.Key, role.Value);
                            dataPoint.Color = roleColors.ContainsKey(role.Key) ? roleColors[role.Key] : Color.Gray;
                            
                            // Tính phần trăm
                            double percentage = (double)role.Value / totalEmployees * 100;
                            dataPoint.Label = $"{role.Key}: {role.Value} ({percentage:F1}%)";
                            
                            series.Points.Add(dataPoint);
                        }
                    }
                    chartPhanBoVaiTro.Series.Add(series);
                    chartPhanBoVaiTro.ChartAreas[0].Area3DStyle.Enable3D = false;
                    
                    chartPhanBoVaiTro.Titles.Clear();
                    var title = new Title("Phân bổ vai trò nhân viên");
                    title.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                    title.ForeColor = Color.Black;
                    title.Alignment = ContentAlignment.TopCenter;
                    chartPhanBoVaiTro.Titles.Add(title);
                    
                    chartPhanBoVaiTro.ChartAreas[0].Position.X = 0; // Vị trí X
                    chartPhanBoVaiTro.ChartAreas[0].Position.Y = 0; // Vị trí Y  
                    chartPhanBoVaiTro.ChartAreas[0].Position.Width = 60; // Chiều rộng (%) - để chỗ cho legend
                    chartPhanBoVaiTro.ChartAreas[0].Position.Height = 100; // Chiều cao (%)
                    
                    // Dock fill để chart chiếm toàn bộ panel
                    chartPhanBoVaiTro.Dock = DockStyle.Fill;
                    
                    // Đặt màu nền transparent cho chart
                    chartPhanBoVaiTro.BackColor = Color.Transparent;
                    chartPhanBoVaiTro.ChartAreas[0].BackColor = Color.Transparent;
                    
                    // Tăng kích thước font cho label
                    series.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    
                    try
                    {
                        chartPhanBoVaiTro.Legends.Clear();
                        var legend = new Legend("Legend1");
                        legend.Docking = Docking.Right;
                        legend.Alignment = StringAlignment.Center;
                        legend.BackColor = Color.Transparent;
                        legend.ForeColor = Color.Black;
                        legend.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                        chartPhanBoVaiTro.Legends.Add(legend);
                    }
                    catch
                    {
                        // Bỏ qua nếu không có reference
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo chart phân bổ vai trò: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

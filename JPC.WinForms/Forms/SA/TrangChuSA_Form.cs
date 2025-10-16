using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.Login;
using Guna.UI2.WinForms;
using Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.DoiMatKhau;
using JPC.WinForms;

namespace Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.SA
{
    public partial class TrangChuSA_Form : Form
    {
        private bool isLoggingOut = false;
        private Guna2Button activeButton = null;

        public TrangChuSA_Form()
        {
            InitializeComponent();
            // Tối ưu render để chuyển form mượt hơn
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();

            // DoubleBuffer cho panel content
            try
            {
                typeof(Panel).InvokeMember("DoubleBuffered",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty,
                    null, panelContent, new object[] { true });
            }
            catch { }

            // Gắn mã chức năng cho các nút (Tag)
            btnQLDanhMucNgheNghiep.Tag = "CN_SA01";  // Quản lý danh mục nghề nghiệp
            btnQLTaiKhoanNhanVien.Tag = "CN_SA02";   // Quản lý tài khoản nhân viên
            btnQLQuyenHan.Tag = "CN_SA03";           // Quản lý quyền hạn chức năng
            btnDoiMatKhau.Tag = "CN_DMK";            // Đổi mật khẩu
        }

        private void LoadFormIntoPanel(Form form)
        {
            panelContent.SuspendLayout();

            // Hủy và gỡ toàn bộ form/controls cũ
            foreach (Control c in panelContent.Controls)
            {
                c.Dispose();
            }
            panelContent.Controls.Clear();

            // Thêm form mới vào panel
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelContent.Controls.Add(form);
            form.Show();

            panelContent.ResumeLayout(true);
        }

        private void ShowControl(UserControl control)
        {
            if (control == null) return;
            control.Dock = DockStyle.Fill;
            panelContent.SuspendLayout();
            try
            {
                panelContent.Controls.Clear();
                panelContent.Controls.Add(control);
            }
            finally
            {
                panelContent.ResumeLayout();
            }
        }

        private void SetActiveButton(Guna2Button button)
        {
            // Reset button cũ về trạng thái bình thường
            if (activeButton != null)
            {
                activeButton.FillColor = Color.Transparent; // Background trong suốt
                activeButton.ForeColor = Color.White; // Chữ trắng
            }

            // Set button mới thành active
            activeButton = button;
            activeButton.FillColor = Color.FromArgb(52, 152, 219); // Background blue
            activeButton.ForeColor = Color.White; // Chữ trắng
        }

        private void TrangChuSA_Form_Load(object sender, EventArgs e)
        {
            btnTrangChu_Click(btnTrangChu, null);
        }

        private void TrangChuSA_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !isLoggingOut)
            {
                // Chỉ hỏi khi đóng bằng nút X
                var result = MessageBox.Show(
                "Bạn có muốn thoát ứng dụng?",
                "Thoát ứng dụng",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
                );

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    Application.Exit();
                }
            }
            // Nếu isLoggingOut = true, không làm gì cả
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            SetActiveButton(sender as Guna2Button);
            LoadFormIntoPanel(new Welcome_Form());
        }

        private void btnQLDanhMucNgheNghiep_Click(object sender, EventArgs e)
        {
            var code = (sender as Control)?.Tag?.ToString();
            if (!string.IsNullOrWhiteSpace(code) && !PermissionGuard.EnsureEnabled(code)) return;
            SetActiveButton(sender as Guna2Button); // Set active
            LoadFormIntoPanel(new QLDanhMucNgheNghiep_Form());
        }

        private void btnQLTaiKhoanNhanVien_Click(object sender, EventArgs e)
        {
            var code = (sender as Control)?.Tag?.ToString();
            if (!string.IsNullOrWhiteSpace(code) && !PermissionGuard.EnsureEnabled(code)) return;
            SetActiveButton(sender as Guna2Button); // Set active
            LoadFormIntoPanel(new QLTaiKhoanNhanVien_Form());
        }

        private void btnQLQuyenHan_Click(object sender, EventArgs e)
        {
            var code = (sender as Control)?.Tag?.ToString();
            if (!string.IsNullOrWhiteSpace(code) && !PermissionGuard.EnsureEnabled(code)) return;
            SetActiveButton(sender as Guna2Button); // Set active
            LoadFormIntoPanel(new QLQuyenHan_Form());
        }

        public void LoadControlIntoPanel(UserControl uc)
        {
            if (uc == null) return;

            panelContent.SuspendLayout();
            try
            {
                foreach (Control c in panelContent.Controls) c.Dispose();
                panelContent.Controls.Clear();

                uc.Dock = DockStyle.Fill;
                panelContent.Controls.Add(uc);
                uc.BringToFront();
            }
            finally
            {
                panelContent.ResumeLayout(true);
            }
        }

        public void LoadControlIntoPanelWithBack(UserControl uc, string title)
        {
            if (uc == null) return;

            var header = new Panel
            {
                Dock = DockStyle.Top,
                Height = 44,
                BackColor = Color.WhiteSmoke
            };

            var btnBack = new Button
            {
                Text = "← Quay lại",
                AutoSize = true,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                ForeColor = Color.Black,
                Padding = new Padding(6, 4, 6, 4),
                Location = new Point(10, 8)
            };
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.Click += (s, e) =>
            {
                // Quay về form tra cứu
                LoadFormIntoPanel(new TraCuuDuLieu_Form(this));
            };

            var lblTitle = new Label
            {
                Text = string.IsNullOrWhiteSpace(title) ? "Tra cứu" : title,
                AutoSize = true,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.Black
            };
            // canh giữa theo chiều ngang
            header.Controls.Add(btnBack);
            header.Controls.Add(lblTitle);
            header.Resize += (s, e) =>
            {
                lblTitle.Left = (header.Width - lblTitle.Width) / 2;
                lblTitle.Top = (header.Height - lblTitle.Height) / 2;
            };

            var container = new Panel { Dock = DockStyle.Fill, BackColor = Color.White };
            uc.Dock = DockStyle.Fill;
            container.Controls.Add(uc);

            panelContent.SuspendLayout();
            try
            {
                foreach (Control c in panelContent.Controls) c.Dispose();
                panelContent.Controls.Clear();

                panelContent.Controls.Add(container);
                panelContent.Controls.Add(header);
            }
            finally
            {
                panelContent.ResumeLayout(true);
            }
        }

        private void btnTraCuuDuLieu_Click(object sender, EventArgs e)
        {
            SetActiveButton(sender as Guna.UI2.WinForms.Guna2Button);
            LoadFormIntoPanel(new TraCuuDuLieu_Form(this));
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            var code = (sender as Control)?.Tag?.ToString();
            if (!string.IsNullOrWhiteSpace(code) && !PermissionGuard.EnsureEnabled(code)) return;
            SetActiveButton(sender as Guna2Button); // Set active
            ShowControl(new DoiMatKhau_UC());
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Hỏi xác nhận trước khi đăng xuất
            var result = MessageBox.Show(
                "Bạn có muốn đăng xuất không?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
                return; // Hủy đăng xuất
            }

            isLoggingOut = true;
            JPC.Models.UserSession.Clear(); // Xóa session khi đăng xuất

            Login_Form loginForm = new Login_Form();

            // Set event để khi Login form đóng thì mới exit app
            loginForm.FormClosed += (s, args) => {
                if (!Equals(loginForm.Tag, "LoginSuccess"))
                {
                    Application.Exit();
                }
            };

            loginForm.Show();
            this.Hide();
        }

        private void TrangChuSA_Form_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                guna2Elipse1.BorderRadius = 0;
            }
            else
            {
                guna2Elipse1.BorderRadius = 20;
            }
        }
    }
}

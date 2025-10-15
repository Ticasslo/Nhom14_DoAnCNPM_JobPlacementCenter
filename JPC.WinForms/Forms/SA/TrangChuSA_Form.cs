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

namespace Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.SA
{
    public partial class TrangChuSA_Form : Form
    {
        private bool isLoggingOut = false;
        private Guna2Button activeButton = null;
        // Bỏ cache form để luôn tạo mới mỗi lần chuyển chức năng

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

            // Bỏ pre-warm: luôn tạo mới form khi chuyển chức năng
            // (để tránh giữ trạng thái cũ giữa các lần mở)
        }

        // Đã bỏ prewarm để luôn tạo mới form khi cần

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
            SetActiveButton(sender as Guna2Button); // Set active
            LoadFormIntoPanel(new QLDanhMucNgheNghiep_Form());
        }

        private void btnQLTaiKhoanNhanVien_Click(object sender, EventArgs e)
        {
            SetActiveButton(sender as Guna2Button); // Set active
            LoadFormIntoPanel(new QLTaiKhoanNhanVien_Form());
        }

        private void btnQLQuyenHan_Click(object sender, EventArgs e)
        {
            SetActiveButton(sender as Guna2Button); // Set active
            LoadFormIntoPanel(new QLQuyenHan_Form());
        }

        private void btnTraCuuDuLieu_Click(object sender, EventArgs e)
        {
            SetActiveButton(sender as Guna2Button); // Set active
            LoadFormIntoPanel(new TraCuuDuLieu_Form());
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
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

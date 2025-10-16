using JPC.Business;
using JPC.WinForms;
using Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.DoiMatKhau;
using Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.ERS
{
    public partial class TrangChuERS_Form : Form
    {
        private UserControl currentUC = null;
        public TrangChuERS_Form()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;

            this.Resize += TrangChuERS_Form_Resize; // <--- gắn sự kiện

            guna2Button1.Tag = "CN_ERS01"; // Đăng kí hồ sơ doanh nghiệp
            guna2Button2.Tag = "CN_ERS02"; // Chỉnh sửa hồ sơ doanh nghiệp
            guna2Button3.Tag = "CN_ERS03"; // Đăng tin tuyển dụng
            guna2Button4.Tag = "CN_ERS04"; // Danh sách ứng viên
            guna2Button5.Tag = "CN_ERS05"; // Cập nhật kết quả
            guna2Button6.Tag = "CN_DMK"; // Đổi mật khẩu
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void TrangChuERS_Form_Resize(object sender, EventArgs e)
        {
            int centerX = panel1.Width / 2;

            label1.Left = centerX - (label1.Width / 2);
            lbWelcome.Left = centerX - (lbWelcome.Width / 2);

            int spacing = 25;

            // Căn giữa theo chiều dọc cho nhóm nút trong panelDanhMucLớn
            int totalButtonsHeight = guna2Button1.Height * 6 + spacing * 5; // 10 là khoảng cách giữa các nút
            int startY = (guna2Panel1.Height - totalButtonsHeight) / 2 + guna2Panel2.Height - 50;


            Guna.UI2.WinForms.Guna2Button[] buttons =
            { guna2Button1, guna2Button2, guna2Button3, guna2Button4, guna2Button5, guna2Button6, btnLogout };

            foreach (var btn in buttons)
            {
                btn.Size = new Size(240, 60);   // 👈 tăng kích thước
                btn.Font = new Font("Segoe UI", 11, FontStyle.Bold); // 👈 chữ rõ nét hơn
                btn.BorderRadius = 25;          // 👈 bo tròn mềm hơn
            }

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Top = startY + i * (buttons[i].Height + spacing);
                buttons[i].Left = (guna2Panel1.Width - buttons[i].Width) / 2; // căn giữa ngang
            }
        }

        private void dangKyHoSo_UC_Form1_Load(object sender, EventArgs e)
        {

        }
        public void LoadUserControl(UserControl uc)
        {
            if (currentUC != null)
            {
                panelMain.Controls.Remove(currentUC);
                currentUC.Dispose();
            }

            currentUC = uc;
            uc.Dock = DockStyle.Fill;  // 👈 Dòng này BẮT BUỘC có
            panelMain.Controls.Add(uc);
            uc.BringToFront();
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (!PermissionGuard.EnsureEnabled((string)guna2Button1.Tag)) return;
            var service = ServiceFactory.CreateDoanhNghiepService();
            LoadUserControl(new DangKyHoSo_UC_Form(service));
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (!PermissionGuard.EnsureEnabled((string)guna2Button2.Tag)) return;
            var service = ServiceFactory.CreateDoanhNghiepService();
            LoadUserControl(new ChinhSuaHoSo_UC_Form(service));
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (!PermissionGuard.EnsureEnabled((string)guna2Button3.Tag)) return;
            LoadUserControl(new SelectDoanhNghiep_UC_Form());
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (!PermissionGuard.EnsureEnabled((string)guna2Button4.Tag)) return;
            LoadUserControl(new SelectDoanhNghiep1_UC_Form());
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (!PermissionGuard.EnsureEnabled((string)guna2Button5.Tag)) return;
            LoadUserControl(new CapNhatKetQua_UC_Form());
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (!PermissionGuard.EnsureEnabled((string)guna2Button6.Tag)) return;
            LoadUserControl(new DoiMatKhau_UC());
        }

        private void btnLogout_Click(object sender, EventArgs e)
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
    }
}
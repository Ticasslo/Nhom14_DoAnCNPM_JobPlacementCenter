using JPC.Business.Services.Interfaces.Login;
using JPC.Business.Services.Implementations.Login;
using JPC.Models.QuanTri;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JPC.Business.Exceptions;
using JPC.Models;
using Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.SA;
using Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.CSS;
using Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.CM;
using Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.FO;

namespace Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.Login
{
    public partial class Login_Form : Form
    {
        public static bool IsAppExiting { get; set; } = false;
        private bool isShowPassword = false;
        public Login_Form()
        {
            InitializeComponent();
           // this.ClientSize = new Size(340, 530);
            this.AcceptButton = btnLogin;
        }

        private void Login_Form_Load(object sender, EventArgs e)
        {
            txtUsername.Text = "username";
            txtUsername.ForeColor = Color.Gray;
            txtPassword.Text = "password";
            txtPassword.ForeColor = Color.Gray;

            picBoxHide.Visible = true;
            picBoxShow.Visible = false;
            txtPassword.PasswordChar = '*';

            radioBtnCSS.Checked = true;
            this.ActiveControl = txtUsername;
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text.Equals("username") && txtUsername.ForeColor == Color.Gray)
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = Color.Black;
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                txtUsername.ForeColor = Color.Gray;
                txtUsername.Text = "username";
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text.Equals("password") && txtPassword.ForeColor == Color.Gray)
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
                if (isShowPassword)
                    txtPassword.PasswordChar = '\0'; // Hiện lại mật khẩu
                else
                    txtPassword.PasswordChar = '*';
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.ForeColor = Color.Gray;
                txtPassword.Text = "password";
                if (isShowPassword)
                    txtPassword.PasswordChar = '\0'; // Hiện lại mật khẩu
                else
                    txtPassword.PasswordChar = '*'; // Ẩn mật khẩu
            }
        }

        private void picBoxShow_Click(object sender, EventArgs e)
        {
            picBoxShow.Visible = false;
            picBoxHide.Visible = true;

            txtPassword.PasswordChar = '*'; // Ẩn mật khẩu
            isShowPassword = false;
        }

        private void picBoxHide_Click(object sender, EventArgs e)
        {
            picBoxHide.Visible = false;
            picBoxShow.Visible = true;

            txtPassword.PasswordChar = '\0'; // Hiện lại mật khẩu
            isShowPassword = true;
        }



        private void Login_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!IsAppExiting && e.CloseReason == CloseReason.UserClosing)
            {
                var result = MessageBox.Show("Bạn có muốn thoát chương trình không?", "Thoát",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No) 
                {
                    e.Cancel = true;
                }
                else
                {
                    IsAppExiting = true;
                    Application.Exit(); // Đảm bảo thoát hoàn toàn
                }
            }
            else if (IsAppExiting)
            {
                Application.Exit(); // Đảm bảo thoát hoàn toàn
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUsername.Text) || txtUsername.ForeColor == Color.Gray)
                {
                    MessageBox.Show("Vui lòng nhập tên đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsername.Focus();
                    return;
                }


                if (string.IsNullOrWhiteSpace(txtPassword.Text) || txtPassword.ForeColor == Color.Gray)
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                    return;
                }

                string expectedVaiTroId = null;
                if (radioBtnCSS.Checked) expectedVaiTroId = "CSS";
                else if (radioBtnERS.Checked) expectedVaiTroId = "ERS";
                else if (radioBtnFO.Checked) expectedVaiTroId = "FO";
                else if (radioBtnCM.Checked) expectedVaiTroId = "CM";
                else if (radioBtnSA.Checked) expectedVaiTroId = "SA";

                IDangNhapService authService = new DangNhapService();
                var nv = authService.DangNhap(txtUsername.Text.Trim(), txtPassword.Text, expectedVaiTroId);
                if (nv == null)
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng, hoặc tài khoản không hoạt động.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show($"Đăng nhập thành công! Xin chào {nv.HoTen} (vai trò: {nv.VaiTroId})", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Lưu session
                UserSession.Username = nv.Username;
                UserSession.NhanVien = nv;

                // Điều hướng theo vai trò
                if (string.Equals(nv.VaiTroId, "SA", StringComparison.OrdinalIgnoreCase))
                {
                    this.Hide();
                    var main = new TrangChuSA_Form();
                    main.FormClosed += (s, args) =>
                    {
                        // Nếu main đóng vì ĐĂNG XUẤT, CounselorMainForm sẽ đặt Tag = "Logout"
                        if (Equals(main.Tag, "Logout"))
                        {
                            this.Show();
                            Login_Form_Load(sender, e);
                        }
                        else
                        {
                            IsAppExiting = true;
                            this.Close();
                        }
                    };

                    main.Show();
                }
                else if (string.Equals(nv.VaiTroId, "CSS", StringComparison.OrdinalIgnoreCase))
                {
                    this.Hide();
                    var main = new TrangChuCSS_Form();
                    main.FormClosed += (s, args) =>
                    {
                        // Nếu main đóng vì ĐĂNG XUẤT, CounselorMainForm sẽ đặt Tag = "Logout"
                        if (Equals(main.Tag, "Logout"))
                        {
                            this.Show();
                            Login_Form_Load(sender, e);
                        }
                        else
                            this.Close();
                    };

                    main.Show();
                }
                else if (string.Equals(nv.VaiTroId, "ERS", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Màn hình chính cho vai trò ERS đang được phát triển", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (string.Equals(nv.VaiTroId, "FO", StringComparison.OrdinalIgnoreCase))
                {
                    this.Hide();
                    var mainfo = new TrangChuFO_Form();
                    mainfo.FormClosed += (s, args) =>
                    {
                        // Nếu main đóng vì ĐĂNG XUẤT, CounselorMainForm sẽ đặt Tag = "Logout"
                        if (Equals(mainfo.Tag, "Logout"))
                        {
                            this.Show();
                            Login_Form_Load(sender, e);
                        }
                        else
                        {
                            IsAppExiting = true;
                            this.Close();
                        }
                    };

                    mainfo.Show();
                }
                else if (string.Equals(nv.VaiTroId, "CM", StringComparison.OrdinalIgnoreCase))
                {
                    this.Hide();

                    var main = new TrangChuCM_Form();
                    main.FormClosed += (s, args) =>
                    {
                        // Nếu main đóng do ĐĂNG XUẤT, form chính sẽ đặt Tag = "Logout"
                        if (Equals(main.Tag, "Logout"))
                        {
                            this.Show();
                            Login_Form_Load(sender, e);   // reset UI đăng nhập (placeholder, clear text,…)
                        }
                        else
                        {
                            IsAppExiting = true;          // đánh dấu thoát hẳn app
                            this.Close();
                        }
                    };

                    main.Show();
                }
                else
                {
                    MessageBox.Show("Vai trò không hợp lệ hoặc chưa được hỗ trợ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (BusinessException dae)
            {
                MessageBox.Show(dae.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

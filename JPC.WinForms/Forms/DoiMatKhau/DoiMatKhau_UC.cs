using JPC.Business.Services.Implementations.DoiMatKhau;
using JPC.Business.Services.Interfaces.DoiMatKhau;
using JPC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.DoiMatKhau
{
    public partial class DoiMatKhau_UC : UserControl
    {
        private readonly IDoiMatKhauService doiMatKhauService;
        private readonly string currentUsername;
        public DoiMatKhau_UC()
        {
            InitializeComponent();
            this.doiMatKhauService = new DoiMatKhauService();
            this.currentUsername = UserSession.Username;
            _debounce.Tick += (s, e) => { _debounce.Stop(); UpdateStrengthFromDb(); };
            txtNewPass.TextChanged += (s, e) => { _debounce.Stop(); _debounce.Start(); };
        }

        private void btnLuuThayDoi_Click(object sender, EventArgs e)
        {
            try
            {
                string oldPass = txtOldPass.Text?.Trim();
                string newPass = txtNewPass.Text?.Trim();
                string confirm = txtConfirm.Text?.Trim();

                if (string.IsNullOrWhiteSpace(oldPass) || string.IsNullOrWhiteSpace(newPass) || string.IsNullOrWhiteSpace(confirm))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!string.Equals(newPass, confirm))
                {
                    MessageBox.Show("Vui lòng nhập lại chính xác mật khẩu mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(currentUsername))
                {
                    MessageBox.Show("Không xác định được người dùng hiện tại. Vui lòng đăng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool ok = doiMatKhauService.DoiMatKhau(currentUsername, oldPass, newPass);
                if (!ok)
                {
                    MessageBox.Show("Không thể đổi mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetForm();
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                if (msg.IndexOf("Mật khẩu cũ không chính xác", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    MessageBox.Show("Mật khẩu cũ không chính xác. Vui lòng thử lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (msg.IndexOf("Vui lòng nhập đầy đủ thông tin", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                MessageBox.Show("Không thể đổi mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            void ResetForm()
            {
                txtOldPass.Text = "";
                txtNewPass.Text = "";
                txtConfirm.Text = "";
            }
        }

    }
}

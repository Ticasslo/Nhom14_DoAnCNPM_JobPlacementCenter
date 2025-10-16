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

namespace Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.CSS
{
    public partial class TrangChuCSS_Form : Form
    {
        bool isExit = true;
        public TrangChuCSS_Form()
        {
            InitializeComponent();
            ShowControl(new DKHoSoUngVien_UC());

            btnLoadTao.Tag = "CN_CSS01";         // Đăng kí hồ sơ ứng viên mới
            btnLoadChinhSua.Tag = "CN_CSS02";    // Chỉnh sửa thông tin ứng viên
            btnLoadGhiNhanUT.Tag = "CN_CSS03";   // Ghi nhận ứng tuyển
            btnLoadDoiMK.Tag = "CN_DMK";       // Đổi mật khẩu
        }

        private void ShowControl(UserControl control)
        {
            if (control == null) return;
            control.Dock = DockStyle.Fill;
            panelUserControl.SuspendLayout();
            try
            {
                panelUserControl.Controls.Clear();
                panelUserControl.Controls.Add(control);
            }
            finally
            {
                panelUserControl.ResumeLayout();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void picBoxBack_Click(object sender, EventArgs e)
        {
            isExit = false;
            JPC.Models.UserSession.Clear();
            this.Tag = "Logout";
            this.Close();
        }

        private void TrangChuCSS_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isExit) return;

            if (e.CloseReason == CloseReason.UserClosing)
            {
                var result = MessageBox.Show("Bạn có muốn thoát ứng dụng?", "Thoát ứng dụng",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
                Login_Form.IsAppExiting = true;
                Application.Exit();
            }
        }

        private void btnLoadTao_Click(object sender, EventArgs e)
        {
            if (!PermissionGuard.EnsureEnabled((string)btnLoadTao.Tag)) return;
            ShowControl(new DKHoSoUngVien_UC());
        }

        private void btnLoadChinhSua_Click(object sender, EventArgs e)
        {
            if (!PermissionGuard.EnsureEnabled((string)btnLoadChinhSua.Tag)) return;
            ShowControl(new ChinhSuaThongTinUngVien_UC());
        }

        private void btnLoadGhiNhanUT_Click(object sender, EventArgs e)
        {
            if (!PermissionGuard.EnsureEnabled((string)btnLoadGhiNhanUT.Tag)) return;
            ShowControl(new GhiNhanUngTuyen_UC());
        }

        private void btnLoadDoiMK_Click(object sender, EventArgs e)
        {
            if (!PermissionGuard.EnsureEnabled((string)btnLoadDoiMK.Tag)) return;
            ShowControl(new DoiMatKhau_UC());
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            isExit = false;
            JPC.Models.UserSession.Clear();
            this.Tag = "Logout";
            this.Close();
        }
    }
}

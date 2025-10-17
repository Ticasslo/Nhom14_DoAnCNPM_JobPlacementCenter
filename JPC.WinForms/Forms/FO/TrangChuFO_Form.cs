using JPC.WinForms;
using Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.DoiMatKhau;
using Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using TheArtOfDevHtmlRenderer.Adapters.Entities;

namespace Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.FO
{
    public partial class TrangChuFO_Form : Form
    {
        private int boderSize = 2;
        private Size formSize;

        public TrangChuFO_Form()
        {
            InitializeComponent();
            //CollapseMenu();
            this.Padding = new Padding(boderSize);//Border size
            this.BackColor = Color.FromArgb(50, 77, 168);//Border color

            iconBtnThuPhiUngVien.AccessibleDescription = "CN_FO01";       // Thu phí ứng tuyển
            iconBtnThuPhiDoanhNghiep.AccessibleDescription = "CN_FO02";   // Thu phí doanh nghiệp
            iconBtnDanhSachHoaDon.AccessibleDescription = "CN_FO03";      // Danh sách hoá đơn
            iconBtnBaoCaoDoanhThuThang.AccessibleDescription = "CN_FO04"; // Báo cáo doanh thu tháng
            iconBtnDoiMatKhau.AccessibleDescription = "CN_DMK";          // Đổi mật khẩu
        }
        private void TrangChuFO_Form_Load(object sender, EventArgs e)
        {
            formSize = this.ClientSize;
        }

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        //Overiden methods
        protected override void WndProc(ref Message m)
        {
            const int WM_NCCALCSIZE = 0x0083;//Standar Title Bar - Snap Window
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MINIMIZE = 0xF020; //Minimize form (Before)
            const int SC_RESTORE = 0xF120; //Restore form (Before)Window resizing software
            const int WM_NCHITTEST = 0x0084;//Win32, Mouse Input Notification: Determine what part of the window corresponds to a point, allows to resize the form.
            const int resizeAreaSize = 10;
            #region Form Resize
            // Resize/WM_NCHITTEST values
            const int HTCLIENT = 1; //Represents the client area of the window
            const int HTLEFT = 10;  //Left border of a window, allows resize horizontally to the left
            const int HTRIGHT = 11; //Right border of a window, allows resize horizontally to the right
            const int HTTOP = 12;   //Upper-horizontal border of a window, allows resize vertically up
            const int HTTOPLEFT = 13;//Upper-left corner of a window border, allows resize diagonally to the left
            const int HTTOPRIGHT = 14;//Upper-right corner of a window border, allows resize diagonally to the right
            const int HTBOTTOM = 15; //Lower-horizontal border of a window, allows resize vertically down
            const int HTBOTTOMLEFT = 16;//Lower-left corner of a window border, allows resize diagonally to the left
            const int HTBOTTOMRIGHT = 17;//Lower-right corner of a window border, allows resize diagonally to the right
            ///<Doc> More Information: https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-nchittest </Doc>
            if (m.Msg == WM_NCHITTEST)
            { //If the windows m is WM_NCHITTEST
                base.WndProc(ref m);
                if (this.WindowState == FormWindowState.Normal)//Resize the form if it is in normal state
                {
                    if ((int)m.Result == HTCLIENT)//If the result of the m (mouse pointer) is in the client area of the window
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32()); //Gets screen point coordinates(X and Y coordinate of the pointer)                           
                        Point clientPoint = this.PointToClient(screenPoint); //Computes the location of the screen point into client coordinates                          
                        if (clientPoint.Y <= resizeAreaSize)//If the pointer is at the top of the form (within the resize area- X coordinate)
                        {
                            if (clientPoint.X <= resizeAreaSize) //If the pointer is at the coordinate X=0 or less than the resizing area(X=10) in 
                                m.Result = (IntPtr)HTTOPLEFT; //Resize diagonally to the left
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize))//If the pointer is at the coordinate X=11 or less than the width of the form(X=Form.Width-resizeArea)
                                m.Result = (IntPtr)HTTOP; //Resize vertically up
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTTOPRIGHT;
                        }
                        else if (clientPoint.Y <= (this.Size.Height - resizeAreaSize)) //If the pointer is inside the form at the Y coordinate(discounting the resize area size)
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize horizontally to the left
                                m.Result = (IntPtr)HTLEFT;
                            else if (clientPoint.X > (this.Width - resizeAreaSize))//Resize horizontally to the right
                                m.Result = (IntPtr)HTRIGHT;
                        }
                        else
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize diagonally to the left
                                m.Result = (IntPtr)HTBOTTOMLEFT;
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize)) //Resize vertically down
                                m.Result = (IntPtr)HTBOTTOM;
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTBOTTOMRIGHT;
                        }
                    }
                }
                return;
            }
            #endregion

            if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
            {
                return;
            }
            // Keep form size when it is minimized and restored.Since the form is resized because it takes into account the size of the title bar and borders.
            if (m.Msg == WM_SYSCOMMAND)
            {
                /// <see cref="https://docs.microsoft.com/en-us/windows/win32/menurc/wm-syscommand"/>
                /// Quote:
                /// In WM_SYSCOMMAND messages, the four low - order bits of the wParam parameter 
                /// are used internally by the system.To obtain the correct result when testing 
                /// the value of wParam, an application must combine the value 0xFFF0 with the 
                /// wParam value by using the bitwise AND operator.
                int wParam = (m.WParam.ToInt32() & 0xFFF0);
                if (wParam == SC_MINIMIZE)  //Before
                    formSize = this.ClientSize;
                if (wParam == SC_RESTORE)// Restored form(Before)
                    this.Size = formSize;
            }
            base.WndProc(ref m);
        }
        

        //Private methods
        private void AdjustForm()
        {
            switch (this.WindowState)
            {
                case FormWindowState.Minimized:
                    this.Padding = new Padding(0,8,8,0);
                    break;
                case FormWindowState.Normal:
                    if (this.Padding.Top != boderSize)
                        this.Padding = new Padding(boderSize);//Border size
                    break;

            }
        }
        private void TrangChuFO_Form_Resize(object sender, EventArgs e)
        {
            AdjustForm();
        }

        private void iconBtnMinimize_Click(object sender, EventArgs e)
        {
            formSize = this.ClientSize;
            this.WindowState = FormWindowState.Minimized;
        }
        private void iconBtnExit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Bạn có muốn thoát ứng dụng?",
                "Thoát ứng dụng",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void iconBtnManimize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                formSize = this.ClientSize;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.Size = formSize;
            }
        }

        private void iconBtnBar_Click(object sender, EventArgs e)
        {
            CollapseMenu();
        }
        
        private void CollapseMenu()
        {
            if (this.panelMenu.Width > 200) //Collapse menu
            {
                panelMenu.Width = 80;
                lblFOName.Visible = false;
                iconBtnBar.Padding = new Padding(0, 10, 0, 0);
                iconBtnBar.Dock = DockStyle.Top;
                foreach (System.Windows.Forms.Button menuButton in panelMenu.Controls.OfType<System.Windows.Forms.Button>())
                {
                    menuButton.Text = "";
                    menuButton.ImageAlign = ContentAlignment.MiddleCenter;
                    menuButton.Padding = new Padding(0);
                }
            }
            else //Expand menu
            {
                panelMenu.Width = 282;
                lblFOName.Visible = true;
                iconBtnBar.Dock = DockStyle.None;
                foreach (System.Windows.Forms.Button menuButton in panelMenu.Controls.OfType<System.Windows.Forms.Button>())
                {
                    menuButton.Text = " " + menuButton.Tag.ToString();
                    menuButton.TextImageRelation = TextImageRelation.ImageBeforeText;
                    menuButton.ImageAlign = ContentAlignment.MiddleLeft;
                    menuButton.ImageAlign = ContentAlignment.MiddleLeft;
                    menuButton.Padding = new Padding(10, 0, 0, 0);
                }
            }
        }

        private void ShowControl(UserControl uc)
        {
            // dọn panel trước khi nạp UC mới
            panelDesktop.SuspendLayout();
            panelDesktop.Controls.Clear();

            // cấu hình UC để chiếm toàn vùng panel
            uc.Dock = DockStyle.Fill;

            // nạp vào panel
            panelDesktop.Controls.Add(uc);
            uc.BringToFront();

            panelDesktop.ResumeLayout();
        }
        private void iconBtnThuPhiUngVien_Click(object sender, EventArgs e)
        {
            if (!PermissionGuard.EnsureEnabled(iconBtnThuPhiUngVien.AccessibleDescription)) return;
            ShowControl(new ThuPhiUngVien_UC());
        }

        private void iconBtnThuPhiDoanhNghiep_Click(object sender, EventArgs e)
        {
            if (!PermissionGuard.EnsureEnabled(iconBtnThuPhiDoanhNghiep.AccessibleDescription)) return;
            ShowControl(new ThuPhiDoanhNghiep_UC());
        }

        private void iconBtnDanhSachHoaDon_Click(object sender, EventArgs e)
        {
            if (!PermissionGuard.EnsureEnabled(iconBtnDanhSachHoaDon.AccessibleDescription)) return;
            ShowControl(new DanhSachHoaDon_UC());
        }

        private void iconBtnBaoCaoDoanhThuThang_Click(object sender, EventArgs e)
        {
            if (!PermissionGuard.EnsureEnabled(iconBtnBaoCaoDoanhThuThang.AccessibleDescription)) return;
            ShowControl(new BaoCaoDoanhThuThang_UC());
        }

        private void iconBtnDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (!PermissionGuard.EnsureEnabled(iconBtnDoiMatKhau.AccessibleDescription)) return;
            ShowControl(new DoiMatKhau_UC());
        }

        private void iconBtnLogOut_Click(object sender, EventArgs e)
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

using JPC.WinForms;
using Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.DoiMatKhau;
using Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.Login;
using Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.SA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.CM
{
    public partial class TrangChuCM_Form : Form
    {
        public TrangChuCM_Form()
        {
            InitializeComponent();
            pnlChinh.Controls.Clear();
            pnlChinh.Controls.Add(new ThongKeSoLuongUngVien_UC());

            btnThongKeSoLuongUV.Tag = "CN_CM01";      // Thống kê số lượng ứng viên
            btnThongKeTyLeKetNoi.Tag = "CN_CM02";     // Thống kê tỷ lệ ứng tuyển thành công
            btnDieuChinhGia.Tag = "CN_CM03";          // Điều chỉnh giá dịch vụ
            btnDoiMatKhau.Tag = "CN_DMK";            // Đổi mật khẩu
        }
        bool isSidebarExpanded = false;
        private void timerMenu_Tick(object sender, EventArgs e)
        {
            if (isSidebarExpanded)
            {
                pnlMenudoc.Width -= 38;
                if (pnlMenudoc.Width <= 77)
                {
                    timerMenu.Stop();
                    isSidebarExpanded = false;
                }
            }
            else
            {
                pnlMenudoc.Width += 38;
                if (pnlMenudoc.Width >= 340)
                {
                    timerMenu.Stop();
                    isSidebarExpanded = true;
                    // Optionally: show label/text/icon
                }
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            timerMenu.Start();
        }

        private void btnDieuChinhGia_Click(object sender, EventArgs e)
        {
            if (!PermissionGuard.EnsureEnabled((string)btnDieuChinhGia.Tag)) return;
            pnlChinh.Controls.Clear();
            pnlChinh.Controls.Add(new DieuChinhGiaDV_UC());
            pnlChinh.Show();

        }

        private void btnThongKeSoLuongUV_Click(object sender, EventArgs e)
        {
            if (!PermissionGuard.EnsureEnabled((string)btnThongKeSoLuongUV.Tag)) return;
            pnlChinh.Controls.Clear();
            pnlChinh.Controls.Add(new ThongKeSoLuongUngVien_UC());
            pnlChinh.Show();
        }

        private void btnThongKeTyLeKetNoi_Click(object sender, EventArgs e)
        {
            if (!PermissionGuard.EnsureEnabled((string)btnThongKeTyLeKetNoi.Tag)) return;
            pnlChinh.Controls.Clear();
            pnlChinh.Controls.Add(new ThongKeTyLeKetNoi_UC());
            pnlChinh.Show();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (!PermissionGuard.EnsureEnabled((string)btnDoiMatKhau.Tag)) return;
            pnlChinh.Controls.Clear();
            pnlChinh.Controls.Add(new DoiMatKhau_UC());
            pnlChinh.Show();

        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            //hoi nguoi dung co muon dang xuat khong
            var result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                var main = new Login_Form();
                main.FormClosed += (s, args) => this.Close();
                main.Show();
            }
            else
            {
                //khong lam gi ca
            }
        }
    }
}

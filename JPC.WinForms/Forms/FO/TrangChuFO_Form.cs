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

namespace Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.FO
{
    public partial class TrangChuFO_Form : Form
    {
        bool isSidebarExpanded = false;
        public TrangChuFO_Form()
        {
            InitializeComponent();

            btnThuPhiUngVien.Tag = "CN_FO01";
            btnThuPhiDoanhNghiep.Tag = "CN_FO02";
            btnDanhSachHoaDon.Tag = "CN_FO03";
            btnBaoCaoDoanhThuThang.Tag = "CN_FO04";
            btnDoiMatKhau.Tag = "CN_DMK";

            ShowControl(new ThuPhiUngVien_UC());
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {

            timerMenu.Start();
        }

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
        
        private void ShowControl(UserControl uc)
        {
            if (uc == null) return;
            uc.Dock = DockStyle.Fill;
            pnlChinh.SuspendLayout();
            try
            {
                pnlChinh.Controls.Clear();
                pnlChinh.Controls.Add(uc);
            }
            finally
            {
                pnlChinh.ResumeLayout();
            }
        }
        private void btnThuPhiUngVien_Click(object sender, EventArgs e)
        {
            if (!PermissionGuard.EnsureEnabled((string)btnThuPhiUngVien.Tag)) return;
            ShowControl(new ThuPhiUngVien_UC());        
        }

        private void btnThuPhiDoanhNghiep_Click(object sender, EventArgs e)
        {
            if (!PermissionGuard.EnsureEnabled((string)btnThuPhiDoanhNghiep.Tag)) return;
            ShowControl(new ThuPhiDoanhNghiep_UC());
        }

        private void btnDanhSachHoaDon_Click(object sender, EventArgs e)
        {
            if (!PermissionGuard.EnsureEnabled((string)btnDanhSachHoaDon.Tag)) return;
            ShowControl(new DanhSachHoaDon_UC());
        }

        private void btnBaoCaoDoanhThuThang_Click(object sender, EventArgs e)
        {
            if (!PermissionGuard.EnsureEnabled((string)btnBaoCaoDoanhThuThang.Tag)) return;
            ShowControl(new BaoCaoDoanhThuThang_UC());
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

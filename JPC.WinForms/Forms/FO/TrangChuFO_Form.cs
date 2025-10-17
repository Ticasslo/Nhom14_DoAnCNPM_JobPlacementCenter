using JPC.Business.Services.Implementations.FO;
using JPC.Business.Services.Interfaces.FO;
using JPC.DataAccess.Repositories.Implementations.FO;
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

            //var uc = new ThuPhiUngVien_UC();
            //uc.BindService(BuildThuPhiUngVienService());
            //ShowControl(uc);
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
        private IThuPhiUngVienService BuildThuPhiUngVienService()
            => new ThuPhiUngVienService(
                new UngVienRepository(),
                new UngTuyenRepository(),
                new PhiDichVuRepository(),
                new NhanVienRepository(),
                new HoaDonRepository());

        private IThuPhiDoanhNghiepService BuildThuPhiDoanhNghiepService()
            => new ThuPhiDoanhNghiepService(
                new TinTuyenDungRepository(),
                new HoaDonRepository(),
                new PhiDichVuRepository(),
                new DoanhNghiepRepository(),
                new NhanVienRepository());



        private IQuanLyHoaDonService BuildQuanLyHoaDonService()
            => new QuanLyHoaDonService(
                new HoaDonRepository(),
                new NhanVienRepository(),
                new DoanhNghiepRepository(),
                new UngVienRepository());

        private void ShowControl(UserControl uc)
        {
            // dọn panel trước khi nạp UC mới
            pnlChinh.SuspendLayout();
            pnlChinh.Controls.Clear();

            // cấu hình UC để chiếm toàn vùng panel
            uc.Dock = DockStyle.Fill;

            // nạp vào panel
            pnlChinh.Controls.Add(uc);
            uc.BringToFront();
                
            pnlChinh.ResumeLayout();
        }
        private void btnThuPhiUngVien_Click(object sender, EventArgs e)
        {
            if (!PermissionGuard.EnsureEnabled(btnThuPhiUngVien.AccessibleDescription)) return;
            var uc = new ThuPhiUngVien_UC();
            uc.BindService(BuildThuPhiUngVienService());
            ShowControl(uc);
        }

        private void btnThuPhiDoanhNghiep_Click(object sender, EventArgs e)
        {
            if (!PermissionGuard.EnsureEnabled((string)btnThuPhiDoanhNghiep.Tag)) return;
            var uc = new ThuPhiDoanhNghiep_UC();
            uc.BindService(BuildThuPhiDoanhNghiepService());
            ShowControl(uc);
        }

        private void btnDanhSachHoaDon_Click(object sender, EventArgs e)
        {
            if (!PermissionGuard.EnsureEnabled((string)btnDanhSachHoaDon.Tag)) return;
            var uc = new DanhSachHoaDon_UC();
            uc.BindService(BuildQuanLyHoaDonService());
            ShowControl(uc);
        }

        private void btnBaoCaoDoanhThuThang_Click(object sender, EventArgs e)
        {
            if (!PermissionGuard.EnsureEnabled((string)btnBaoCaoDoanhThuThang.Tag)) return;
            var uc = new BaoCaoDoanhThuThang_UC();

            var svc = new ThongKeService(new HoaDonRepository());
            uc.BindService(svc);

            ShowControl(uc);
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

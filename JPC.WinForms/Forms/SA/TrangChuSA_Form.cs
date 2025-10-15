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
namespace Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.SA
{
    public partial class TrangChuSA_Form : Form
    {
        public TrangChuSA_Form()
        {
            InitializeComponent();
        }

        private void btnQLDanhMucNgheNghiep_Click(object sender, EventArgs e)
        {
            QLDanhMucNgheNghiep_Form next = new QLDanhMucNgheNghiep_Form();
            next.Show();
            this.Hide();
        }

        private void btnQLTaiKhoanNhanVien_Click(object sender, EventArgs e)
        {
            QLTaiKhoanNhanVien_Form next = new QLTaiKhoanNhanVien_Form();
            next.Show();
            this.Hide();
        }

        private void btnQLQuyenHan_Click(object sender, EventArgs e)
        {
            QLQuyenHan_Form next = new QLQuyenHan_Form();
            next.Show();
            this.Hide();
        }

        private void btnTraCuuDuLieu_Click(object sender, EventArgs e)
        {
            TraCuuDuLieu_Form next = new TraCuuDuLieu_Form();
            next.Show();
            this.Hide();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            
        }

        private void btnClose_Click(object sender, EventArgs e)
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

        private void TrangChuSA_Form_Load(object sender, EventArgs e)
        {

        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            JPC.Models.UserSession.Clear(); // Xóa session khi đăng xuất
            this.Tag = "Logout";
            this.Close();
        }
    }
}

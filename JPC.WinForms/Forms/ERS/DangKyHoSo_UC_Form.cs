using System;
using System.Windows.Forms;
using JPC.Business.Services.Implementations.ERS;
using JPC.Business.Services.Interfaces.ERS;
using JPC.DataAccess.Repositories.Implementations.ERS;
using JPC.DataAccess.Repositories.Interfaces.ERS;
using JPC.Models.DoanhNghiep;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms
{
    public partial class DangKyHoSo_UC_Form : UserControl
    {

        private readonly IDoanhNghiepService _service;

        private void LoadDoanhNghiepList()
        {
            var list = _service.LayTatCa();
            dgvDoanhNghiep.DataSource = list;
        }



        public DangKyHoSo_UC_Form()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.Resize += DangKyHoSo_UC_Form_Resize;
            IDoanhNghiepRepository repo = new DoanhNghiepRepository();
            _service = new DoanhNghiepService(repo);

        }

        private void DangKyHoSo_UC_Form_Load(object sender, EventArgs e)
        {
            LoadDoanhNghiepList();

        }
        private void DangKyHoSo_UC_Form_Resize(object sender, EventArgs e)
        {
            int centerX = guna2Panel1.Width / 2;

            lbTitle.Left = centerX - (lbTitle.Width / 2);
            lbWelcome.Left = centerX - (lbWelcome.Width / 2);


            // Panel chiếm khoảng 85% chiều rộng và 75% chiều cao form
            int targetWidth = (int)(this.Width * 1);
            int targetHeight = (int)(this.Height * 0.95);

            panel1.Size = new Size(targetWidth, targetHeight);

            // Giả sử guna2Panel1 là panel cam nhạt
            guna2Panel1.Left = (this.Width - guna2Panel1.Width) / 2;
            guna2Panel1.Top = (this.Height - guna2Panel1.Height) / 2 - 20; // -20 để lệch nhẹ lên trên



            int startX_Label = 230;     // vị trí Label bên trái
            int startX_TextBox = 400;  // vị trí TextBox bên phải
            int startY = 40;           // vị trí bắt đầu từ trên xuống
            int spacingY = 70;         // khoảng cách giữa các hàng
            int textBoxWidth = (int)(guna2Panel1.Width * 0.35);
            int textBoxHeight = 35;

            // Lấy danh sách label và textbox
            Label[] labels = { lbHoTen, label1, label2, label3, label4, label5 };
            Guna.UI2.WinForms.Guna2TextBox[] textBoxes =
            { txttendoanhnghiep, txtdiachi, txtSDT, txtemail, txtlinhvuc, txtMST };

            for (int i = 0; i < labels.Length; i++)
            {
                // Căn chỉnh label
                labels[i].AutoSize = true;
                labels[i].Location = new Point(startX_Label, startY + i * spacingY);
                labels[i].Font = new Font("Segoe UI", 11, FontStyle.Bold);

                // Căn chỉnh textbox
                textBoxes[i].Size = new Size(textBoxWidth, textBoxHeight);
                textBoxes[i].Location = new Point(startX_TextBox, startY + i * spacingY - 5);
                textBoxes[i].Font = new Font("Segoe UI", 11, FontStyle.Regular);
            }

            // Căn giữa nút Lưu hồ sơ
            btnLuu.Left = (this.Width - btnLuu.Width) / 2;
            btnLuu.Top = guna2Panel1.Bottom + 430; // cách panel một khoảng 20px
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            var dn = new DoanhNghiep
            {
                TenDoanhNghiep = txttendoanhnghiep.Text.Trim(),
                DiaChi = txtdiachi.Text.Trim(),
                SoDienThoai = txtSDT.Text.Trim(),
                Email = txtemail.Text.Trim(),
                LinhVuc = txtlinhvuc.Text.Trim(),
                MaSoThue = txtMST.Text.Trim()
            };

            var (ok, msg, newId) = _service.DangKy(dn);

            if (ok)
            {
                MessageBox.Show($"✅ {msg}\nMã DN mới: {newId}", "Thành công");
                ClearForm();
                LoadDoanhNghiepList();
            }
            else
            {
                MessageBox.Show("❌ " + msg, "Không hợp lệ");
                // Bạn có thể focus vào control tương ứng tùy theo message
            }

        }

        private void ClearForm()
        {
            txttendoanhnghiep.Clear();
            txtdiachi.Clear();
            txtSDT.Clear();
            txtemail.Clear();
            txtlinhvuc.Clear();
            txtMST.Clear();
        }
    }
}

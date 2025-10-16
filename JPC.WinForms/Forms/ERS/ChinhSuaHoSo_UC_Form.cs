using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JPC.Business.Services.Implementations.ERS;
using JPC.Business.Services.Interfaces.ERS;
using JPC.Models.DoanhNghiep;

namespace Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.ERS
{
    public partial class ChinhSuaHoSo_UC_Form : UserControl
    {

        private readonly IDoanhNghiepService_ERS _service;
        private DoanhNghiep _selected;

        public ChinhSuaHoSo_UC_Form()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            throw new InvalidOperationException(
                "Vui lòng khởi tạo ChinhSuaHoSo_UC_Form bằng constructor có tham số IDoanhNghiepService_ERS.");
        }

        public ChinhSuaHoSo_UC_Form(IDoanhNghiepService_ERS service)
        {
            InitializeComponent();
            _service = service ?? throw new ArgumentNullException(nameof(service));
            this.Resize += DangKyHoSo_UC_Form_Resize;
        }

        private void ChinhSuaHoSo_UC_Form_Load(object sender, EventArgs e)
        {
            LoadDoanhNghiepList();
        }
        private void LoadDoanhNghiepList()
        {
            var list = _service.LayTatCa();
            dgvDoanhNghiep.DataSource = list;
        }
        private void DangKyHoSo_UC_Form_Resize(object sender, EventArgs e)
        {
            int centerX = guna2Panel1.Width / 2;

            // 🌟 Căn giữa tiêu đề và dòng phụ
            lbTitle.Left = centerX - (lbTitle.Width / 2);
            lbWelcome.Left = centerX - (lbWelcome.Width / 2);

            int startX_LeftLabel = 120;     // label cột trái
            int startX_LeftTextBox = 290;   // textbox cột trái
            int startX_RightLabel = 650;    // label cột phải
            int startX_RightTextBox = 770; // textbox cột phải
            int startY = 150;                // vị trí bắt đầu từ trên xuống
            int spacingY = 70;              // khoảng cách giữa các hàng
            int textBoxWidth = (int)(guna2Panel1.Width * 0.25);
            int textBoxHeight = 35;

            // Lấy danh sách label và textbox
            Label[] labels = { label3, lbHoTen, label1, label2, label6, label4, label5 };
            Guna.UI2.WinForms.Guna2TextBox[] textBoxes =
            { txtmadoanhnghiep, txttendoanhnghiep, txtdiachi, txtSDT, txtemail, txtlinhvuc, txtMST };

            // Cột trái: 4 dòng
            for (int i = 0; i < 4; i++)
            {
                labels[i].AutoSize = true;
                labels[i].Location = new Point(startX_LeftLabel, startY + i * spacingY);
                labels[i].Font = new Font("Segoe UI", 11, FontStyle.Bold);

                textBoxes[i].Size = new Size(textBoxWidth, textBoxHeight);
                textBoxes[i].Location = new Point(startX_LeftTextBox, startY + i * spacingY - 5);
                textBoxes[i].Font = new Font("Segoe UI", 11, FontStyle.Regular);
            }

            // Cột phải: 3 dòng
            for (int i = 4; i < labels.Length; i++)
            {
                int row = i - 4;
                labels[i].AutoSize = true;
                labels[i].Location = new Point(startX_RightLabel, startY + row * spacingY);
                labels[i].Font = new Font("Segoe UI", 11, FontStyle.Bold);

                textBoxes[i].Size = new Size(textBoxWidth, textBoxHeight);
                textBoxes[i].Location = new Point(startX_RightTextBox, startY + row * spacingY - 5);
                textBoxes[i].Font = new Font("Segoe UI", 11, FontStyle.Regular);
            }

            btnluu.Left = (this.Width - btnluu.Width) / 2;
            btnluu.Top = guna2Panel1.Bottom + 380; // cách panel một khoảng 20px

            // 🌟 Căn chỉnh vị trí 2 nút Tìm kiếm và Làm mới
            int btnSpacing = 30; // khoảng cách giữa 2 nút
            int btnTop = textBoxes[6].Bottom + 20; // đặt ngay dưới dòng "Số điện thoại"
            int btnWidth = 120;
            int btnHeight = 40;

            btnfind.Size = new Size(btnWidth, btnHeight);
            btnlammoi.Size = new Size(btnWidth, btnHeight);

            // Căn 2 nút vào khoảng giữa cột phải
            btnfind.Left = startX_RightTextBox;
            btnlammoi.Left = btnfind.Right + btnSpacing;
            btnfind.Top = btnlammoi.Top = btnTop;


        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            if (_selected == null)
            {
                MessageBox.Show("⚠️ Hãy chọn doanh nghiệp trước!");
                return;
            }

            var updated = new DoanhNghiep
            {
                DnId = _selected.DnId,
                TenDoanhNghiep = txttendoanhnghiep.Text.Trim(),
                DiaChi = txtdiachi.Text.Trim(),
                SoDienThoai = txtSDT.Text.Trim(),
                Email = txtemail.Text.Trim(),
                LinhVuc = txtlinhvuc.Text.Trim(),
                MaSoThue = _selected.MaSoThue
            };

            if (MessageBox.Show("Bạn chắc chắn muốn cập nhật?", "Xác nhận",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            (bool ok, string msg) = _service.CapNhat(updated);

            MessageBox.Show(
                msg,
                ok ? "Thành công" : "Thông báo",
                MessageBoxButtons.OK,
                ok ? MessageBoxIcon.Information : MessageBoxIcon.Warning
            );


            if (ok)
            {
                _selected = null;
                dgvDoanhNghiep.DataSource = null;
                ClearForm();
            }
        }

        private void ClearForm()
        {
            txtmadoanhnghiep.Clear();
            txttendoanhnghiep.Clear();
            txtdiachi.Clear();
            txtSDT.Clear();
            txtemail.Clear();
            txtlinhvuc.Clear();
            txtMST.Clear();
            txtMST.Enabled = true;
        }

        private void btnfind_Click(object sender, EventArgs e)
        {
            if (dgvDoanhNghiep.SelectedRows.Count == 0)
            {
                // lần đầu tiên bấm tìm kiếm → load danh sách
                if (int.TryParse(txtmadoanhnghiep.Text.Trim(), out int id))
                {
                    var dn = _service.TimTheoMa(id);
                    if (dn == null)
                    {
                        MessageBox.Show("❌ Không tìm thấy doanh nghiệp.");
                        return;
                    }

                    dgvDoanhNghiep.DataSource = new[] { dn };
                }
                else
                {
                    MessageBox.Show("⚠️ Vui lòng nhập mã doanh nghiệp hợp lệ!");
                }
            }
            else
            {
                // lần 2 bấm → lấy thông tin lên textbox
                _selected = dgvDoanhNghiep.SelectedRows[0].DataBoundItem as DoanhNghiep;
                if (_selected != null)
                {
                    txtmadoanhnghiep.Text = _selected.DnId.ToString();
                    txttendoanhnghiep.Text = _selected.TenDoanhNghiep;
                    txtdiachi.Text = _selected.DiaChi;
                    txtSDT.Text = _selected.SoDienThoai;
                    txtemail.Text = _selected.Email;
                    txtlinhvuc.Text = _selected.LinhVuc;
                    txtMST.Text = _selected.MaSoThue;
                    txtMST.Enabled = false; // không cho sửa MST
                }
            }
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
}

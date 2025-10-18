using System;
using System.Windows.Forms;
using JPC.Business.Services.Implementations.ERS;
using JPC.Business.Services.Interfaces.ERS;
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

        private readonly IDoanhNghiepService_ERS _service;

        public DangKyHoSo_UC_Form()
        {
            InitializeComponent();

            // Nếu đang mở trong Designer thì không làm gì thêm
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            // Ở runtime bạn KHÔNG nên dùng ctor này. Nếu bị gọi nhầm -> báo rõ.
            throw new InvalidOperationException(
                "Vui lòng khởi tạo DangKyHoSo_UC_Form bằng constructor có tham số IDoanhNghiepService_ERS.");
        }


        public DangKyHoSo_UC_Form(IDoanhNghiepService_ERS service)
        {
            InitializeComponent();

            _service = service ?? throw new ArgumentNullException(nameof(service));

            this.Dock = DockStyle.Fill;
            //this.Resize += DangKyHoSo_UC_Form_Resize;

            // Nếu bạn muốn auto tạo cột theo model:
            // dgvDoanhNghiep.AutoGenerateColumns = true;

            // Tải dữ liệu ban đầu
            LoadDoanhNghiepList();
        }

        private void LoadDoanhNghiepList()
        {
            var list = _service.LayTatCa();
            // Nếu cần cho phép thêm/xóa ràng buộc, dùng BindingList:
            // dgvDoanhNghiep.DataSource = new BindingList<DoanhNghiep>(list);
            dgvDoanhNghiep.DataSource = list;
        }

        private void DangKyHoSo_UC_Form_Load(object sender, EventArgs e)
        {

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
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
           // this.Resize += DangKyHoSo_UC_Form_Resize;
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
                LoadDoanhNghiepList();
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

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

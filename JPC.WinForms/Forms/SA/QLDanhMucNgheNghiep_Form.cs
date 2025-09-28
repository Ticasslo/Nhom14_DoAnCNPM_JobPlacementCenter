using JPC.Business.Services.Implementations.SA;
using JPC.Business.Services.Interfaces.SA;
using JPC.Models.DanhMucNghe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.SA
{
    public partial class QLDanhMucNgheNghiep_Form : Form
    {
        private INhomNgheService _nhomNgheService;
        private bool _isEditMode = false;
        private int _selectedNhomNgheId = -1;

        public QLDanhMucNgheNghiep_Form()
        {
            InitializeComponent();
            InitializeServices();
            LoadComboBoxData();
            LoadData();
            SetupForm();
        }

        private void QLDanhMucNgheNghiep_Form_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            TrangChuSA_Form next = new TrangChuSA_Form();
            next.Show();
            this.Hide();
        }

        private void InitializeServices()
        {
            // Tạo service thông qua Business layer
            // Business layer sẽ tự tạo repository
            _nhomNgheService = new NhomNgheService();
        }

        private void LoadComboBoxData()
        {
            // Load dữ liệu cho ComboBox Trạng thái
            cbTrangThai1.Items.Clear();
            cbTrangThai1.Items.Add("Active");
            cbTrangThai1.Items.Add("Inactive");
            cbTrangThai1.SelectedIndex = 0; // Mặc định "Active"
        }

        private void LoadData()
        {
            try
            {
                DataTable dt = _nhomNgheService.GetAllNhomNghe();
                DGVNhomNghe.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupForm()
        {
            // Khóa DataGridView ban đầu
            DGVNhomNghe.Enabled = true;

            // Vô hiệu hóa panel chi tiết ban đầu
            SetPanelDetailEnabled(false);

            // Reset form về trạng thái ban đầu
            ResetForm();
        }

        private void SetPanelDetailEnabled(bool enabled)
        {
            txtNhomNghe1.Enabled = enabled;
            cbTrangThai1.Enabled = enabled;
            btnLuu1.Enabled = enabled;
            btnHuy1.Enabled = enabled;
        }

        private void ResetForm()
        {
            txtNhomNghe1.Clear();
            // Kiểm tra ComboBox có items không trước khi set SelectedIndex
            if (cbTrangThai1.Items.Count > 0)
            {
                cbTrangThai1.SelectedIndex = 0; // Mặc định "Active"
            }
            _isEditMode = false;
            _selectedNhomNgheId = -1;
            SetPanelDetailEnabled(false);
        }

        private void btnSuaNhomNghe_Click(object sender, EventArgs e)
        {
            if (DGVNhomNghe.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhóm nghề cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _isEditMode = true;
            _selectedNhomNgheId = Convert.ToInt32(DGVNhomNghe.SelectedRows[0].Cells["ID"].Value);

            try
            {
                NhomNghe nhomNghe = _nhomNgheService.GetNhomNgheById(_selectedNhomNgheId);
                if (nhomNghe != null)
                {
                    txtNhomNghe1.Text = nhomNghe.TenNhom;
                    cbTrangThai1.Text = nhomNghe.TrangThai;
                    SetPanelDetailEnabled(true);
                    txtNhomNghe1.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin nhóm nghề: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTaiLaiNhomNghe_Click(object sender, EventArgs e)
        {
            LoadData();
            txtTimKiemNhomNghe.Clear();
            ResetForm();
        }

        private void btnThemNhomNghe_Click(object sender, EventArgs e)
        {
            _isEditMode = false;
            _selectedNhomNgheId = -1;
            ResetForm();
            SetPanelDetailEnabled(true);
            txtNhomNghe1.Focus();
        }

        private void btnLuu1_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(txtNhomNghe1.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên nhóm nghề", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNhomNghe1.Focus();
                    return;
                }

                NhomNghe nhomNghe = new NhomNghe
                {
                    TenNhom = txtNhomNghe1.Text.Trim(),
                    TrangThai = cbTrangThai1.Text
                };

                bool success = false;
                string message = "";

                if (_isEditMode)
                {
                    nhomNghe.NhomId = _selectedNhomNgheId;
                    success = _nhomNgheService.UpdateNhomNghe(nhomNghe);
                    message = success ? "Cập nhật nhóm nghề thành công" : "Cập nhật nhóm nghề thất bại";
                }
                else
                {
                    success = _nhomNgheService.InsertNhomNghe(nhomNghe);
                    message = success ? "Thêm nhóm nghề thành công" : "Thêm nhóm nghề thất bại";
                }

                if (success)
                {
                    MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy1_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void txtTimKiemNhomNghe_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTimKiemNhomNghe.Text.Trim();
                DataTable dt;

                if (string.IsNullOrEmpty(keyword))
                {
                    dt = _nhomNgheService.GetAllNhomNghe();
                }
                else
                {
                    dt = _nhomNgheService.SearchNhomNghe(keyword);
                }

                DGVNhomNghe.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGVNhomNghe_SelectionChanged(object sender, EventArgs e)
        {
            if (DGVNhomNghe.SelectedRows.Count > 0 && !_isEditMode)
            {
                DataGridViewRow row = DGVNhomNghe.SelectedRows[0];
                txtNhomNghe1.Text = row.Cells["Tên nhóm"].Value.ToString();
                cbTrangThai1.Text = row.Cells["Trạng thái"].Value.ToString();
            }
        }
    }
}

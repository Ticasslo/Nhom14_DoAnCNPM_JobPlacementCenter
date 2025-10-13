using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JPC.Business.Services.Interfaces.SA;
using JPC.Business.Services.Implementations.SA;

namespace Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.SA
{
    public partial class QLTaiKhoanNhanVien_Form : Form
    {
        private INhanVienService _nhanVienService;
        private bool _isAddMode = false;
        private bool _isEditMode = false;
        private int _selectedNhanVienId = -1;
        public QLTaiKhoanNhanVien_Form()
        {
            InitializeComponent();
            SetupResponsiveLayout();
            _nhanVienService = new NhanVienService();
            LoadComboBoxes();
            LoadDataNhanVien();
            ResetForm(); // Set initial state to view mode
            // Căn header theo toolbar ngay khi mở và khi resize
            AdjustHeaderLayout();
            panelHeader.Resize += (s, e) => AdjustHeaderLayout();
        }

        private void LoadComboBoxes()
        {
            try
            {
                // Load ComboBox Vai trò
                DataTable dtVaiTro = _nhanVienService.GetAllVaiTro();
                cbVaiTro.DataSource = dtVaiTro;
                cbVaiTro.DisplayMember = "ten_vai_tro";
                cbVaiTro.ValueMember = "vai_tro_id";
                cbVaiTro.SelectedIndex = -1;

                // Load ComboBox Trạng thái
                cbTrangThai.Items.Clear();
                cbTrangThai.Items.Add("active");
                cbTrangThai.Items.Add("inactive");
                cbTrangThai.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load ComboBox: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupResponsiveLayout()
        {
            panelHeader.Dock = DockStyle.Top;
            label4.Dock = DockStyle.Top;
            label4.AutoSize = false;
            label4.Height = 56;
            label4.TextAlign = ContentAlignment.MiddleCenter;

            btnThem.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnSua.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnTaiLai.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // Khu giữa: panelDGV Fill, DGV Fill trong panelDGV
            panelDGV.Dock = DockStyle.Fill;
            DGVTaiKhoanNhanVien.Dock = DockStyle.Fill;

            panelChiTiet.Dock = DockStyle.Bottom;
            if (panelChiTiet.Height < 200) panelChiTiet.Height = 287;

            // Bên trong panel chi tiết: input bám trái, nút bám phải
            txtHoTen.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            txtEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            txtSDT.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            cbVaiTro.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            txtUsername.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            cbTrangThai.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            btnLuu.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnHuy.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // Hai nút Hiện/Cập nhật mật khẩu đặt ngay dưới ô mật khẩu
            btnHienMatKhau.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnCapNhatMatKhau.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnHienMatKhau.Location = new Point(txtPassword.Left, txtPassword.Bottom + 8);
            btnCapNhatMatKhau.Location = new Point(btnHienMatKhau.Right + 8, btnHienMatKhau.Top);
        }

        private void AdjustHeaderLayout()
        {
            if (panelHeader == null || label4 == null) return;
            int padding = 12;
            int toolbarTop = label4.Bottom + 6;
            btnThem.Top = toolbarTop;
            btnSua.Top = toolbarTop;
            btnTaiLai.Top = toolbarTop;
            btnThem.Left = padding;
            btnSua.Left = btnThem.Right + 12;
            btnTaiLai.Left = btnSua.Right + 12;
            txtTimKiem.Top = toolbarTop + (btnThem.Height - txtTimKiem.Height) / 2;
            txtTimKiem.Left = panelHeader.ClientSize.Width - txtTimKiem.Width - padding;
            label2.Top = toolbarTop + (btnThem.Height - label2.Height) / 2;
            label2.Left = txtTimKiem.Left - label2.Width - 8;
            int desired = toolbarTop + btnThem.Height + padding;
            if (desired < 60) desired = 60;
            if (panelHeader.Height != desired) panelHeader.Height = desired;
        }

        private void LoadDataNhanVien()
        {
            try
            {
                DataTable dt = _nhanVienService.GetAllNhanVien();
                DGVTaiKhoanNhanVien.DataSource = dt;

                // Ưu tiên cột Email rộng hơn
                if (DGVTaiKhoanNhanVien.Columns.Contains("Email"))
                {
                    DGVTaiKhoanNhanVien.Columns["Email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    DGVTaiKhoanNhanVien.Columns["Email"].FillWeight = 220;
                }
                if (DGVTaiKhoanNhanVien.Columns.Contains("Username"))
                {
                    DGVTaiKhoanNhanVien.Columns["Username"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    DGVTaiKhoanNhanVien.Columns["Username"].FillWeight = 120;
                }
                foreach (DataGridViewColumn col in DGVTaiKhoanNhanVien.Columns)
                {
                    if (col.Name != "Email" && col.Name != "Username")
                    {
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        col.FillWeight = 100;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // KIỂM TRA ĐIỀU KIỆN: Không được thêm khi đang ở chế độ sửa
            if (_isEditMode && !_isAddMode)
            {
                MessageBox.Show("Đang ở chế độ sửa. Vui lòng hủy hoặc lưu trước khi thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            _isAddMode = true;
            _isEditMode = true;
            _selectedNhanVienId = -1;
            
            // Clear input fields
            txtHoTen.Clear();
            txtEmail.Clear();
            txtSDT.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            if (cbVaiTro.Items.Count > 0) cbVaiTro.SelectedIndex = 0;
            if (cbTrangThai.Items.Count > 0) cbTrangThai.SelectedIndex = 0;
            
            // Enable panel for editing
            SetPanelEnabled(true);
            
            // Đổi label thành "Thêm nhân viên mới"
            label3.Text = "Thêm nhân viên mới";
            
            // Focus vào field đầu tiên
            txtHoTen.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // KIỂM TRA ĐIỀU KIỆN: Phải chọn dòng trong DGV
            if (DGVTaiKhoanNhanVien.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            // KIỂM TRA ĐIỀU KIỆN: Không được sửa khi đang ở chế độ thêm
            if (_isAddMode)
            {
                MessageBox.Show("Đang ở chế độ thêm mới. Vui lòng hủy hoặc lưu trước khi sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            _isAddMode = false;
            _isEditMode = true;
            _selectedNhanVienId = Convert.ToInt32(DGVTaiKhoanNhanVien.SelectedRows[0].Cells["ID"].Value);
            
            // Enable panel for editing
            SetPanelEnabled(true);
            
            // Đổi label thành "Sửa nhân viên"
            label3.Text = $"Sửa nhân viên ID = {_selectedNhanVienId}";
            
            // Focus vào field đầu tiên
            txtHoTen.Focus();
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            try
            {
                LoadDataNhanVien();
                ResetForm(); // Reset form về trạng thái ban đầu
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải lại dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(txtHoTen.Text))
                {
                    MessageBox.Show("Vui lòng nhập họ tên", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtHoTen.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    MessageBox.Show("Vui lòng nhập email", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    MessageBox.Show("Vui lòng nhập username", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsername.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                    return;
                }
                if (cbVaiTro.SelectedIndex < 0)
                {
                    MessageBox.Show("Vui lòng chọn vai trò", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbVaiTro.Focus();
                    return;
                }
                if (cbTrangThai.SelectedIndex < 0)
                {
                    MessageBox.Show("Vui lòng chọn trạng thái", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbTrangThai.Focus();
                    return;
                }

                // Lấy dữ liệu từ form
                string hoTen = txtHoTen.Text.Trim();
                string email = txtEmail.Text.Trim();
                string soDienThoai = txtSDT.Text.Trim();
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();
                string vaiTroId = cbVaiTro.SelectedValue.ToString();
                string trangThai = cbTrangThai.Text;

                // Hash password (SHA256)
                string passwordHash = HashPassword(password);

                bool success = false;
                string message = "";

                string actionText = _isAddMode
                    ? "Bạn có chắc muốn THÊM nhân viên này?"
                    : $"Bạn có chắc muốn CẬP NHẬT nhân viên ID = {_selectedNhanVienId}?";
                var confirm = MessageBox.Show(actionText, "Xác nhận",
                                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (confirm != DialogResult.OK) return;

                if (_isAddMode) // ĐANG THÊM MỚI
                {
                    success = _nhanVienService.InsertNhanVien(hoTen, email, soDienThoai, username, passwordHash, vaiTroId, trangThai);
                    message = success ? "Thêm nhân viên thành công" : "Thêm nhân viên thất bại";
                }
                else            // ĐANG SỬA
                {
                    success = _nhanVienService.UpdateNhanVien(_selectedNhanVienId, hoTen, email, soDienThoai, username, passwordHash, vaiTroId, trangThai);
                    message = success ? "Cập nhật nhân viên thành công" : "Cập nhật nhân viên thất bại";
                }

                if (success)
                {
                    MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataNhanVien();
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

        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTimKiem.Text.Trim();
                DataTable dt;
                if (string.IsNullOrEmpty(keyword))
                {
                    dt = _nhanVienService.GetAllNhanVien();
                }
                else
                {
                    dt = _nhanVienService.SearchNhanVien(keyword);
                }
                DGVTaiKhoanNhanVien.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGVTaiKhoanNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            // KHÔNG load data khi đang edit để tránh ghi đè dữ liệu đang nhập
            if (_isEditMode || _isAddMode) return;
            
            try
            {
                if (DGVTaiKhoanNhanVien.CurrentRow != null && !DGVTaiKhoanNhanVien.CurrentRow.IsNewRow)
                {
                    DataGridViewRow row = DGVTaiKhoanNhanVien.CurrentRow;
                    
                    // Đổ dữ liệu vào panel chi tiết
                    txtHoTen.Text = row.Cells["Họ tên"].Value?.ToString() ?? "";
                    txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
                    txtSDT.Text = row.Cells["SĐT"].Value?.ToString() ?? "";
                    txtUsername.Text = row.Cells["Username"].Value?.ToString() ?? "";
                    
                    // Set ComboBox Vai trò - sử dụng SelectedValue
                    string vaiTro = row.Cells["Vai trò"].Value?.ToString() ?? "";
                    // Tìm vai trò ID từ database để set SelectedValue
                    var dtVaiTro = _nhanVienService.GetAllVaiTro();
                    foreach (DataRow dr in dtVaiTro.Rows)
                    {
                        if (dr["ten_vai_tro"].ToString() == vaiTro)
                        {
                            cbVaiTro.SelectedValue = dr["vai_tro_id"];
                            break;
                        }
                    }
                    
                    // Set ComboBox Trạng thái
                    string trangThai = row.Cells["Trạng thái"].Value?.ToString() ?? "";
                    if (cbTrangThai.Items.Count > 0)
                    {
                        cbTrangThai.SelectedIndex = trangThai.ToLower() == "active" ? 0 : 1;
                    }
                    
                    // Clear password field
                    txtPassword.Clear();
                    
                    // Cập nhật label thành "Chi tiết nhân viên"
                    label3.Text = "Chi tiết nhân viên";
                    
                    // Set panel to view mode (disable editing)
                    SetPanelEnabled(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load chi tiết: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCapNhatMatKhau_Click(object sender, EventArgs e)
        {

        }

        private void btnHienMatKhau_Click(object sender, EventArgs e)
        {

        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void SetPanelEnabled(bool enabled)
        {
            // Enable/disable input fields
            txtHoTen.Enabled = enabled;
            txtEmail.Enabled = enabled;
            txtSDT.Enabled = enabled;
            txtUsername.Enabled = enabled;
            txtPassword.Enabled = enabled;
            cbVaiTro.Enabled = enabled;
            cbTrangThai.Enabled = enabled;
            
            // Show/hide buttons based on mode
            if (enabled)
            {
                // Khi đang edit: hiện nút Lưu, Hủy và các nút mật khẩu
                btnLuu.Visible = true;
                btnHuy.Visible = true;
                btnHienMatKhau.Visible = true;
                btnCapNhatMatKhau.Visible = true;
                
                // Ẩn các nút không cần thiết khi edit
                btnThem.Visible = false;
                btnSua.Visible = false;
                btnTaiLai.Visible = false;
                
                // Ẩn tìm kiếm khi edit (như QL danh mục)
                txtTimKiem.Visible = false;
                label2.Visible = false;
                
                // Disable DGV selection khi đang edit để tránh conflict
                DGVTaiKhoanNhanVien.Enabled = false;
            }
            else
            {
                // Khi đang xem: ẩn nút Lưu, Hủy và các nút mật khẩu
                btnLuu.Visible = false;
                btnHuy.Visible = false;
                btnHienMatKhau.Visible = false;
                btnCapNhatMatKhau.Visible = false;
                
                // Hiện các nút chính khi xem
                btnThem.Visible = true;
                btnSua.Visible = true;
                btnTaiLai.Visible = true;
                
                // Hiện tìm kiếm khi xem
                txtTimKiem.Visible = true;
                label2.Visible = true;
                
                // Enable DGV selection khi đang xem
                DGVTaiKhoanNhanVien.Enabled = true;
            }
        }

        private void ResetForm()
        {
            _isAddMode = false;
            _isEditMode = false;
            _selectedNhanVienId = -1;
            
            // Clear input fields
            txtHoTen.Clear();
            txtEmail.Clear();
            txtSDT.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            if (cbVaiTro.Items.Count > 0) cbVaiTro.SelectedIndex = -1;
            if (cbTrangThai.Items.Count > 0) cbTrangThai.SelectedIndex = -1;
            
            // Clear DGV selection
            DGVTaiKhoanNhanVien.ClearSelection();
            
            // Reset label về mặc định
            label3.Text = "Chi tiết nhân viên";
            
            // Set panel to view mode
            SetPanelEnabled(false);
        }

    }
}

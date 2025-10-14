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
        private bool _isPasswordVisible = false;
        private System.Windows.Forms.Timer _debounceSearch;
        public QLTaiKhoanNhanVien_Form()
        {
            InitializeComponent();
            SetupResponsiveLayout(); // Setup layout cho full màn hình
            _nhanVienService = new NhanVienService(); // Khởi tạo service
            LoadComboBoxes(); // Load dữ liệu cho các ComboBox
            LoadDataNhanVien(); // Load dữ liệu nhân viên vào DataGridView
            ResetForm(); // Đặt trạng thái ban đầu cho form

            // Căn header ngay khi mở và khi resize
            AdjustHeaderLayout();
            panelHeader.Resize += (s, e) => AdjustHeaderLayout();

            // Debounce tìm kiếm
            _debounceSearch = new System.Windows.Forms.Timer { Interval = 300 };
            _debounceSearch.Tick += (s, e) => { _debounceSearch.Stop(); ExecuteSearchNhanVien(); };
        }

        private void SetupResponsiveLayout()
        {
            panelHeader.Dock = DockStyle.Top;
            lblTieuDe.Dock = DockStyle.Top;
            lblTieuDe.AutoSize = false;
            lblTieuDe.Height = 56;
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;

            btnThem.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnSua.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnTaiLai.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            lblTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
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

        private void AdjustHeaderLayout()
        {
            if (panelHeader == null || lblTieuDe == null) return;
            int padding = 12;
            int toolbarTop = lblTieuDe.Bottom + 6;
            btnThem.Top = toolbarTop;
            btnSua.Top = toolbarTop;
            btnTaiLai.Top = toolbarTop;
            btnThem.Left = padding;
            btnSua.Left = btnThem.Right + 12;
            btnTaiLai.Left = btnSua.Right + 12;
            txtTimKiem.Top = toolbarTop + (btnThem.Height - txtTimKiem.Height) / 2;
            txtTimKiem.Left = panelHeader.ClientSize.Width - txtTimKiem.Width - padding;
            lblTimKiem.Top = toolbarTop + (btnThem.Height - lblTimKiem.Height) / 2;
            lblTimKiem.Left = txtTimKiem.Left - lblTimKiem.Width - 8;
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
            if (cbVaiTro.Items.Count > 0) cbVaiTro.SelectedIndex = -1; // Trống ban đầu
            if (cbTrangThai.Items.Count > 0) cbTrangThai.SelectedIndex = 0;
            
            // Enable panel for editing
            SetPanelEnabled(true);
            
            // Đổi label thành "Thêm nhân viên mới"
            lblChiTiet.Text = "Thêm nhân viên mới";
            
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
            lblChiTiet.Text = $"Sửa nhân viên ID = {_selectedNhanVienId}";
            
            // Focus vào field đầu tiên
            txtHoTen.Focus();

            // Chế độ sửa: để trống và khóa ô mật khẩu; checkbox đổi mật khẩu hiện, chưa chọn; ẩn nút cập nhật mật khẩu
            if (txtPassword != null)
            {
                txtPassword.Clear();
                txtPassword.PasswordChar = '●';
                txtPassword.Enabled = false;
            }
            if (checkDoiMatKhau != null)
            {
                checkDoiMatKhau.Visible = true;
                checkDoiMatKhau.Checked = false;
            }
            if (btnCapNhatMatKhau != null)
            {
                btnCapNhatMatKhau.Visible = false;
            }
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
                // Mật khẩu chỉ bắt buộc khi THÊM mới
                if (_isAddMode && string.IsNullOrWhiteSpace(txtPassword.Text))
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

                // Validation dữ liệu
                string email = txtEmail.Text.Trim();
                string soDienThoai = txtSDT.Text.Trim();
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();

                // Kiểm tra format email
                if (!IsValidEmail(email))
                {
                    MessageBox.Show("Email không đúng định dạng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }

                // Kiểm tra số điện thoại (10-11 số)
                if (!string.IsNullOrEmpty(soDienThoai) && !IsValidPhoneNumber(soDienThoai))
                {
                    MessageBox.Show("Số điện thoại phải có 10-11 chữ số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSDT.Focus();
                    return;
                }

                // Kiểm tra username (3-20 ký tự, chỉ chữ và số)
                if (!IsValidUsername(username))
                {
                    MessageBox.Show("Username phải có 3-20 ký tự, chỉ chứa chữ cái và số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsername.Focus();
                    return;
                }

                // Kiểm tra mật khẩu (ít nhất 6 ký tự)
                if (_isAddMode && password.Length < 6)
                {
                    MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                    return;
                }

                // Kiểm tra trùng email/username
                int? excludeId = _isAddMode ? (int?)null : _selectedNhanVienId;
                if (IsEmailDuplicate(email, excludeId))
                {
                    MessageBox.Show("Email đã tồn tại trong hệ thống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }
                if (IsUsernameDuplicate(username, excludeId))
                {
                    MessageBox.Show("Username đã tồn tại trong hệ thống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsername.Focus();
                    return;
                }

                // Lấy dữ liệu từ form
                string hoTen = txtHoTen.Text.Trim();
                string vaiTroId = cbVaiTro.SelectedValue.ToString();
                string trangThai = cbTrangThai.Text;

                // Hash password (SHA256) chỉ khi thêm mới; khi sửa không đổi mật khẩu
                string passwordHash = _isAddMode ? HashPassword(password) : string.Empty;

                bool success = false;
                string message = "";

                // Xác nhận đích gửi email trước khi lưu
                if (!IsValidEmail(email))
                {
                    MessageBox.Show("Email không hợp lệ. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }

                var confirmRecipient = MessageBox.Show($"Sau khi lưu, hệ thống sẽ gửi thông tin tài khoản đến: {email}.\nBạn có muốn tiếp tục?", "Xác nhận gửi email", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (confirmRecipient != DialogResult.OK) return;

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
                    // Truyền passwordHash rỗng để repository giữ nguyên mật khẩu cũ
                    success = _nhanVienService.UpdateNhanVien(_selectedNhanVienId, hoTen, email, soDienThoai, username, string.Empty, vaiTroId, trangThai);
                    message = success ? "Cập nhật nhân viên thành công" : "Cập nhật nhân viên thất bại";
                }

                if (success)
                {
                    MessageBox.Show($"{message}\nEmail sẽ được gửi đến: {email}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Gửi email thông tin tài khoản: nếu THÊM thì gửi kèm mật khẩu, nếu SỬA thì không
                    string roleName = cbVaiTro.Text?.Trim() ?? vaiTroId;
                    string roleId = cbVaiTro.SelectedValue?.ToString() ?? vaiTroId;
                    string statusText = cbTrangThai.Text?.Trim();
                    string phoneToSend = soDienThoai;
                    if (_isAddMode)
                    {
                        SendAccountInfoEmailAsync(email, hoTen, username, roleName, roleId, statusText, phoneToSend, password).ConfigureAwait(false);
                    }
                    else
                    {
                        SendAccountInfoEmailAsync(email, hoTen, username, roleName, roleId, statusText, phoneToSend, null).ConfigureAwait(false);
                    }
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
                var bytes = System.Text.Encoding.UTF8.GetBytes(password);
                var hashBytes = sha256.ComputeHash(bytes);
                var sb = new System.Text.StringBuilder(hashBytes.Length * 2);
                foreach (var b in hashBytes)
                {
                    sb.Append(b.ToString("X2")); // X2 = chữ hoa, x2 = chữ thường
                }
                return sb.ToString();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            _debounceSearch.Stop();
            _debounceSearch.Start();
        }

        private void ExecuteSearchNhanVien()
        {
            try
            {
                string keyword = txtTimKiem.Text.Trim();
                DataTable dt = string.IsNullOrEmpty(keyword)
                    ? _nhanVienService.GetAllNhanVien()
                    : _nhanVienService.SearchNhanVien(keyword);
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
                    lblChiTiet.Text = "Chi tiết nhân viên";
                    
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
			try
            {
                if (_selectedNhanVienId <= 0)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên để cập nhật mật khẩu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string newPassword = txtPassword.Text.Trim();
                if (string.IsNullOrWhiteSpace(newPassword) || newPassword.Length < 6)
                {
                    MessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                    return;
                }

                // Hash mật khẩu mới để cập nhật
                string newHash = HashPassword(newPassword);

				// Xác nhận kèm email người nhận
				string toEmail = txtEmail.Text.Trim();
				string fullName = txtHoTen.Text.Trim();
				if (!IsValidEmail(toEmail))
				{
					MessageBox.Show("Email nhân viên không hợp lệ. Vui lòng kiểm tra lại trước khi gửi thông báo.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					txtEmail.Focus();
					return;
				}

				var confirm = MessageBox.Show($"Xác nhận cập nhật mật khẩu và gửi email đến: {toEmail}?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (confirm != DialogResult.OK) return;

                bool ok = _nhanVienService.UpdatePassword(_selectedNhanVienId, newHash);
                if (!ok)
                {
                    MessageBox.Show("Cập nhật mật khẩu thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SendPasswordChangedEmailAsync(toEmail, fullName, newPassword).ConfigureAwait(false);

                MessageBox.Show("Cập nhật mật khẩu thành công và đã gửi email thông báo", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Thoát chế độ đổi mật khẩu: clear nội dung, khóa ô, reset nút hiện/ẩn, hiện lại Lưu/Hủy
                txtPassword.Clear();
                txtPassword.Enabled = false;
                _isPasswordVisible = false;
                btnHienMatKhau.Text = "👁️ Hiện mật khẩu";
                if (checkDoiMatKhau != null) checkDoiMatKhau.Checked = false;
                SetPanelEnabled(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Gửi email (MailKit)
        private async Task SendPasswordChangedEmailAsync(string toEmail, string fullName, string newPassword)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(toEmail)) return;

                var message = new MimeKit.MimeMessage();
                message.From.Add(new MimeKit.MailboxAddress("Trung tâm giới thiệu việc làm JFC", "win2005thang@gmail.com"));
                message.To.Add(MimeKit.MailboxAddress.Parse(toEmail));
                message.Subject = "[JPC] Mật khẩu của bạn đã được cập nhật";

                var bodyText = $"Chào {fullName},\n\nMật khẩu tài khoản của bạn đã được cập nhật thành công.\n\nThông tin đăng nhập:\n- Mật khẩu mới: {newPassword}\n\nVì lý do an toàn, vui lòng đăng nhập và ĐỔI MẬT KHẨU ngay sau khi đăng nhập lại.\nNếu bạn không thực hiện yêu cầu này, hãy liên hệ quản trị ngay.\n\nTrân trọng,\nJPC";
                message.Body = new MimeKit.TextPart("plain") { Text = bodyText };

                using (var smtp = new MailKit.Net.Smtp.SmtpClient())
                {
                    var security = MailKit.Security.SecureSocketOptions.StartTls;
                    await smtp.ConnectAsync("smtp.gmail.com", 587, security);
                    await smtp.AuthenticateAsync("win2005thang@gmail.com", "imwn mccd vnsh vofe");
                    await smtp.SendAsync(message);
                    await smtp.DisconnectAsync(true);
                }
            }
            catch
            {
                // Im lặng: không chặn luồng cập nhật nếu email lỗi
            }
        }

        // Gửi email thông tin tài khoản khi thêm/sửa
        private async Task SendAccountInfoEmailAsync(string toEmail, string fullName, string username, string roleName, string roleId, string statusText, string phoneNumber, string passwordOrNull)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(toEmail)) return;

                var message = new MimeKit.MimeMessage();
                message.From.Add(new MimeKit.MailboxAddress("Trung tâm giới thiệu việc làm JFC", "win2005thang@gmail.com"));
                message.To.Add(MimeKit.MailboxAddress.Parse(toEmail));

                bool includePassword = !string.IsNullOrEmpty(passwordOrNull);
                message.Subject = includePassword ? "[JPC] Tài khoản nhân viên của bạn đã được tạo" : "[JPC] Thông tin tài khoản nhân viên";

                var sb = new System.Text.StringBuilder();
                sb.AppendLine($"Chào {fullName},\n");
                if (includePassword)
                {
                    sb.AppendLine("Tài khoản nhân viên của bạn đã được tạo thành công.");
                }
                else
                {
                    sb.AppendLine("Thông tin tài khoản của bạn đã được cập nhật.");
                }
                sb.AppendLine("\nThông tin đăng nhập:");
                sb.AppendLine($"- Họ tên: {fullName}");
                sb.AppendLine($"- Username: {username}");
                sb.AppendLine($"- Vai trò: {roleName} ({roleId})");
                sb.AppendLine($"- Trạng thái: {statusText}");
                sb.AppendLine($"- Email: {toEmail}");
                if (!string.IsNullOrWhiteSpace(phoneNumber)) sb.AppendLine($"- SĐT: {phoneNumber}");
                if (includePassword)
                {
                    sb.AppendLine($"- Mật khẩu: {passwordOrNull}");
                    sb.AppendLine("\nVì lý do an toàn, vui lòng đăng nhập và ĐỔI MẬT KHẨU ngay sau khi đăng nhập.");
                }
                sb.AppendLine("\nNếu bạn không thực hiện yêu cầu này, vui lòng liên hệ quản trị.");
                sb.AppendLine("\nTrân trọng,\nJPC");

                message.Body = new MimeKit.TextPart("plain") { Text = sb.ToString() };

                using (var smtp = new MailKit.Net.Smtp.SmtpClient())
                {
                    var security = MailKit.Security.SecureSocketOptions.StartTls;
                    await smtp.ConnectAsync("smtp.gmail.com", 587, security);
                    await smtp.AuthenticateAsync("win2005thang@gmail.com", "imwn mccd vnsh vofe");
                    await smtp.SendAsync(message);
                    await smtp.DisconnectAsync(true);
                }
            }
            catch
            {
                // không chặn luồng nếu gửi email thất bại
            }
        }

        private void btnHienMatKhau_Click(object sender, EventArgs e)
        {
            _isPasswordVisible = !_isPasswordVisible;
            
            if (_isPasswordVisible)
            {
                txtPassword.PasswordChar = '\0'; // Hiện mật khẩu
                btnHienMatKhau.Text = "🔐 Ẩn mật khẩu";
            }
            else
            {
                txtPassword.PasswordChar = '●'; // Ẩn mật khẩu
                btnHienMatKhau.Text = "👁️ Hiện mật khẩu";
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void checkDoiMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            bool changing = checkDoiMatKhau.Checked;
            // Khi bật đổi mật khẩu: chỉ bật Email và Password; ẩn Lưu/Hủy, hiện nút Cập nhật
            txtHoTen.Enabled = !changing && _isEditMode;
            txtSDT.Enabled = !changing && _isEditMode;
            txtUsername.Enabled = !changing && _isEditMode;
            cbVaiTro.Enabled = !changing && _isEditMode;
            cbTrangThai.Enabled = !changing && _isEditMode;

            // Khi đổi mật khẩu: vô hiệu hóa email; chỉ cho nhập mật khẩu mới
            txtEmail.Enabled = !changing && _isEditMode;
            txtPassword.Enabled = changing;

            btnLuu.Visible = !changing;
            btnHuy.Visible = !changing;
            btnCapNhatMatKhau.Visible = changing;
            // Nút hiện mật khẩu chỉ hiện khi đang đổi mật khẩu
            btnHienMatKhau.Visible = changing;

            // Ẩn/hiện các label và control khác, chỉ giữ Email và Mật khẩu
            try
            {
                // Các input khác
                if (txtHoTen != null) txtHoTen.Visible = !changing;
                if (txtSDT != null) txtSDT.Visible = !changing;
                if (txtUsername != null) txtUsername.Visible = !changing;
                if (cbVaiTro != null) cbVaiTro.Visible = !changing;
                if (cbTrangThai != null) cbTrangThai.Visible = !changing;

                // Email và Password luôn hiển thị
                if (txtEmail != null) txtEmail.Visible = true;
                if (txtPassword != null) txtPassword.Visible = true;

                if (lblSDT != null) lblSDT.Visible = !changing;
                if (lblHoten != null) lblHoten.Visible = !changing;
                if (lblUsername != null) lblUsername.Visible = !changing;
                if (lblVaiTro != null) lblVaiTro.Visible = !changing;
                if (lblTrangThai != null) lblTrangThai.Visible = !changing;

                if (lblEmail != null) lblEmail.Visible = true;
                if (lblMatKhau != null) lblMatKhau.Visible = true;
            }
            catch { }

            // Khi tắt chế độ đổi mật khẩu: clear ô password và reset trạng thái hiện/ẩn
            if (!changing)
            {
                if (txtPassword != null) txtPassword.Clear();
                _isPasswordVisible = false;
                if (btnHienMatKhau != null) btnHienMatKhau.Text = "👁️ Hiện mật khẩu";
                if (txtPassword != null) txtPassword.PasswordChar = '●';
            }
        }

        private void SetPanelEnabled(bool enabled)
        {
            // Enable/disable input fields
            txtHoTen.Enabled = enabled;
            txtEmail.Enabled = enabled;
            txtSDT.Enabled = enabled;
            txtUsername.Enabled = enabled;
            // txtPassword: trong sửa sẽ bị khóa trừ khi tích đổi mật khẩu
            txtPassword.Enabled = _isAddMode ? enabled : (checkDoiMatKhau != null && checkDoiMatKhau.Checked && enabled);
            cbVaiTro.Enabled = enabled;
            cbTrangThai.Enabled = enabled;
            
            // Show/hide buttons based on mode
            if (enabled)
            {
                // Khi đang edit: hiện nút Lưu, Hủy và các nút mật khẩu
                btnLuu.Visible = true;
                btnHuy.Visible = true;
                // Nút hiện mật khẩu: luôn hiện ở chế độ Thêm; ở chế độ Sửa chỉ hiện khi tick Đổi mật khẩu
                btnHienMatKhau.Visible = _isAddMode || (checkDoiMatKhau != null && checkDoiMatKhau.Checked);
                // Nút cập nhật mật khẩu chỉ hiện khi sửa và đã chọn đổi mật khẩu
                btnCapNhatMatKhau.Visible = (!_isAddMode) && (checkDoiMatKhau != null && checkDoiMatKhau.Checked);
                // Checkbox đổi mật khẩu chỉ hiện khi sửa
                if (checkDoiMatKhau != null) checkDoiMatKhau.Visible = !_isAddMode;
                
                // Ẩn các nút không cần thiết khi edit
                btnThem.Visible = false;
                btnSua.Visible = false;
                btnTaiLai.Visible = false;
                
                // Ẩn tìm kiếm khi edit (như QL danh mục)
                txtTimKiem.Visible = false;
                lblTimKiem.Visible = false;
                
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
                if (checkDoiMatKhau != null)
                {
                    checkDoiMatKhau.Visible = false;
                    checkDoiMatKhau.Checked = false;
                }
                
                // Hiện các nút chính khi xem
                btnThem.Visible = true;
                btnSua.Visible = true;
                btnTaiLai.Visible = true;
                
                // Hiện tìm kiếm khi xem
                txtTimKiem.Visible = true;
                lblTimKiem.Visible = true;
                
                // Enable DGV selection khi đang xem
                DGVTaiKhoanNhanVien.Enabled = true;
            }
        }

        private void ResetForm()
        {
            _isAddMode = false;
            _isEditMode = false;
            _selectedNhanVienId = -1;
            _isPasswordVisible = false; // Reset trạng thái hiện/ẩn mật khẩu
            
            // Clear input fields
            txtHoTen.Clear();
            txtEmail.Clear();
            txtSDT.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtPassword.PasswordChar = '●'; // Đảm bảo mật khẩu được ẩn
            btnHienMatKhau.Text = "👁️ Hiện mật khẩu"; // Reset text nút
            if (checkDoiMatKhau != null)
            {
                checkDoiMatKhau.Visible = false;
                checkDoiMatKhau.Checked = false;
            }
            if (cbVaiTro.Items.Count > 0) cbVaiTro.SelectedIndex = -1;
            if (cbTrangThai.Items.Count > 0) cbTrangThai.SelectedIndex = -1;
            
            // Clear DGV selection
            DGVTaiKhoanNhanVien.ClearSelection();
            
            // Reset label về mặc định
            lblChiTiet.Text = "Chi tiết nhân viên";
            
            // Set panel to view mode
            SetPanelEnabled(false);
        }





        // VALIDATION
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) return false;
            
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber)) return true; // Cho phép để trống
            
            // Loại bỏ khoảng trắng và dấu gạch ngang
            string cleanPhone = phoneNumber.Replace(" ", "").Replace("-", "");
            
            // Kiểm tra chỉ chứa số và có độ dài 10-11
            return cleanPhone.Length >= 10 && cleanPhone.Length <= 11 && 
                   cleanPhone.All(char.IsDigit);
        }

        private bool IsValidUsername(string username)
        {
            if (string.IsNullOrEmpty(username)) return false;
            
            // Kiểm tra độ dài 3-20 ký tự
            if (username.Length < 3 || username.Length > 20) return false;
            
            // Kiểm tra chỉ chứa chữ cái và số
            return username.All(c => char.IsLetterOrDigit(c));
        }

        // USERNAME TỰ ĐỘNG KHI THÊM NHÂN VIÊN MỚI

        private void cbVaiTro_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Chỉ tự động điền username khi đang thêm mới
            if (!_isAddMode) return;

            if (cbVaiTro.SelectedIndex >= 0)
            {
                string vaiTroId = cbVaiTro.SelectedValue.ToString();
                string nextUsername = GetNextUsername(vaiTroId);
                txtUsername.Text = nextUsername;
            }
        }

        private string GetNextUsername(string vaiTroId)
        {
            try
            {
                // Lấy tất cả username hiện có của vai trò này
                DataTable dt = _nhanVienService.GetAllNhanVien();
                
                // Tìm username có pattern {vaiTroId}{số}
                var existingUsernames = new List<string>();
                foreach (DataRow row in dt.Rows)
                {
                    string username = row["Username"].ToString();
                    if (username.StartsWith(vaiTroId.ToLower()))
                    {
                        existingUsernames.Add(username);
                    }
                }
                
                // Tìm số tiếp theo
                int nextNumber = 1;
                while (existingUsernames.Contains($"{vaiTroId.ToLower()}{nextNumber:D3}"))
                {
                    nextNumber++;
                }
                
                return $"{vaiTroId.ToLower()}{nextNumber:D3}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo username: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return $"{vaiTroId.ToLower()}001";
            }
        }

        // DUPLICATE: KIỂM TRA TRÙNG LẶP
        private bool IsEmailDuplicate(string email, int? excludeNhanVienId)
        {
            try
            {
                DataTable dt = _nhanVienService.GetAllNhanVien();
                foreach (DataRow row in dt.Rows)
                {
                    string rowEmail = row["Email"].ToString();
                    int rowId = Convert.ToInt32(row["ID"]);
                    if (string.Equals(rowEmail, email, StringComparison.OrdinalIgnoreCase))
                    {
                        if (!excludeNhanVienId.HasValue || rowId != excludeNhanVienId.Value)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        private bool IsUsernameDuplicate(string username, int? excludeNhanVienId)
        {
            try
            {
                DataTable dt = _nhanVienService.GetAllNhanVien();
                foreach (DataRow row in dt.Rows)
                {
                    string rowUsername = row["Username"].ToString();
                    int rowId = Convert.ToInt32(row["ID"]);
                    if (string.Equals(rowUsername, username, StringComparison.OrdinalIgnoreCase))
                    {
                        if (!excludeNhanVienId.HasValue || rowId != excludeNhanVienId.Value)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}

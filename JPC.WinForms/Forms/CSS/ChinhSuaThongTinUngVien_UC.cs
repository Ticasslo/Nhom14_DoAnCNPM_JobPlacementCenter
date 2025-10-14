using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JPC.Business.Services.Interfaces.CSS;
using JPC.Business.Services.Implementations.CSS;
using JPC.Business.Exceptions;
using JPC.Models.UngVien;
using JPC.Models.DanhMucNghe;
using JPC.Models.Common;

namespace Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.CSS
{
    public partial class ChinhSuaThongTinUngVien_UC : UserControl
    {
        private IUngVienService ungVienService;
        private IDanhMucNgheService danhMucNgheService;
        private UngVien selectedUngVien;
        private List<UngVien> currentUngVienList;

        public ChinhSuaThongTinUngVien_UC()
        {
            InitializeComponent();
            InitializeServices();
            SetupDataGridView();
            LoadDanhSachUngVien();
            LoadNhomNghe();
            ClearForm();
        }

        private void InitializeServices()
        {
            ungVienService = new UngVienService();
            danhMucNgheService = new DanhMucNgheService();
        }

        private void ClearForm()
        {
            txtMaUV.Enabled = true;

            txtMaUV.Text = "";
            txtHoTen.Text = "";
            txtEmail.Text = "";
            txtSDT.Text = "";
            txtCCCD.Text = "";
            dtpNgaySinh.Value = DateTime.Now;
            txtQueQuan.Text = "";

            cbbNhomNghe.SelectedIndex = 0;
            cbbNghe.Items.Clear();
            cbbNghe.Items.Add(new ComboBoxItem { Text = "-- Chọn nghề --", Value = 0 });
            cbbNghe.SelectedIndex = 0;
            cbbVT.Items.Clear();
            cbbVT.Items.Add(new ComboBoxItem { Text = "-- Chọn vị trí chuyên môn --", Value = 0 });
            cbbVT.SelectedIndex = 0;

            selectedUngVien = null;
        }

        private void SetupDataGridView()
        {
            // Thêm các cột
            dgvDSHoSoUngVien.Columns.Clear();
            dgvDSHoSoUngVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "UvId",
                HeaderText = "Mã ứng viên",
                DataPropertyName = "UvId",
                Width = 100,
                ReadOnly = true
            });
            dgvDSHoSoUngVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "HoTen",
                HeaderText = "Họ và tên",
                DataPropertyName = "HoTen",
                Width = 200,
                ReadOnly = true
            });
            dgvDSHoSoUngVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Email",
                HeaderText = "Email",
                DataPropertyName = "Email",
                Width = 200,
                ReadOnly = true
            });
            dgvDSHoSoUngVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SoDienThoai",
                HeaderText = "Số điện thoại",
                DataPropertyName = "SoDienThoai",
                Width = 100,
                ReadOnly = true
            });
            dgvDSHoSoUngVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Cccd",
                HeaderText = "CCCD",
                DataPropertyName = "Cccd",
                Width = 100,
                ReadOnly = true
            });
            dgvDSHoSoUngVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NgaySinh",
                HeaderText = "Ngày sinh",
                DataPropertyName = "NgaySinh",
                Width = 80,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "dd/MM/yyyy"
                }
            });
            dgvDSHoSoUngVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "QueQuan",
                HeaderText = "Quê quán",
                DataPropertyName = "QueQuan",
                Width = 200,
                ReadOnly = true
            });
            dgvDSHoSoUngVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "VtId",
                HeaderText = "Mã vị trí",
                DataPropertyName = "VtId",
                Width = 50,
                ReadOnly = true
            });
            dgvDSHoSoUngVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NgayTao",
                HeaderText = "Ngày tạo",
                DataPropertyName = "NgayTao",
                Width = 120,
                ReadOnly = true,
            });

            
        }

        private void LoadNhomNghe()
        {
            try
            {
                cbbNhomNghe.Items.Clear();
                cbbNhomNghe.Items.Add(new ComboBoxItem { Text = "-- Chọn nhóm nghề --", Value = 0 });

                var nhomNgheList = danhMucNgheService.GetAllNhomNghe();
                foreach (var nhom in nhomNgheList)
                {
                    cbbNhomNghe.Items.Add(new ComboBoxItem { Text = nhom.TenNhom, Value = nhom.NhomId });
                }
                cbbNhomNghe.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách nhóm nghề: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadNghe(int nhomId)
        {
            try
            {
                cbbNghe.Items.Clear();
                cbbNghe.Items.Add(new ComboBoxItem { Text = "-- Chọn nghề --", Value = 0 });

                if (nhomId > 0)
                {
                    var ngheList = danhMucNgheService.GetNgheByNhom(nhomId);
                    foreach (var nghe in ngheList)
                    {
                        cbbNghe.Items.Add(new ComboBoxItem { Text = nghe.TenNghe, Value = nghe.NgheId });
                    }
                }
                cbbNghe.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách nghề: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadViTri(int ngheId)
        {
            try
            {
                cbbVT.Items.Clear();
                cbbVT.Items.Add(new ComboBoxItem { Text = "-- Chọn vị trí chuyên môn --", Value = 0 });

                if (ngheId > 0)
                {
                    var viTriList = danhMucNgheService.GetViTriByNghe(ngheId);
                    foreach (var viTri in viTriList)
                    {
                        cbbVT.Items.Add(new ComboBoxItem { Text = viTri.TenViTri, Value = viTri.VtId });
                    }
                }
                cbbVT.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách vị trí chuyên môn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDanhSachUngVien()
        {
            try
            {
                currentUngVienList = ungVienService.GetAllUngVien().ToList();
                dgvDSHoSoUngVien.DataSource = currentUngVienList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách ứng viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillFormWithUngVien(UngVien ungVien)
        {
            if (ungVien == null) return;

            // Điền thông tin cơ bản
            txtMaUV.Text = ungVien.UvId.ToString();
            txtHoTen.Text = ungVien.HoTen;
            txtEmail.Text = ungVien.Email;
            txtSDT.Text = ungVien.SoDienThoai;
            txtCCCD.Text = ungVien.Cccd;
            dtpNgaySinh.Value = ungVien.NgaySinh;
            txtQueQuan.Text = ungVien.QueQuan;

            // Tìm và chọn vị trí chuyên môn - Tối ưu hóa
            if (ungVien.VtId.HasValue)
            {
                try
                {
                    // Sử dụng method mới để lấy thông tin trực tiếp
                    var viTri = danhMucNgheService.GetViTriChuyenMonById(ungVien.VtId.Value);
                    if (viTri != null)
                    {
                        var nghe = danhMucNgheService.GetNgheById(viTri.NgheId);
                        if (nghe != null)
                        {
                            // Chọn nhóm nghề
                            SelectComboBoxItem(cbbNhomNghe, nghe.NhomId);
                            
                            // Load và chọn nghề
                            LoadNghe(nghe.NhomId);
                            SelectComboBoxItem(cbbNghe, nghe.NgheId);
                            
                            // Load và chọn vị trí
                            LoadViTri(nghe.NgheId);
                            SelectComboBoxItem(cbbVT, viTri.VtId);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tải thông tin nghề nghiệp: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // Helper method để chọn item trong ComboBox
        private void SelectComboBoxItem(ComboBox comboBox, int value)
        {
            for (int i = 0; i < comboBox.Items.Count; i++)
            {
                var item = (ComboBoxItem)comboBox.Items[i];
                if (item.Value == value)
                {
                    comboBox.SelectedIndex = i;
                    return;
                }
            }
        }

        private void dgvDSHoSoUngVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && currentUngVienList != null && e.RowIndex < currentUngVienList.Count)
            {
                selectedUngVien = currentUngVienList[e.RowIndex];
                FillFormWithUngVien(selectedUngVien);
                txtMaUV.Enabled = false; // Mã ứng viên không được sửa
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string maUngVien = txtMaUV.Text.Trim();
                string hoTen = txtHoTen.Text.Trim();
                string email = txtEmail.Text.Trim();
                string soDienThoai = txtSDT.Text.Trim();
                string cccd = txtCCCD.Text.Trim();

                currentUngVienList = ungVienService.SearchUngVien(maUngVien, hoTen, email, soDienThoai, cccd).ToList();
                dgvDSHoSoUngVien.DataSource = currentUngVienList;

                if (currentUngVienList.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy ứng viên nào phù hợp với điều kiện tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm ứng viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra đã chọn ứng viên chưa
                if (selectedUngVien == null)
                {
                    MessageBox.Show("Vui lòng chọn một hồ sơ để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra thông tin bắt buộc
                if (string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text) ||
                    string.IsNullOrWhiteSpace(txtSDT.Text) ||
                    string.IsNullOrWhiteSpace(txtCCCD.Text) ||
                    string.IsNullOrWhiteSpace(txtQueQuan.Text) ||
                    cbbVT.SelectedIndex <= 0)
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin cần chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo đối tượng ứng viên để cập nhật
                var ungVienToUpdate = new UngVien
                {
                    UvId = selectedUngVien.UvId,
                    HoTen = txtHoTen.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    SoDienThoai = txtSDT.Text.Trim(),
                    Cccd = txtCCCD.Text.Trim(),
                    NgaySinh = dtpNgaySinh.Value,
                    QueQuan = txtQueQuan.Text.Trim(),
                    VtId = ((ComboBoxItem)cbbVT.SelectedItem).Value,
                    NgayTao = selectedUngVien.NgayTao
                };

                // Hiển thị thông báo xác nhận
                string confirmMessage = $"Bạn có chắc chắn muốn chỉnh sửa thông tin ứng viên này? Thông tin mới sẽ là:\n" +
                    $"Mã ứng viên: {ungVienToUpdate.UvId} (không đổi)\n" +
                    $"Họ và tên: {ungVienToUpdate.HoTen}\n" +
                    $"Email: {ungVienToUpdate.Email}\n" +
                    $"Số điện thoại: {ungVienToUpdate.SoDienThoai}\n" +
                    $"CCCD: {ungVienToUpdate.Cccd}\n" +
                    $"Ngày sinh: {ungVienToUpdate.NgaySinh:dd/MM/yyyy}\n" +
                    $"Quê quán: {ungVienToUpdate.QueQuan}\n" +
                    $"Vị trí chuyên môn: {((ComboBoxItem)cbbVT.SelectedItem).Text}";

                var result = MessageBox.Show(confirmMessage, "Xác nhận chỉnh sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    ungVienService.CapNhatUngVien(ungVienToUpdate);
                    MessageBox.Show("Chỉnh sửa thông tin ứng viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Cập nhật lại danh sách và làm mới form
                    LoadDanhSachUngVien();
                    ClearForm();
                }
            }
            catch (DomainValidationException ex)
            {
                HandleUngVienValidationError(ex); // <— ánh xạ ErrorCode → UI
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật thông tin ứng viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleUngVienValidationError(DomainValidationException ex)
        {
            switch (ex.ErrorCode)
            {
                case "REQUIRED_MISSING":
                    MessageBox.Show("Vui lòng nhập/ chọn đầy đủ thông tin.", "Thiếu thông tin",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtHoTen.Focus();
                    break;

                case "INVALID_EMAIL":
                    MessageBox.Show("Email không hợp lệ.", "Không hợp lệ",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    txtEmail.SelectAll();
                    break;

                case "INVALID_PHONE":
                    MessageBox.Show("Số điện thoại phải gồm đúng 10 chữ số.", "Không hợp lệ",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSDT.Focus();
                    txtSDT.SelectAll();
                    break;

                case "INVALID_CCCD":
                    MessageBox.Show("CCCD phải gồm đúng 12 chữ số.", "Không hợp lệ",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCCCD.Focus();
                    txtCCCD.SelectAll();
                    break;

                case "INVALID_DOB":
                    MessageBox.Show("Ngày sinh không hợp lệ.", "Không hợp lệ",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpNgaySinh.Focus();
                    break;

                case "GROUP_NOT_FOUND":
                    MessageBox.Show("Nhóm nghề không tồn tại.", "Không hợp lệ",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbbNhomNghe.Focus();
                    break;

                case "DUP_CCCD":
                    MessageBox.Show("CCCD đã được đăng ký.", "Không hợp lệ",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCCCD.Focus();
                    txtCCCD.SelectAll();
                    break;

                default:
                    // fallback: vẫn dùng message thân thiện từ Service
                    MessageBox.Show(ex.Message, "Không hợp lệ",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        private void cbbNhomNghe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbNhomNghe.SelectedItem is ComboBoxItem selectedItem)
            {
                LoadNghe(selectedItem.Value);
                cbbVT.Items.Clear();
                cbbVT.Items.Add(new ComboBoxItem { Text = "-- Chọn vị trí chuyên môn --", Value = 0 });
                cbbVT.SelectedIndex = 0;
            }
        }

        private void cbbNghe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbNghe.SelectedItem is ComboBoxItem selectedItem)
            {
                LoadViTri(selectedItem.Value);
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Chặn ký tự không phải số
            }
        }

        private void txtCCCD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Chặn ký tự không phải số
            }
        }
    }
}

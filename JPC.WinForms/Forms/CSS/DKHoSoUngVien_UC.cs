using JPC.Business.Exceptions;
using JPC.Business.Services.Implementations.CSS;
using JPC.Business.Services.Interfaces.CSS;
using JPC.Models.DanhMucNghe;
using JPC.Models.UngVien;
using JPC.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.CSS
{
    public partial class DKHoSoUngVien_UC : UserControl
    {
        private readonly IDanhMucNgheService danhMucNgheService;
        private readonly IUngVienService ungVienService;
        private bool isLoading; // tránh chạy sự kiện khi nạp dữ liệu

        public DKHoSoUngVien_UC()
        {
            InitializeComponent();
            this.danhMucNgheService = new DanhMucNgheService();
            this.ungVienService = new UngVienService();
        }

        private void DKHoSoUngVien_UC_Load(object sender, EventArgs e)
        {
            isLoading = true;
            try { LoadNhomNghe(); }
            finally { isLoading = false; }
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

        private void cbbNhomNghe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            if (cbbNhomNghe.SelectedItem is ComboBoxItem selectedItem && selectedItem.Value > 0)
            {
                try
                {
                    cbbNghe.Items.Clear();
                    cbbNghe.Items.Add(new ComboBoxItem { Text = "-- Chọn nghề --", Value = 0 });

                    var ngheList = danhMucNgheService.GetNgheByNhom(selectedItem.Value);
                    foreach (var nghe in ngheList)
                    {
                        cbbNghe.Items.Add(new ComboBoxItem { Text = nghe.TenNghe, Value = nghe.NgheId });
                    }
                    cbbNghe.SelectedIndex = 0;

                    cbbVT.Items.Clear();
                    cbbVT.Items.Add(new ComboBoxItem { Text = "-- Chọn vị trí chuyên môn --", Value = 0 });
                    cbbVT.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tải danh sách nghề: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cbbNghe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            if (cbbNghe.SelectedItem is ComboBoxItem selectedItem && selectedItem.Value > 0)
            {
                try
                {
                    cbbVT.Items.Clear();
                    cbbVT.Items.Add(new ComboBoxItem { Text = "-- Chọn vị trí chuyên môn --", Value = 0 });

                    var viTriList = danhMucNgheService.GetViTriByNghe(selectedItem.Value);
                    foreach (var viTri in viTriList)
                    {
                        cbbVT.Items.Add(new ComboBoxItem { Text = viTri.TenViTri, Value = viTri.VtId });
                    }
                    cbbVT.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tải danh sách vị trí chuyên môn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các control
            string hoTen = txtHoTen.Text?.Trim();
            string email = txtEmail.Text?.Trim();
            string sdt = txtSDT.Text?.Trim();
            string queQuan = txtQueQuan.Text?.Trim();
            string cccd = txtCCCD.Text?.Trim();
            DateTime ngaySinh = dtpNgaySinh.Value;

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(hoTen) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(cccd)
                || string.IsNullOrWhiteSpace(sdt) || string.IsNullOrWhiteSpace(queQuan)
                || cbbNhomNghe.SelectedIndex <= 0 || cbbNghe.SelectedIndex <= 0 || cbbVT.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng nhập/chọn đầy đủ thông tin", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int vtId = ((ComboBoxItem)cbbVT.SelectedItem).Value;

            var uv = new UngVien
            {
                HoTen = hoTen,
                Email = email,
                SoDienThoai = sdt,
                Cccd = cccd,
                NgaySinh = ngaySinh,
                QueQuan = queQuan,
                VtId = vtId
            };

            try
            {
                ungVienService.DangKyUngVien(uv);
                MessageBox.Show("Lưu hồ sơ thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
            }
            catch (DomainValidationException ex)
            {
                HandleUngVienValidationError(ex); // <— ánh xạ ErrorCode → UI
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Số điện thoại chỉ được chứa chữ số.", "Không hợp lệ",
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

        private void ClearForm()
        {
            txtHoTen.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtQueQuan.Text = string.Empty;
            txtCCCD.Text = string.Empty;
            dtpNgaySinh.Value = DateTime.Now;
            
            isLoading = true;
            try { LoadNhomNghe(); }
            finally { isLoading = false; }
        }

        private void txtCCCD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ngăn chặn ký tự không hợp lệ
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ngăn chặn ký tự không hợp lệ
            }
        }
    }
}

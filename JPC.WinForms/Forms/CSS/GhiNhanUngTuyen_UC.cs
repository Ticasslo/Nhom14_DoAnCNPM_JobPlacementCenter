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
using JPC.Models.DoanhNghiep;
using JPC.Models.DanhMucNghe;
using JPC.Models.Common;

namespace Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.CSS
{
    public partial class GhiNhanUngTuyen_UC : UserControl
    {
        private IUngVienService ungVienService;
        private IUngTuyenService ungTuyenService;
        private ITinTuyenDungService tinTuyenDungService;
        private IDanhMucNgheService danhMucNgheService;
        private IDoanhNghiepService doanhNghiepService;

        private UngVien selectedUngVien;
        private TinTuyenDung selectedTinTuyenDung;
        private List<UngVien> currentUngVienList;
        private List<TinTuyenDung> currentTinTuyenDungList;

        // Lưu lựa chọn vị trí ứng tuyển (từ combobox)
        private int? selectedViTriId;
        private string selectedViTriTen;

        public GhiNhanUngTuyen_UC()
        {
            InitializeComponent();
            InitializeServices();
            SetupDataGridView();
            LoadDanhSachUngVien();
            LoadDanhSachTinTuyenDung();
            ClearForm();
            SetFormState(false);
        }

        private void InitializeServices()
        {
            ungVienService = new UngVienService();
            ungTuyenService = new UngTuyenService();
            tinTuyenDungService = new TinTuyenDungService();
            danhMucNgheService = new DanhMucNgheService();
            doanhNghiepService = new DoanhNghiepService();
        }

        private void SetupDataGridView()
        {
            // Setup DataGridView danh sách hồ sơ ứng viên
            dgvDSHoSoUV.Columns.Clear();
            dgvDSHoSoUV.Columns.Add("uv_id", "Mã UV");
            dgvDSHoSoUV.Columns.Add("ho_ten", "Họ tên");
            dgvDSHoSoUV.Columns.Add("email", "Email");
            dgvDSHoSoUV.Columns.Add("so_dien_thoai", "SĐT");
            dgvDSHoSoUV.Columns.Add("cccd", "CCCD");
            dgvDSHoSoUV.Columns.Add("ngay_sinh", "Ngày sinh");
            dgvDSHoSoUV.Columns.Add("que_quan", "Quê quán");
            dgvDSHoSoUV.Columns.Add("vt_id", "Vị trí mong muốn");

            // Setup DataGridView danh sách tin tuyển dụng
            dgvDSTinTuyenDung.Columns.Clear();
            dgvDSTinTuyenDung.Columns.Add("tin_id", "Mã tin");
            dgvDSTinTuyenDung.Columns.Add("tieu_de", "Tiêu đề");
            dgvDSTinTuyenDung.Columns.Add("ten_doanh_nghiep", "Doanh nghiệp");
            dgvDSTinTuyenDung.Columns.Add("muc_luong", "Mức lương");
            dgvDSTinTuyenDung.Columns.Add("khu_vuc_lam_viec", "Khu vực");
            dgvDSTinTuyenDung.Columns.Add("hinh_thuc_lam_viec", "Hình thức");
            dgvDSTinTuyenDung.Columns.Add("kinh_nghiem_yeu_cau", "Kinh nghiệm");
            dgvDSTinTuyenDung.Columns.Add("han_nop_ho_so", "Hạn nộp");

            // Set column widths
            foreach (DataGridViewColumn col in dgvDSHoSoUV.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            foreach (DataGridViewColumn col in dgvDSTinTuyenDung.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void LoadDanhSachUngVien()
        {
            try
            {
                currentUngVienList = ungVienService.GetAllUngVien().ToList();
                RefreshDataGridViewUngVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách ứng viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshDataGridViewUngVien()
        {
            dgvDSHoSoUV.Rows.Clear();
            foreach (var ungVien in currentUngVienList)
            {
                // Lấy tên vị trí chuyên môn thay vì mã
                string tenViTri = "Chưa chọn";
                if (ungVien.VtId.HasValue)
                {
                    try
                    {
                        var viTri = danhMucNgheService.GetViTriChuyenMonById(ungVien.VtId.Value);
                        tenViTri = viTri?.TenViTri ?? $"VT{ungVien.VtId}";
                    }
                    catch
                    {
                        tenViTri = $"VT{ungVien.VtId}";
                    }
                }

                dgvDSHoSoUV.Rows.Add(
                    ungVien.UvId,
                    ungVien.HoTen,
                    ungVien.Email,
                    ungVien.SoDienThoai,
                    ungVien.Cccd,
                    ungVien.NgaySinh.ToString("dd/MM/yyyy"),
                    ungVien.QueQuan,
                    tenViTri
                );
            }
        }

        private void LoadDanhSachTinTuyenDung()
        {
            try
            {
                currentTinTuyenDungList = tinTuyenDungService.GetTinTuyenDungActive().ToList();
                RefreshDataGridViewTinTuyenDung();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách tin tuyển dụng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshDataGridViewTinTuyenDung()
        {
            dgvDSTinTuyenDung.Rows.Clear();
            if (currentTinTuyenDungList != null)
            {
                foreach (var tin in currentTinTuyenDungList)
                {
                    dgvDSTinTuyenDung.Rows.Add(
                        tin.TinId,
                        tin.TieuDe,
                        GetTenDoanhNghiep(tin.DnId),
                        tin.MucLuong,
                        tin.KhuVucLamViec,
                        tin.HinhThucLamViec,
                        tin.KinhNghiemYeuCau + " năm",
                        tin.HanNopHoSo.ToString("dd/MM/yyyy")
                    );
                }
            }
        }

        private string GetTenDoanhNghiep(int dnId)
        {
            try
            {
                var doanhNghiep = doanhNghiepService.GetDoanhNghiepById(dnId);
                return doanhNghiep?.TenDoanhNghiep ?? $"DN{dnId}";
            }
            catch
            {
                return $"DN{dnId}";
            }
        }

        private void ClearForm()
        {
            txtMaUV.Text = "";
            txtHoTen.Text = "";
            txtCCCD.Text = "";

            // Reset rich text placeholder
            richTxtLyDo.ForeColor = Color.Gray;
            richTxtLyDo.Text = "Lý do ứng tuyển:...";

            richTxtChiTietTinTuyenDung.ForeColor = Color.Gray;
            richTxtChiTietTinTuyenDung.Text = "Chọn tin tuyển dụng để xem chi tiết...";

            // Reset combobox vị trí
            try
            {
                cbbChonViTri.DataSource = null;
                cbbChonViTri.Items.Clear();
                cbbChonViTri.Items.Add("-- Chọn vị trí --");
                cbbChonViTri.SelectedIndex = 0;
                cbbChonViTri.ForeColor = Color.Gray;
                cbbChonViTri.Enabled = false;
            }
            catch { }
            selectedViTriId = null;
            selectedViTriTen = null;

            selectedUngVien = null;
            selectedTinTuyenDung = null;
            currentTinTuyenDungList = null;
        }

        private void SetFormState(bool ungVienSelected)
        {
            // Khóa/mở khóa các ô nhập thông tin ứng viên
            txtMaUV.ReadOnly = ungVienSelected;
            txtHoTen.ReadOnly = ungVienSelected;
            txtCCCD.ReadOnly = ungVienSelected;

            // Mở/khóa các phần liên quan đến tin tuyển dụng
            richTxtLyDo.ReadOnly = !ungVienSelected;

            // Enable/disable nút ứng tuyển
            btnUngTuyen.Enabled = ungVienSelected && selectedTinTuyenDung != null;
        }

        private void LoadTinTuyenDungPhuHop()
        {
            try
            {
                if (selectedUngVien != null)
                {
                    currentTinTuyenDungList = tinTuyenDungService.GetTinTuyenDungPhuHop(selectedUngVien).ToList();
                    RefreshDataGridViewTinTuyenDung();

                    if (currentTinTuyenDungList.Count == 0)
                    {
                        MessageBox.Show("Không có tin tuyển dụng phù hợp cho ứng viên này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách tin tuyển dụng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDSHoSoUV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && currentUngVienList != null && e.RowIndex < currentUngVienList.Count)
            {
                selectedUngVien = currentUngVienList[e.RowIndex];
                if (selectedUngVien != null)
                {
                    // Điền thông tin ứng viên vào form
                    txtMaUV.Text = selectedUngVien.UvId.ToString();
                    txtHoTen.Text = selectedUngVien.HoTen;
                    txtCCCD.Text = selectedUngVien.Cccd;

                    // Khóa các ô thông tin ứng viên
                    SetFormState(true);

                    // Load danh sách tin tuyển dụng phù hợp
                    LoadTinTuyenDungPhuHop();
                }
            }
        }

        private void dgvDSTinTuyenDung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && currentTinTuyenDungList != null && e.RowIndex < currentTinTuyenDungList.Count)
            {
                selectedTinTuyenDung = currentTinTuyenDungList[e.RowIndex];
                if (selectedTinTuyenDung != null)
                {
                    // Nạp nội dung chi tiết vào RichTextBox theo bố cục yêu cầu
                    var sb = new StringBuilder();
                    var tenDoanhNghiep = GetTenDoanhNghiep(selectedTinTuyenDung.DnId);
                    sb.AppendLine($"Tên doanh nghiệp: {tenDoanhNghiep}");
                    sb.AppendLine("\nVị trí chuyên môn:");

                    var viTriIdList = tinTuyenDungService.GetViTriByTin(selectedTinTuyenDung.TinId).ToList();
                    // Nạp combobox chọn vị trí
                    var viTriItems = new List<ComboBoxItem>();
                    foreach (var vtId in viTriIdList)
                    {
                        string tenViTri;
                        try
                        {
                            tenViTri = danhMucNgheService.GetViTriChuyenMonById(vtId)?.TenViTri ?? $"VT{vtId}";
                        }
                        catch
                        {
                            tenViTri = $"VT{vtId}";
                        }
                        viTriItems.Add(new ComboBoxItem(tenViTri, vtId));

                        sb.AppendLine($"\t- {tenViTri}:");
                        try
                        {
                            var kyNangList = tinTuyenDungService.GetKyNangByTinAndViTri(selectedTinTuyenDung.TinId, vtId).ToList();
                            var kyNangText = kyNangList != null && kyNangList.Count > 0 ? string.Join(", ", kyNangList) : "(Không yêu cầu)";
                            sb.AppendLine($"\t\tYêu cầu kĩ năng: {kyNangText}");
                        }
                        catch
                        {
                            sb.AppendLine("\t\tYêu cầu kĩ năng: (Không xác định)");
                        }
                    }

                    sb.AppendLine($"\nYêu cầu năm kinh nghiệm: {selectedTinTuyenDung.KinhNghiemYeuCau} năm");
                    sb.AppendLine($"\nHình thức làm việc: {selectedTinTuyenDung.HinhThucLamViec}");
                    sb.AppendLine($"\nKhu vực làm việc: {selectedTinTuyenDung.KhuVucLamViec}");
                    sb.AppendLine($"\nMức lương: {selectedTinTuyenDung.MucLuong}");
                    sb.AppendLine($"\nMô tả cụ thể: {selectedTinTuyenDung.MoTaCongViec}");

                    richTxtChiTietTinTuyenDung.ForeColor = Color.Black;
                    richTxtChiTietTinTuyenDung.Text = sb.ToString();

                    // Bind combobox vị trí theo số lượng
                    if (viTriItems.Count > 1)
                    {
                        // Thêm placeholder đầu tiên
                        var bindingList = new List<ComboBoxItem>();
                        bindingList.Add(new ComboBoxItem("-- Chọn vị trí --", -1));
                        bindingList.AddRange(viTriItems);

                        cbbChonViTri.DisplayMember = "Text";
                        cbbChonViTri.ValueMember = "Value";
                        cbbChonViTri.DataSource = bindingList;
                        cbbChonViTri.Enabled = true;
                        cbbChonViTri.SelectedIndex = 0; // placeholder
                        cbbChonViTri.ForeColor = Color.Gray;
                        selectedViTriId = null;
                        selectedViTriTen = null;
                    }
                    else if (viTriItems.Count == 1)
                    {
                        cbbChonViTri.DisplayMember = "Text";
                        cbbChonViTri.ValueMember = "Value";
                        cbbChonViTri.DataSource = viTriItems;
                        cbbChonViTri.Enabled = false; // khóa vì chỉ có 1 vị trí
                        cbbChonViTri.SelectedIndex = 0;
                        selectedViTriId = viTriItems[0].Value;
                        selectedViTriTen = viTriItems[0].Text;
                        cbbChonViTri.ForeColor = Color.Black;
                    }
                    else
                    {
                        // Không có vị trí nào (edge case)
                        cbbChonViTri.DataSource = null;
                        cbbChonViTri.Items.Clear();
                        cbbChonViTri.Items.Add("-- Không có vị trí --");
                        cbbChonViTri.SelectedIndex = 0;
                        cbbChonViTri.Enabled = false;
                        cbbChonViTri.ForeColor = Color.Gray;
                        selectedViTriId = null;
                        selectedViTriTen = null;
                    }

                    // Enable nút ứng tuyển
                    btnUngTuyen.Enabled = true;
                }
            }
        }

        private void cbbChonViTri_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbbChonViTri.SelectedItem is ComboBoxItem item)
                {
                    if (item.Value == -1)
                    {
                        // placeholder
                        selectedViTriId = null;
                        selectedViTriTen = null;
                        cbbChonViTri.ForeColor = Color.Gray;
                    }
                    else
                    {
                        selectedViTriId = item.Value;
                        selectedViTriTen = item.Text;
                        cbbChonViTri.ForeColor = Color.Black;
                    }
                }
                else
                {
                    // Khi chưa bind danh sách với KeyValuePair
                    if (cbbChonViTri.SelectedIndex == 0 && cbbChonViTri.Text.StartsWith("-- "))
                    {
                        selectedViTriId = null;
                        selectedViTriTen = null;
                        cbbChonViTri.ForeColor = Color.Gray;
                    }
                    else
                    {
                        selectedViTriId = cbbChonViTri.SelectedValue as int?;
                        selectedViTriTen = cbbChonViTri.Text;
                        cbbChonViTri.ForeColor = Color.Black;
                    }
                }
            }
            catch
            {
                selectedViTriId = null;
                selectedViTriTen = null;
                cbbChonViTri.ForeColor = Color.Gray;
            }
        }

        private void richTxtLyDo_Enter(object sender, EventArgs e)
        {
            if (richTxtLyDo.ForeColor == Color.Gray)
            {
                richTxtLyDo.Text = "";
                richTxtLyDo.ForeColor = Color.Black;
            }
        }

        private void richTxtLyDo_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(richTxtLyDo.Text))
            {
                richTxtLyDo.ForeColor = Color.Gray;
                richTxtLyDo.Text = "Lý do ứng tuyển:...";
            }
        }

        private void txtMaUV_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string maUngVien = txtMaUV.Text.Trim();
                string hoTen = txtHoTen.Text.Trim();
                string email = "";
                string soDienThoai = "";
                string cccd = txtCCCD.Text.Trim();

                currentUngVienList = ungVienService.SearchUngVien(maUngVien, hoTen, email, soDienThoai, cccd).ToList();
                RefreshDataGridViewUngVien();

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

        private void btnUngTuyen_Click(object sender, EventArgs e)
        {
            if (selectedUngVien == null)
            {
                MessageBox.Show("Vui lòng chọn ứng viên để ứng tuyển.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedTinTuyenDung == null)
            {
                MessageBox.Show("Vui lòng chọn một tin tuyển dụng để ứng tuyển.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hiển thị thông báo xác nhận
            string message = $"Bạn có chắc chắn muốn ghi nhận ứng viên:\n" +
                           $"Mã ứng viên: {selectedUngVien.UvId}\n" +
                           $"Họ tên: {selectedUngVien.HoTen}\n" +
                           $"CCCD: {selectedUngVien.Cccd}\n" +
                           $"ứng tuyển vào tin tuyển dụng này không?";

            var result = MessageBox.Show(message, "Xác nhận ứng tuyển", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Kiểm tra chọn vị trí ứng tuyển
                    var viTriDataSource = cbbChonViTri.DataSource as System.Collections.IList;
                    int soLuongViTriTrongTin = viTriDataSource != null ? viTriDataSource.Count : 0;
                    if (soLuongViTriTrongTin > 1)
                    {
                        if (selectedViTriId == null)
                        {
                            MessageBox.Show("Vui lòng chọn vị trí ứng tuyển trong danh sách.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else if (soLuongViTriTrongTin == 1 && selectedViTriId == null)
                    {
                        // Trường hợp đã bind auto nhưng chưa gán được giá trị
                        if (cbbChonViTri.SelectedItem is KeyValuePair<int, string> kv)
                        {
                            selectedViTriId = kv.Key;
                            selectedViTriTen = kv.Value;
                        }
                    }

                    // Tạo đối tượng ứng tuyển
                    var ungTuyen = new UngTuyen
                    {
                        UvId = selectedUngVien.UvId,
                        TinId = selectedTinTuyenDung.TinId,
                        TrangThai = "DA_NOP",
                        PhiId = 1,
                        DaThanhToanPhi = false,
                        NgayNop = DateTime.Now
                    };

                    // Ghi nhận ứng tuyển
                    int utId = ungTuyenService.GhiNhanUngTuyen(ungTuyen);

                    // Chuẩn bị dữ liệu phiếu TRƯỚC khi reset form (tránh mất lựa chọn và lý do)
                    string viTriUngTuyenTen = selectedViTriTen ?? string.Empty;
                    string lyDo;
                    try
                    {
                        // Nếu đang ở trạng thái placeholder (màu xám) thì coi như trống
                        lyDo = (richTxtLyDo.ForeColor == Color.Gray) ? string.Empty : (richTxtLyDo.Text?.Trim() ?? string.Empty);
                    }
                    catch { lyDo = string.Empty; }

                    MessageBox.Show("Ghi nhận ứng tuyển thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reset form
                    ClearForm();
                    SetFormState(false);
                    LoadDanhSachUngVien();

                    // Xuất phiếu ứng tuyển, truyền vị trí đã chọn và lý do (có thể trống)
                    var phieuForm = new PhieuUngTuyen_Form(utId, viTriUngTuyenTen, lyDo);
                    phieuForm.ShowDialog();
                }
                catch (BusinessException ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi nghiệp vụ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi ghi nhận ứng tuyển: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

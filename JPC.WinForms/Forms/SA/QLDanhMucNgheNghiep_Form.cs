using JPC.Business.Services.Implementations.SA;
using JPC.Business.Services.Interfaces.SA;
using JPC.Models.DanhMucNghe;
using System;
using Guna.UI2.WinForms;
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
        // Debounce timers cho ô tìm kiếm
        private System.Windows.Forms.Timer _debounceSearch1;
        private System.Windows.Forms.Timer _debounceSearch2;
        private System.Windows.Forms.Timer _debounceSearch3;
        private INhomNgheService _nhomNgheService;
        private INgheService _ngheService;
        private IViTriChuyenMonService _viTriChuyenMonService;

        // State cho tab Nhóm Nghề
        private bool _isEditMode = false;
        private int _selectedNhomNgheId = -1;
        private bool _isAddMode = false; // true: Thêm mới, false: Sửa

        // State cho tab Nghề
        private bool _isEditMode2 = false;
        private int _selectedNgheId = -1;
        private bool _isAddMode2 = false; // true: Thêm mới, false: Sửa

        // State cho tab Vị trí chuyên môn
        private bool _isEditMode3 = false;
        private int _selectedViTriId = -1;
        private bool _isAddMode3 = false; // true: Thêm mới, false: Sửa
        private bool _userChangingNhom3 = false; // chỉ thông báo khi người dùng đổi nhóm nghề

        public QLDanhMucNgheNghiep_Form()
        {
            InitializeComponent();
            InitializeServices(); // Khởi tạo các service
            LoadComboBoxData(); // Load dữ liệu cho ComboBox
            LoadDataNhomNghe(); // Load dữ liệu ban đầu (tab Nhóm nghề)
            SetupForm(); // Thiết lập form

            SetupResponsiveLayout(); // Thiết lập layout cho full screen

            // Khởi tạo debounce timers
            _debounceSearch1 = new System.Windows.Forms.Timer { Interval = 300 };
            _debounceSearch1.Tick += (s, e) => { _debounceSearch1.Stop(); ExecuteSearchTab1(); };
            _debounceSearch2 = new System.Windows.Forms.Timer { Interval = 300 };
            _debounceSearch2.Tick += (s, e) => { _debounceSearch2.Stop(); ExecuteSearchTab2(); };
            _debounceSearch3 = new System.Windows.Forms.Timer { Interval = 300 };
            _debounceSearch3.Tick += (s, e) => { _debounceSearch3.Stop(); ExecuteSearchTab3(); };
        }

        private void SetupResponsiveLayout()
        {
            // Title căn giữa và dock top
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            lblTieuDe.Dock = DockStyle.Top;
            lblTieuDe.Height = 60;
            lblTieuDe.AutoSize = false;

            // TabControl fill phần còn lại
            tabControlDanhMucNghe.Dock = DockStyle.Fill;

            // DataGridView trong các tab tự resize
            DGVNhomNghe.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            DGVNghe.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            DGVViTriChuyenMon.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

            // Panel chi tiết anchor bottom và full width
            panelNhomNghe.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            panelNghe.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            panelViTriChuyenMon.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

            // Textbox tìm kiếm anchor right
            txtTimKiemNhomNghe.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtTimKiemNghe.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtTimKiemViTriChuyenMon.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // Labels tìm kiếm anchor right
            lblTimKiem1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTimKiem2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTimKiem3.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // Buttons trong panel chi tiết anchor right
            btnLuu1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnHuy1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLuu2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnHuy2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLuu3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnHuy3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        }

        private void QLDanhMucNgheNghiep_Form_Load(object sender, EventArgs e)
        {

        }

        private void InitializeServices()
        {
            _nhomNgheService = new NhomNgheService();
            _ngheService = new NgheService();
            _viTriChuyenMonService = new ViTriChuyenMonService();
        }

        private void LoadComboBoxData()
        {
            // Load dữ liệu cho ComboBox Trạng thái tab 1
            cbTrangThai1.Items.Clear();
            cbTrangThai1.Items.Add("active");
            cbTrangThai1.Items.Add("inactive");
            cbTrangThai1.SelectedIndex = 0;

            // Load dữ liệu cho ComboBox Trạng thái tab 2
            cbTrangThai2.Items.Clear();
            cbTrangThai2.Items.Add("active");
            cbTrangThai2.Items.Add("inactive");
            cbTrangThai2.SelectedIndex = 0;
            // Load ComboBox Nhóm nghề cho tab 2
            LoadNhomNgheComboBox();

            // Load dữ liệu cho ComboBox Trạng thái tab 3
            cbTrangThai3.Items.Clear();
            cbTrangThai3.Items.Add("active");
            cbTrangThai3.Items.Add("inactive");
            cbTrangThai3.SelectedIndex = 0;
            // Load ComboBox cho tab 3
            LoadNhomNgheComboBox3();
            // Không load nghề khi chưa chọn nhóm nghề
            cbNghe3.DataSource = null;
            cbNghe3.Items.Clear();
            cbNghe3.Text = "";
            cbNghe3.Enabled = false;
        }




        private void tabControlDanhMucNghe_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Xóa text trong tất cả ô tìm kiếm khi chuyển tab
            txtTimKiemNhomNghe.Text = "";
            txtTimKiemNghe.Text = "";
            txtTimKiemViTriChuyenMon.Text = "";

            // Reload data khi chuyển tab để đảm bảo data mới nhất
            try
            {
                if (tabControlDanhMucNghe.SelectedIndex == 0) // Tab Nhóm nghề
                {
                    if (!_isEditMode) // Chỉ reload khi không đang edit
            {
                DataTable dt = _nhomNgheService.GetAllNhomNghe();
                DGVNhomNghe.DataSource = dt;
                    }
                }
                else if (tabControlDanhMucNghe.SelectedIndex == 1) // Tab Nghề
                {
                    if (!_isEditMode2) // Chỉ reload khi không đang edit
                    {
                        // Chỉ load khi chưa có data
                        if (DGVNghe.DataSource == null)
                        {
                            LoadDataNghe();
                        }
                        LoadNhomNgheComboBox(); // Refresh ComboBox

                        // Load chi tiết cho dòng đầu tiên nếu có dữ liệu
                        if (DGVNghe.Rows.Count > 0)
                        {
                            DataGridViewRow row = DGVNghe.Rows[0];
                            int ngheId = Convert.ToInt32(row.Cells["ID"].Value);
                            Nghe nghe = _ngheService.GetNgheById(ngheId);

                            if (nghe != null)
                            {
                                LoadNhomNgheComboBox2ForDisplay();
                                cbNhomNghe2.SelectedValue = nghe.NhomId;
                                txtNghe2.Text = nghe.TenNghe;
                                cbTrangThai2.Text = nghe.TrangThai;
                            }
                        }
                    }
                }
                else if (tabControlDanhMucNghe.SelectedIndex == 2) // Tab Vị trí chuyên môn
                {
                    if (!_isEditMode3) // Chỉ reload khi không đang edit
                    {
                        // Chỉ load khi chưa có data
                        if (DGVViTriChuyenMon.DataSource == null)
                        {
                            LoadDataViTriChuyenMon();
                        }

                        // Load chi tiết cho dòng đầu tiên nếu có dữ liệu (chỉ khi không ở chế độ Thêm/Sửa)
                        if (!_isAddMode3 && DGVViTriChuyenMon.Rows.Count > 0)
                        {
                            DataGridViewRow row = DGVViTriChuyenMon.Rows[0];
                            int vtId = Convert.ToInt32(row.Cells["ID"].Value);
                            ViTriChuyenMon viTri = _viTriChuyenMonService.GetViTriChuyenMonById(vtId);

                            if (viTri != null)
                            {
                                Nghe nghe = _ngheService.GetNgheById(viTri.NgheId);
                                if (nghe != null)
                                {
                                    LoadNhomNgheComboBox3ForDisplay();
                                    cbNhomNghe3.SelectedValue = nghe.NhomId;
                                    LoadNgheComboBoxByNhomForDisplay(nghe.NhomId);
                                    cbNghe3.SelectedValue = viTri.NgheId;
                                }
                                txtViTri3.Text = viTri.TenViTri;
                                cbTrangThai3.Text = viTri.TrangThai;
                            }
                        }
                        else
                        {
                            // Không load nghề khi chưa chọn nhóm nghề
                            cbNghe3.DataSource = null;
                            cbNghe3.Items.Clear();
                            cbNghe3.Text = "";
                            cbNghe3.Enabled = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }







        // ===============================================================================================
        #region SỰ CHUYÊN ĐỔI TRẠNG THÁI GIỮA THÊM/ SỬA VÀ KHÔNG THÊM/ SỬA
        private void SetupForm()
        {
            // Setup tab Nhóm nghề
            DGVNhomNghe.Enabled = true;
            SetPanelNhomNgheEnabled(false);
            btnLuu1.Visible = false;
            btnHuy1.Visible = false;
            txtNhomNghe1.ReadOnly = true;
            ResetFormNhomNghe();

            // Setup tab Nghề
            DGVNghe.Enabled = true;
            SetPanelNgheEnabled(false);
            btnLuu2.Visible = false;
            btnHuy2.Visible = false;
            txtNghe2.ReadOnly = true;
            ResetFormNghe();

            // Setup tab Vị trí chuyên môn
            DGVViTriChuyenMon.Enabled = true;
            SetPanelViTriEnabled(false);
            btnLuu3.Visible = false;
            btnHuy3.Visible = false;
            txtViTri3.ReadOnly = true;
            ResetFormViTri();
        }

        private void SetPanelNhomNgheEnabled(bool enabled)
        {
            txtNhomNghe1.ReadOnly = !enabled;
            cbTrangThai1.Enabled = enabled;

            // Lưu/Hủy hiện khi edit; ẩn khi bình thường
            btnLuu1.Visible = enabled;
            btnHuy1.Visible = enabled;

            // ẨN/HIỆN các thành phần còn lại theo yêu cầu khi Thêm/Sửa
            // (khi edit: ẩn Sửa, Tải lại, Tìm kiếm & nhãn tìm kiếm, Thêm)
            txtTimKiemNhomNghe.Visible = !enabled;
            lblTimKiem1.Visible = !enabled;
            btnSuaNhomNghe.Visible = !enabled;
            btnTaiLaiNhomNghe.Visible = !enabled;
            btnThemNhomNghe.Visible = !enabled;

            // Khóa lưới khi edit để không đổi chọn dòng
            DGVNhomNghe.Enabled = !enabled;

            // Đổi tiêu đề khu vực chi tiết
            if (enabled)
                lblChiTiet1.Text = _isAddMode ? "Thêm nhóm nghề mới"
                                             : $"Sửa nhóm nghề ID = {_selectedNhomNgheId}";
            else
                lblChiTiet1.Text = "Chi tiết";
        }

        private void SetPanelNgheEnabled(bool enabled)
        {
            txtNghe2.ReadOnly = !enabled;
            cbNhomNghe2.Enabled = enabled;
            cbTrangThai2.Enabled = enabled;

            // Lưu/Hủy hiện khi edit; ẩn khi bình thường
            btnLuu2.Visible = enabled;
            btnHuy2.Visible = enabled;

            // ẨN/HIỆN các thành phần
            txtTimKiemNghe.Visible = !enabled;
            lblTimKiem2.Visible = !enabled;
            btnSuaNghe.Visible = !enabled;
            btnTaiLaiNghe.Visible = !enabled;
            btnThemNghe.Visible = !enabled;

            // Khóa lưới khi edit
            DGVNghe.Enabled = !enabled;

            // Đổi tiêu đề
            if (enabled)
                lblChiTiet2.Text = _isAddMode2 ? "Thêm nghề mới"
                                              : $"Sửa nghề ID = {_selectedNgheId}";
            else
                lblChiTiet2.Text = "Chi tiết";
        }

        private void SetPanelViTriEnabled(bool enabled)
        {
            txtViTri3.ReadOnly = !enabled;
            cbNhomNghe3.Enabled = enabled;
            // ComboBox nghề chỉ enable khi đang edit và đã chọn nhóm nghề
            if (enabled)
            {
                cbNghe3.Enabled = cbNhomNghe3.SelectedIndex >= 0;
            }
            else
            {
                cbNghe3.Enabled = false;
            }
            cbTrangThai3.Enabled = enabled;

            // Lưu/Hủy hiện khi edit; ẩn khi bình thường
            btnLuu3.Visible = enabled;
            btnHuy3.Visible = enabled;

            // ẨN/HIỆN các thành phần còn lại theo yêu cầu khi Thêm/Sửa
            txtTimKiemViTriChuyenMon.Visible = !enabled;
            lblTimKiem3.Visible = !enabled;
            btnSuaViTriChuyenMon.Visible = !enabled;
            btnTaiLaiViTriChuyenMon.Visible = !enabled;
            btnThemViTriChuyenMon.Visible = !enabled;

            // Khóa lưới khi edit để không đổi chọn dòng
            DGVViTriChuyenMon.Enabled = !enabled;

            // Đổi tiêu đề khu vực chi tiết
            if (enabled)
            {
                if (_isAddMode3)
                {
                    lblChiTiet3.Text = "Thêm vị trí chuyên môn mới";
                }
                else
                {
                    lblChiTiet3.Text = _selectedViTriId > 0
                        ? $"Sửa vị trí chuyên môn ID = {_selectedViTriId}"
                        : "Sửa vị trí chuyên môn"; // không hiện ID âm/0
                }
            }
            else
                lblChiTiet3.Text = "Chi tiết";
        }

        private void ResetFormNhomNghe()
        {
            txtNhomNghe1.Clear();
            // Kiểm tra ComboBox có items không trước khi set SelectedIndex
            if (cbTrangThai1.Items.Count > 0)
            {
                cbTrangThai1.SelectedIndex = 0; // Mặc định "Active"
            }
            _isEditMode = false;
            _isAddMode = false;
            _selectedNhomNgheId = -1;
            SetPanelNhomNgheEnabled(false);
        }

        private void ResetFormNghe()
        {
            txtNghe2.Clear();
            cbNhomNghe2.SelectedIndex = -1;
            if (cbTrangThai2.Items.Count > 0)
            {
                cbTrangThai2.SelectedIndex = 0; //Mặc định "Active"
            }

            _isEditMode2 = false;
            _selectedNgheId = -1;
            _isAddMode2 = false;
            SetPanelNgheEnabled(false);
        }

        private void ResetFormViTri()
        {
            txtViTri3.Clear();
            cbNhomNghe3.SelectedIndex = -1;
            cbNghe3.DataSource = null;
            cbNghe3.Items.Clear();
            cbNghe3.Text = "";
            cbNghe3.Enabled = false;
            if (cbTrangThai3.Items.Count > 0)
            {
                cbTrangThai3.SelectedIndex = 0; // Mặc định "Active"
            }
            _isEditMode3 = false;
            _isAddMode3 = false;
            _selectedViTriId = -1;
            SetPanelViTriEnabled(false);
        }
        #endregion
        // ===============================================================================================







        // ===============================================================================================
        #region TAB 1: NHÓM NGHỀ
        private void LoadDataNhomNghe()
        {
            try
            {
                // Chỉ load Tab 1 (tab đầu tiên)
                DataTable dt = _nhomNgheService.GetAllNhomNghe();
                DGVNhomNghe.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemNhomNghe_Click(object sender, EventArgs e)
        {
            _isAddMode = true;
            _isEditMode = true;
            _selectedNhomNgheId = -1;

            // Clear detail và set mặc định
            txtNhomNghe1.Clear();
            if (cbTrangThai1.Items.Count > 0) cbTrangThai1.SelectedIndex = 0;

            // Vào edit mode: ẩn Sửa/Tải/Tìm kiếm, hiện Lưu/Hủy, đổi lblChiTiet
            SetPanelNhomNgheEnabled(true);
            txtNhomNghe1.Focus();
            DGVNhomNghe.ClearSelection();
        }

        private void btnSuaNhomNghe_Click(object sender, EventArgs e)
        {
            if (DGVNhomNghe.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhóm nghề cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _isEditMode = true;
            _isAddMode = false; // Đánh dấu đang Sửa
            _selectedNhomNgheId = Convert.ToInt32(DGVNhomNghe.SelectedRows[0].Cells["ID"].Value);

            try
            {
                NhomNghe nhomNghe = _nhomNgheService.GetNhomNgheById(_selectedNhomNgheId);
                if (nhomNghe != null)
                {
                    txtNhomNghe1.Text = nhomNghe.TenNhom;
                    cbTrangThai1.Text = nhomNghe.TrangThai;
                    SetPanelNhomNgheEnabled(true);
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
            LoadDataNhomNghe();
            LoadNhomNgheComboBox(); // Refresh ComboBox cho tab Nghề
            txtTimKiemNhomNghe.Clear();
            _isEditMode = false; // Reset chế độ edit
            ResetFormNhomNghe();
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

                string actionText = _isAddMode
                    ? "Bạn có chắc muốn THÊM nhóm nghề này?"
                    : $"Bạn có chắc muốn CẬP NHẬT nhóm nghề ID = {_selectedNhomNgheId}?";
                var confirm = MessageBox.Show(actionText, "Xác nhận",
                                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (confirm != DialogResult.OK) return;

                if (_isAddMode) // ĐANG THÊM MỚI
                {
                    success = _nhomNgheService.InsertNhomNghe(nhomNghe);
                    message = success ? "Thêm nhóm nghề thành công" : "Thêm nhóm nghề thất bại";
                }
                else            // ĐANG SỬA
                {
                    nhomNghe.NhomId = _selectedNhomNgheId;
                    success = _nhomNgheService.UpdateNhomNghe(nhomNghe);
                    message = success ? "Cập nhật nhóm nghề thành công" : "Cập nhật nhóm nghề thất bại";
                }

                if (success)
                {
                    MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataNhomNghe();
                    LoadNhomNgheComboBox(); // Refresh ComboBox cho tab Nghề
                    LoadNhomNgheComboBox3(); // Refresh ComboBox cho tab Vị trí chuyên môn
                    ResetFormNhomNghe();
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
            _isAddMode = false;
            _isEditMode = false; // Reset edit mode
            ResetFormNhomNghe();
        }

        private void txtTimKiemNhomNghe_TextChanged(object sender, EventArgs e)
        {
            _debounceSearch1.Stop();
            _debounceSearch1.Start();
        }

        private void ExecuteSearchTab1()
        {
            try
            {
                string keyword = txtTimKiemNhomNghe.Text.Trim();
                DataTable dt = string.IsNullOrEmpty(keyword)
                    ? _nhomNgheService.GetAllNhomNghe()
                    : _nhomNgheService.SearchNhomNghe(keyword);
                DGVNhomNghe.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGVNhomNghe_SelectionChanged(object sender, EventArgs e)
        {
            if (_isEditMode) return;
            var row = DGVNhomNghe.CurrentRow;
            if (row == null || row.IsNewRow) return;
            var tenNhom = row.Cells["Tên nhóm"].Value?.ToString() ?? string.Empty;
            var trangThai = row.Cells["Trạng thái"].Value?.ToString() ?? string.Empty;
            txtNhomNghe1.Text = tenNhom;
            cbTrangThai1.Text = trangThai;
        }
        #endregion
        // ===============================================================================================







        // ===============================================================================================
        #region TAB 2: NGHỀ
        private void LoadDataNghe()
        {
            try
            {
                DataTable dt = _ngheService.GetAllNghe();
                DGVNghe.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu nghề: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadNhomNgheComboBox2ForDisplay()
        {
            try
            {
                DataTable dt = _nhomNgheService.GetAllNhomNghe(); // Lấy tất cả (active + inactive) cho hiển thị
                cbNhomNghe2.DataSource = dt;
                cbNhomNghe2.DisplayMember = "Tên nhóm";
                cbNhomNghe2.ValueMember = "ID";
                cbNhomNghe2.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải nhóm nghề: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadNhomNgheComboBox()
        {
            try
            {
                DataTable dt = _nhomNgheService.GetActiveNhomNghe(); // Chỉ lấy active
                cbNhomNghe2.DataSource = dt;
                cbNhomNghe2.DisplayMember = "Tên nhóm";
                cbNhomNghe2.ValueMember = "ID";
                cbNhomNghe2.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải nhóm nghề: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemNghe_Click(object sender, EventArgs e)
        {
            _isAddMode2 = true;
            _isEditMode2 = true;
            _selectedNgheId = -1;

            // Load ComboBox nhóm nghề với chỉ active cho thêm mới
            LoadNhomNgheComboBox();

            txtNghe2.Clear();
            cbNhomNghe2.SelectedIndex = -1;
            if (cbTrangThai2.Items.Count > 0) cbTrangThai2.SelectedIndex = 0;

            SetPanelNgheEnabled(true);
            cbNhomNghe2.Focus();
            DGVNghe.ClearSelection();
        }

        private void btnSuaNghe_Click(object sender, EventArgs e)
        {
            if (DGVNghe.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nghề cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _isEditMode2 = true;
            _isAddMode2 = false;
            _selectedNgheId = Convert.ToInt32(DGVNghe.SelectedRows[0].Cells["ID"].Value);

            try
            {
                Nghe nghe = _ngheService.GetNgheById(_selectedNgheId);
                if (nghe != null)
                {
                    // Kiểm tra trạng thái của nhóm nghề
                    NhomNghe nhomNghe = _nhomNgheService.GetNhomNgheById(nghe.NhomId);
                    if (nhomNghe != null && nhomNghe.TrangThai.ToLower() == "inactive")
                    {
                        MessageBox.Show("Không thể sửa nghề này vì nhóm nghề đã bị vô hiệu hóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        btnTaiLaiNghe_Click(sender, e); // Dùng nút tải lại
                        return;
                    }

                    cbNhomNghe2.SelectedValue = nghe.NhomId;
                    txtNghe2.Text = nghe.TenNghe;
                    cbTrangThai2.Text = nghe.TrangThai;
                    SetPanelNgheEnabled(true);
                    txtNghe2.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin nghề: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTaiLaiNghe_Click(object sender, EventArgs e)
        {
            LoadDataNghe();
            LoadNhomNgheComboBox(); // Reload ComboBox với chỉ active items
            txtTimKiemNghe.Clear();
            _isEditMode2 = false; // Reset chế độ edit
            ResetFormNghe();
        }

        private void btnLuu2_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (cbNhomNghe2.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn nhóm nghề", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbNhomNghe2.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNghe2.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên nghề", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNghe2.Focus();
                    return;
                }

                string actionText = _isAddMode2
                    ? "Bạn có chắc muốn THÊM nghề này?"
                    : $"Bạn có chắc muốn CẬP NHẬT nghề ID = {_selectedNgheId}?";
                var confirm = MessageBox.Show(actionText, "Xác nhận",
                                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (confirm != DialogResult.OK) return;

                Nghe nghe = new Nghe
                {
                    NhomId = Convert.ToInt32(cbNhomNghe2.SelectedValue),
                    TenNghe = txtNghe2.Text.Trim(),
                    TrangThai = cbTrangThai2.Text
                };

                bool success = false;
                string message = "";

                if (_isAddMode2)
                {
                    success = _ngheService.InsertNghe(nghe);
                    message = success ? "Thêm nghề thành công" : "Thêm nghề thất bại";
                }
                else
                {
                    nghe.NgheId = _selectedNgheId;
                    success = _ngheService.UpdateNghe(nghe);
                    message = success ? "Cập nhật nghề thành công" : "Cập nhật nghề thất bại";
                }

                if (success)
                {
                    MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataNghe();
                    // Refresh ComboBox nghề trong tab Vị trí chuyên môn nếu đang chọn nhóm nghề
                    if (cbNhomNghe3.SelectedIndex >= 0)
                    {
                        int nhomId = Convert.ToInt32(((DataRowView)cbNhomNghe3.SelectedItem)["ID"]);
                        // Nếu đang trong edit mode thì load chỉ active, nếu không thì load tất cả
                        if (_isEditMode3)
                        {
                            LoadNgheComboBoxByNhom(nhomId); // Chỉ active cho edit
                        }
                        else
                        {
                            LoadNgheComboBoxByNhomForDisplay(nhomId); // Tất cả cho display
                        }
                    }
                    ResetFormNghe();
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

        private void btnHuy2_Click(object sender, EventArgs e)
        {
            _isAddMode2 = false;
            _isEditMode2 = false; // Reset edit mode
            ResetFormNghe();
        }

        private void txtTimKiemNghe_TextChanged(object sender, EventArgs e)
        {
            _debounceSearch2.Stop();
            _debounceSearch2.Start();
        }

        private void ExecuteSearchTab2()
        {
            try
            {
                string keyword = txtTimKiemNghe.Text.Trim();
                DataTable dt = string.IsNullOrEmpty(keyword)
                    ? _ngheService.GetAllNghe()
                    : _ngheService.SearchNghe(keyword);
                DGVNghe.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGVNghe_SelectionChanged(object sender, EventArgs e)
        {
            if (_isEditMode2) return;
            var row = DGVNghe.CurrentRow;
            if (row == null || row.IsNewRow) return;

            // Load tất cả nhóm nghề (active + inactive) để hiển thị chi tiết
            LoadNhomNgheComboBox2ForDisplay();

            var nhom = row.Cells["Nhóm nghề"].Value?.ToString() ?? string.Empty;
            var ten = row.Cells["Tên nghề"].Value?.ToString() ?? string.Empty;
            var tt = row.Cells["Trạng thái"].Value?.ToString() ?? string.Empty;
            cbNhomNghe2.Text = nhom;
            txtNghe2.Text = ten;
            cbTrangThai2.Text = tt;
        }
        #endregion
        // ===============================================================================================







        // ===============================================================================================
        #region TAB 3: VỊ TRÍ CHUYÊN MÔN
        private void LoadDataViTriChuyenMon()
        {
            try
            {
                DataTable dt = _viTriChuyenMonService.GetAllViTriChuyenMon();
                DGVViTriChuyenMon.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu vị trí chuyên môn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadNhomNgheComboBox3()
        {
            try
            {
                DataTable dt = _nhomNgheService.GetActiveNhomNghe(); // Chỉ lấy nhóm nghề active
                cbNhomNghe3.DataSource = dt;
                cbNhomNghe3.DisplayMember = "Tên nhóm";
                cbNhomNghe3.ValueMember = "ID";
                cbNhomNghe3.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách nhóm nghề: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadNhomNgheComboBox3ForDisplay()
        {
            try
            {
                // Load TẤT CẢ nhóm nghề (cả active và inactive) để hiển thị chi tiết
                DataTable dt = _nhomNgheService.GetAllNhomNghe();
                cbNhomNghe3.DataSource = dt;
                cbNhomNghe3.DisplayMember = "Tên nhóm";
                cbNhomNghe3.ValueMember = "ID";
                cbNhomNghe3.Enabled = false; // Disable khi xem chi tiết
            }
            catch (Exception ex)
            {
                // Ignore lỗi khi load cho display
                cbNhomNghe3.DataSource = null;
                cbNhomNghe3.Items.Clear();
                cbNhomNghe3.Text = "";
                cbNhomNghe3.Enabled = false;
            }
        }

        private void LoadNgheComboBoxByNhom(int nhomId)
        {
            try
            {
                DataTable dt = _ngheService.GetActiveNgheByNhomId(nhomId); // Lấy nghề theo nhóm nghề

                if (dt.Rows.Count == 0)
                {
                    // Không có nghề nào trong nhóm nghề này
                    cbNghe3.DataSource = null;
                    cbNghe3.Items.Clear();
                    cbNghe3.Text = "";
                    cbNghe3.Enabled = false;
                    // Chỉ hiển thị thông báo khi người dùng chủ động đổi nhóm
                    if (_userChangingNhom3)
                        MessageBox.Show("Nhóm nghề này không có nghề nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                cbNghe3.DataSource = dt;
                cbNghe3.DisplayMember = "Tên nghề";
                cbNghe3.ValueMember = "ID";
                cbNghe3.SelectedIndex = -1;
                // Enable ComboBox nghề khi đang trong chế độ edit
                cbNghe3.Enabled = _isEditMode3;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách nghề theo nhóm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadNgheComboBoxByNhomForDisplay(int nhomId)
        {
            try
            {
                // Load TẤT CẢ nghề (cả active và inactive) để hiển thị chi tiết
                DataTable allNghe = _ngheService.GetAllNgheForDisplay();

                // Filter theo nhóm nghề
                var filteredRows = allNghe.AsEnumerable()
                    .Where(r => Convert.ToInt32(r["Nhóm nghề ID"]) == nhomId);

                if (filteredRows.Any())
                {
                    var filteredNghe = filteredRows.CopyToDataTable();
                    cbNghe3.DataSource = filteredNghe;
                    cbNghe3.DisplayMember = "Tên nghề";
                    cbNghe3.ValueMember = "ID";
                    cbNghe3.Enabled = false; // Disable khi xem chi tiết
                }
                else
                {
                    // Không có nghề nào - chỉ clear ComboBox
                    cbNghe3.DataSource = null;
                    cbNghe3.Items.Clear();
                    cbNghe3.Text = "";
                    cbNghe3.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                // Ignore lỗi khi load cho display
                cbNghe3.DataSource = null;
                cbNghe3.Items.Clear();
                cbNghe3.Text = "";
                cbNghe3.Enabled = false;
            }
        }

        private void btnThemViTriChuyenMon_Click(object sender, EventArgs e)
        {
            _isAddMode3 = true;
            _isEditMode3 = true;
            _selectedViTriId = -1;

            // Clear nhẹ, KHÔNG reset trạng thái enable
            txtViTri3.Clear();
            if (cbTrangThai3.Items.Count > 0) cbTrangThai3.SelectedIndex = 0;
            // Reset nhóm/nghề về trống để tránh tự đổ từ grid
            cbNhomNghe3.DataSource = null;
            cbNhomNghe3.Items.Clear();
            cbNhomNghe3.Text = "";
            cbNhomNghe3.SelectedIndex = -1;
            cbNhomNghe3.Enabled = true;
            cbNghe3.DataSource = null;
            cbNghe3.Items.Clear();
            cbNghe3.Text = "";
            cbNghe3.Enabled = false; // chờ chọn nhóm

            // Load ComboBox nhóm nghề với chỉ active cho thêm mới (không phát sinh thông báo)
            _userChangingNhom3 = false;
            LoadNhomNgheComboBox3();
            _userChangingNhom3 = true; // từ giờ trở đi coi là thao tác người dùng

            SetPanelViTriEnabled(true);
            DGVViTriChuyenMon.ClearSelection();
            lblChiTiet3.Text = "Thêm vị trí chuyên môn mới";
            cbNhomNghe3.Focus();
        }

        private void btnSuaViTriChuyenMon_Click(object sender, EventArgs e)
        {
            if (DGVViTriChuyenMon.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn vị trí chuyên môn cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _isEditMode3 = true;
            _isAddMode3 = false;
            _selectedViTriId = Convert.ToInt32(DGVViTriChuyenMon.SelectedRows[0].Cells["ID"].Value);

            try
            {
                ViTriChuyenMon viTri = _viTriChuyenMonService.GetViTriChuyenMonById(_selectedViTriId);
                if (viTri != null)
                {
                    // Cần lấy nhóm nghề từ nghề để set ComboBox nhóm nghề
                    Nghe nghe = _ngheService.GetNgheById(viTri.NgheId);
                    if (nghe != null)
                    {
                        // Kiểm tra trạng thái của nghề và nhóm nghề
                        if (nghe.TrangThai.ToLower() == "inactive")
                        {
                            MessageBox.Show("Không thể sửa vị trí chuyên môn này vì nghề đã bị vô hiệu hóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            btnTaiLaiViTriChuyenMon_Click(sender, e); // Dùng nút tải lại
                            return;
                        }

                        // Kiểm tra trạng thái của nhóm nghề
                        NhomNghe nhomNghe = _nhomNgheService.GetNhomNgheById(nghe.NhomId);
                        if (nhomNghe != null && nhomNghe.TrangThai.ToLower() == "inactive")
                        {
                            MessageBox.Show("Không thể sửa vị trí chuyên môn này vì nhóm nghề đã bị vô hiệu hóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            btnTaiLaiViTriChuyenMon_Click(sender, e); // Dùng nút tải lại
                            return;
                        }

                        // Set ComboBox nhóm nghề bằng SelectedValue (nhanh hơn)
                        cbNhomNghe3.SelectedValue = nghe.NhomId;

                        LoadNgheComboBoxByNhom(nghe.NhomId);

                        // Set ComboBox nghề bằng SelectedValue (nhanh hơn)
                        cbNghe3.SelectedValue = viTri.NgheId;
                    }
                    txtViTri3.Text = viTri.TenViTri;
                    cbTrangThai3.Text = viTri.TrangThai;
                    SetPanelViTriEnabled(true);
                    txtViTri3.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin vị trí chuyên môn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTaiLaiViTriChuyenMon_Click(object sender, EventArgs e)
        {
            LoadDataViTriChuyenMon();
            txtTimKiemViTriChuyenMon.Clear();
            _isEditMode3 = false; // Reset chế độ edit
            ResetFormViTri();
            // Load lại ComboBox nhóm nghề sau khi reset
            LoadNhomNgheComboBox3();
        }

        private void btnLuu3_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (cbNghe3.SelectedIndex < 0)
                {
                    MessageBox.Show("Vui lòng chọn nghề", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbNghe3.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtViTri3.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên vị trí chuyên môn", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtViTri3.Focus();
                    return;
                }

                string actionText = _isAddMode3 ? "Bạn có chắc muốn THÊM vị trí chuyên môn này?" : $"Bạn có chắc muốn CẬP NHẬT vị trí chuyên môn ID = {_selectedViTriId}?";
                var confirm = MessageBox.Show(actionText, "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (confirm != DialogResult.OK) return;

                // Lấy giá trị từ DataRowView
                DataRowView ngheRow = (DataRowView)cbNghe3.SelectedItem;
                int ngheId = Convert.ToInt32(ngheRow["ID"]);

                ViTriChuyenMon viTri = new ViTriChuyenMon
                {
                    NgheId = ngheId,
                    TenViTri = txtViTri3.Text.Trim(),
                    TrangThai = cbTrangThai3.Text
                };

                bool success = false;
                string message = "";

                if (_isAddMode3)
                {
                    success = _viTriChuyenMonService.InsertViTriChuyenMon(viTri);
                    message = success ? "Thêm vị trí chuyên môn thành công" : "Thêm vị trí chuyên môn thất bại";
                }
                else
                {
                    viTri.VtId = _selectedViTriId;
                    success = _viTriChuyenMonService.UpdateViTriChuyenMon(viTri);
                    message = success ? "Cập nhật vị trí chuyên môn thành công" : "Cập nhật vị trí chuyên môn thất bại";
                }

                if (success)
                {
                    MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataViTriChuyenMon();
                    ResetFormViTri();
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

        private void btnHuy3_Click(object sender, EventArgs e)
        {
            _isAddMode3 = false;
            _isEditMode3 = false; // Reset chế độ edit
            ResetFormViTri();
        }

        private void txtTimKiemViTriChuyenMon_TextChanged(object sender, EventArgs e)
        {
            _debounceSearch3.Stop();
            _debounceSearch3.Start();
        }

        private void ExecuteSearchTab3()
        {
            try
            {
                string keyword = txtTimKiemViTriChuyenMon.Text.Trim();
                DataTable dt = string.IsNullOrEmpty(keyword)
                    ? _viTriChuyenMonService.GetAllViTriChuyenMon()
                    : _viTriChuyenMonService.SearchViTriChuyenMon(keyword);
                DGVViTriChuyenMon.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGVViTriChuyenMon_SelectionChanged(object sender, EventArgs e)
        {
            // Khi đang thêm/sửa, không cho grid ảnh hưởng panel chi tiết
            if (_isEditMode3 || _isAddMode3) return;
            var row = DGVViTriChuyenMon.CurrentRow;
            if (row == null || row.IsNewRow) return;

            if (row.Cells["ID"].Value == null) return;
            int vtId;
            if (!int.TryParse(row.Cells["ID"].Value.ToString(), out vtId)) return;

            ViTriChuyenMon viTri = _viTriChuyenMonService.GetViTriChuyenMonById(vtId);
            if (viTri == null) return;

            Nghe nghe = _ngheService.GetNgheById(viTri.NgheId);
            if (nghe != null)
            {
                // Load TẤT CẢ nhóm nghề để có thể hiển thị đúng (dù inactive)
                LoadNhomNgheComboBox3ForDisplay();
                cbNhomNghe3.SelectedValue = nghe.NhomId;
                // Load ComboBox nghề theo nhóm nghề (TẤT CẢ nghề cho display)
                LoadNgheComboBoxByNhomForDisplay(nghe.NhomId);
                cbNghe3.SelectedValue = viTri.NgheId;
            }

            txtViTri3.Text = viTri.TenViTri;
            cbTrangThai3.Text = viTri.TrangThai;
        }

        private void cbNhomNghe3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNhomNghe3.SelectedIndex >= 0)
            {
                try
                {
                    // Lấy giá trị từ DataRowView
                    DataRowView row = (DataRowView)cbNhomNghe3.SelectedItem;
                    int nhomId = Convert.ToInt32(row["ID"]);

                    // Nếu đang trong edit mode thì load chỉ active, nếu không thì load tất cả
                    if (_isEditMode3)
                    {
                        LoadNgheComboBoxByNhom(nhomId); // Chỉ active cho edit
                    }
                    else
                    {
                        LoadNgheComboBoxByNhomForDisplay(nhomId); // Tất cả cho display
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi chọn nhóm nghề: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Không chọn nhóm nghề thì disable ComboBox nghề
                cbNghe3.DataSource = null;
                cbNghe3.Items.Clear();
                cbNghe3.Text = "";
                cbNghe3.Enabled = false;
            }
        }
        #endregion
        // ===============================================================================================
    }
}

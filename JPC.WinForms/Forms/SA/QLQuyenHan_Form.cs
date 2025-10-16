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
    public partial class QLQuyenHan_Form : Form
    {
        private const int HeaderMinHeight = 60;
        private const int HeaderPadding = 12;

        private bool _isEditMode = false;
        private IQuyenHanChucNangService _service = new QuyenHanChucNangService();

        private DataTable _rawMatrix; // VaiTroId, VaiTro, ChucNangId, ChucNang, MoTa, QuyenHan, MapExists
        private DataTable _pivotTable; // DGV bind
        private List<string> _roleIds = new List<string>();
        private Dictionary<string, string> _roleIdToName = new Dictionary<string, string>();
        private Dictionary<(string roleId, string funcId), bool> _original = new Dictionary<(string, string), bool>();
        private Dictionary<(string roleId, string funcId), bool> _changes = new Dictionary<(string, string), bool>();
        private Dictionary<string, string> _funcIdToDescription = new Dictionary<string, string>();
        private HashSet<(string roleId, string funcId)> _unavailable = new HashSet<(string, string)>();

        public QLQuyenHan_Form()
        {
            InitializeComponent();
            SetupResponsiveLayout();
            AdjustHeaderLayout();
            this.Resize += (s, e) => { AdjustHeaderLayout(); AdjustDetailLayout(); };

            // Double buffer cho DGV để cuộn mượt
            try
            {
                typeof(DataGridView).InvokeMember("DoubleBuffered",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty,
                    null, DGVQuyenHan, new object[] { true });
            }
            catch { }
        }

        private void QLQuyenHan_Form_Load(object sender, EventArgs e)
        {
            LoadMatrix();
            SetEditMode(false);
        }

        private void SetupResponsiveLayout()
        {
            // Header dock top
            panelHeader.Dock = DockStyle.Top;

            // Khu lưới chiếm phần giữa
            panelDGV.Dock = DockStyle.Fill;
            DGVQuyenHan.Dock = DockStyle.Fill;

            // Panel chi tiết dock bottom
            panelChiTiet.Dock = DockStyle.Bottom;
            if (panelChiTiet.Height < 220) panelChiTiet.Height = 200;

            // Bên trong chi tiết: input bám trái
            txtVaiTro.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            txtChucNang.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            txtMoTaChucNang.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbTrangThai.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            // Panel chi tiết chỉ hiển thị (READ-ONLY)
            try { txtVaiTro.ReadOnly = true; txtChucNang.ReadOnly = true; txtMoTaChucNang.ReadOnly = true; cbTrangThai.Enabled = false; } catch { }

            // Tránh panel chi tiết che hàng cuối: chèn padding đáy cho vùng DGV bằng chiều cao panel chi tiết
            try
            {
                panelDGV.Padding = new Padding(panelDGV.Padding.Left, panelDGV.Padding.Top, panelDGV.Padding.Right, panelChiTiet.Height + 8);
                panelChiTiet.SizeChanged += (s, e) => {
                    panelDGV.Padding = new Padding(panelDGV.Padding.Left, panelDGV.Padding.Top, panelDGV.Padding.Right, panelChiTiet.Height + 8);
                };
            }
            catch { }

            // Nút bám phải trong header
            btnSua.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLuu.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnHuy.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // Căn chi tiết lúc khởi tạo
            AdjustDetailLayout();
        }

        private void AdjustHeaderLayout()
        {
            if (panelHeader == null || lblTieuDe == null) return;
            int padding = HeaderPadding;
            // Tiêu đề ở trên
            lblTieuDe.Left = (panelHeader.ClientSize.Width - lblTieuDe.Width) / 2;
            lblTieuDe.Top = 0;

            int toolbarTop = lblTieuDe.Bottom + 6;
            btnSua.Top = toolbarTop;
            btnLuu.Top = toolbarTop;
            btnHuy.Top = toolbarTop;

            // Căn phải bộ nút: Hủy (ngoài cùng phải) – Lưu – Sửa (bên trái)
            int rightEdge = panelHeader.ClientSize.Width - padding;
            btnHuy.Left = rightEdge - btnHuy.Width;
            btnLuu.Left = btnHuy.Left - 12 - btnLuu.Width;
            btnSua.Left = btnLuu.Left - 12 - btnSua.Width;

            int desired = toolbarTop + btnSua.Height + padding;
            if (desired < HeaderMinHeight) desired = HeaderMinHeight;
            panelHeader.Height = desired;
        }

        private void AdjustDetailLayout()
        {
            if (panelChiTiet == null) return;
            int padding = 16;
            int gap = 16;
            int baseTop = 42; // phía dưới tiêu đề "Chi tiết thông tin"
            int labelGap = 6;

            int w = panelChiTiet.ClientSize.Width - padding * 2 - 5;
            if (w <= 100) return;
            int colW = (w - gap * 2) / 3;
            int col1X = padding;
            int col2X = col1X + colW + gap;
            int col3X = col2X + colW + gap;

            // Đặt label hàng 1
            if (lblVaiTro != null) { lblVaiTro.Left = col1X; lblVaiTro.Top = baseTop; }
            if (lblChucNang != null) { lblChucNang.Left = col2X; lblChucNang.Top = baseTop; }
            if (lblTrangThai != null) { lblTrangThai.Left = col3X; lblTrangThai.Top = baseTop; }

            int inputTop = baseTop + (lblVaiTro?.Height ?? 24) + labelGap;
            int inputH = txtVaiTro?.Height > 0 ? txtVaiTro.Height : 34;

            if (txtVaiTro != null) { txtVaiTro.Left = col1X; txtVaiTro.Top = inputTop; txtVaiTro.Width = colW; txtVaiTro.Height = inputH; }
            if (txtChucNang != null) { txtChucNang.Left = col2X; txtChucNang.Top = inputTop; txtChucNang.Width = colW; txtChucNang.Height = inputH; }
            if (cbTrangThai != null) { cbTrangThai.Left = col3X; cbTrangThai.Top = inputTop; cbTrangThai.Width = colW; }

            // Hàng mô tả full width
            int row2Top = inputTop + inputH + 16;
            if (lblMoTa != null) { lblMoTa.Left = col1X; lblMoTa.Top = row2Top; }
            int moTaTop = row2Top + (lblMoTa?.Height ?? 24) + labelGap;
            if (txtMoTaChucNang != null)
            {
                txtMoTaChucNang.Left = col1X;
                txtMoTaChucNang.Top = moTaTop;
                txtMoTaChucNang.Width = w;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SetEditMode(true);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (_changes.Count == 0)
                {
                    SetEditMode(false);
                    return;
                }

                var confirm = MessageBox.Show($"Bạn có muốn lưu {_changes.Count} thay đổi quyền hạn?", "Xác nhận",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (confirm != DialogResult.OK) return;

                // Lưu lần lượt các thay đổi
                foreach (var kv in _changes)
                {
                    string roleId = kv.Key.roleId;
                    string funcId = kv.Key.funcId;
                    bool val = kv.Value;
                    bool ok = _service.UpsertPermission(roleId, funcId, val);
                    if (!ok)
                    {
                        MessageBox.Show($"Lưu thất bại tại {roleId} - {funcId}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _original[(roleId, funcId)] = val; // cập nhật gốc
                }

                // Reset màu vàng và badge nút Lưu
                foreach (DataGridViewRow row in DGVQuyenHan.Rows)
                {
                    for (int i = 2; i < DGVQuyenHan.Columns.Count; i++)
                    {
                        row.Cells[i].Style.BackColor = DGVQuyenHan.DefaultCellStyle.BackColor;
                        // Clear override để dùng màu selection mặc định sau khi thoát edit
                        row.Cells[i].Style.SelectionBackColor = Color.Empty;
                        row.Cells[i].Style.SelectionForeColor = Color.Empty;
                    }
                }
                _changes.Clear();
                btnLuu.Text = "Lưu";

                MessageBox.Show("Cập nhật quyền hạn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetEditMode(false);

                // Sau khi thoát edit, đồng bộ lại selection về mặc định
                foreach (DataGridViewRow row in DGVQuyenHan.Rows)
                {
                    for (int i = 2; i < DGVQuyenHan.Columns.Count; i++)
                    {
                        row.Cells[i].Style.SelectionBackColor = Color.Empty;
                        row.Cells[i].Style.SelectionForeColor = Color.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Hủy toàn bộ thay đổi tạm
            RevertChanges();
            SetEditMode(false);
        }

        private void LoadMatrix()
        {
            try
            {
                _rawMatrix = _service.GetRolePermissionMatrix();
                BuildPivot();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải ma trận: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuildPivot()
        {
            _changes.Clear();
            _original.Clear();
            _roleIds = _rawMatrix.AsEnumerable()
                .Select(r => Convert.ToString(r["VaiTroId"]))
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            _roleIdToName = _rawMatrix.AsEnumerable()
                .GroupBy(r => Convert.ToString(r["VaiTroId"]))
                .ToDictionary(g => g.Key, g => Convert.ToString(g.First()["VaiTro"]));

            _pivotTable = new DataTable();
            _pivotTable.Columns.Add("ChucNangId", typeof(string));
            _pivotTable.Columns.Add("ChucNang", typeof(string));
            foreach (var rid in _roleIds)
            {
                _pivotTable.Columns.Add(rid, typeof(bool));
            }

            var funcs = _rawMatrix.AsEnumerable()
                .Select(r => new { Id = Convert.ToString(r["ChucNangId"]), Name = Convert.ToString(r["ChucNang"]), MoTa = Convert.ToString(r["MoTa"]) })
                .Distinct()
                .OrderBy(x => x.Id)
                .ToList();

            foreach (var f in funcs)
            {
                var row = _pivotTable.NewRow();
                row["ChucNangId"] = f.Id;
                row["ChucNang"] = f.Name;
                foreach (var rid in _roleIds)
                {
                    var found = _rawMatrix.AsEnumerable().FirstOrDefault(r =>
                        Convert.ToString(r["ChucNangId"]) == f.Id && Convert.ToString(r["VaiTroId"]) == rid);
                    bool val = found != null && Convert.ToBoolean(found["QuyenHan"]);
                    row[rid] = val;
                    _original[(rid, f.Id)] = val;
                }
                _pivotTable.Rows.Add(row);
                _funcIdToDescription[f.Id] = f.MoTa;
            }

            DGVQuyenHan.DataSource = _pivotTable;
            DGVQuyenHan.ReadOnly = true;
            DGVQuyenHan.AllowUserToAddRows = false;
            DGVQuyenHan.AllowUserToDeleteRows = false;
            DGVQuyenHan.SelectionMode = DataGridViewSelectionMode.CellSelect;

            // Đổi 2 cột đầu là text, còn lại checkbox
            DGVQuyenHan.Columns["ChucNangId"].HeaderText = "Mã CN";
            DGVQuyenHan.Columns["ChucNang"].HeaderText = "Tên chức năng";
            for (int i = 2; i < DGVQuyenHan.Columns.Count; i++)
            {
                var col = DGVQuyenHan.Columns[i];
                if (!(col is DataGridViewCheckBoxColumn))
                {
                    int idx = col.Index;
                    var chk = new DataGridViewCheckBoxColumn();
                    chk.Name = col.Name;
                    chk.HeaderText = _roleIdToName.ContainsKey(col.Name) ? _roleIdToName[col.Name] : col.Name;
                    chk.DataPropertyName = col.DataPropertyName;
                    DGVQuyenHan.Columns.RemoveAt(idx);
                    DGVQuyenHan.Columns.Insert(idx, chk);
                }
            }

            DGVQuyenHan.CellClick -= DGVQuyenHan_CellClick;
            DGVQuyenHan.CellClick += DGVQuyenHan_CellClick;

            // Tô xám những ô không có mapping hoặc cột SA
            ApplyGrayForUnavailable();

            // Đảm bảo màu xám không bị mất khi scroll/refresh
            DGVQuyenHan.CellFormatting -= DGVQuyenHan_CellFormatting;
            DGVQuyenHan.CellFormatting += DGVQuyenHan_CellFormatting;
        }

        private void ApplyGrayForUnavailable()
        {
            _unavailable.Clear();
            foreach (DataGridViewRow row in DGVQuyenHan.Rows)
            {
                string funcId = Convert.ToString(row.Cells["ChucNangId"].Value);
                for (int i = 2; i < DGVQuyenHan.Columns.Count; i++)
                {
                    string roleId = DGVQuyenHan.Columns[i].Name;
                    bool isSACol = string.Equals(roleId, "SA", StringComparison.OrdinalIgnoreCase);
                    var found = _rawMatrix.AsEnumerable().FirstOrDefault(r =>
                        Convert.ToString(r["ChucNangId"]) == funcId && Convert.ToString(r["VaiTroId"]) == roleId);
                    bool mapExists = found != null && Convert.ToBoolean(found["MapExists"]);
                    var cell = row.Cells[i];
                    if (isSACol || !mapExists)
                    {
                        cell.ReadOnly = true;
                        cell.Style.BackColor = Color.Silver;
                        cell.Style.SelectionBackColor = Color.Silver;
                        cell.Style.ForeColor = Color.DimGray;
                        cell.ToolTipText = isSACol ? "Không thể thay đổi quyền của System Administrator" : "Vai trò không sử dụng chức năng này";
                        _unavailable.Add((roleId, funcId));
                    }
                }
            }
        }

        private void DGVQuyenHan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 2) return;
            string funcId = Convert.ToString(DGVQuyenHan.Rows[e.RowIndex].Cells["ChucNangId"].Value);
            string roleId = DGVQuyenHan.Columns[e.ColumnIndex].Name;
            if (_unavailable.Contains((roleId, funcId)) || string.Equals(roleId, "SA", StringComparison.OrdinalIgnoreCase))
            {
                e.CellStyle.BackColor = Color.Silver;
                e.CellStyle.SelectionBackColor = Color.Silver;
                e.CellStyle.ForeColor = Color.DimGray;
            }
        }

        private void SetEditMode(bool enabled)
        {
            _isEditMode = enabled;
            btnSua.Visible = !enabled;
            btnLuu.Visible = enabled;
            btnHuy.Visible = enabled;

            if (enabled)
            {
                DGVQuyenHan.DefaultCellStyle.SelectionBackColor = Color.White;
                DGVQuyenHan.DefaultCellStyle.SelectionForeColor = DGVQuyenHan.DefaultCellStyle.ForeColor;
            }
            else
            {
                DGVQuyenHan.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
                DGVQuyenHan.DefaultCellStyle.SelectionForeColor = Color.White;
                // Xóa override selection ở cấp cell để dùng lại màu mặc định (xanh) khi thoát chỉnh sửa
                try
                {
                    foreach (DataGridViewRow row in DGVQuyenHan.Rows)
                    {
                        for (int i = 2; i < DGVQuyenHan.Columns.Count; i++)
                        {
                            row.Cells[i].Style.SelectionBackColor = Color.Empty;
                            row.Cells[i].Style.SelectionForeColor = Color.Empty;
                        }
                    }
                }
                catch { }
            }

            // Cho phép chỉnh checkbox khi edit, trừ vai trò SA
            if (DGVQuyenHan.DataSource is DataTable dt)
            {
                foreach (DataGridViewRow row in DGVQuyenHan.Rows)
                {
                    for (int i = 2; i < DGVQuyenHan.Columns.Count; i++)
                    {
                        var col = DGVQuyenHan.Columns[i];
                        bool isSACol = string.Equals(col.Name, "SA", StringComparison.OrdinalIgnoreCase);
                        string funcId = Convert.ToString(row.Cells["ChucNangId"].Value);
                        bool isUnavailable = _unavailable.Contains((col.Name, funcId));
                        row.Cells[i].ReadOnly = !enabled || isSACol || isUnavailable;
                        row.Cells[i].Style.BackColor = row.Cells[i].Style.BackColor; // giữ màu hiện tại
                        if (enabled && (isSACol || isUnavailable))
                            row.Cells[i].ToolTipText = isSACol ? "Không thể thay đổi quyền của System Administrator" : "Vai trò không sử dụng chức năng này";
                        else row.Cells[i].ToolTipText = string.Empty;
                    }
                }
            }

            // Panel chi tiết luôn READ-ONLY
            try { txtVaiTro.ReadOnly = true; txtChucNang.ReadOnly = true; txtMoTaChucNang.ReadOnly = true; cbTrangThai.Enabled = false; } catch { }
        }

        private void DGVQuyenHan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (e.ColumnIndex < 2) return; // chỉ cột checkbox

            // Cập nhật panel chi tiết (vai trò, chức năng, trạng thái)
            string funcId = Convert.ToString(DGVQuyenHan.Rows[e.RowIndex].Cells["ChucNangId"].Value);
            string funcName = Convert.ToString(DGVQuyenHan.Rows[e.RowIndex].Cells["ChucNang"].Value);
            string roleId = DGVQuyenHan.Columns[e.ColumnIndex].Name;
            string roleName = _roleIdToName.ContainsKey(roleId) ? _roleIdToName[roleId] : roleId;
            lblVaiTro.Text = "Vai trò được chọn:"; // đảm bảo label tồn tại
            lblChucNang.Text = "Chức năng được chọn:";
            // hiển thị trên textbox
            if (txtVaiTro != null) txtVaiTro.Text = roleName;
            if (txtChucNang != null) txtChucNang.Text = $"{funcId} - {funcName}";
            if (txtMoTaChucNang != null)
            {
                if (_funcIdToDescription.TryGetValue(funcId, out string moTa)) txtMoTaChucNang.Text = moTa; else txtMoTaChucNang.Clear();
            }

            if (cbTrangThai != null)
            {
                bool current = Convert.ToBoolean(DGVQuyenHan.Rows[e.RowIndex].Cells[e.ColumnIndex].Value ?? false);
                cbTrangThai.Items.Clear();
                cbTrangThai.Items.Add("Được phép sử dụng");
                cbTrangThai.Items.Add("Không được phép");
                cbTrangThai.SelectedIndex = current ? 0 : 1;
            }

            if (!_isEditMode) return;
            // toggle khi edit nếu không phải cột SA
            bool isSACol = string.Equals(roleId, "SA", StringComparison.OrdinalIgnoreCase);
            if (isSACol) return;

            var cell = DGVQuyenHan.Rows[e.RowIndex].Cells[e.ColumnIndex];
            bool oldVal = _original[(roleId, funcId)];
            bool newVal = !(Convert.ToBoolean(cell.Value ?? false));
            cell.Value = newVal;

            var key = (roleId, funcId);
            if (newVal != oldVal)
            {
                _changes[key] = newVal;
                cell.Style.BackColor = Color.LightYellow;
                cell.Style.SelectionBackColor = Color.LightYellow; // hiển thị ngay cả khi đang chọn
            }
            else
            {
                if (_changes.ContainsKey(key)) _changes.Remove(key);
                cell.Style.BackColor = DGVQuyenHan.DefaultCellStyle.BackColor;
                cell.Style.SelectionBackColor = Color.White;
            }

            btnLuu.Text = _changes.Count > 0 ? $"Lưu ({_changes.Count})" : "Lưu";
        }


        // Hủy các thay đổi: trả về giá trị gốc và bỏ màu vàng
        private void RevertChanges()
        {
            foreach (var kv in _changes.ToList())
            {
                string roleId = kv.Key.roleId;
                string funcId = kv.Key.funcId;
                bool originalVal = _original[(roleId, funcId)];
                foreach (DataGridViewRow row in DGVQuyenHan.Rows)
                {
                    if (Convert.ToString(row.Cells["ChucNangId"].Value) == funcId)
                    {
                        int colIndex = DGVQuyenHan.Columns[roleId].Index;
                        row.Cells[colIndex].Value = originalVal;
                        row.Cells[colIndex].Style.BackColor = DGVQuyenHan.DefaultCellStyle.BackColor;
                        row.Cells[colIndex].Style.SelectionBackColor = Color.White;
                        break;
                    }
                }
            }
            _changes.Clear();
            btnLuu.Text = "Lưu";
        }
    }
}

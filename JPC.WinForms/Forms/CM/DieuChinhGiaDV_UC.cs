using JPC.Business.Services.Implementations.CM;
using JPC.Business.Services.Interfaces.CM;
using JPC.Models.TaiChinh;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.CM
{
    public partial class DieuChinhGiaDV_UC : UserControl
    {
        private readonly ICMFeesService _svc = new CMFeesService();
        private bool _isEditing = false;

        public DieuChinhGiaDV_UC()
        {
            InitializeComponent();
            // cấu hình lưới 4 cột: STT | PhiId | TenDichVu | SoTien
            SetupGridPhi();

            // events
            this.Load += (s, e) => { LoadGrid(); SetEditMode(false); };
            btnTaiLai.Click += (s, e) => { LoadGrid(); SetEditMode(false); };
            dgvPhi.SelectionChanged += dgvPhi_SelectionChanged;


            // chặn ký tự không phải số cho Giá mới
            txtGiaMoi.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
                    e.Handled = true;
                if ((e.KeyChar == '.' || e.KeyChar == ',') && (txtGiaMoi.Text.Contains(".") || txtGiaMoi.Text.Contains(",")))
                    e.Handled = true;
            };
        }
        private void SetupGridPhi()
        {
            dgvPhi.AutoGenerateColumns = false;           // KHÔNG tự sinh cột
            dgvPhi.RowHeadersVisible = false;
            dgvPhi.AllowUserToAddRows = false;
            dgvPhi.ReadOnly = true;
            dgvPhi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPhi.MultiSelect = false;
            dgvPhi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvPhi.Columns.Clear();

            var colSTT = new DataGridViewTextBoxColumn
            {
                Name = "colSTT",
                HeaderText = "STT",
                FillWeight = 8,
                ReadOnly = true
            };
            var colMaPhi = new DataGridViewTextBoxColumn
            {
                Name = "PhiId",
                DataPropertyName = "PhiId",
                HeaderText = "Mã Phí",
                FillWeight = 15,
                ReadOnly = true,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            };
            var colTenDV = new DataGridViewTextBoxColumn
            {
                Name = "TenDichVu",
                DataPropertyName = "TenDichVu",
                HeaderText = "Tên dịch vụ",
                FillWeight = 55,
                ReadOnly = true
            };
            var colGia = new DataGridViewTextBoxColumn
            {
                Name = "SoTien",
                DataPropertyName = "SoTien",
                HeaderText = "Giá hiện tại",
                FillWeight = 22,
                ReadOnly = true,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N0" }
            };

            dgvPhi.Columns.AddRange(colSTT, colMaPhi, colTenDV, colGia);

            foreach (DataGridViewColumn c in dgvPhi.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

            // STT
            dgvPhi.DataBindingComplete += (s, e) =>
            {
                for (int i = 0; i < dgvPhi.Rows.Count; i++)
                    dgvPhi.Rows[i].Cells["colSTT"].Value = i + 1;
            };
        }


        private void LoadGrid()
        {
            var list = _svc.GetAll();           // List<PhiDichVu> (PhiId, TenDichVu, SoTien)
            dgvPhi.DataSource = list;

            if (dgvPhi.Rows.Count > 0)
                dgvPhi.Rows[0].Selected = true; // chọn dòng đầu
            FillFormFromGrid();                 // đổ sang panel bên phải
        }

        private void DieuChinhGiaDV_UC_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }
        private void ResetForm()
        {
            txtMaPhi.Clear(); txtTenDV.Clear(); txtGiaHT.Clear(); txtGiaMoi.Clear();
            txtGiaMoi.Enabled = false;
        }

        private void dgvPhi_SelectionChanged(object sender, EventArgs e)
        {
            if (_isEditing) return; // đang sửa thì không thay đổi form
            FillFormFromGrid();
        }
        private void FillFormFromGrid()
        {
            if (dgvPhi.CurrentRow?.DataBoundItem is PhiDichVu item)
            {
                txtMaPhi.Text = item.PhiId.ToString();
                txtTenDV.Text = item.TenDichVu;
                txtGiaHT.Text = item.SoTien.ToString("N0");
                txtGiaMoi.Clear();
            }
            else
            {
                txtMaPhi.Clear(); txtTenDV.Clear(); txtGiaHT.Clear(); txtGiaMoi.Clear();
            }
        }

        private void SetEditMode(bool editing)
        {
            _isEditing = editing;

            // KHÓA toàn bộ text khi chưa sửa
            txtMaPhi.ReadOnly = true;
            txtTenDV.ReadOnly = true;
            txtGiaHT.ReadOnly = true;

            // chỉ cho nhập Giá mới khi đang sửa
            txtGiaMoi.ReadOnly = !editing;
            if (editing) txtGiaMoi.Focus(); else txtGiaMoi.Clear();

            // trạng thái nút + lưới
            btnSua.Enabled = !editing && dgvPhi.CurrentRow != null;
            btnLuu.Enabled = editing;
            btnHuy.Enabled = editing;
            btnTaiLai.Enabled = !editing;
            dgvPhi.Enabled = !editing;
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvPhi.CurrentRow == null) { MessageBox.Show("Chọn một mục phí."); return; }
            // gợi ý đặt giá mới = giá hiện tại
            if (decimal.TryParse(txtGiaHT.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out var cur))
                txtGiaMoi.Text = cur.ToString("0");
            SetEditMode(true);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMaPhi.Text, out var id)) { MessageBox.Show("Chọn một mục phí."); return; }
            if (!decimal.TryParse(txtGiaMoi.Text.Replace(',', '.'),
                                  NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out var giaMoi)
                && !decimal.TryParse(txtGiaMoi.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out giaMoi))
            {
                MessageBox.Show("Giá mới phải >0 và là số nguyên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            if (giaMoi <= 0) { MessageBox.Show("Giá mới phải > 0."); return; }

            // nếu không đổi giá, bỏ qua
            if (decimal.TryParse(txtGiaHT.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out var giaHT) && giaMoi == giaHT)
            {
                MessageBox.Show("Giá không thay đổi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); SetEditMode(false); return;
            }

            try
            {
                _svc.UpdatePrice(id, giaMoi);
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGrid();               // reload dữ liệu + giữ trạng thái view
                // đưa con trỏ về dòng vừa sửa
                var row = dgvPhi.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => (int)r.Cells["PhiId"].Value == id);
                if (row != null) row.Selected = true;
                SetEditMode(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetEditMode(false);
            FillFormFromGrid();   // trả lại giá trị theo dòng đang chọn
        }
    
    }
}

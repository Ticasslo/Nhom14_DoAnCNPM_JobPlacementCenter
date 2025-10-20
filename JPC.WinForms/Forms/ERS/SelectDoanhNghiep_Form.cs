using Guna.UI2.WinForms;
using JPC.Business;
using JPC.Business.Services.Implementations.ERS;
using JPC.Business.Services.Interfaces.ERS;
using JPC.Models.DoanhNghiep;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JPC.Models;

namespace Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.ERS
{
    public partial class SelectDoanhNghiep_UC_Form : UserControl
    {
        private readonly IDoanhNghiepService_ERS _service;
        public SelectDoanhNghiep_UC_Form()
        {
            InitializeComponent();
           // this.Resize += SelectDoanhNghiep_UC_Form_Resize;
            _service = ServiceFactory.CreateDoanhNghiepService();
            LoadAllDoanhNghiep();

            // Chỉ đọc khi là SA (dùng ở luồng Tra cứu)
            if (UserSession.NhanVien != null && UserSession.NhanVien.VaiTroId == "SA")
            {
                ApplyReadOnlyForSA();
            }
        }

        private void ApplyReadOnlyForSA()
        {
            // 1) Ẩn/khóa thao tác ghi
            if (btnluu != null) btnluu.Visible = false; // hoặc btnluu.Enabled = false;

            // 2) DGV chỉ đọc, không cho chỉnh sửa/xóa hàng
            if (dgvDoanhNghiep != null)
            {
                dgvDoanhNghiep.ReadOnly = true;
                dgvDoanhNghiep.AllowUserToAddRows = false;
                dgvDoanhNghiep.AllowUserToDeleteRows = false;
                dgvDoanhNghiep.MultiSelect = false;
                dgvDoanhNghiep.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }

            // 3) đổi nhãn tiêu đề để rõ đây là chế độ tra cứu
            if (lbTitle != null) lbTitle.Text = "Tra cứu doanh nghiệp (Chỉ đọc)";
        }

        private void LoadAllDoanhNghiep()
        {
            var list = _service.LayTatCa();
            dgvDoanhNghiep.DataSource = list;
            dgvDoanhNghiep.ClearSelection();
        }
        private void SelectDoanhNghiep_UC_Form_Load(object sender, EventArgs e)
        {

        }

        //private void SelectDoanhNghiep_UC_Form_Resize(object sender, EventArgs e)
        //{
        //    int centerX = guna2Panel1.Width / 2;

        //    // 🌟 Căn giữa tiêu đề và dòng phụ
        //    lbTitle.Left = centerX - (lbTitle.Width / 2);

        //    // 🌟 Căn giữa label "Bảng Doanh nghiệp"
        //    lbBangDN.AutoSize = true;
        //    lbBangDN.Font = new Font("Segoe UI", 12, FontStyle.Bold);
        //    lbBangDN.Left = centerX - (lbBangDN.Width / 2);
        //    lbBangDN.Top = 230; // tuỳ chỉnh khoảng cách từ tiêu đề xuống

        //    // 🌟 Canh lại DataGridView
        //    dgvDoanhNghiep.Top = lbBangDN.Bottom + 45; // cách label 15px
        //    dgvDoanhNghiep.Left = this.Width * 10 / 100;  // cách trái 10% usercontrol
        //    dgvDoanhNghiep.Width = this.Width * 80 / 100; // rộng 80% usercontrol
        //    dgvDoanhNghiep.Height = this.Height * 45 / 100; // cao 45% usercontrol
        //    dgvDoanhNghiep.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;




        //    btnluu.Left = (this.Width - btnluu.Width) / 2;
        //    btnluu.Top = guna2Panel1.Bottom + 570; // cách panel một khoảng 20px

        //}

        private void btnluu_Click(object sender, EventArgs e)
        {
            try
            {
                if (UserSession.NhanVien != null && UserSession.NhanVien.VaiTroId == "SA")
                {
                    MessageBox.Show("Chế độ tra cứu (chỉ đọc). SA không thể thực hiện thao tác này.",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (dgvDoanhNghiep.SelectedRows.Count == 0)
                {
                    MessageBox.Show("⚠️ Vui lòng chọn doanh nghiệp trước!");
                    return;
                }

                var row = dgvDoanhNghiep.SelectedRows[0];

                int dnId = Convert.ToInt32(row.Cells[0].Value);
                string tenDn = row.Cells[1].Value.ToString();


                if (dnId == 0)
                {
                    MessageBox.Show("⚠️ Không tìm thấy mã doanh nghiệp trong bảng!");
                    return;
                }

                var dn = new DoanhNghiep
                {
                    DnId = dnId,
                    TenDoanhNghiep = tenDn
                };

                var formDangTin = new DangTinTuyenDung_UC_Form(dn);
                var parentForm = this.FindForm();
                if (parentForm is TrangChuERS_Form mainForm)
                {
                    mainForm.LoadUserControl(formDangTin);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Đã có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadAllDoanhNghiep();

        }
        private void ClearForm()
        {
            txtmadoanhnghiep.Clear();

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmadoanhnghiep.Text))
            {
                MessageBox.Show("⚠️ Vui lòng nhập mã doanh nghiệp để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //LoadAllDoanhNghiep();
                return;
            }

            if (int.TryParse(txtmadoanhnghiep.Text.Trim(), out int id))
            {
                var dn = _service.TimTheoMa(id);
                if (dn == null)
                {
                    MessageBox.Show("❌ Không tìm thấy doanh nghiệp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvDoanhNghiep.DataSource = null;
                    return;
                }

                dgvDoanhNghiep.DataSource = new[] { dn };
            }
            else
            {
                MessageBox.Show("⚠️ Mã doanh nghiệp phải là số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
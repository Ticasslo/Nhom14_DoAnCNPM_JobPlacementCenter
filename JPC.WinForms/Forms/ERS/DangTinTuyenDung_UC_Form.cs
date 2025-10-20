using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JPC.Business.Services.Implementations.ERS;
using JPC.Business.Services.Interfaces.ERS;
using JPC.Business.Services.Implementations.SA;
using JPC.Models.DanhMucNghe;
using JPC.Models.DoanhNghiep;

namespace Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.ERS
{
    public partial class DangTinTuyenDung_UC_Form : UserControl
    {
        private readonly NhomNgheService _nhomNgheService;
        private readonly NgheService _ngheService;
        private readonly ViTriChuyenMonService _viTriService;
        private readonly TinTuyenDungService_ERS _tinTuyenDungService;
        private readonly DoanhNghiep _dn;

        public DangTinTuyenDung_UC_Form()
        {
            InitializeComponent();
           // this.Resize += DangTinTuyenDung_UC_Form_Resize;

            _nhomNgheService = new NhomNgheService();
            _ngheService = new NgheService();
            _viTriService = new ViTriChuyenMonService();

            this.Load += DangTinTuyenDung_UC_Form_Load;
            cbonhomnghe.SelectedIndexChanged += cbonhomnghe_SelectedIndexChanged;
            cbonghe.SelectedIndexChanged += cbonghe_SelectedIndexChanged;
        }

        private void DangTinTuyenDung_UC_Form_Load(object sender, EventArgs e)
        {
            try
            {
                LoadComboBoxNhomNghe();
                LoadComboBoxHinhThucLamViec();
                LoadTinTuyenDung();

                // reset combobox
                cbonhomnghe.SelectedIndex = -1;
                cbonghe.DataSource = null;
                cbovitrichuyenmon.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu ban đầu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadComboBoxHinhThucLamViec()
        {
            cbohinhthuc.Items.Clear();
            cbohinhthuc.Items.Add("Toàn thời gian");
            cbohinhthuc.Items.Add("Bán thời gian");
            cbohinhthuc.Items.Add("Thực tập");
            cbohinhthuc.SelectedIndex = -1;
        }

        // ================== 🟢 NHÓM NGHỀ ==================
        private void LoadComboBoxNhomNghe()
        {
            try
            {
                DataTable dt = _nhomNgheService.GetActiveNhomNghe();

                if (dt == null || dt.Columns.Count == 0)
                {
                    MessageBox.Show("⚠️ Không có nhóm nghề nào!", "Thông báo");
                    return;
                }

                cbonhomnghe.DataSource = dt;
                cbonhomnghe.DisplayMember = "Tên nhóm";
                cbonhomnghe.ValueMember = "ID";
                cbonhomnghe.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải nhóm nghề: {ex.Message}");
            }
        }

        private void cbonhomnghe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbonhomnghe.SelectedValue == null || cbonhomnghe.SelectedValue is DataRowView)
                return;

            try
            {
                int nhomId = Convert.ToInt32(cbonhomnghe.SelectedValue);
                LoadComboBoxNghe(nhomId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách nghề: {ex.Message}");
            }
        }


        // ================== 🟢 NGHỀ ==================
        private void LoadComboBoxNghe(int nhomId)
        {
            try
            {
                DataTable dt = _ngheService.GetActiveNgheByNhomId(nhomId);

                if (dt == null || dt.Rows.Count == 0)
                {
                    cbonghe.DataSource = null;
                    cbovitrichuyenmon.DataSource = null;
                    return;
                }

                cbonghe.DataSource = dt;
                cbonghe.DisplayMember = "Tên nghề"; // đúng tên cột trong DataTable
                cbonghe.ValueMember = "ID";         // đúng tên cột trong DataTable
                cbonghe.SelectedIndex = -1;

                cbovitrichuyenmon.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load nghề: {ex.Message}", "Lỗi");
            }
        }

        private void cbonghe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbonghe.SelectedValue == null || cbonghe.SelectedValue is DataRowView)
                return;

            try
            {
                int ngheId = Convert.ToInt32(cbonghe.SelectedValue);
                LoadComboBoxViTri(ngheId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải vị trí chuyên môn: {ex.Message}");
            }
        }


        // ================== 🟢 VỊ TRÍ CHUYÊN MÔN ==================
        private void LoadComboBoxViTri(int ngheId)
        {
            try
            {
                DataTable dt = _viTriService.GetAllViTriChuyenMon();

                if (dt == null || dt.Rows.Count == 0)
                {
                    cbovitrichuyenmon.DataSource = null;
                    return;
                }

                //// Debug tên cột thực tế
                //string cols = string.Join(", ", dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName));
                //MessageBox.Show($"Các cột trong DataTable vị trí: {cols}", "Debug");

                // 🔹 Lọc theo tên nghề
                string ngheTen = cbonghe.Text; // tên nghề đang chọn
                DataView dv = new DataView(dt);
                dv.RowFilter = $"Nghề = '{ngheTen.Replace("'", "''")}'"; // tránh lỗi ký tự '

                // 🔹 Gán vào combobox vị trí chuyên môn
                cbovitrichuyenmon.DataSource = dv;
                cbovitrichuyenmon.DisplayMember = "Tên vị trí";
                cbovitrichuyenmon.ValueMember = "ID";
                cbovitrichuyenmon.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load vị trí chuyên môn: {ex.Message}", "Lỗi");
            }
        }

        // ================== 🟠 CONSTRUCTOR NHẬN DOANH NGHIỆP ==================
        public DangTinTuyenDung_UC_Form(DoanhNghiep dn)
        {
            InitializeComponent();
           // this.Resize += DangTinTuyenDung_UC_Form_Resize;

            _dn = dn ?? throw new ArgumentNullException(nameof(dn));
            _nhomNgheService = new NhomNgheService();
            _ngheService = new NgheService();
            _viTriService = new ViTriChuyenMonService();
            _tinTuyenDungService = new TinTuyenDungService_ERS();

            cbonhomnghe.SelectedIndexChanged += cbonhomnghe_SelectedIndexChanged;
            cbonghe.SelectedIndexChanged += cbonghe_SelectedIndexChanged;
            this.Load += DangTinTuyenDung_UC_Form_Load;
        }


        

        private void btndangtin_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbonhomnghe.SelectedIndex < 0 || cbonghe.SelectedIndex < 0 || cbovitrichuyenmon.SelectedIndex < 0)
                {
                    MessageBox.Show("⚠️ Vui lòng chọn đầy đủ Nhóm nghề, Nghề và Vị trí chuyên môn!", "Thiếu thông tin");
                    return;
                }

                var tin = new JPC.Models.DoanhNghiep.TinTuyenDung
                {
                    DnId = _dn.DnId,
                    TieuDe = txttieude.Text.Trim(),
                    MoTaCongViec = txtmota.Text.Trim(),
                    SoLuongTuyen = (int)numsoluong.Value,
                    MucLuong = txtmucluong.Text.Trim(),
                    KhuVucLamViec = txtkhuvuc.Text.Trim(),
                    HinhThucLamViec = cbohinhthuc.Text.Trim(),
                    KinhNghiemYeuCau = (int)numkinhnghiem1.Value,
                    HanNopHoSo = dtphannop.Value.Date
                };

                var (ok, msg, newId) = _tinTuyenDungService.InsertTinTuyenDung(tin);

                if (ok)
                {
                    MessageBox.Show($"✅ {msg}\nMã tin mới: {newId}", "Thành công",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // ✅ Xoá trắng các ô nhập
                    ClearForm();

                    // ✅ Tải lại danh sách tin
                    LoadTinTuyenDung();

                    // ✅ Tự động chọn tin mới vừa đăng (nếu muốn)
                    if (dgvTinTuyenDung.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow row in dgvTinTuyenDung.Rows)
                        {
                            if (Convert.ToInt32(row.Cells["Mã tin"].Value) == newId)
                            {
                                row.Selected = true;
                                dgvTinTuyenDung.FirstDisplayedScrollingRowIndex = row.Index;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"❌ {msg}", "Thất bại",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đăng tin: {ex.Message}");
            }
        }

        private void LoadTinTuyenDung()
        {
            try
            {
                DataTable dt = _tinTuyenDungService.GetTinByDoanhNghiep(_dn.DnId);
                dgvTinTuyenDung.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải tin tuyển dụng: " + ex.Message);
            }
        }


        private void ClearForm()
        {
            txttieude.Clear();
            txtmota.Clear();
            numsoluong.Value = 0;
            txtmucluong.Clear();
            txtkhuvuc.Clear();
            cbohinhthuc.SelectedIndex = -1;
            numkinhnghiem1.Value = 0;
            dtphannop.Value = DateTime.Now;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Tìm form cha chứa UC hiện tại
            Form parentForm = this.FindForm();

            // Nếu form cha là Frm_Main thì gọi LoadUserControl
            if (parentForm is TrangChuERS_Form mainForm)
            {
                var ucBack = new SelectDoanhNghiep_UC_Form();
                mainForm.LoadUserControl(ucBack);
            }
        }

        private void cbonhomnghe_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
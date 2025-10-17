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

namespace Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.ERS
{
    public partial class CapNhatKetQua_UC_Form : UserControl
    {
        private readonly UngTuyenService_ERS _ungTuyenService = new UngTuyenService_ERS();
        public CapNhatKetQua_UC_Form()
        {
            InitializeComponent();
            //this.Resize += CapNhatKetQua_UC_Form_Resize;
        }

        private void CapNhatKetQua_UC_Form_Load(object sender, EventArgs e)
        {

        }

        //TROI OI LA TROIIIIII
        //private void CapNhatKetQua_UC_Form_Resize(object sender, EventArgs e)
        //{
        //    //int centerX = this.Width / 2;

        //    //// 🌟 Căn giữa tiêu đề
        //    //lbTitle.Left = centerX - (lbTitle.Width / 2);
        //    //lbTitle.Top = guna2Panel1.Bottom + 40;

        //    // Đặt tiêu đề cố định cách trên khoảng 50px tính từ Form (không phụ thuộc panel)
        //    lbTitle.Left = (this.Width - lbTitle.Width) / 2;
        //    lbTitle.Top = 50; // cách mép trên form một khoảng an toàn
        //    lbTitle.BringToFront(); // đảm bảo nằm trên tất cả panel


        //    // 🌟 Giảm chiều rộng panel lại cho vừa hơn
        //    int panelSpacing = 60; // khoảng cách giữa 2 khung
        //    int panelWidth = (this.Width - 7 * panelSpacing) / 2; // giảm bớt chiều dài
        //    int panelHeight = 75; // thấp hơn cho gọn

        //    // 🌟 Khung Tìm kiếm
        //    pnlTimKiem.Width = panelWidth;
        //    pnlTimKiem.Height = panelHeight + 70;
        //    pnlTimKiem.Left = panelSpacing;
        //    pnlTimKiem.Top = lbTitle.Bottom + 60;

        //    // 🌟 Khung Cập nhật kết quả
        //    pnlCapNhat.Width = panelWidth;
        //    pnlCapNhat.Height = panelHeight;
        //    pnlCapNhat.Left = pnlTimKiem.Right + panelSpacing;
        //    pnlCapNhat.Top = pnlTimKiem.Top;

        //    // 🌟 Label "Tìm kiếm" và "Cập nhật kết quả" sát với panel hơn
        //    lbTimKiem.Left = pnlTimKiem.Left + 5;
        //    lbTimKiem.Top = pnlTimKiem.Top - lbTimKiem.Height - 5; // chỉ cách panel 5px

        //    lbCapNhat.Left = pnlCapNhat.Left + 5;
        //    lbCapNhat.Top = pnlCapNhat.Top - lbCapNhat.Height - 5;

        //    //// 🌟 Làm nổi bật nút "Tìm kiếm"
        //    //btnTimKiem.FillColor = Color.RoyalBlue;
        //    //btnTimKiem.ForeColor = Color.White;
        //    //btnTimKiem.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        //    //btnTimKiem.HoverState.FillColor = Color.DodgerBlue;
        //    //btnTimKiem.BorderRadius = 6;
        //    //btnTimKiem.Left = pnlTimKiem.Left + pnlTimKiem.Width - btnTimKiem.Width - 20;
        //    //btnTimKiem.Top = pnlTimKiem.Top + (pnlTimKiem.Height - btnTimKiem.Height) / 2;

        //    //// 🌟 Nút "Làm mới" nằm ngang hàng với nút Tìm kiếm, lệch sang phải một chút
        //    //btnlammoi.FillColor = Color.Silver;
        //    //btnlammoi.ForeColor = Color.Black;
        //    //btnlammoi.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        //    //btnlammoi.HoverState.FillColor = Color.LightGray;
        //    //btnlammoi.BorderRadius = 6;
        //    //btnlammoi.Top = btnTimKiem.Top; // cùng hàng
        //    //btnlammoi.Left = btnTimKiem.Right + 15; // cách nút Tìm kiếm 15px


        //    btntrungtuyen.FillColor = Color.RoyalBlue;
        //    btntrungtuyen.ForeColor = Color.White;
        //    btntrungtuyen.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        //    btntrungtuyen.HoverState.FillColor = Color.DodgerBlue;
        //    btntrungtuyen.BorderRadius = 6;

        //    btnkhongtrungtuyen.FillColor = Color.RoyalBlue;
        //    btnkhongtrungtuyen.ForeColor = Color.White;
        //    btnkhongtrungtuyen.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        //    btnkhongtrungtuyen.HoverState.FillColor = Color.DodgerBlue;
        //    btnkhongtrungtuyen.BorderRadius = 6;

        //    btncapnhat.FillColor = Color.RoyalBlue;
        //    btncapnhat.ForeColor = Color.White;
        //    btncapnhat.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        //    btncapnhat.HoverState.FillColor = Color.DodgerBlue;
        //    btncapnhat.BorderRadius = 6;

        //    // 🌟 DataGridView ở giữa
        //    dgvUngVien.Width = (int)(this.Width * 0.8);
        //    dgvUngVien.Left = (this.Width - dgvUngVien.Width) / 2;
        //    dgvUngVien.Top = pnlTimKiem.Bottom + 100;
        //    dgvUngVien.Height = (int)(this.Height * 0.45);
        //    dgvUngVien.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

        //    // 🌟 Nút "Cập nhật kết quả" căn giữa bên dưới DataGridView
        //    btncapnhat.Left = (this.Width - btncapnhat.Width) / 2;
        //    btncapnhat.Top = dgvUngVien.Bottom + 25;

        //}

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtmadoanhnghiep.Text) || string.IsNullOrWhiteSpace(txtmatin.Text))
                {
                    MessageBox.Show("⚠️ Vui lòng nhập đầy đủ Mã Doanh nghiệp và Mã Tin tuyển dụng!");
                    return;
                }

                int dnId = Convert.ToInt32(txtmadoanhnghiep.Text);
                int tinId = Convert.ToInt32(txtmatin.Text);

                DataTable dt = _ungTuyenService.LayUngVienTheoDoanhNghiepVaTin(dnId, tinId);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("❌ Không có ứng viên nào cho tin tuyển dụng này!", "Thông báo");
                }

                dgvUngVien.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btntrungtuyen_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvUngVien.SelectedRows)
            {
                row.Cells["Trạng thái"].Value = "TRUNG_TUYEN";
            }
        }

        private void btnkhongtrungtuyen_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvUngVien.SelectedRows)
            {
                row.Cells["Trạng thái"].Value = "KHONG_TRUNG_TUYEN";
            }
        }

        private void btncapnhat_Click(object sender, EventArgs e)
        {
            if (dgvUngVien.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để cập nhật!");
                return;
            }

            int tinId = Convert.ToInt32(txtmatin.Text);
            var updates = new List<(int uvId, int tinId, string trangThai)>();

            foreach (DataGridViewRow row in dgvUngVien.Rows)
            {
                if (row.Cells["Mã Ứng Viên"].Value != null && row.Cells["Trạng thái"].Value != null)
                {
                    int uvId = Convert.ToInt32(row.Cells["Mã Ứng Viên"].Value);
                    string trangThai = row.Cells["Trạng thái"].Value.ToString();
                    updates.Add((uvId, tinId, trangThai));
                }
            }

            bool result = _ungTuyenService.CapNhatKetQuaTuyenDung(updates);

            if (result)
                MessageBox.Show("✅ Cập nhật kết quả tuyển dụng thành công!");
            else
                MessageBox.Show("⚠️ Có một số bản ghi không cập nhật được!");
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            txtmadoanhnghiep.Clear();
            txtmatin.Clear();
            dgvUngVien.DataSource = null;  // 🧹 Xóa toàn bộ dữ liệu hiện có
            dgvUngVien.Rows.Clear();       // Xóa hàng nếu còn sót
        }
    }
}
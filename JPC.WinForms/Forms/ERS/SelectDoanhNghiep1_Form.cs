using Guna.UI2.WinForms;
using JPC.Business.Services.Implementations.ERS;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Xml.Linq;
using JPC.Models;

namespace Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.ERS
{
    public partial class SelectDoanhNghiep1_UC_Form : UserControl

    {

        private readonly UngTuyenService_ERS _ungTuyenService;

        public SelectDoanhNghiep1_UC_Form()
        {
            InitializeComponent();
          //  this.Resize += SelectTinTuyenDung1_UC_Form_Resize;
            _ungTuyenService = new UngTuyenService_ERS();

            if (UserSession.NhanVien != null && UserSession.NhanVien.VaiTroId == "SA")
            {
                ApplyReadOnlyForSA();
            }
        }

        private void ApplyReadOnlyForSA()
        {
            // DGV chỉ đọc
            if (dgvUngVien != null)
            {
                dgvUngVien.ReadOnly = true;
                dgvUngVien.AllowUserToAddRows = false;
                dgvUngVien.AllowUserToDeleteRows = false;
                dgvUngVien.MultiSelect = false;
                dgvUngVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }

            // Tiêu đề báo rõ trạng thái
            if (lbTitle != null)
            {
                lbTitle.Text = "Tra cứu danh sách ứng viên (Chỉ đọc)";
            }

            // Tùy chọn: ẩn các nút có thể dẫn tới thao tác ghi/sửa (nếu có)
            // Ví dụ: ẩn nút Xem chi tiết nếu màn Xem cho phép sửa
            // if (btnXem != null) btnXem.Visible = false;

            // Export là thao tác chỉ đọc → có thể giữ nguyên
            // if (btnXuat != null) btnXuat.Enabled = true;
        }

        private void SelectDoanhNghiep1_UC_Form_Load(object sender, EventArgs e)
        {

        }

        //private void SelectTinTuyenDung1_UC_Form_Resize(object sender, EventArgs e)
        //{
        //    int centerX = guna2Panel1.Width / 2;

        //    // 🌟 Căn giữa tiêu đề và dòng phụ
        //    lbTitle.Left = centerX - (lbTitle.Width / 2);

        //    // 🌟 Căn giữa label "Bảng Doanh nghiệp"
        //    lbBangDN.AutoSize = true;
        //    lbBangDN.Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold);

        //    lbBangDN.Left = centerX - (lbBangDN.Width / 2);
        //    lbBangDN.Top = 230; // tuỳ chỉnh khoảng cách từ tiêu đề xuống

        //    // 🌟 Canh lại DataGridView
        //    dgvUngVien.Top = lbBangDN.Bottom + 45; // cách label 15px
        //    dgvUngVien.Left = this.Width * 10 / 100;  // cách trái 10% usercontrol
        //    dgvUngVien.Width = this.Width * 80 / 100; // rộng 80% usercontrol
        //    dgvUngVien.Height = this.Height * 45 / 100; // cao 45% usercontrol
        //    dgvUngVien.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;




        //    // 🌟 Hai nút ngang hàng nhau
        //    int spacing = 100; // khoảng cách giữa hai nút
        //    int totalWidth = btnXuat.Width + btnXem.Width + spacing;

        //    int startX = (this.Width - totalWidth) / 2;
        //    int baseY = dgvUngVien.Bottom + 40; // khoảng cách dưới datagridview

        //    btnXuat.Left = startX;
        //    btnXuat.Top = baseY;

        //    btnXem.Left = btnXuat.Right + spacing;
        //    btnXem.Top = baseY;


        //}

        private void btnluu_Click(object sender, EventArgs e)
        {
            if (dgvUngVien.SelectedRows.Count == 0)
            {
                MessageBox.Show("⚠️ Vui lòng chọn 1 tin tuyển dụng để xem danh sách ứng viên!");
                return;
            }

            int tinId = Convert.ToInt32(dgvUngVien.SelectedRows[0].Cells["tin_id"].Value);
            System.Data.DataTable dtUngVien = _ungTuyenService.GetUngVienByTin(tinId);

            dgvUngVien.DataSource = dtUngVien;

        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            try
            {
                string dnText = txtmadoanhnghiep.Text.Trim();
                string tinText = txtmatintuyendung.Text.Trim();

                if (string.IsNullOrEmpty(dnText))
                {
                    MessageBox.Show("⚠️ Vui lòng nhập mã doanh nghiệp!", "Thông báo");
                    return;
                }

                int dnId = int.Parse(dnText);
                System.Data.DataTable dt;

                if (string.IsNullOrEmpty(tinText))
                {
                    // Chỉ có DN → hiển thị toàn bộ tin
                    dt = _ungTuyenService.LayTinTheoDoanhNghiep(dnId);
                }
                else
                {
                    // Có cả DN và Tin → chỉ hiển thị 1 tin
                    int tinId = int.Parse(tinText);
                    dt = _ungTuyenService.LayTinTheoDoanhNghiepVaTin(dnId, tinId);
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("❌ Không tìm thấy dữ liệu phù hợp!", "Kết quả trống");
                    dgvUngVien.DataSource = null;
                }
                else
                {
                    dgvUngVien.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi");
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            if (dgvUngVien.SelectedRows.Count == 0)
            {
                MessageBox.Show("⚠️ Vui lòng chọn 1 tin tuyển dụng để xuất danh sách ứng viên!");
                return;
            }

            int tinId = Convert.ToInt32(dgvUngVien.SelectedRows[0].Cells["tin_id"].Value);
            System.Data.DataTable dtUngVien = _ungTuyenService.GetUngVienByTin(tinId);

            if (dtUngVien.Rows.Count == 0)
            {
                MessageBox.Show("❌ Tin tuyển dụng này chưa có ứng viên nào.");
                return;
            }

            // 📝 Tạo file Word
            var app = new Microsoft.Office.Interop.Word.Application();
            Document doc = app.Documents.Add();

            Paragraph header = doc.Content.Paragraphs.Add();
            header.Range.Text = "DANH SÁCH ỨNG VIÊN ỨNG TUYỂN";
            header.Range.Font.Bold = 1;
            header.Range.Font.Size = 16;
            header.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            header.Range.InsertParagraphAfter();

            // 🔹 Tạo bảng
            Microsoft.Office.Interop.Word.Table table = doc.Tables.Add(doc.Bookmarks.get_Item("\\endofdoc").Range, dtUngVien.Rows.Count + 1, dtUngVien.Columns.Count);
            table.Borders.Enable = 1;

            // Header
            for (int c = 0; c < dtUngVien.Columns.Count; c++)
            {
                table.Cell(1, c + 1).Range.Text = dtUngVien.Columns[c].ColumnName;
                table.Cell(1, c + 1).Range.Bold = 1;
            }

            // Rows
            for (int r = 0; r < dtUngVien.Rows.Count; r++)
            {
                for (int c = 0; c < dtUngVien.Columns.Count; c++)
                {
                    table.Cell(r + 2, c + 1).Range.Text = dtUngVien.Rows[r][c].ToString();
                }
            }

            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"UngVien_Tin{tinId}.docx");
            doc.SaveAs2(path);
            doc.Close();
            app.Quit();

            MessageBox.Show($"✅ Đã xuất danh sách ứng viên ra file:\n{path}", "Thành công");
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            txtmadoanhnghiep.Clear();
            txtmatintuyendung.Clear();
            dgvUngVien.DataSource = null;  // 🧹 Xóa toàn bộ dữ liệu hiện có
            dgvUngVien.Rows.Clear();       // Xóa hàng nếu còn sót
        }
    }
}
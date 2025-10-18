using Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.CSS;
using Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.ERS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.SA
{
    public partial class TraCuuDuLieu_Form : Form
    {
        private const int PagePadding = 16;
        private const int ColumnGap = 12;
        private const int SectionSpacing = 10;
        private const int BottomButtonsHeight = 101;

        private readonly TrangChuSA_Form _host;

        public TraCuuDuLieu_Form(TrangChuSA_Form host)
        {
            InitializeComponent();
            _host = host ?? throw new ArgumentNullException(nameof(host));
            SetupResponsiveLayout();
            this.Resize += (s, e) => AdjustLayout();
            AdjustLayout();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            TrangChuSA_Form next = new TrangChuSA_Form();
            next.Show();
            this.Hide();
        }

        private void SetupResponsiveLayout()
        {
            // Tiêu đề dock top, canh giữa
            if (lblTieuDe != null)
            {
                lblTieuDe.Dock = DockStyle.Top;
                lblTieuDe.AutoSize = false;
                lblTieuDe.Height = 56;
                lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            }

            // Anchor các nhãn mục và hình ảnh theo Top
            if (lblHoSo != null) lblHoSo.Anchor = AnchorStyles.Top;
            if (lblDoanhNghiep != null) lblDoanhNghiep.Anchor = AnchorStyles.Top;
            if (lblDanhSach != null) lblDanhSach.Anchor = AnchorStyles.Top;

            if (picTinTuyenDung != null) picTinTuyenDung.SizeMode = PictureBoxSizeMode.Zoom;
            if (picDanhSach != null) picDanhSach.SizeMode = PictureBoxSizeMode.Zoom;
            if (picHoSo != null) picHoSo.SizeMode = PictureBoxSizeMode.Zoom;

            // Nút dưới cùng bám Bottom, căn theo cột
            if (btnTraCuuHoSoUV != null) btnTraCuuHoSoUV.Anchor = AnchorStyles.Bottom;
            if (btnTimKiemTTD != null) btnTimKiemTTD.Anchor = AnchorStyles.Bottom;
            if (btnTraCuuDanhSachUV != null) btnTraCuuDanhSachUV.Anchor = AnchorStyles.Bottom;
        }

        private void AdjustLayout()
        {
            // Tính layout 3 cột cân bằng theo chiều rộng form
            int topStart = (lblTieuDe?.Bottom ?? 0) + SectionSpacing;
            int clientW = this.ClientSize.Width;
            int clientH = this.ClientSize.Height;
            if (clientW <= 0 || clientH <= 0) return;

            int availableW = clientW - (PagePadding * 2) - (ColumnGap * 2);
            int colW = Math.Max(200, availableW / 3);

            int col1X = PagePadding;
            int col2X = col1X + colW + ColumnGap;
            int col3X = col2X + colW + ColumnGap;

            // Chiều cao phần hình ảnh: từ sau nhãn đến trước khu nút
            int bottomButtonsTop = clientH - (BottomButtonsHeight + PagePadding);
            int imageTop = topStart + (lblHoSo?.Height ?? 38) + SectionSpacing;
            int imageHeight = Math.Max(120, bottomButtonsTop - imageTop - SectionSpacing);

            // Đặt nhãn tiêu đề cho từng cột
            if (lblHoSo != null)
            {
                lblHoSo.Left = col1X + (colW - lblHoSo.Width) / 2;
                lblHoSo.Top = topStart;
            }
            if (lblDoanhNghiep != null)
            {
                lblDoanhNghiep.Left = col2X + (colW - lblDoanhNghiep.Width) / 2;
                lblDoanhNghiep.Top = topStart;
            }
            if (lblDanhSach != null)
            {
                lblDanhSach.Left = col3X + (colW - lblDanhSach.Width) / 2;
                lblDanhSach.Top = topStart;
            }

            // Đặt hình ảnh
            if (picHoSo != null)
            {
                picHoSo.Left = col1X;
                picHoSo.Top = imageTop;
                picHoSo.Width = colW;
                picHoSo.Height = imageHeight;
            }
            if (picTinTuyenDung != null)
            {
                picTinTuyenDung.Left = col2X;
                picTinTuyenDung.Top = imageTop;
                picTinTuyenDung.Width = colW;
                picTinTuyenDung.Height = imageHeight;
            }
            if (picDanhSach != null)
            {
                picDanhSach.Left = col3X;
                picDanhSach.Top = imageTop;
                picDanhSach.Width = colW;
                picDanhSach.Height = imageHeight;
            }

            // Nút đáy
            int btnTop = bottomButtonsTop;
            int btnH = BottomButtonsHeight;
            int btnW = colW;
            if (btnTraCuuHoSoUV != null)
            {
                btnTraCuuHoSoUV.Left = col1X;
                btnTraCuuHoSoUV.Top = btnTop;
                btnTraCuuHoSoUV.Width = btnW;
                btnTraCuuHoSoUV.Height = btnH;
            }
            if (btnTimKiemTTD != null)
            {
                btnTimKiemTTD.Left = col2X;
                btnTimKiemTTD.Top = btnTop;
                btnTimKiemTTD.Width = btnW;
                btnTimKiemTTD.Height = btnH;
            }
            if (btnTraCuuDanhSachUV != null)
            {
                btnTraCuuDanhSachUV.Left = col3X;
                btnTraCuuDanhSachUV.Top = btnTop;
                btnTraCuuDanhSachUV.Width = btnW;
                btnTraCuuDanhSachUV.Height = btnH;
            }
        }

        private void btnTraCuuHoSoUV_Click(object sender, EventArgs e)
        {
            var uc = new ChinhSuaThongTinUngVien_UC();
            _host.LoadControlIntoPanelWithBack(uc, "Tra cứu hồ sơ ứng viên");
        }

        private void btnTimKiemTTD_Click(object sender, EventArgs e)
        {
            var uc = new SelectDoanhNghiep_UC_Form();
            _host.LoadControlIntoPanelWithBack(uc, "Tra cứu hồ sơ doanh nghiệp");
        }

        private void btnTraCuuDanhSachUV_Click(object sender, EventArgs e)
        {
            var uc = new SelectDoanhNghiep1_UC_Form();
            _host.LoadControlIntoPanelWithBack(uc, "Tra cứu danh sách ứng viên");
        }

        private void TraCuuDuLieu_Form_Load(object sender, EventArgs e)
        {

        }
    }
}

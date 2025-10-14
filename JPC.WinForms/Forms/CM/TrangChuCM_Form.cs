using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.CM
{
    public partial class TrangChuCM_Form : Form
    {
        public TrangChuCM_Form()
        {
            InitializeComponent();
        }
        bool isSidebarExpanded = false;
        private void timerMenu_Tick(object sender, EventArgs e)
        {
            if (isSidebarExpanded)
            {
                pnlMenudoc.Width -= 38;
                if (pnlMenudoc.Width <= 77)
                {
                    timerMenu.Stop();
                    isSidebarExpanded = false;
                }
            }
            else
            {
                pnlMenudoc.Width += 38;
                if (pnlMenudoc.Width >= 340)
                {
                    timerMenu.Stop();
                    isSidebarExpanded = true;
                    // Optionally: show label/text/icon
                }
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            timerMenu.Start();
        }

        private void btnDieuChinhGia_Click(object sender, EventArgs e)
        {
            panelChinh.Controls.Clear();
            panelChinh.Controls.Add(new DieuChinhGiaDV_UC());
            panelChinh.Show();

        }

        private void btnThongKeSoLuongUV_Click(object sender, EventArgs e)
        {
            panelChinh.Controls.Clear();
            panelChinh.Controls.Add(new ThongKeSoLuongUngVien_UC());
            panelChinh.Show();
        }

        private void btnThongKeTyLeKetNoi_Click(object sender, EventArgs e)
        {
            panelChinh.Controls.Clear();
            panelChinh.Controls.Add(new ThongKeTyLeKetNoi_UC());
            panelChinh.Show();
        }
    }
}

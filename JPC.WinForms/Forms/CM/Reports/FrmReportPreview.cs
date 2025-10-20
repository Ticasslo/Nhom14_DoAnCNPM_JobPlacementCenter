using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.CM.Reports
{
    public partial class FrmReportPreview : Form
    {
        public FrmReportPreview()
        {
            InitializeComponent();
        }

        private void FrmReportPreview_Load(object sender, EventArgs e)
        {

            this.rv.RefreshReport();
        }
        //   public void LoadReport(string embeddedRdlc, DataTable data, ReportParameter[] ps)
        //   {
        //       rv.Reset();
        //       rv.ProcessingMode = ProcessingMode.Local;
        //       rv.LocalReport.ReportEmbeddedResource =
        //"Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.CM.Reports.CM_BM1_ThongKeSoLuong.rdlc";



        //       rv.LocalReport.DataSources.Clear();
        //       rv.LocalReport.DataSources.Add(new ReportDataSource("dsThongKe", data)); // tên dataset trong RDLC

        //       if (ps != null) rv.LocalReport.SetParameters(ps);
        //       rv.RefreshReport();
        //   }
        // Hàm tổng quát: truyền tên RDLC nhúng + tên dataset + DataTable + params
        public void LoadReport(string embeddedRdlc, string datasetName, DataTable data, ReportParameter[] ps)
        {
            rv.Reset();
            rv.ProcessingMode = ProcessingMode.Local;
            rv.LocalReport.ReportEmbeddedResource = embeddedRdlc;

            rv.LocalReport.DataSources.Clear();
            rv.LocalReport.DataSources.Add(new ReportDataSource(datasetName, data));
            if (ps != null && ps.Length > 0) rv.LocalReport.SetParameters(ps);

            rv.RefreshReport();
        }

        // Giữ lại hàm cũ cho BM1 (tương thích ngược)
        public void LoadReport(string embeddedRdlc, DataTable data, ReportParameter[] ps)
            => LoadReport(embeddedRdlc, "dsThongKe", data, ps);
        private void rv_Load(object sender, EventArgs e)
        {

        }

    }
}

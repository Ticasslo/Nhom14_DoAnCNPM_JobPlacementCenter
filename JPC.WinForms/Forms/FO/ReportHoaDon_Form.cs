using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.FO
{
    public partial class reportForm : Form
    {
        private readonly Dictionary<string, string> _ps;

        public reportForm(Dictionary<string, string> parameters = null)
        {
            InitializeComponent();
            _ps = parameters ?? new Dictionary<string, string>();
        }

        private void reportForm_Load(object sender, EventArgs e)
        {
            try
            {
                // 1) Chỉ định file/embedded
                var fullPath = Path.Combine(Application.StartupPath, "Forms", "FO", "ReportHoaDon.rdlc");
                reportViewerHoaDon.LocalReport.ReportPath = fullPath;

                reportViewerHoaDon.LocalReport.DataSources.Clear();

                // 2) (Tuỳ chọn) kiểm tra thiếu param
                var required = new[]
                {
            "DonVi","DiaChiDonVi","SoPhieu","NgayLap",
            "TenNguoiNop","DiaChiNguoiNop","LyDoNop","SoTien","SoTienBangChu",
            "KemTheo","ChungTuGoc","QuyenSo","No","Co"
            // nếu bạn có thêm: "NgayLapChu","NgayKyChu"
        };
                var missing = required.Where(k => !_ps.ContainsKey(k)).ToList();
                if (missing.Count > 0)
                    throw new Exception("Thiếu Report Parameters: " + string.Join(", ", missing));

                // 3) Set parameters
                var rp = _ps.Select(kv => new ReportParameter(kv.Key, kv.Value ?? ""))
                            .ToArray();
                reportViewerHoaDon.LocalReport.SetParameters(rp);

                reportViewerHoaDon.RefreshReport();
            }
            catch (LocalProcessingException ex)
            {
                var sb = new StringBuilder();
                sb.AppendLine(ex.Message);
                var ie = ex.InnerException;
                while (ie != null) { sb.AppendLine(ie.Message); ie = ie.InnerException; }
                MessageBox.Show("Lỗi khi tải báo cáo: " + sb.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải báo cáo: " + ex.Message);
            }
        }
    }
}

using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JPC.Business.Services.Interfaces.CSS;
using JPC.Business.Services.Implementations.CSS;
using JPC.Models;
using JPC.Models.UngVien;
using JPC.Models.DoanhNghiep;

namespace Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.CSS
{
    public partial class PhieuUngTuyen_Form : Form
    {
        private readonly int utId;
        private readonly string viTriUngTuyenTuUI; // có thể trống
        private readonly string lyDoUngTuyenTuUI; // có thể trống
        private readonly IUngTuyenService ungTuyenService;
        private readonly IUngVienService ungVienService;
        private readonly ITinTuyenDungService tinTuyenDungService;
        private readonly IDanhMucNgheService danhMucNgheService;

        public PhieuUngTuyen_Form(int utId, string viTriUngTuyen, string lyDoUngTuyen)
        {
            InitializeComponent();
            this.utId = utId;
            this.viTriUngTuyenTuUI = viTriUngTuyen ?? string.Empty;
            this.lyDoUngTuyenTuUI = lyDoUngTuyen ?? string.Empty;
            this.ungTuyenService = new UngTuyenService();
            this.ungVienService = new UngVienService();
            this.tinTuyenDungService = new TinTuyenDungService();
            this.danhMucNgheService = new DanhMucNgheService();
        }

        private void PhieuUngTuyen_Form_Load(object sender, EventArgs e)
        {
            try
            {
                var ungTuyen = ungTuyenService.GetUngTuyenById(this.utId);
                if (ungTuyen == null)
                {
                    MessageBox.Show("Không tìm thấy hồ sơ ứng tuyển.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }

                var ungVien = ungVienService.GetUngVienById(ungTuyen.UvId);
                var tin = tinTuyenDungService.GetTinTuyenDungById(ungTuyen.TinId);

                // ViTri: tập các vị trí mà tin tuyển dụng cần tuyển
                string tenViTri = string.Empty;
                var viTriIds = tinTuyenDungService.GetViTriByTin(tin.TinId).ToList();
                if (viTriIds.Count > 0)
                {
                    var tenList = viTriIds.Select(id => {
                        try { return danhMucNgheService.GetViTriChuyenMonById(id)?.TenViTri ?? $"VT{id}"; } catch { return $"VT{id}"; }
                    }).ToList();
                    tenViTri = string.Join(", ", tenList);
                }

                var doanhNghiepService = new DoanhNghiepService();
                var doanhNghiep = doanhNghiepService.GetDoanhNghiepById(tin.DnId);

                // ViTriUngTuyen: vị trí ứng viên mong muốn (ưu tiên từ UI nếu có)
                string viTriUngTuyen = string.Empty;
                if (!string.IsNullOrWhiteSpace(this.viTriUngTuyenTuUI))
                {
                    viTriUngTuyen = this.viTriUngTuyenTuUI;
                }
                else if (ungVien != null && ungVien.VtId.HasValue)
                {
                    try
                    {
                        viTriUngTuyen = danhMucNgheService.GetViTriChuyenMonById(ungVien.VtId.Value)?.TenViTri ?? $"VT{ungVien.VtId.Value}";
                    }
                    catch
                    {
                        viTriUngTuyen = $"VT{ungVien.VtId.Value}";
                    }
                }

                var table = new DataTable("PhieuUngTuyenData");
                table.Columns.Add("UtId", typeof(int));
                table.Columns.Add("NgayNop", typeof(string));
                table.Columns.Add("UvId", typeof(int));
                table.Columns.Add("HoTen", typeof(string));
                table.Columns.Add("CCCD", typeof(string));
                table.Columns.Add("Email", typeof(string));
                table.Columns.Add("SoDienThoai", typeof(string));
                table.Columns.Add("NgaySinh", typeof(string));
                table.Columns.Add("TinId", typeof(int));
                table.Columns.Add("TieuDe", typeof(string));
                table.Columns.Add("TenDoanhNghiep", typeof(string));
                table.Columns.Add("ViTri", typeof(string));
                table.Columns.Add("ViTriUngTuyen", typeof(string));
                table.Columns.Add("MucLuong", typeof(string));
                table.Columns.Add("LyDoUngTuyen", typeof(string));

                table.Rows.Add(
                    ungTuyen.UtId,
                    ungTuyen.NgayNop.ToString("dd/MM/yyyy HH:mm"),
                    ungVien?.UvId ?? 0,
                    ungVien?.HoTen ?? string.Empty,
                    ungVien?.Cccd ?? string.Empty,
                    ungVien?.Email ?? string.Empty,
                    ungVien?.SoDienThoai ?? string.Empty,
                    ungVien?.NgaySinh.ToString("dd/MM/yyyy"),
                    tin?.TinId ?? 0,
                    tin?.TieuDe ?? string.Empty,
                    doanhNghiep?.TenDoanhNghiep ?? string.Empty,
                    tenViTri,
                    viTriUngTuyen,
                    tin?.MucLuong ?? string.Empty,
                    this.lyDoUngTuyenTuUI
                );

                phieuUngTuyenReport.ProcessingMode = ProcessingMode.Local;
                phieuUngTuyenReport.LocalReport.DataSources.Clear();
                phieuUngTuyenReport.LocalReport.ReportEmbeddedResource = "Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.CSS.PhieuUngTuyen.rdlc";
                phieuUngTuyenReport.LocalReport.DataSources.Add(new ReportDataSource("PhieuUngTuyenData", table));
                phieuUngTuyenReport.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải phiếu ứng tuyển: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}

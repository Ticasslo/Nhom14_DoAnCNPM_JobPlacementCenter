using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.Models.DanhMucNghe
{
    public class ViTriChuyenMon
    {
        private int vtId;
        private int ngheId;
        private string tenViTri;
        private string trangThai;

        public ViTriChuyenMon()
        {
            this.vtId = 0;
            this.ngheId = 0;
            this.tenViTri = string.Empty;
            this.trangThai = "active";
        }

        public ViTriChuyenMon(int vtId, int ngheId, string tenViTri, string trangThai)
        {
            this.vtId = vtId;
            this.ngheId = ngheId;
            this.tenViTri = tenViTri ?? string.Empty;
            this.trangThai = string.IsNullOrWhiteSpace(trangThai) ? "active" : trangThai;
        }

        public int VtId { get { return this.vtId; } set { this.vtId = value; } }
        public int NgheId { get { return this.ngheId; } set { this.ngheId = value; } }
        public string TenViTri { get { return this.tenViTri; } set { this.tenViTri = value ?? string.Empty; } }
        public string TrangThai { get { return this.trangThai; } set { this.trangThai = value ?? "active"; } }
    }
}

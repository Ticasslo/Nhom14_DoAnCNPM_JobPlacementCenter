using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.Models.DanhMucNghe
{
    public class Nghe
    {
        private int ngheId;
        private int nhomId;
        private string tenNghe;
        private string trangThai;

        public Nghe()
        {
            this.ngheId = 0;
            this.nhomId = 0;
            this.tenNghe = string.Empty;
            this.trangThai = "active";
        }

        public Nghe(int ngheId, int nhomId, string tenNghe, string trangThai)
        {
            this.ngheId = ngheId;
            this.nhomId = nhomId;
            this.tenNghe = tenNghe ?? string.Empty;
            this.trangThai = string.IsNullOrWhiteSpace(trangThai) ? "active" : trangThai;
        }

        public int NgheId { get { return this.ngheId; } set { this.ngheId = value; } }
        public int NhomId { get { return this.nhomId; } set { this.nhomId = value; } }
        public string TenNghe { get { return this.tenNghe; } set { this.tenNghe = value ?? string.Empty; } }
        public string TrangThai { get { return this.trangThai; } set { this.trangThai = value ?? "active"; } }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.Models.DanhMucNghe
{
    public class NhomNghe
    {
        private int nhomId;
        private string tenNhom;
        private string trangThai;

        public NhomNghe()
        {
            this.nhomId = 0;
            this.tenNhom = string.Empty;
            this.trangThai = "active";
        }

        public NhomNghe(int nhomId, string tenNhom, string trangThai)
        {
            this.nhomId = nhomId;
            this.tenNhom = tenNhom ?? string.Empty;
            this.trangThai = string.IsNullOrWhiteSpace(trangThai) ? "active" : trangThai;
        }

        public int NhomId { get { return this.nhomId; } set { this.nhomId = value; } }
        public string TenNhom { get { return this.tenNhom; } set { this.tenNhom = value ?? string.Empty; } }
        public string TrangThai { get { return this.trangThai; } set { this.trangThai = value ?? "active"; } }
    }
}

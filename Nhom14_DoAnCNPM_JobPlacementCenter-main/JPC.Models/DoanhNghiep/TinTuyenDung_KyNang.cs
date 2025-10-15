using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.Models.DoanhNghiep
{
    public class TinTuyenDung_KyNang
    {
        private int tinId;
        private int vtId;
        private string tenKyNang;

        public TinTuyenDung_KyNang()
        {
            this.tinId = 0;
            this.vtId = 0;
            this.tenKyNang = string.Empty;
        }

        public TinTuyenDung_KyNang(int tinId, int vtId, string tenKyNang)
        {
            this.tinId = tinId;
            this.vtId = vtId;
            this.tenKyNang = tenKyNang ?? string.Empty;
        }

        public int TinId { get { return this.tinId; } set { this.tinId = value; } }
        public int VtId { get { return this.vtId; } set { this.vtId = value; } }
        public string TenKyNang { get { return this.tenKyNang; } set { this.tenKyNang = value ?? string.Empty; } }
    }
}

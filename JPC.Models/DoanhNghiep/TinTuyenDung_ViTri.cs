using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.Models.DoanhNghiep
{
    public class TinTuyenDung_ViTri
    {
        private int tinId;
        private int vtId;

        public TinTuyenDung_ViTri()
        {
            this.tinId = 0;
            this.vtId = 0;
        }

        public TinTuyenDung_ViTri(int tinId, int vtId)
        {
            this.tinId = tinId;
            this.vtId = vtId;
        }

        public int TinId { get { return this.tinId; } set { this.tinId = value; } }
        public int VtId { get { return this.vtId; } set { this.vtId = value; } }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.Models.TaiChinh
{
    public class PhiDichVu
    {
        private int phiId;
        private string tenDichVu;
        private decimal soTien;

        public PhiDichVu()
        {
            this.phiId = 0;
            this.tenDichVu = string.Empty;
            this.soTien = 0m;
        }

        public PhiDichVu(int phiId, string tenDichVu, decimal soTien)
        {
            this.phiId = phiId;
            this.tenDichVu = tenDichVu ?? string.Empty;
            this.soTien = soTien;
        }

        public int PhiId { get { return this.phiId; } set { this.phiId = value; } }
        public string TenDichVu { get { return this.tenDichVu; } set { this.tenDichVu = value ?? string.Empty; } }
        public decimal SoTien { get { return this.soTien; } set { this.soTien = value; } }
    }
}

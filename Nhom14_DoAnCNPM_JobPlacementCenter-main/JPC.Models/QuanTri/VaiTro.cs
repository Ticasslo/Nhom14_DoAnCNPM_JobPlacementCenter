using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.Models.QuanTri
{
    public class VaiTro
    {
        private string vaiTroId;
        private string tenVaiTro;

        public VaiTro()
        {
            this.vaiTroId = string.Empty;
            this.tenVaiTro = string.Empty;
        }

        public VaiTro(string vaiTroId, string tenVaiTro)
        {
            this.vaiTroId = vaiTroId ?? string.Empty;
            this.tenVaiTro = tenVaiTro ?? string.Empty;
        }

        public string VaiTroId { get { return this.vaiTroId; } set { this.vaiTroId = value ?? string.Empty; } }
        public string TenVaiTro { get { return this.tenVaiTro; } set { this.tenVaiTro = value ?? string.Empty; } }
    }
}

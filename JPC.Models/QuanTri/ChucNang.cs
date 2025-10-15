using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.Models.QuanTri
{
    public class ChucNang
    {
        private string chucNangId;
        private string tenChucNang;
        private string moTa;

        public ChucNang()
        {
            this.chucNangId = string.Empty;
            this.tenChucNang = string.Empty;
            this.moTa = string.Empty;
        }

        public ChucNang(string chucNangId, string tenChucNang, string moTa)
        {
            this.chucNangId = chucNangId ?? string.Empty;
            this.tenChucNang = tenChucNang ?? string.Empty;
            this.moTa = moTa ?? string.Empty;
        }

        public string ChucNangId { get { return this.chucNangId; } set { this.chucNangId = value ?? string.Empty; } }
        public string TenChucNang { get { return this.tenChucNang; } set { this.tenChucNang = value ?? string.Empty; } }
        public string MoTa { get { return this.moTa; } set { this.moTa = value ?? string.Empty; } }
    }
}

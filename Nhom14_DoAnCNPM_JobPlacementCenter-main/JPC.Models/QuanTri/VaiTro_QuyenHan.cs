using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.Models.QuanTri
{
    public class VaiTro_QuyenHan
    {
        private string vaiTroId;
        private string chucNangId;
        private bool quyenHan;

        public VaiTro_QuyenHan()
        {
            this.vaiTroId = string.Empty;
            this.chucNangId = string.Empty;
            this.quyenHan = false;
        }

        public VaiTro_QuyenHan(string vaiTroId, string chucNangId, bool quyenHan)
        {
            this.vaiTroId = vaiTroId ?? string.Empty;
            this.chucNangId = chucNangId ?? string.Empty;
            this.quyenHan = quyenHan;
        }

        public string VaiTroId { get { return this.vaiTroId; } set { this.vaiTroId = value ?? string.Empty; } }
        public string ChucNangId { get { return this.chucNangId; } set { this.chucNangId = value ?? string.Empty; } }
        public bool QuyenHan { get { return this.quyenHan; } set { this.quyenHan = value; } }
    }
}

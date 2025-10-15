using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.Models.UngVien
{
    public class UngTuyen
    {
        private int utId;
        private int uvId;
        private int tinId;
        private string trangThai;       // DA_NOP, TRUNG_TUYEN, KHONG_TRUNG_TUYEN
        private int phiId;              // 1
        private bool daThanhToanPhi;
        private DateTime ngayNop;

        public UngTuyen()
        {
            this.utId = 0;
            this.uvId = 0;
            this.tinId = 0;
            this.trangThai = "DA_NOP";
            this.phiId = 1;
            this.daThanhToanPhi = false;
            this.ngayNop = DateTime.Now;
        }

        public UngTuyen(int utId, int uvId, int tinId, string trangThai, int phiId, bool daThanhToanPhi, DateTime ngayNop)
        {
            this.utId = utId;
            this.uvId = uvId;
            this.tinId = tinId;
            this.trangThai = string.IsNullOrWhiteSpace(trangThai) ? "DA_NOP" : trangThai;
            this.phiId = phiId;
            this.daThanhToanPhi = daThanhToanPhi;
            this.ngayNop = ngayNop;
        }

        public int UtId { get { return this.utId; } set { this.utId = value; } }
        public int UvId { get { return this.uvId; } set { this.uvId = value; } }
        public int TinId { get { return this.tinId; } set { this.tinId = value; } }
        public string TrangThai { get { return this.trangThai; } set { this.trangThai = value ?? "DA_NOP"; } }
        public int PhiId { get { return this.phiId; } set { this.phiId = value; } }
        public bool DaThanhToanPhi { get { return this.daThanhToanPhi; } set { this.daThanhToanPhi = value; } }
        public DateTime NgayNop { get { return this.ngayNop; } set { this.ngayNop = value; } }
    }
}

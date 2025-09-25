using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.Models.TaiChinh
{
    public class HoaDon
    {
        private int maHoaDon;
        private string loaiKhachHang;   // 'ung_vien' | 'doanh_nghiep'
        private int? uvId;
        private int? utId;
        private int? dnId;
        private int? tinId;
        private string tenKhachHang;
        private int phiId;              // 1 hoặc 2
        private decimal soTien;         // DECIMAL(10,0)
        private DateTime ngayLapHoaDon;
        private int maNhanVienLap;

        public HoaDon()
        {
            this.maHoaDon = 0;
            this.loaiKhachHang = string.Empty;
            this.uvId = null;
            this.utId = null;
            this.dnId = null;
            this.tinId = null;
            this.tenKhachHang = string.Empty;
            this.phiId = 0;
            this.soTien = 0m;
            this.ngayLapHoaDon = DateTime.Now;
            this.maNhanVienLap = 0;
        }

        public HoaDon(int maHoaDon, string loaiKhachHang, int? uvId, int? utId, int? dnId, int? tinId,
                      string tenKhachHang, int phiId, decimal soTien, DateTime ngayLapHoaDon, int maNhanVienLap)
        {
            this.maHoaDon = maHoaDon;
            this.loaiKhachHang = loaiKhachHang ?? string.Empty;
            this.uvId = uvId;
            this.utId = utId;
            this.dnId = dnId;
            this.tinId = tinId;
            this.tenKhachHang = tenKhachHang ?? string.Empty;
            this.phiId = phiId;
            this.soTien = soTien;
            this.ngayLapHoaDon = ngayLapHoaDon;
            this.maNhanVienLap = maNhanVienLap;
        }

        public int MaHoaDon { get { return this.maHoaDon; } set { this.maHoaDon = value; } }
        public string LoaiKhachHang { get { return this.loaiKhachHang; } set { this.loaiKhachHang = value ?? string.Empty; } }
        public int? UvId { get { return this.uvId; } set { this.uvId = value; } }
        public int? UtId { get { return this.utId; } set { this.utId = value; } }
        public int? DnId { get { return this.dnId; } set { this.dnId = value; } }
        public int? TinId { get { return this.tinId; } set { this.tinId = value; } }
        public string TenKhachHang { get { return this.tenKhachHang; } set { this.tenKhachHang = value ?? string.Empty; } }
        public int PhiId { get { return this.phiId; } set { this.phiId = value; } }
        public decimal SoTien { get { return this.soTien; } set { this.soTien = value; } }
        public DateTime NgayLapHoaDon { get { return this.ngayLapHoaDon; } set { this.ngayLapHoaDon = value; } }
        public int MaNhanVienLap { get { return this.maNhanVienLap; } set { this.maNhanVienLap = value; } }
    }
}

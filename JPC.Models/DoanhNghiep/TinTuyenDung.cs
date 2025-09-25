using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.Models.DoanhNghiep
{
    public class TinTuyenDung
    {
        private int tinId;
        private int dnId;
        private string tieuDe;
        private string moTaCongViec;
        private int soLuongTuyen;
        private string mucLuong;
        private string khuVucLamViec;
        private string hinhThucLamViec;
        private int kinhNghiemYeuCau;
        private DateTime ngayDang;
        private DateTime hanNopHoSo; // DATE → dùng DateTime chỉ phần ngày
        private string trangThai;
        private int phiId;
        private bool daThanhToan;

        public TinTuyenDung()
        {
            this.tinId = 0;
            this.dnId = 0;
            this.tieuDe = string.Empty;
            this.moTaCongViec = string.Empty;
            this.soLuongTuyen = 1;
            this.mucLuong = string.Empty;
            this.khuVucLamViec = string.Empty;
            this.hinhThucLamViec = string.Empty;
            this.kinhNghiemYeuCau = 0;
            this.ngayDang = DateTime.Now;
            this.hanNopHoSo = DateTime.Now.Date;
            this.trangThai = "inactive";
            this.phiId = 2;
            this.daThanhToan = false;
        }

        public TinTuyenDung(int tinId, int dnId, string tieuDe, string moTaCongViec,
                            int soLuongTuyen, string mucLuong, string khuVucLamViec,
                            string hinhThucLamViec, int kinhNghiemYeuCau,
                            DateTime ngayDang, DateTime hanNopHoSo,
                            string trangThai, int phiId, bool daThanhToan)
        {
            this.tinId = tinId;
            this.dnId = dnId;
            this.tieuDe = tieuDe ?? string.Empty;
            this.moTaCongViec = moTaCongViec ?? string.Empty;
            this.soLuongTuyen = soLuongTuyen;
            this.mucLuong = mucLuong ?? string.Empty;
            this.khuVucLamViec = khuVucLamViec ?? string.Empty;
            this.hinhThucLamViec = hinhThucLamViec ?? string.Empty;
            this.kinhNghiemYeuCau = kinhNghiemYeuCau;
            this.ngayDang = ngayDang;
            this.hanNopHoSo = hanNopHoSo;
            this.trangThai = string.IsNullOrWhiteSpace(trangThai) ? "inactive" : trangThai;
            this.phiId = phiId;
            this.daThanhToan = daThanhToan;
        }

        public int TinId { get { return this.tinId; } set { this.tinId = value; } }
        public int DnId { get { return this.dnId; } set { this.dnId = value; } }
        public string TieuDe { get { return this.tieuDe; } set { this.tieuDe = value ?? string.Empty; } }
        public string MoTaCongViec { get { return this.moTaCongViec; } set { this.moTaCongViec = value ?? string.Empty; } }
        public int SoLuongTuyen { get { return this.soLuongTuyen; } set { this.soLuongTuyen = value; } }
        public string MucLuong { get { return this.mucLuong; } set { this.mucLuong = value ?? string.Empty; } }
        public string KhuVucLamViec { get { return this.khuVucLamViec; } set { this.khuVucLamViec = value ?? string.Empty; } }
        public string HinhThucLamViec { get { return this.hinhThucLamViec; } set { this.hinhThucLamViec = value ?? string.Empty; } }
        public int KinhNghiemYeuCau { get { return this.kinhNghiemYeuCau; } set { this.kinhNghiemYeuCau = value; } }
        public DateTime NgayDang { get { return this.ngayDang; } set { this.ngayDang = value; } }
        public DateTime HanNopHoSo { get { return this.hanNopHoSo; } set { this.hanNopHoSo = value; } }
        public string TrangThai { get { return this.trangThai; } set { this.trangThai = value ?? "inactive"; } }
        public int PhiId { get { return this.phiId; } set { this.phiId = value; } }
        public bool DaThanhToan { get { return this.daThanhToan; } set { this.daThanhToan = value; } }
    }
}

using JPC.Business.Services.Interfaces.CSS;
using JPC.Business.Services.Interfaces.ERS;
using JPC.DataAccess.Repositories.Implementations.ERS;
using JPC.DataAccess.Repositories.Interfaces.ERS;
using JPC.Models.DoanhNghiep;
using System;
using System.Data;

namespace JPC.Business.Services.Implementations.ERS
{
    public class TinTuyenDungService_ERS : Interfaces.ERS.ITinTuyenDungService_ERS
    {
        private readonly ITinTuyenDungRepository_ERS _repo;

        public TinTuyenDungService_ERS()
        {
            _repo = new TinTuyenDungRepository_ERS();
        }

        public (bool Ok, string Message, int NewId) InsertTinTuyenDung(TinTuyenDung tin)
        {
            // Validate tối thiểu
            if (tin == null) return (false, "Dữ liệu trống.", 0);
            if (tin.DnId <= 0) return (false, "Thiếu mã doanh nghiệp.", 0);
            if (string.IsNullOrWhiteSpace(tin.TieuDe)) return (false, "Thiếu tiêu đề.", 0);
            if (string.IsNullOrWhiteSpace(tin.HinhThucLamViec))
                return (false, "Thiếu hình thức làm việc.", 0);

            // Theo constraint: hinh_thuc_lam_viec ∈ {Toàn thời gian, Bán thời gian, Thực tập}
            var ht = tin.HinhThucLamViec.Trim();
            if (ht != "Toàn thời gian" && ht != "Bán thời gian" && ht != "Thực tập")
                return (false, "Hình thức làm việc không hợp lệ.", 0);

            if (tin.HanNopHoSo.Date < DateTime.Now.Date)
                return (false, "Hạn nộp phải từ hôm nay trở đi.", 0);

            // DB mặc định: phi_id = 2, trang_thai 'inactive', da_thanh_toan = 0
            tin.PhiId = 2;
            tin.TrangThai = "inactive";
            tin.DaThanhToan = false;
            tin.NgayDang = DateTime.Now;

            var newId = _repo.InsertTinTuyenDung(tin);
            return newId > 0
                ? (true, "Đăng tin thành công. FO sẽ kích hoạt sau khi thanh toán.", newId)
                : (false, "Không thể thêm tin.", 0);
        }
        public DataTable GetTinByDoanhNghiep(int dnId)
        {
            if (dnId <= 0)
                throw new ArgumentException("Mã doanh nghiệp không hợp lệ.");

            return _repo.GetTinByDoanhNghiep(dnId);
        }

    }
}
//using JPC.Business.Services.Interfaces.CSS;
//using JPC.Business.Services.Interfaces.ERS;
//using JPC.DataAccess.Repositories.Implementations.ERS;
//using JPC.DataAccess.Repositories.Interfaces.ERS;
//using JPC.Models.DoanhNghiep;
//using System;
//using System.Data;

//namespace JPC.Business.Services.Implementations.ERS
//{
//    public class TinTuyenDungService_ERS : Interfaces.ERS.ITinTuyenDungService_ERS
//    {
//        private readonly ITinTuyenDungRepository_ERS _repo;

//        public TinTuyenDungService_ERS()
//        {
//            _repo = new TinTuyenDungRepository_ERS();
//        }

//        public (bool Ok, string Message, int NewId) InsertTinTuyenDung(TinTuyenDung tin)
//        {
//            // Validate tối thiểu
//            if (tin == null) return (false, "Dữ liệu trống.", 0);
//            if (tin.DnId <= 0) return (false, "Thiếu mã doanh nghiệp.", 0);
//            if (string.IsNullOrWhiteSpace(tin.TieuDe)) return (false, "Thiếu tiêu đề.", 0);
//            if (string.IsNullOrWhiteSpace(tin.HinhThucLamViec))
//                return (false, "Thiếu hình thức làm việc.", 0);
//            if (tin.SoLuongTuyen <= 0)
//                return (false, "Số lượng tuyển phải lớn hơn 0.", 0);

//            if (string.IsNullOrWhiteSpace(tin.KhuVucLamViec))
//                return (false, "Thiếu khu vực làm việc.", 0);
//            if (string.IsNullOrWhiteSpace(tin.MoTaCongViec))
//                return (false, "Thiếu mô tả công việc.", 0);
//            if (string.IsNullOrWhiteSpace(tin.MucLuong))
//                return (false, "Thiếu lương.", 0);
//            //if (string.IsNullOrWhiteSpace(tin.KinhNghiemYeuCau))
//            //    return (false, "Thiếu kinh nghiệm yêu cầu.", 0);
//            if (tin.KinhNghiemYeuCau < 0)
//                return (false, "Kinh nghiệm yêu cầu không hợp lệ.", 0);


//            // Theo constraint: hinh_thuc_lam_viec ∈ {Toàn thời gian, Bán thời gian, Thực tập}
//            var ht = tin.HinhThucLamViec.Trim();
//            if (ht != "Toàn thời gian" && ht != "Bán thời gian" && ht != "Thực tập")
//                return (false, "Hình thức làm việc không hợp lệ.", 0);

//            if (tin.HanNopHoSo.Date < DateTime.Now.Date)
//                return (false, "Hạn nộp phải từ hôm nay trở đi.", 0);

//            // DB mặc định: phi_id = 2, trang_thai 'inactive', da_thanh_toan = 0
//            tin.PhiId = 2;
//            tin.TrangThai = "inactive";
//            tin.DaThanhToan = false;
//            tin.NgayDang = DateTime.Now;

//            var newId = _repo.InsertTinTuyenDung(tin);
//            return newId > 0
//                ? (true, "Đăng tin thành công. FO sẽ kích hoạt sau khi thanh toán.", newId)
//                : (false, "Không thể thêm tin.", 0);
//        }
//        public DataTable GetTinByDoanhNghiep(int dnId)
//        {
//            if (dnId <= 0)
//                throw new ArgumentException("Mã doanh nghiệp không hợp lệ.");

//            return _repo.GetTinByDoanhNghiep(dnId);
//        }

//    }
//}


using System;
using System.Data;
using JPC.Business.Services.Interfaces.ERS;
using JPC.DataAccess.Repositories.Implementations.ERS;
using JPC.DataAccess.Repositories.Interfaces.ERS;
using JPC.Models.DoanhNghiep;

namespace JPC.Business.Services.Implementations.ERS
{
    public class TinTuyenDungService_ERS : ITinTuyenDungService_ERS
    {
        private readonly ITinTuyenDungRepository_ERS _repo;

        public TinTuyenDungService_ERS()
        {
            _repo = new TinTuyenDungRepository_ERS();
        }

        // 🟢 Thêm tin tuyển dụng
        public (bool Ok, string Message, int NewId) InsertTinTuyenDung(TinTuyenDung tin)
        {
            if (tin == null) return (false, "Dữ liệu trống.", 0);
            if (tin.DnId <= 0) return (false, "Thiếu mã doanh nghiệp.", 0);
            if (string.IsNullOrWhiteSpace(tin.TieuDe)) return (false, "Thiếu tiêu đề.", 0);
            if (string.IsNullOrWhiteSpace(tin.MoTaCongViec)) return (false, "Thiếu mô tả công việc.", 0);
            if (tin.SoLuongTuyen <= 0) return (false, "Số lượng tuyển phải lớn hơn 0.", 0);
            if (string.IsNullOrWhiteSpace(tin.MucLuong)) return (false, "Thiếu mức lương.", 0);
            if (string.IsNullOrWhiteSpace(tin.KhuVucLamViec)) return (false, "Thiếu khu vực làm việc.", 0);
            if (tin.KinhNghiemYeuCau < 0) return (false, "Kinh nghiệm yêu cầu không hợp lệ.", 0);

            var ht = tin.HinhThucLamViec?.Trim();
            if (ht != "Toàn thời gian" && ht != "Bán thời gian" && ht != "Thực tập")
                return (false, "Hình thức làm việc không hợp lệ.", 0);

            if (tin.HanNopHoSo.Date < DateTime.Now.Date)
                return (false, "Hạn nộp hồ sơ phải từ hôm nay trở đi.", 0);

            tin.PhiId = 2;
            tin.TrangThai = "inactive";
            tin.DaThanhToan = false;
            tin.NgayDang = DateTime.Now;

            var newId = _repo.InsertTinTuyenDung(tin);
            return newId > 0
                ? (true, "Đăng tin thành công. FO sẽ kích hoạt sau khi thanh toán.", newId)
                : (false, "Không thể thêm tin.", 0);
        }

        // 🟢 Thêm vị trí chuyên môn cho tin
        public (bool Ok, string Message) InsertViTriChoTin(int tinId, int vtId)
        {
            if (tinId <= 0 || vtId <= 0)
                return (false, "Mã tin hoặc mã vị trí không hợp lệ.");

            try
            {
                bool result = _repo.InsertViTriChoTin(tinId, vtId);
                return result
                    ? (true, "Đã thêm vị trí chuyên môn cho tin thành công.")
                    : (false, "Không thể thêm vị trí chuyên môn cho tin.");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi khi thêm vị trí: " + ex.Message);
            }
        }

        // 🟢 Lấy danh sách tin theo doanh nghiệp
        public DataTable GetTinByDoanhNghiep(int dnId)
        {
            if (dnId <= 0)
                throw new ArgumentException("Mã doanh nghiệp không hợp lệ.");

            return _repo.GetTinByDoanhNghiep(dnId);
        }
    }
}
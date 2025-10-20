using JPC.Business.Services.Interfaces.FO;
using JPC.DataAccess.Repositories.Implementations.FO;
using JPC.DataAccess.Repositories.Interfaces.FO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.Business.Services.Implementations.FO
{
    public class QuanLyHoaDonService : IQuanLyHoaDonService
    {
        private readonly IHoaDonRepository _hdRepo;
        private readonly INhanVienRepository _nvRepo;
        private readonly IDoanhNghiepRepository _dnRepo;
        private readonly IUngVienRepository _uvRepo;

        // ctor KHÔNG tham số: tự new repo, không cần service factory
        public QuanLyHoaDonService()
        {
            _hdRepo = new HoaDonRepository();
            _nvRepo = new NhanVienRepository();
            _dnRepo = new DoanhNghiepRepository();
            _uvRepo = new UngVienRepository();
        }

        // --- Combos ---
        public DataTable GetNhanVienActive() => _nvRepo.GetNhanViensActive();

        public IEnumerable<(int dn_id, string ten_doanh_nghiep, string dia_chi)> GetDoanhNghiepBasic()
            => _dnRepo.GetAllBasic();

        // --- Grid ---
        public DataTable GetAllHoaDon() => _hdRepo.GetAll();

        public DataTable GetHoaDonFiltered(int? dnId, int? maNvLap)
        {
            // UI dùng 0 = “Tất cả” → chuyển thành null
            if (dnId.HasValue && dnId.Value == 0) dnId = null;
            if (maNvLap.HasValue && maNvLap.Value == 0) maNvLap = null;
            return _hdRepo.GetList(dnId, maNvLap);
        }

        public int UpdateHoaDonBasic(int id, string tenKh, decimal soTien, DateTime ngay, int maNvLap)
            => _hdRepo.UpdateBasic(id, tenKh, soTien, ngay, maNvLap);

        // --- Hỗ trợ in report ---
        public string GetDiaChiDoanhNghiep(int dnId) => _dnRepo.GetDiaChiById(dnId);
        public string GetDiaChiUngVien(int uvId) => _uvRepo.GetDiaChiById(uvId);

        // --- Xóa an toàn ---
        public (bool ok, string message) XoaHoaDonAnToan(int maHoaDon)
        {
            var (rows, msg) = _hdRepo.DeleteHoaDonAnToan(maHoaDon);
            return (rows > 0, msg);
        }
    }
}
using JPC.Business.Services.Interfaces.FO;
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
        private readonly IHoaDonRepository _hoaDonRepo;
        private readonly INhanVienRepository _nhanVienRepo;
        private readonly IDoanhNghiepRepository _doanhNghiepRepo;
        private readonly IUngVienRepository _ungVienRepo;

        public QuanLyHoaDonService(
            IHoaDonRepository hoaDonRepo,
            INhanVienRepository nhanVienRepo,
            IDoanhNghiepRepository doanhNghiepRepo,
            IUngVienRepository ungVienRepo)
        {
            _hoaDonRepo = hoaDonRepo;
            _nhanVienRepo = nhanVienRepo;
            _doanhNghiepRepo = doanhNghiepRepo;
            _ungVienRepo = ungVienRepo;
        }

        public DataTable GetNhanVienActive() => _nhanVienRepo.GetNhanViensActive();
        public IEnumerable<(int dn_id, string ten_doanh_nghiep, string dia_chi)> GetDoanhNghiepBasic() => _doanhNghiepRepo.GetAllBasic();

        public DataTable GetAllHoaDon() => _hoaDonRepo.GetAll();
        public DataTable GetHoaDonFiltered(DateTime? ngay, int? dnId, int? maNvLap) => _hoaDonRepo.GetList(ngay, dnId, maNvLap);
        public int UpdateHoaDonBasic(int id, string tenKh, decimal soTien, DateTime ngay, int maNvLap)
            => _hoaDonRepo.UpdateBasic(id, tenKh, soTien, ngay, maNvLap);

        public string GetDiaChiDoanhNghiep(int dnId) => _doanhNghiepRepo.GetDiaChiById(dnId);
        public string GetDiaChiUngVien(int uvId) => _ungVienRepo.GetDiaChiById(uvId);
    }
}
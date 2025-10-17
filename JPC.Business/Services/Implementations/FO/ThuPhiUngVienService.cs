using JPC.Business.Services.Interfaces.FO;
using JPC.DataAccess.Repositories.Implementations.FO;
using JPC.DataAccess.Repositories.Interfaces.FO;
using JPC.Models.TaiChinh;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.Business.Services.Implementations.FO
{
    public class ThuPhiUngVienService : IThuPhiUngVienService
    {
        private readonly IUngVienRepository _uvRepo;
        private readonly IUngTuyenRepository _utRepo;
        private readonly IPhiDichVuRepository _phiRepo;
        private readonly INhanVienRepository _nvRepo;
        private readonly IHoaDonRepository _hdRepo;

        private const int PHI_UNG_TUYEN_ID = 1;

        public ThuPhiUngVienService(
            IUngVienRepository uvRepo,
            IUngTuyenRepository utRepo,
            IPhiDichVuRepository phiRepo,
            INhanVienRepository nvRepo,
            IHoaDonRepository hdRepo)
        {
            _uvRepo = uvRepo;
            _utRepo = utRepo;
            _phiRepo = phiRepo;
            _nvRepo = nvRepo;
            _hdRepo = hdRepo;
        }

        public decimal GetDonGiaCoDinh()
            => _phiRepo.GetSoTienById(PHI_UNG_TUYEN_ID);

        public DataTable GetUngVien()
            => _uvRepo.GetAllUngVienBasic();

        public DataTable GetHoSoUngTuyenChuaThuPhi(int uvId)
            => _utRepo.GetHoSoUngTuyenChuaThuPhiByUv(uvId);

        public DataTable GetNhanViensActive()
            => _nvRepo.GetNhanViensActive(); // method này bạn đã có trong repo NV

        public (int maHoaDon, decimal soTien) LapHoaDonPhiUngVien(int uvId, int utId, string tenUv, int maNv)
        {
            // Nếu đã có hóa đơn thì trả về id cũ
            var existedId = _utRepo.GetInvoiceIdForUt(utId);
            if (existedId > 0)
            {
                var gia = GetDonGiaCoDinh();
                return (existedId, gia);
            }

            var soTien = GetDonGiaCoDinh();
            if (soTien <= 0) throw new InvalidOperationException("Chưa cấu hình đơn giá phí ứng tuyển (phi_id=1).");

            var hd = new HoaDon
            {
                LoaiKhachHang = "ung_vien",
                UvId = uvId,
                UtId = utId,
                TenKhachHang = tenUv ?? "",
                PhiId = PHI_UNG_TUYEN_ID,
                SoTien = soTien,
                MaNhanVienLap = maNv
            };

            var maHoaDon = _hdRepo.InsertHoaDon(hd);
            _utRepo.MarkPaid(utId);
            return (maHoaDon, soTien);
        }

        public int GetExistingInvoiceIdForUt(int utId) => _utRepo.GetInvoiceIdForUt(utId);
    }
}

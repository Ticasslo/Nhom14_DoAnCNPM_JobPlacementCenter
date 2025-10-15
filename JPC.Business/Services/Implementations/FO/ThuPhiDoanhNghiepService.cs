using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using JPC.DataAccess.Repositories.Interfaces.ERS;
using JPC.DataAccess.Repositories.Interfaces.FO;
using JPC.Models.TaiChinh;
using JPC.Business.Services.Interfaces.FO;
using System.Configuration;

namespace JPC.Business.Services.Implementations.FO
{
    public class ThuPhiDoanhNghiepService : IThuPhiDoanhNghiepService
    {
        private readonly ITinTuyenDungRepository _tinRepo;
        private readonly IHoaDonRepository _hdRepo;
        private readonly IPhiDichVuRepository _phiRepo;
        private readonly IDoanhNghiepRepository _dnRepo;
        private readonly INhanVienRepository _nvRepo;
        private static readonly string _cnn = ConfigurationManager.ConnectionStrings["JobPlacementCenter"].ConnectionString;

        public ThuPhiDoanhNghiepService(ITinTuyenDungRepository tinRepo, IHoaDonRepository hdRepo,
                                        IPhiDichVuRepository phiRepo, IDoanhNghiepRepository dnRepo,
                                        INhanVienRepository nvRepo)
        {
            _tinRepo = tinRepo;
            _hdRepo = hdRepo;
            _phiRepo = phiRepo;
            _dnRepo = dnRepo;
            _nvRepo = nvRepo;
        }

        public IEnumerable<(int dn_id, string ten_doanh_nghiep, string dia_chi)> GetDoanhNghieps() => _dnRepo.GetAllBasic();

        public IEnumerable<(int tin_id, string display)> GetUnpaidPostsByDn(int dnId)
        {
            foreach (var x in _tinRepo.GetUnpaidByDoanhNghiep(dnId))
                yield return (x.tin_id, x.display);
        }

        public IEnumerable<(int ma_nhan_vien, string ho_ten)> GetNhanViens() => _nvRepo.GetAllBasic();

        public (int soNgay, decimal soTienMacDinh, string tenDoanhNghiep) PreviewAmount(int tinId)
        {
            var core = _tinRepo.GetCoreInfo(tinId);
            int soNgay = (int)(core.han_nop_ho_so.Date - core.ngay_dang.Date).TotalDays + 1;
            if (soNgay < 1) soNgay = 1;

            var phi = _phiRepo.GetById(2) ?? throw new Exception("Không tìm thấy phí đăng tin (phi_id=2).");
            decimal soTien = soNgay * phi.SoTien;
            return (soNgay, soTien, core.ten_dn);
        }

        public (int maHoaDon, int soNgay, decimal soTien) LapHoaDonThuPhiDN(int tinId, int maNhanVienLap, decimal? soTienOverride = null)
        {
            var core = _tinRepo.GetCoreInfo(tinId);
            int soNgay = (int)(core.han_nop_ho_so.Date - core.ngay_dang.Date).TotalDays + 1;
            if (soNgay < 1) soNgay = 1;

            var phi = _phiRepo.GetById(2) ?? throw new Exception("Không tìm thấy phí đăng tin (phi_id=2).");
            decimal soTien = soTienOverride ?? (soNgay * phi.SoTien);

            SqlConnection con = new SqlConnection(_cnn);
            con.Open();
            SqlTransaction tran = con.BeginTransaction();

            try
            {
                var hoaDon = new HoaDon
                {
                    LoaiKhachHang = "doanh_nghiep",
                    DnId = core.dn_id,
                    TinId = tinId,
                    TenKhachHang = core.ten_dn,
                    PhiId = 2,
                    SoTien = soTien,
                    NgayLapHoaDon = DateTime.Now,
                    MaNhanVienLap = maNhanVienLap
                };

                int maHd = _hdRepo.Insert(hoaDon, tran); // IHoaDonRepository.Insert dùng transaction
                _tinRepo.MarkPaidAndActivate(tinId, tran);

                tran.Commit();
                return (maHd, soNgay, soTien);
            }
            catch
            {
                tran.Rollback();
                throw;
            }
            finally
            {
                tran.Dispose();
                con.Dispose();
            }
        }
    }
}

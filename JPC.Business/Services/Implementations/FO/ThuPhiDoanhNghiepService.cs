using JPC.Business.Services.Interfaces.FO;
using JPC.DataAccess.Repositories.Interfaces.FO;
using JPC.DataAccess.Repositories.Implementations.FO;
using JPC.Models.DoanhNghiep;
using JPC.Models.TaiChinh;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.Business.Services.Implementations.FO
{
    public class ThuPhiDoanhNghiepService : IThuPhiDoanhNghiepService
    {
        private readonly ITinTuyenDungRepository _tinRepo;
        private readonly IHoaDonRepository _hdRepo;
        private readonly IPhiDichVuRepository _phiRepo;
        private readonly IDoanhNghiepRepository _dnRepo;
        private readonly INhanVienRepository _nvRepo;

        public ThuPhiDoanhNghiepService()
        {
            _tinRepo = new TinTuyenDungRepository();
            _hdRepo = new HoaDonRepository();
            _phiRepo = new PhiDichVuRepository();
            _dnRepo = new DoanhNghiepRepository();
            _nvRepo = new NhanVienRepository();
        }

        public IEnumerable<(int tin_id, string display, DateTime ngay_dang, DateTime han_nop_ho_so)>
            GetTinChuaThanhToanByDoanhNghiep(int dnId)
            => _tinRepo.GetUnpaidByDoanhNghiep(dnId);
        public DataTable GetDoanhNghieps()
        {
            var list = _dnRepo.GetAllBasic();
            var t = new DataTable();
            t.Columns.Add("dn_id", typeof(int));
            t.Columns.Add("ten_doanh_nghiep", typeof(string));
            t.Columns.Add("dia_chi", typeof(string));
            foreach (var x in list) t.Rows.Add(x.dn_id, x.ten_doanh_nghiep, x.dia_chi ?? "");
            return t;
        }


        public DataTable GetTinByDoanhNghiep_ForCbb(int dnId)
        {
            var list = _tinRepo.GetUnpaidByDoanhNghiep(dnId);
            var t = new DataTable();
            t.Columns.Add("tin_id", typeof(int));
            t.Columns.Add("ngay_dang", typeof(DateTime));
            t.Columns.Add("han_nop_ho_so", typeof(DateTime));
            t.Columns.Add("ma_hoa_don", typeof(int));
            t.Columns.Add("so_tien_hd", typeof(decimal));
            t.Columns.Add("display", typeof(string));
            foreach (var it in list)
            {
                var row = t.NewRow();
                row["tin_id"] = it.tin_id;
                row["ngay_dang"] = it.ngay_dang.Date;
                row["han_nop_ho_so"] = it.han_nop_ho_so.Date;
                row["ma_hoa_don"] = DBNull.Value;
                row["so_tien_hd"] = DBNull.Value;
                row["display"] = it.display;
                t.Rows.Add(row);
            }
            return t;
        }

        public TinTuyenDung GetTinById(int tinId)
        {
            var c = _tinRepo.GetCoreInfo(tinId);
            return new TinTuyenDung
            {
                TinId = tinId,
                DnId = c.dn_id,
                TieuDe = "",
                NgayDang = c.ngay_dang,
                HanNopHoSo = c.han_nop_ho_so,
            };
        }

        public HoaDon GetHoaDonGanNhatCuaTin(int tinId) => _hdRepo.GetLatestByTinId(tinId);

        public decimal GetDonGiaNgay() => _phiRepo.GetSoTienById(2);

        public (int maHoaDon, int soNgay, decimal soTien) LapHoaDonThuPhiDN(int tinId, int maNhanVienLap, decimal? soTienOverride)
        {
            // lấy info tin
            var info = _tinRepo.GetCoreInfo(tinId); // (ngay_dang, han_nop_ho_so, dn_id, ten_dn)
            var soNgay = Math.Max(1, (info.han_nop_ho_so.Date - info.ngay_dang.Date).Days + 1);
            var donGia = GetDonGiaNgay();
            var soTien = soTienOverride ?? (soNgay * donGia);

            var hd = new HoaDon
            {
                LoaiKhachHang = "doanh_nghiep",
                DnId = info.dn_id,
                TinId = tinId,
                TenKhachHang = info.ten_dn ?? "",
                PhiId = 2,
                SoTien = soTien,
                NgayLapHoaDon = DateTime.Now,
                MaNhanVienLap = maNhanVienLap
            };

            // MỞ TRANSACTION và truyền xuống cả 2 repo
            var cnn = ConfigurationManager.ConnectionStrings["JobPlacementCenter"].ConnectionString;
            using (var con = new SqlConnection(cnn))
            {
                con.Open();
                using (var tran = con.BeginTransaction())
                {
                    try
                    {
                        var maHd = _hdRepo.Insert(hd, tran);
                        _tinRepo.MarkPaidAndActivate(tinId, tran);

                        tran.Commit();
                        return (maHd, soNgay, soTien);
                    }
                    catch
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
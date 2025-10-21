using JPC.Models.DoanhNghiep;
using JPC.Models.TaiChinh;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.Business.Services.Interfaces.FO
{
    public interface IThuPhiDoanhNghiepService
    {
        IEnumerable<(int tin_id, string display, DateTime ngay_dang, DateTime han_nop_ho_so)> GetTinChuaThanhToanByDoanhNghiep(int dnId);
        DataTable GetDoanhNghieps();
        DataTable GetTinByDoanhNghiep_ForCbb(int dnId);
        TinTuyenDung GetTinById(int tinId);
        HoaDon GetHoaDonGanNhatCuaTin(int tinId);

        decimal GetDonGiaNgay(); // phi_id=2

        (int maHoaDon, int soNgay, decimal soTien) LapHoaDonThuPhiDN(int tinId, int maNhanVienLap, decimal? soTienOverride, bool markPaid);
    }
}
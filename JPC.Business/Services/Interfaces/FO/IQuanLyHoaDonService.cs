using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.Business.Services.Interfaces.FO
{
    public interface IQuanLyHoaDonService
    {
        // Combos
        DataTable GetNhanVienActive();
        IEnumerable<(int dn_id, string ten_doanh_nghiep, string dia_chi)> GetDoanhNghiepBasic();

        // Grid
        DataTable GetAllHoaDon();
        DataTable GetHoaDonFiltered(int? dnId, int? maNvLap);
        int UpdateHoaDonBasic(int id, string tenKh, decimal soTien, DateTime ngay, int maNvLap);

        // Hỗ trợ in report
        string GetDiaChiDoanhNghiep(int dnId);
        string GetDiaChiUngVien(int uvId);

        (bool ok, string message) XoaHoaDonAnToan(int maHoaDon);

    }
}
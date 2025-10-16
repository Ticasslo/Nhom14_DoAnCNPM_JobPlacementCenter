using System.Collections.Generic;
using System.Data;

namespace JPC.Business.Services.Interfaces.ERS
{
    public interface IUngTuyenService_ERS
    {
        DataTable LayTinTheoDoanhNghiep(int dnId);

        DataTable LayTinTheoDoanhNghiepVaTin(int dnId, int tinId);

        DataTable GetUngVienByTin(int tinId);

        DataTable LayUngVienTheoDoanhNghiepVaTin(int dnId, int tinId);

        bool CapNhatKetQuaTuyenDung(List<(int uvId, int tinId, string trangThai)> updates);
    }
}

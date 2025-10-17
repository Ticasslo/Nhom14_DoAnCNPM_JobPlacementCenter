using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.Business.Services.Interfaces.FO
{
    public interface IThuPhiUngVienService
    {
        decimal GetDonGiaCoDinh();                 // từ bảng PhiDichVu phi_id=1
        DataTable GetUngVien();                    // uv_id, ho_ten, dia_chi
        DataTable GetHoSoUngTuyenChuaThuPhi(int uvId); // ut_id, tin_id, display
        DataTable GetNhanViensActive();            // ma_nhan_vien, ho_ten

        // Lập hóa đơn: trả về (maHoaDon, soTien)
        (int maHoaDon, decimal soTien) LapHoaDonPhiUngVien(int uvId, int utId, string tenUv, int maNv);

        // Kiểm tra đã có hóa đơn cho UT chưa (phục vụ UI nếu cần)
        int GetExistingInvoiceIdForUt(int utId); // 0 nếu chưa có
    }
}

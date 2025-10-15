using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.Business.Services.Interfaces.FO
{
    public interface IThuPhiDoanhNghiepService
    {
        // combobox nguồn
        IEnumerable<(int dn_id, string ten_doanh_nghiep, string dia_chi)> GetDoanhNghieps();
        IEnumerable<(int tin_id, string display)> GetUnpaidPostsByDn(int dnId);
        IEnumerable<(int ma_nhan_vien, string ho_ten)> GetNhanViens();

        // xem trước số ngày & số tiền mặc định
        (int soNgay, decimal soTienMacDinh, string tenDoanhNghiep) PreviewAmount(int tinId);

        // tạo hóa đơn + kích hoạt tin
        (int maHoaDon, int soNgay, decimal soTien) LapHoaDonThuPhiDN(int tinId, int maNhanVienLap, decimal? soTienOverride = null);
    }
}

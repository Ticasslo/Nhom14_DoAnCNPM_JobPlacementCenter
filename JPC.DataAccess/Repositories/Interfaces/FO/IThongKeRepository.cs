using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.DataAccess.Repositories.Interfaces.FO
{
    public interface IThongKeRepository
    {
        /// <summary>
        /// Lấy bảng hóa đơn trong khoảng ngày (đã format cột giống UI).
        /// </summary>
        DataTable GetHoaDonTrongKhoang(DateTime tuNgay, DateTime denNgay);
    }
}

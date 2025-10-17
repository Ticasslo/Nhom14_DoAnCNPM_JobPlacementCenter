using JPC.DataAccess.Repositories.Interfaces.FO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.DataAccess.Repositories.Implementations.FO
{
    public class ThongKeRepository : DBConnection.DBConnection, IThongKeRepository
    {
        private const string SQL = @"
SELECT 
    h.ma_hoa_don,
    h.ten_khach_hang,
    CASE WHEN h.loai_khach_hang='ung_vien' THEN N'Ứng viên' ELSE N'Doanh nghiệp' END AS doi_tuong,
    h.so_tien,
    CAST(h.ngay_lap_hoa_don AS date) AS ngay_thu
FROM HoaDon h
WHERE CAST(h.ngay_lap_hoa_don AS date) BETWEEN @from AND @to
ORDER BY h.ngay_lap_hoa_don DESC, h.ma_hoa_don DESC;";

        public DataTable GetHoaDonTrongKhoang(DateTime tuNgay, DateTime denNgay)
        {
            var prms = new List<SqlParameter>
            {
                new SqlParameter("@from", SqlDbType.Date){ Value = tuNgay.Date },
                new SqlParameter("@to",   SqlDbType.Date){ Value = denNgay.Date }
            };
            return ExecuteQuery(SQL, prms);
        }
    }
}
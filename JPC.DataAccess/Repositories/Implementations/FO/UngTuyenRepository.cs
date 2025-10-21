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
    public class UngTuyenRepository : DBConnection.DBConnection, IUngTuyenRepository
    {

        public DataTable GetHoSoUngTuyenChuaThuPhiByUv(int uvId)
        {
            const string sql = @"
                SELECT ut.ut_id,
                       ut.tin_id,
                       'UT#' + CONVERT(varchar,ut.ut_id) + ' - Tin ' + CONVERT(varchar,ut.tin_id) AS display,
                       ut.ngay_nop
                FROM UngTuyen ut
                INNER JOIN TinTuyenDung t ON t.tin_id = ut.tin_id
                WHERE ut.uv_id = @uv
                  AND ISNULL(ut.da_thanh_toan_phi,0)=0
                  AND ISNULL(t.da_thanh_toan,0)=1
                ORDER BY ut.ut_id DESC";
            return ExecuteQuery(sql, new List<SqlParameter>
            {
                new SqlParameter("@uv", uvId)
            });
        }

        public void MarkPaid(int utId)
        {
            const string sql = "UPDATE UngTuyen SET da_thanh_toan_phi=1 WHERE ut_id=@id";
            ExecuteNonQuery(sql, new List<SqlParameter>
            {
                new SqlParameter("@id", utId)
            });
        }

        public bool HasInvoice(int utId)
        {
            const string sql = "SELECT 1 FROM HoaDon WHERE loai_khach_hang='ung_vien' AND ut_id=@u";
            var o = ExecuteScalar(sql, new List<SqlParameter>
            {
                new SqlParameter("@u", utId)
            });
            return o != null && o != DBNull.Value;
        }

        public int GetInvoiceIdForUt(int utId)
        {
            const string sql = @"
                SELECT TOP(1) ma_hoa_don 
                FROM HoaDon 
                WHERE loai_khach_hang='ung_vien' AND ut_id=@u
                ORDER BY ma_hoa_don DESC";
            var o = ExecuteScalar(sql, new List<SqlParameter>
            {
                new SqlParameter("@u", utId)
            });
            return (o == null || o == DBNull.Value) ? 0 : Convert.ToInt32(o);
        }
    }
}
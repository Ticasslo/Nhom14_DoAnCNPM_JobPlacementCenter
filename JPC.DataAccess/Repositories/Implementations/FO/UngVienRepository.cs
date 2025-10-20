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
    public class UngVienRepository : DBConnection.DBConnection, IUngVienRepository
    {
        public DataTable GetAllUngVienBasic()
        {
            const string sql = @"
                SELECT uv_id, ho_ten, ISNULL(que_quan,'') AS dia_chi
                FROM UngVien
                ORDER BY ho_ten";
            return ExecuteQuery(sql);
        }
        public string GetDiaChiById(int uvId)
        {
            const string sql = "SELECT ISNULL(que_quan,'') FROM UngVien WHERE uv_id=@id";
            var o = ExecuteScalar(sql, new List<SqlParameter> { new SqlParameter("@id", uvId) });
            return o == null ? string.Empty : o.ToString();
        }
    }
}
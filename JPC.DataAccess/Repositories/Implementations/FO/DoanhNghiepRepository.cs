using JPC.DataAccess.DBConnection;                 // <-- thêm dòng này
using JPC.DataAccess.Repositories.Interfaces.FO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace JPC.DataAccess.Repositories.Implementations.FO
{
    public class DoanhNghiepRepository : DBConnection.DBConnection, IDoanhNghiepRepository
    {
        public IEnumerable<(int dn_id, string ten_doanh_nghiep, string dia_chi)> GetAllBasic()
        {
            const string sql = @"
                SELECT dn_id, ten_doanh_nghiep, ISNULL(dia_chi,'') AS dia_chi
                FROM DoanhNghiep
                ORDER BY ten_doanh_nghiep";

            var dt = ExecuteQuery(sql);
            var list = new List<(int, string, string)>();
            foreach (DataRow r in dt.Rows)
            {
                list.Add((
                    Convert.ToInt32(r["dn_id"]),
                    Convert.ToString(r["ten_doanh_nghiep"]),
                    Convert.ToString(r["dia_chi"])
                ));
            }
            return list;
        }
        
        public (int dn_id, string ten_doanh_nghiep, string dia_chi) GetById(int dnId)
        {
            const string sql = @"
                SELECT dn_id, ten_doanh_nghiep, ISNULL(dia_chi,'') AS dia_chi
                FROM DoanhNghiep
                WHERE dn_id = @id";

            var prms = new List<SqlParameter> { new SqlParameter("@id", dnId) };
            var dt = ExecuteQuery(sql, prms);
            if (dt.Rows.Count == 0)
                throw new InvalidOperationException("Không tìm thấy doanh nghiệp.");

            var r = dt.Rows[0];
            return (
                Convert.ToInt32(r["dn_id"]),
                Convert.ToString(r["ten_doanh_nghiep"]),
                Convert.ToString(r["dia_chi"])
            );
        }

        public string GetDiaChiById(int dnId)
        {
            const string sql = "SELECT ISNULL(dia_chi,'') FROM DoanhNghiep WHERE dn_id=@id";
            var o = ExecuteScalar(sql, new List<SqlParameter> { new SqlParameter("@id", dnId) });
            return o == null ? string.Empty : o.ToString();
        }
    }
}
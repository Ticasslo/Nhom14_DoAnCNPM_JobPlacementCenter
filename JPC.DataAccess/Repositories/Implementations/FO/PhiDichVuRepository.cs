using JPC.DataAccess.DBConnection;
using JPC.DataAccess.Repositories.Interfaces.FO;
using JPC.Models.TaiChinh;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace JPC.DataAccess.Repositories.Implementations.FO
{
    public class PhiDichVuRepository : DBConnection.DBConnection, IPhiDichVuRepository
    {
        public PhiDichVu GetById(int phiId)
        {
            const string sql = @"SELECT phi_id, ten_dich_vu, so_tien 
                                 FROM PhiDichVu 
                                 WHERE phi_id=@id";

            var prms = new List<SqlParameter> { new SqlParameter("@id", phiId) };
            var dt = ExecuteQuery(sql, prms);

            if (dt.Rows.Count == 0) return null;

            var r = dt.Rows[0];
            return new PhiDichVu(
                r.Field<int>("phi_id"),
                r.Field<string>("ten_dich_vu"),
                r.Field<decimal>("so_tien")
            );
        }

        public decimal GetSoTienById(int phiId)
        {
            const string sql = @"SELECT so_tien FROM PhiDichVu WHERE phi_id=@id";
            var prms = new List<SqlParameter> { new SqlParameter("@id", phiId) };

            var o = ExecuteScalar(sql, prms);
            return (o == null || o == DBNull.Value) ? 0m : Convert.ToDecimal(o);
        }
    }
}
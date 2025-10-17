using JPC.DataAccess.DBConnection;
using JPC.DataAccess.Repositories.Interfaces.FO;
using JPC.Models.TaiChinh;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.DataAccess.Repositories.Implementations.FO
{
    public class PhiDichVuRepository : DBConnection.DBConnection, IPhiDichVuRepository
    {
        private static readonly string _cnn = ConfigurationManager.ConnectionStrings["JobPlacementCenter"].ConnectionString;
        
        public PhiDichVu GetById(int phiId)
        {
            const string sql = "SELECT phi_id, ten_dich_vu, so_tien FROM PhiDichVu WHERE phi_id=@id";
            using (var con = new SqlConnection(_cnn))
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", phiId);
                con.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    if (!rd.Read()) return null;
                    return new PhiDichVu((int)rd["phi_id"], (string)rd["ten_dich_vu"], (decimal)rd["so_tien"]);
                }
            }
        }

        public decimal GetSoTienById(int phiId)
        {
            const string sql = "SELECT so_tien FROM PhiDichVu WHERE phi_id=@id";
            var o = ExecuteScalar(sql, new List<SqlParameter> { new SqlParameter("@id", phiId) });
            return (o == null || o == DBNull.Value) ? 0m : Convert.ToDecimal(o);
        }
    }
}

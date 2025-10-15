using JPC.DataAccess.Repositories.Interfaces.FO;
using JPC.Models.TaiChinh;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.DataAccess.Repositories.Implementations.FO
{
    public class PhiDichVuRepository : IPhiDichVuRepository
    {
        private readonly string _cnn;
        public PhiDichVuRepository(string connectionString) => _cnn = connectionString;

        public PhiDichVu GetById(int phiId)
        {
            const string sql = "SELECT phi_id, ten_dich_vu, so_tien FROM PhiDichVu WHERE phi_id=@id";
            using (var con = new SqlConnection(_cnn))
            {
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
        }
    }
}

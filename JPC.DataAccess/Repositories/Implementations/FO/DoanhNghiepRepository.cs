using JPC.DataAccess.Repositories.Interfaces.FO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JPC.DataAccess.DBConnection;

namespace JPC.DataAccess.Repositories.Implementations.FO
{
    public class DoanhNghiepRepository : IDoanhNghiepRepository
    {
        private readonly string _cnn;
        public DoanhNghiepRepository(string connectionString) => _cnn = connectionString;

        public IEnumerable<(int dn_id, string ten_doanh_nghiep, string dia_chi)> GetAllBasic()
        {
            const string sql = "SELECT dn_id, ten_doanh_nghiep, ISNULL(dia_chi,'') dia_chi FROM DoanhNghiep ORDER BY ten_doanh_nghiep";
            var list = new List<(int, string, string)>();
            using (var con = new SqlConnection(_cnn))
            {
                using (var cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                            list.Add(((int)rd["dn_id"], (string)rd["ten_doanh_nghiep"], (string)rd["dia_chi"]));
                    }
                }
            }
            return list;
        }

        public (int dn_id, string ten_doanh_nghiep, string dia_chi) GetById(int dnId)
        {
            const string sql = "SELECT dn_id, ten_doanh_nghiep, ISNULL(dia_chi,'') dia_chi FROM DoanhNghiep WHERE dn_id=@id";
            using (var con = new SqlConnection(_cnn))
            {
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@id", dnId);
                    con.Open();
                    using (var rd = cmd.ExecuteReader())
                    {
                        rd.Read();
                        return ((int)rd["dn_id"], (string)rd["ten_doanh_nghiep"], (string)rd["dia_chi"]);
                    }
                }
            }
        }
    }
}

using JPC.DataAccess.Repositories.Interfaces.FO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.DataAccess.Repositories.Implementations.FO
{
    public class NhanVienRepository : INhanVienRepository
    {

        private readonly string _cnn;
        public NhanVienRepository(string connectionString) => _cnn = connectionString;

        public IEnumerable<(int ma_nhan_vien, string ho_ten)> GetAllBasic()
        {
            const string sql = "SELECT ma_nhan_vien, ho_ten FROM NhanVien WHERE trang_thai='active' ORDER BY ho_ten";
            var list = new List<(int, string)>();
            using (var con = new SqlConnection(_cnn))
            {
                using (var cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                            list.Add(((int)rd["ma_nhan_vien"], (string)rd["ho_ten"]));
                    }
                }
            }
            return list;
        }
    }
}

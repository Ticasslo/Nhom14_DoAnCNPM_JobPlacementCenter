using JPC.DataAccess.Repositories.Interfaces.ERS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.DataAccess.Repositories.Implementations.ERS
{
    public class TinTuyenDungRepository : ITinTuyenDungRepository
    {
        private readonly string _cnn;
        public TinTuyenDungRepository(string connectionString) => _cnn = connectionString;

        public (DateTime ngay_dang, DateTime han_nop_ho_so, int dn_id, string ten_dn) GetCoreInfo(int tinId)
        {
            const string sql = @"SELECT t.ngay_dang, t.han_nop_ho_so, t.dn_id, d.ten_doanh_nghiep
                         FROM TinTuyenDung t
                         JOIN DoanhNghiep d ON d.dn_id=t.dn_id
                         WHERE t.tin_id=@id";
            using (var con = new SqlConnection(_cnn))
            {
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@id", tinId);
                    con.Open();
                    using (var rd = cmd.ExecuteReader())
                    {
                        if (!rd.Read()) throw new Exception("Không tìm thấy tin tuyển dụng.");
                        return ((DateTime)rd["ngay_dang"], (DateTime)rd["han_nop_ho_so"], (int)rd["dn_id"], (string)rd["ten_doanh_nghiep"]);
                    }
                }
            }
        }

        public IEnumerable<(int tin_id, string display, DateTime ngay_dang, DateTime han_nop_ho_so)> GetUnpaidByDoanhNghiep(int dnId)
        {
            const string sql = @"
              SELECT tin_id,
                     (tieu_de + ' (' + CONVERT(varchar(10), ngay_dang, 103) + ' → ' +
                                     CONVERT(varchar(10), han_nop_ho_so, 103) + ')') AS display,
                     ngay_dang, han_nop_ho_so
              FROM TinTuyenDung
              WHERE dn_id=@dn AND ISNULL(da_thanh_toan,0)=0
              ORDER BY tin_id DESC";
            var list = new List<(int, string, DateTime, DateTime)>();
            using (var con = new SqlConnection(_cnn))
            {
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@dn", dnId);
                    con.Open();
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                            list.Add(((int)rd["tin_id"], (string)rd["display"], (DateTime)rd["ngay_dang"], (DateTime)rd["han_nop_ho_so"]));
                    }
                }
            }
            return list;
        }

        public void MarkPaidAndActivate(int tinId, SqlTransaction tran)
        {
            const string sql = "UPDATE TinTuyenDung SET da_thanh_toan=1, trang_thai='active' WHERE tin_id=@id";
            using (var cmd = new SqlCommand(sql, tran.Connection, tran))
            {
                cmd.Parameters.AddWithValue("@id", tinId);
                cmd.ExecuteNonQuery();
            }
            
        }
    }
}

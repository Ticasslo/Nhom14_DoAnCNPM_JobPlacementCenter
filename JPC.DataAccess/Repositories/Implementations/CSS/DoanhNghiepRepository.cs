using JPC.DataAccess.DBConnection;
using JPC.DataAccess.Repositories.Interfaces.CSS;
using JPC.Models.DoanhNghiep;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace JPC.DataAccess.Repositories.Implementations.CSS
{
    public class DoanhNghiepRepository : DBConnection.DBConnection, IDoanhNghiepRepository
    {
        public DoanhNghiep GetDoanhNghiepById(int dnId)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@dnId", SqlDbType.Int) { Value = dnId }
            };
            var dt = ExecuteQuery(
                "SELECT dn_id, ten_doanh_nghiep, dia_chi, so_dien_thoai, email, ma_so_thue, linh_vuc, ngay_tao FROM DoanhNghiep WHERE dn_id = @dnId",
                parameters
            );
            
            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                return new DoanhNghiep(
                    Convert.ToInt32(row["dn_id"]),
                    Convert.ToString(row["ten_doanh_nghiep"]),
                    Convert.ToString(row["dia_chi"]),
                    Convert.ToString(row["so_dien_thoai"]),
                    Convert.ToString(row["email"]),
                    Convert.ToString(row["ma_so_thue"]),
                    Convert.ToString(row["linh_vuc"]),
                    Convert.ToDateTime(row["ngay_tao"])
                );
            }
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using JPC.DataAccess.DBConnection;
using JPC.DataAccess.Exceptions;
using JPC.DataAccess.Repositories.Interfaces.ERS;
using JPC.Models.DoanhNghiep;

namespace JPC.DataAccess.Repositories.Implementations.ERS
{
    public class DoanhNghiepRepository : JPC.DataAccess.DBConnection.DBConnection, IDoanhNghiepRepository
    {
        public bool ExistsByMST(string mst)
        {
            const string sql = "SELECT COUNT(1) FROM DoanhNghiep WHERE ma_so_thue = @mst";
            var prms = new List<SqlParameter> { new SqlParameter("@mst", mst) };
            var count = Convert.ToInt32(ExecuteScalar(sql, prms));
            return count > 0;
        }

        public bool ExistsByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            const string sql = "SELECT COUNT(1) FROM DoanhNghiep WHERE email = @e";
            var prms = new List<SqlParameter> { new SqlParameter("@e", email) };
            var count = Convert.ToInt32(ExecuteScalar(sql, prms));
            return count > 0;
        }

        public int Insert(DoanhNghiep dn)
        {
            const string sql = @"
INSERT INTO DoanhNghiep(ten_doanh_nghiep, dia_chi, so_dien_thoai, email, linh_vuc, ma_so_thue)
VALUES (@ten, @dc, @sdt, @em, @lv, @mst);";

            var prms = new List<SqlParameter>
            {
                new SqlParameter("@ten", dn.TenDoanhNghiep),
                new SqlParameter("@dc",  (object)dn.DiaChi      ?? DBNull.Value),
                new SqlParameter("@sdt", (object)dn.SoDienThoai ?? DBNull.Value),
                new SqlParameter("@em",  (object)dn.Email       ?? DBNull.Value),
                new SqlParameter("@lv",  (object)dn.LinhVuc     ?? DBNull.Value),
                new SqlParameter("@mst", dn.MaSoThue)
            };

            try
            {
                return ExecuteNonQuery(sql, prms);
            }
            catch (SqlException ex) // bắt duplicate key ở level DAL
            {
                if (ex.Message.Contains("UNIQUE") || ex.Number == 2627 || ex.Number == 2601)
                    throw new DataAccessException("Mã số thuế hoặc email đã tồn tại.", ex);
                throw;
            }
        }

        public int InsertAndReturnId(DoanhNghiep dn)
        {
            const string sql = @"
INSERT INTO DoanhNghiep(ten_doanh_nghiep, dia_chi, so_dien_thoai, email, linh_vuc, ma_so_thue)
VALUES (@ten, @dc, @sdt, @em, @lv, @mst);
SELECT CAST(SCOPE_IDENTITY() AS INT);";

            var prms = new List<SqlParameter>
            {
                new SqlParameter("@ten", dn.TenDoanhNghiep),
                new SqlParameter("@dc",  (object)dn.DiaChi      ?? DBNull.Value),
                new SqlParameter("@sdt", (object)dn.SoDienThoai ?? DBNull.Value),
                new SqlParameter("@em",  (object)dn.Email       ?? DBNull.Value),
                new SqlParameter("@lv",  (object)dn.LinhVuc     ?? DBNull.Value),
                new SqlParameter("@mst", dn.MaSoThue)
            };

            try
            {
                var newId = ExecuteScalar(sql, prms);
                return Convert.ToInt32(newId);
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("UNIQUE") || ex.Number == 2627 || ex.Number == 2601)
                    throw new DataAccessException("Mã số thuế hoặc email đã tồn tại.", ex);
                throw;
            }
        }

        public List<DoanhNghiep> GetAll()
        {
            string sql = @"SELECT dn_id, ten_doanh_nghiep, dia_chi, so_dien_thoai, email, linh_vuc, ma_so_thue 
                           FROM DoanhNghiep";
            var dt = ExecuteQuery(sql);
            var list = new List<DoanhNghiep>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new DoanhNghiep
                {
                    DnId = Convert.ToInt32(row["dn_id"]),
                    TenDoanhNghiep = row["ten_doanh_nghiep"].ToString(),
                    DiaChi = row["dia_chi"].ToString(),
                    SoDienThoai = row["so_dien_thoai"].ToString(),
                    Email = row["email"].ToString(),
                    LinhVuc = row["linh_vuc"].ToString(),
                    MaSoThue = row["ma_so_thue"].ToString()
                });
            }

            return list;
        }

        public DoanhNghiep GetById(int id)
        {
            string sql = @"SELECT * FROM DoanhNghiep WHERE dn_id = @id";
            var param = new List<SqlParameter> { new SqlParameter("@id", id) };
            var dt = ExecuteQuery(sql, param);

            if (dt.Rows.Count == 0) return null;

            var row = dt.Rows[0];
            return new DoanhNghiep
            {
                DnId = Convert.ToInt32(row["dn_id"]),
                TenDoanhNghiep = row["ten_doanh_nghiep"].ToString(),
                DiaChi = row["dia_chi"].ToString(),
                SoDienThoai = row["so_dien_thoai"].ToString(),
                Email = row["email"].ToString(),
                LinhVuc = row["linh_vuc"].ToString(),
                MaSoThue = row["ma_so_thue"].ToString()
            };
        }

        public int Update(DoanhNghiep dn)
        {
            string sql = @"
        UPDATE DoanhNghiep
        SET ten_doanh_nghiep = @ten,
            dia_chi = @diachi,
            so_dien_thoai = @sdt,
            email = @em,
            linh_vuc = @lv
        WHERE dn_id = @id";

            var p = new List<SqlParameter>
    {
        new SqlParameter("@ten", dn.TenDoanhNghiep),
        new SqlParameter("@diachi", (object)dn.DiaChi ?? DBNull.Value),
        new SqlParameter("@sdt", (object)dn.SoDienThoai ?? DBNull.Value),
        new SqlParameter("@em", (object)dn.Email ?? DBNull.Value),
        new SqlParameter("@lv", (object)dn.LinhVuc ?? DBNull.Value),
        new SqlParameter("@id", dn.DnId)
    };

            return ExecuteNonQuery(sql, p);
        }


    }
}

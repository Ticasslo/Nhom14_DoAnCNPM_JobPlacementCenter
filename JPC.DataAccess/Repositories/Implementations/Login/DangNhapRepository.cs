using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JPC.DataAccess.DBConnection;
using JPC.DataAccess.Exceptions;
using JPC.DataAccess.Repositories.Interfaces.Login;
using JPC.Models.QuanTri;

namespace JPC.DataAccess.Repositories.Implementations.Login
{
    public class DangNhapRepository : DBConnection.DBConnection, IDangNhapRepository
    {
        public NhanVien DangNhap(string username, string passwordHash, string expectedVaiTroId = null)
        {
            var sql = new StringBuilder();
            sql.Append("SELECT TOP 1 ma_nhan_vien, ho_ten, email, so_dien_thoai, username, password_hash, vai_tro_id, trang_thai ");
            sql.Append("FROM NhanVien ");
            sql.Append("WHERE username = @username AND password_hash = @passwordHash AND trang_thai = 'active'");
            if (!string.IsNullOrWhiteSpace(expectedVaiTroId))
            {
                sql.Append(" AND vai_tro_id = @vaiTroId");
            }

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@username", SqlDbType.VarChar) { Value = username },
                new SqlParameter("@passwordHash", SqlDbType.VarChar) { Value = passwordHash }
            };
            if (!string.IsNullOrWhiteSpace(expectedVaiTroId))
            {
                parameters.Add(new SqlParameter("@vaiTroId", SqlDbType.VarChar) { Value = expectedVaiTroId });
            }

            try
            {
                var dt = ExecuteQuery(sql.ToString(), parameters);
                if (dt.Rows.Count == 0) return null;

                var row = dt.Rows[0];
                return new NhanVien
                (
                    maNhanVien: Convert.ToInt32(row["ma_nhan_vien"]),
                    hoTen: Convert.ToString(row["ho_ten"]),
                    email: Convert.ToString(row["email"]),
                    soDienThoai: Convert.ToString(row["so_dien_thoai"]),
                    username: Convert.ToString(row["username"]),
                    passwordHash: Convert.ToString(row["password_hash"]),
                    vaiTroId: Convert.ToString(row["vai_tro_id"]),
                    trangThai: Convert.ToString(row["trang_thai"]) 
                );
            }
            catch (DataAccessException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Lỗi khi kiểm tra đăng nhập.", ex);
            }
        }
    }
}

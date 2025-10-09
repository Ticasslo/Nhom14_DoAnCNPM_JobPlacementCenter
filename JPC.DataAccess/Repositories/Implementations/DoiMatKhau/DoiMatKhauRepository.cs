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

namespace JPC.DataAccess.Repositories.Implementations.Login
{
	public class DoiMatKhauRepository : DBConnection.DBConnection, IDoiMatKhauRepository
	{
		public bool CapNhatMatKhau(string username, string newPasswordHash)
		{
			string sql = "UPDATE NhanVien SET password_hash = @password_hash WHERE username = @username AND trang_thai = 'active'";
			var parameters = new List<SqlParameter>
			{
				new SqlParameter("@password_hash", SqlDbType.VarChar) { Value = newPasswordHash },
				new SqlParameter("@username", SqlDbType.VarChar) { Value = username }
			};

			try
			{
				int affected = ExecuteNonQuery(sql, parameters);
				return affected > 0;
			}
			catch (DataAccessException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new DataAccessException("Lỗi khi cập nhật mật khẩu.", ex);
			}
		}
	}
}



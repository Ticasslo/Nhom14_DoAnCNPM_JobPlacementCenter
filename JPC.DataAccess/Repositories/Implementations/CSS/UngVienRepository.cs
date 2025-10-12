using JPC.DataAccess.DBConnection;
using JPC.DataAccess.Repositories.Interfaces.CSS;
using JPC.Models.UngVien;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace JPC.DataAccess.Repositories.Implementations.CSS
{
	public class UngVienRepository : DBConnection.DBConnection, IUngVienRepository
	{
		public bool ExistsByCccd(string cccd)
		{
			string sql = "SELECT COUNT(1) FROM UngVien WHERE cccd=@cccd";
			var parameters = new List<SqlParameter>
			{
				new SqlParameter("@cccd", SqlDbType.VarChar, 12) { Value = cccd }
			};
			var dt = ExecuteQuery(sql, parameters);
			if (dt.Rows.Count > 0)
			{
				int count = Convert.ToInt32(dt.Rows[0][0]);
				return count > 0;
			}
			return false;
        }

        public int Create(UngVien entity)
		{
			string sql = @"INSERT INTO UngVien(ho_ten, email, so_dien_thoai, cccd, ngay_sinh, que_quan, vt_id)
						 VALUES (@hoTen, @Email, @Sdt, @Cccd, @NgaySinh, @QueQuan, @VtId)";
			var parameters = new List<SqlParameter>
			{
				new SqlParameter("@hoTen", SqlDbType.NVarChar, 100) { Value = (object)entity.HoTen ?? string.Empty },
				new SqlParameter("@Email", SqlDbType.NVarChar, 100) { Value = (object)entity.Email ?? string.Empty },
				new SqlParameter("@Sdt", SqlDbType.VarChar, 20) { Value = (object)entity.SoDienThoai ?? string.Empty },
				new SqlParameter("@Cccd", SqlDbType.VarChar, 12) { Value = (object)entity.Cccd ?? string.Empty },
				new SqlParameter("@NgaySinh", SqlDbType.Date) { Value = entity.NgaySinh.Date },
				new SqlParameter("@QueQuan", SqlDbType.NVarChar, 200) { Value = (object)entity.QueQuan ?? string.Empty },
				new SqlParameter("@VtId", SqlDbType.Int) { Value = (object)entity.VtId ?? DBNull.Value },
			};
			return ExecuteNonQuery(sql, parameters);
		}

		public IEnumerable<UngVien> GetAllUngVien()
		{
			var result = new List<UngVien>();
			string sql = @"SELECT uv_id, ho_ten, email, so_dien_thoai, cccd, ngay_sinh, que_quan, vt_id, ngay_tao 
						  FROM UngVien ORDER BY uv_id DESC";
			var dt = ExecuteQuery(sql);
			foreach (DataRow row in dt.Rows)
			{
				result.Add(new UngVien(
					Convert.ToInt32(row["uv_id"]),
					Convert.ToString(row["ho_ten"]),
					Convert.ToString(row["email"]),
					Convert.ToString(row["so_dien_thoai"]),
					Convert.ToString(row["cccd"]),
					Convert.ToDateTime(row["ngay_sinh"]),
					Convert.ToString(row["que_quan"]),
					row["vt_id"] == DBNull.Value ? null : (int?)Convert.ToInt32(row["vt_id"]),
					Convert.ToDateTime(row["ngay_tao"])
				));
			}
			return result;
		}

		public IEnumerable<UngVien> SearchUngVien(string hoTen, string email, string soDienThoai, string cccd)
		{
			var result = new List<UngVien>();
			var parameters = new List<SqlParameter>();
			var conditions = new List<string>();

			string sql = @"SELECT uv_id, ho_ten, email, so_dien_thoai, cccd, ngay_sinh, que_quan, vt_id, ngay_tao 
						  FROM UngVien WHERE 1=1";

			if (!string.IsNullOrWhiteSpace(hoTen))
			{
				conditions.Add("ho_ten LIKE @hoTen");
				parameters.Add(new SqlParameter("@hoTen", SqlDbType.NVarChar, 100) { Value = "%" + hoTen + "%" });
			}

			if (!string.IsNullOrWhiteSpace(email))
			{
				conditions.Add("email LIKE @email");
				parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 100) { Value = "%" + email + "%" });
			}

			if (!string.IsNullOrWhiteSpace(soDienThoai))
			{
				conditions.Add("so_dien_thoai LIKE @soDienThoai");
				parameters.Add(new SqlParameter("@soDienThoai", SqlDbType.VarChar, 20) { Value = "%" + soDienThoai + "%" });
			}

			if (!string.IsNullOrWhiteSpace(cccd))
			{
				conditions.Add("cccd LIKE @cccd");
				parameters.Add(new SqlParameter("@cccd", SqlDbType.VarChar, 12) { Value = "%" + cccd + "%" });
			}

			if (conditions.Count > 0)
			{
				sql += " AND " + string.Join(" AND ", conditions);
			}

			sql += " ORDER BY uv_id DESC";

			var dt = ExecuteQuery(sql, parameters);
			foreach (DataRow row in dt.Rows)
			{
				result.Add(new UngVien(
					Convert.ToInt32(row["uv_id"]),
					Convert.ToString(row["ho_ten"]),
					Convert.ToString(row["email"]),
					Convert.ToString(row["so_dien_thoai"]),
					Convert.ToString(row["cccd"]),
					Convert.ToDateTime(row["ngay_sinh"]),
					Convert.ToString(row["que_quan"]),
					row["vt_id"] == DBNull.Value ? null : (int?)Convert.ToInt32(row["vt_id"]),
					Convert.ToDateTime(row["ngay_tao"])
				));
			}
			return result;
		}

		public UngVien GetUngVienById(int uvId)
		{
			string sql = @"SELECT uv_id, ho_ten, email, so_dien_thoai, cccd, ngay_sinh, que_quan, vt_id, ngay_tao 
						  FROM UngVien WHERE uv_id = @uvId";
			var parameters = new List<SqlParameter>
			{
				new SqlParameter("@uvId", SqlDbType.Int) { Value = uvId }
			};

			var dt = ExecuteQuery(sql, parameters);
			if (dt.Rows.Count > 0)
			{
				var row = dt.Rows[0];
				return new UngVien(
					Convert.ToInt32(row["uv_id"]),
					Convert.ToString(row["ho_ten"]),
					Convert.ToString(row["email"]),
					Convert.ToString(row["so_dien_thoai"]),
					Convert.ToString(row["cccd"]),
					Convert.ToDateTime(row["ngay_sinh"]),
					Convert.ToString(row["que_quan"]),
					row["vt_id"] == DBNull.Value ? null : (int?)Convert.ToInt32(row["vt_id"]),
					Convert.ToDateTime(row["ngay_tao"])
				);
			}
			return null;
		}

		public bool UpdateUngVien(UngVien ungVien)
		{
			string sql = @"UPDATE UngVien SET 
						  ho_ten = @hoTen, 
						  email = @email, 
						  so_dien_thoai = @soDienThoai, 
						  cccd = @cccd, 
						  ngay_sinh = @ngaySinh, 
						  que_quan = @queQuan, 
						  vt_id = @vtId 
						  WHERE uv_id = @uvId";

			var parameters = new List<SqlParameter>
			{
				new SqlParameter("@uvId", SqlDbType.Int) { Value = ungVien.UvId },
				new SqlParameter("@hoTen", SqlDbType.NVarChar, 100) { Value = (object)ungVien.HoTen ?? string.Empty },
				new SqlParameter("@email", SqlDbType.NVarChar, 100) { Value = (object)ungVien.Email ?? string.Empty },
				new SqlParameter("@soDienThoai", SqlDbType.VarChar, 20) { Value = (object)ungVien.SoDienThoai ?? string.Empty },
				new SqlParameter("@cccd", SqlDbType.VarChar, 12) { Value = (object)ungVien.Cccd ?? string.Empty },
				new SqlParameter("@ngaySinh", SqlDbType.Date) { Value = ungVien.NgaySinh.Date },
				new SqlParameter("@queQuan", SqlDbType.NVarChar, 200) { Value = (object)ungVien.QueQuan ?? string.Empty },
				new SqlParameter("@vtId", SqlDbType.Int) { Value = (object)ungVien.VtId ?? DBNull.Value }
			};

			return ExecuteNonQuery(sql, parameters) > 0;
		}
	}
}



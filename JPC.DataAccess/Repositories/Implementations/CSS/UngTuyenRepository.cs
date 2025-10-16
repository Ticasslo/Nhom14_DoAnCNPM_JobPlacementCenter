using JPC.DataAccess.DBConnection;
using JPC.DataAccess.Repositories.Interfaces.CSS;
using JPC.Models.UngVien;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace JPC.DataAccess.Repositories.Implementations.CSS
{
    public class UngTuyenRepository : DBConnection.DBConnection, IUngTuyenRepository
    {
        public int Create(UngTuyen ungTuyen)
        {
            string sql = @"INSERT INTO UngTuyen (uv_id, tin_id, trang_thai, phi_id, da_thanh_toan_phi, ngay_nop)
                          VALUES (@uvId, @tinId, @trangThai, @phiId, @daThanhToanPhi, @ngayNop);
                          SELECT SCOPE_IDENTITY();";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@uvId", SqlDbType.Int) { Value = ungTuyen.UvId },
                new SqlParameter("@tinId", SqlDbType.Int) { Value = ungTuyen.TinId },
                new SqlParameter("@trangThai", SqlDbType.VarChar, 20) { Value = ungTuyen.TrangThai },
                new SqlParameter("@phiId", SqlDbType.Int) { Value = ungTuyen.PhiId },
                new SqlParameter("@daThanhToanPhi", SqlDbType.Bit) { Value = ungTuyen.DaThanhToanPhi },
                new SqlParameter("@ngayNop", SqlDbType.DateTime) { Value = ungTuyen.NgayNop }
            };

            var result = ExecuteScalar(sql, parameters);
            return Convert.ToInt32(result);
        }

        public bool ExistsUngTuyen(int uvId, int tinId)
        {
            string sql = "SELECT COUNT(*) FROM UngTuyen WHERE uv_id = @uvId AND tin_id = @tinId";
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@uvId", SqlDbType.Int) { Value = uvId },
                new SqlParameter("@tinId", SqlDbType.Int) { Value = tinId }
            };

            var result = ExecuteScalar(sql, parameters);
            return Convert.ToInt32(result) > 0;
        }

        public UngTuyen GetUngTuyenById(int utId)
        {
            string sql = @"SELECT ut_id, uv_id, tin_id, trang_thai, phi_id, da_thanh_toan_phi, ngay_nop 
                          FROM UngTuyen WHERE ut_id = @utId";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@utId", SqlDbType.Int) { Value = utId }
            };

            var dt = ExecuteQuery(sql, parameters);
            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                return new UngTuyen(
                    Convert.ToInt32(row["ut_id"]),
                    Convert.ToInt32(row["uv_id"]),
                    Convert.ToInt32(row["tin_id"]),
                    Convert.ToString(row["trang_thai"]),
                    Convert.ToInt32(row["phi_id"]),
                    Convert.ToBoolean(row["da_thanh_toan_phi"]),
                    Convert.ToDateTime(row["ngay_nop"])
                );
            }
            return null;
        }
    }
}

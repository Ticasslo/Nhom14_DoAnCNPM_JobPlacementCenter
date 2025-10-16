using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JPC.DataAccess.DBConnection;
using JPC.DataAccess.Repositories.Interfaces.SA;

namespace JPC.DataAccess.Repositories.Implementations.SA
{
    public class QuyenHanChucNangRepository : DBConnection.DBConnection, IQuyenHanChucNangRepository
    {
        public DataTable GetRolePermissionMatrix()
        {
            string sql = @"
                SELECT vt.vai_tro_id AS VaiTroId, vt.ten_vai_tro AS VaiTro,
                       cn.chuc_nang_id AS ChucNangId, cn.ten_chuc_nang AS ChucNang, cn.mo_ta AS MoTa,
                       CAST(ISNULL(vq.quyen_han, 0) AS bit) AS QuyenHan,
                       CAST(CASE WHEN vq.vai_tro_id IS NULL THEN 0 ELSE 1 END AS bit) AS MapExists
                FROM VaiTro vt
                CROSS JOIN ChucNang cn
                LEFT JOIN VaiTro_QuyenHan vq
                  ON vq.vai_tro_id = vt.vai_tro_id AND vq.chuc_nang_id = cn.chuc_nang_id
                ORDER BY vt.vai_tro_id, cn.chuc_nang_id";
            return ExecuteQuery(sql);
        }

        public bool UpsertPermission(string vaiTroId, string chucNangId, bool quyenHan)
        {
            string sql = @"
                MERGE VaiTro_QuyenHan AS target
                USING (SELECT @vaiTroId AS vai_tro_id, @chucNangId AS chuc_nang_id) AS src
                    ON target.vai_tro_id = src.vai_tro_id AND target.chuc_nang_id = src.chuc_nang_id
                WHEN MATCHED THEN UPDATE SET quyen_han = @quyenHan
                WHEN NOT MATCHED THEN INSERT (vai_tro_id, chuc_nang_id, quyen_han)
                VALUES (@vaiTroId, @chucNangId, @quyenHan);";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@vaiTroId", vaiTroId),
                new SqlParameter("@chucNangId", chucNangId),
                new SqlParameter("@quyenHan", quyenHan ? 1 : 0)
            };

            return ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool IsFunctionEnabledForRole(string vaiTroId, string chucNangId)
        {
            string sql = @"SELECT CASE WHEN EXISTS (
                                SELECT 1 FROM VaiTro_QuyenHan 
                                WHERE vai_tro_id = @vaiTroId 
                                  AND chuc_nang_id = @chucNangId 
                                  AND quyen_han = 1)
                            THEN 1 ELSE 0 END";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@vaiTroId", vaiTroId),
                new SqlParameter("@chucNangId", chucNangId)
            };

            var dt = ExecuteQuery(sql, parameters);
            if (dt.Rows.Count == 0) return false;
            return dt.Rows[0][0] != DBNull.Value && Convert.ToInt32(dt.Rows[0][0]) == 1;
        }
    }
}

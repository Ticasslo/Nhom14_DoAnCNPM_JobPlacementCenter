using JPC.DataAccess.Repositories.Interfaces.SA;
using JPC.Models.DanhMucNghe;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JPC.DataAccess.DBConnection;

namespace JPC.DataAccess.Repositories.Implementations.SA
{
    public class NgheRepository : DBConnection.DBConnection, INgheRepository
    {
        public DataTable GetAllNghe()
        {
            string sql = @"
                SELECT 
                    n.nghe_id as 'ID',
                    nn.ten_nhom as 'Nhóm nghề',
                    n.ten_nghe as 'Tên nghề',
                    n.trang_thai as 'Trạng thái'
                FROM Nghe n
                INNER JOIN NhomNghe nn ON n.nhom_id = nn.nhom_id
                ORDER BY n.nghe_id";

            return ExecuteQuery(sql);
        }

        public DataTable GetAllNgheForDisplay()
        {
            string sql = @"
                SELECT 
                    n.nghe_id as 'ID',
                    n.nhom_id as 'Nhóm nghề ID',
                    nn.ten_nhom as 'Nhóm nghề',
                    n.ten_nghe as 'Tên nghề',
                    n.trang_thai as 'Trạng thái'
                FROM Nghe n
                INNER JOIN NhomNghe nn ON n.nhom_id = nn.nhom_id
                ORDER BY n.nghe_id";

            return ExecuteQuery(sql);
        }

        public DataTable GetActiveNgheByNhomId(int nhomId)
        {
            string sql = @"
                SELECT 
                    n.nghe_id as 'ID',
                    n.ten_nghe as 'Tên nghề'
                FROM Nghe n
                WHERE n.nhom_id = @nhom_id AND n.trang_thai = 'active'
                ORDER BY n.ten_nghe";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@nhom_id", nhomId)
            };

            return ExecuteQuery(sql, parameters);
        }

        public DataTable SearchNghe(string keyword)
        {
            string sql = @"
                SELECT 
                    n.nghe_id as 'ID',
                    nn.ten_nhom as 'Nhóm nghề',
                    n.ten_nghe as 'Tên nghề',
                    n.trang_thai as 'Trạng thái'
                FROM Nghe n
                INNER JOIN NhomNghe nn ON n.nhom_id = nn.nhom_id
                WHERE n.ten_nghe LIKE @keyword OR nn.ten_nhom LIKE @keyword
                ORDER BY n.nghe_id";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@keyword", "%" + keyword + "%")
            };

            return ExecuteQuery(sql, parameters);
        }

        public Nghe GetNgheById(int id)
        {
            string sql = "SELECT * FROM Nghe WHERE nghe_id = @id";
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@id", id)
            };

            DataTable dt = ExecuteQuery(sql, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new Nghe
                {
                    NgheId = Convert.ToInt32(row["nghe_id"]),
                    NhomId = Convert.ToInt32(row["nhom_id"]),
                    TenNghe = row["ten_nghe"].ToString(),
                    TrangThai = row["trang_thai"].ToString()
                };
            }
            return null;
        }

        public bool InsertNghe(Nghe nghe)
        {
            string sql = "INSERT INTO Nghe (nhom_id, ten_nghe, trang_thai) VALUES (@nhom_id, @ten_nghe, @trang_thai)";
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@nhom_id", nghe.NhomId),
                new SqlParameter("@ten_nghe", nghe.TenNghe),
                new SqlParameter("@trang_thai", nghe.TrangThai)
            };

            return ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool UpdateNghe(Nghe nghe)
        {
            string sql = "UPDATE Nghe SET nhom_id = @nhom_id, ten_nghe = @ten_nghe, trang_thai = @trang_thai WHERE nghe_id = @nghe_id";
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@nhom_id", nghe.NhomId),
                new SqlParameter("@ten_nghe", nghe.TenNghe),
                new SqlParameter("@trang_thai", nghe.TrangThai),
                new SqlParameter("@nghe_id", nghe.NgheId)
            };

            return ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool CheckDuplicateNghe(int nhomId, string tenNghe, int excludeId = 0)
        {
            string sql = "SELECT COUNT(*) FROM Nghe WHERE nhom_id = @nhom_id AND ten_nghe = @ten_nghe";
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@nhom_id", nhomId),
                new SqlParameter("@ten_nghe", tenNghe)
            };

            // Nếu đang sửa, loại trừ ID hiện tại
            if (excludeId > 0)
            {
                sql += " AND nghe_id != @exclude_id";
                parameters.Add(new SqlParameter("@exclude_id", excludeId));
            }

            object result = ExecuteScalar(sql, parameters);
            return Convert.ToInt32(result) > 0;
        }

        public int CountActiveViTriInNghe(int ngheId)
        {
            string sql = "SELECT COUNT(*) FROM ViTriChuyenMon WHERE nghe_id = @nghe_id AND trang_thai = 'active'";
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@nghe_id", ngheId)
            };

            object result = ExecuteScalar(sql, parameters);
            return Convert.ToInt32(result);
        }
    }
}

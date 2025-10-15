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
    public class ViTriChuyenMonRepository : DBConnection.DBConnection, IViTriChuyenMonRepository
    {
        public DataTable GetAllViTriChuyenMon()
        {
            string sql = @"
                SELECT 
                    vt.vt_id as 'ID',
                    nn.ten_nhom as 'Nhóm nghề',
                    n.ten_nghe as 'Nghề',
                    vt.ten_vi_tri as 'Tên vị trí',
                    vt.trang_thai as 'Trạng thái'
                FROM ViTriChuyenMon vt
                INNER JOIN Nghe n ON vt.nghe_id = n.nghe_id
                INNER JOIN NhomNghe nn ON n.nhom_id = nn.nhom_id
                ORDER BY vt.vt_id";

            return ExecuteQuery(sql);
        }

        public DataTable SearchViTriChuyenMon(string keyword)
        {
            string sql = @"
                SELECT 
                    vt.vt_id as 'ID',
                    nn.ten_nhom as 'Nhóm nghề',
                    n.ten_nghe as 'Nghề',
                    vt.ten_vi_tri as 'Tên vị trí',
                    vt.trang_thai as 'Trạng thái'
                FROM ViTriChuyenMon vt
                INNER JOIN Nghe n ON vt.nghe_id = n.nghe_id
                INNER JOIN NhomNghe nn ON n.nhom_id = nn.nhom_id
                WHERE vt.ten_vi_tri LIKE @keyword OR n.ten_nghe LIKE @keyword OR nn.ten_nhom LIKE @keyword
                ORDER BY vt.vt_id";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@keyword", $"%{keyword}%")
            };

            return ExecuteQuery(sql, parameters);
        }

        public ViTriChuyenMon GetViTriChuyenMonById(int id)
        {
            string sql = "SELECT * FROM ViTriChuyenMon WHERE vt_id = @id";
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@id", id)
            };

            DataTable dt = ExecuteQuery(sql, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new ViTriChuyenMon
                {
                    VtId = Convert.ToInt32(row["vt_id"]),
                    NgheId = Convert.ToInt32(row["nghe_id"]),
                    TenViTri = row["ten_vi_tri"].ToString(),
                    TrangThai = row["trang_thai"].ToString()
                };
            }
            return null;
        }

        public bool InsertViTriChuyenMon(ViTriChuyenMon viTri)
        {
            string sql = "INSERT INTO ViTriChuyenMon (nghe_id, ten_vi_tri, trang_thai) VALUES (@nghe_id, @ten_vi_tri, @trang_thai)";
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@nghe_id", viTri.NgheId),
                new SqlParameter("@ten_vi_tri", viTri.TenViTri),
                new SqlParameter("@trang_thai", viTri.TrangThai)
            };

            return ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool UpdateViTriChuyenMon(ViTriChuyenMon viTri)
        {
            string sql = "UPDATE ViTriChuyenMon SET nghe_id = @nghe_id, ten_vi_tri = @ten_vi_tri, trang_thai = @trang_thai WHERE vt_id = @vt_id";
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@vt_id", viTri.VtId),
                new SqlParameter("@nghe_id", viTri.NgheId),
                new SqlParameter("@ten_vi_tri", viTri.TenViTri),
                new SqlParameter("@trang_thai", viTri.TrangThai)
            };

            return ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool CheckDuplicateViTriChuyenMon(int ngheId, string tenViTri, int excludeId = 0)
        {
            string sql = "SELECT COUNT(*) FROM ViTriChuyenMon WHERE nghe_id = @nghe_id AND ten_vi_tri = @ten_vi_tri";
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@nghe_id", ngheId),
                new SqlParameter("@ten_vi_tri", tenViTri)
            };

            // Nếu đang sửa, loại trừ ID hiện tại
            if (excludeId > 0)
            {
                sql += " AND vt_id != @exclude_id";
                parameters.Add(new SqlParameter("@exclude_id", excludeId));
            }

            object result = ExecuteScalar(sql, parameters);
            return Convert.ToInt32(result) > 0;
        }
    }
}

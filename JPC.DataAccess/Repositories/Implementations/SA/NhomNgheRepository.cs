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
    public class NhomNgheRepository : DBConnection.DBConnection, INhomNgheRepository
    {
        public DataTable GetAllNhomNghe()
        {
            string sql = @"
                SELECT 
                    nhom_id as 'ID',
                    ten_nhom as 'Tên nhóm',
                    trang_thai as 'Trạng thái'
                FROM NhomNghe 
                ORDER BY nhom_id";
            
            return ExecuteQuery(sql);
        }

        public DataTable GetActiveNhomNghe()
        {
            string sql = @"
                SELECT 
                    nhom_id as 'ID',
                    ten_nhom as 'Tên nhóm'
                FROM NhomNghe 
                WHERE trang_thai = 'active'
                ORDER BY ten_nhom";
            
            return ExecuteQuery(sql);
        }

        public DataTable SearchNhomNghe(string keyword)
        {
            string sql = @"
                SELECT 
                    nhom_id as 'ID',
                    ten_nhom as 'Tên nhóm',
                    trang_thai as 'Trạng thái'
                FROM NhomNghe 
                WHERE ten_nhom LIKE @keyword
                ORDER BY nhom_id";
            
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@keyword", "%" + keyword + "%")
            };
            
            return ExecuteQuery(sql, parameters);
        }

        public NhomNghe GetNhomNgheById(int id)
        {
            string sql = "SELECT * FROM NhomNghe WHERE nhom_id = @id";
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@id", id)
            };

            DataTable dt = ExecuteQuery(sql, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new NhomNghe
                {
                    NhomId = Convert.ToInt32(row["nhom_id"]),
                    TenNhom = row["ten_nhom"].ToString(),
                    TrangThai = row["trang_thai"].ToString()
                };
            }
            return null;
        }

        public bool InsertNhomNghe(NhomNghe nhomNghe)
        {
            string sql = "INSERT INTO NhomNghe (ten_nhom, trang_thai) VALUES (@ten_nhom, @trang_thai)";
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@ten_nhom", nhomNghe.TenNhom),
                new SqlParameter("@trang_thai", nhomNghe.TrangThai)
            };

            return ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool UpdateNhomNghe(NhomNghe nhomNghe)
        {
            string sql = "UPDATE NhomNghe SET ten_nhom = @ten_nhom, trang_thai = @trang_thai WHERE nhom_id = @nhom_id";
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@ten_nhom", nhomNghe.TenNhom),
                new SqlParameter("@trang_thai", nhomNghe.TrangThai),
                new SqlParameter("@nhom_id", nhomNghe.NhomId)
            };

            return ExecuteNonQuery(sql, parameters) > 0;
        }

        public int CountActiveNgheInNhomNghe(int nhomId)
        {
            string sql = "SELECT COUNT(*) FROM Nghe WHERE nhom_id = @nhom_id AND trang_thai = 'active'";
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@nhom_id", nhomId)
            };

            object result = ExecuteScalar(sql, parameters);
            return Convert.ToInt32(result);
        }

        public bool CheckDuplicateNhomNghe(string tenNhom, int excludeId = 0)
        {
            string sql = "SELECT COUNT(*) FROM NhomNghe WHERE ten_nhom = @ten_nhom";
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@ten_nhom", tenNhom)
            };

            // Nếu đang sửa, loại trừ ID hiện tại
            if (excludeId > 0)
            {
                sql += " AND nhom_id != @exclude_id";
                parameters.Add(new SqlParameter("@exclude_id", excludeId));
            }

            object result = ExecuteScalar(sql, parameters);
            return Convert.ToInt32(result) > 0;
        }
    }
}

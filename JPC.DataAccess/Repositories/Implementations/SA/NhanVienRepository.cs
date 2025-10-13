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
    public class NhanVienRepository : DBConnection.DBConnection, INhanVienRepository
    {
        public DataTable GetAllNhanVien()
        {
            string sql = @"
                SELECT 
                    nv.ma_nhan_vien as 'ID',
                    nv.ho_ten as 'Họ tên',
                    nv.email as 'Email',
                    nv.so_dien_thoai as 'SĐT',
                    nv.username as 'Username',
                    vt.ten_vai_tro as 'Vai trò',
                    nv.trang_thai as 'Trạng thái'
                FROM NhanVien nv
                INNER JOIN VaiTro vt ON nv.vai_tro_id = vt.vai_tro_id
                ORDER BY nv.ma_nhan_vien";
            return ExecuteQuery(sql);
        }

        public DataTable SearchNhanVien(string keyword)
        {
            string sql = @"
                SELECT 
                    nv.ma_nhan_vien as 'ID',
                    nv.ho_ten as 'Họ tên',
                    nv.email as 'Email',
                    nv.so_dien_thoai as 'SĐT',
                    nv.username as 'Username',
                    vt.ten_vai_tro as 'Vai trò',
                    nv.trang_thai as 'Trạng thái'
                FROM NhanVien nv
                INNER JOIN VaiTro vt ON nv.vai_tro_id = vt.vai_tro_id
                WHERE nv.ho_ten LIKE @keyword OR nv.email LIKE @keyword OR nv.username LIKE @keyword
                ORDER BY nv.ma_nhan_vien";
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@keyword", $"%{keyword}%")
            };
            return ExecuteQuery(sql, parameters);
        }

        public DataTable GetAllVaiTro()
        {
            string sql = "SELECT vai_tro_id, ten_vai_tro FROM VaiTro ORDER BY ten_vai_tro";
            return ExecuteQuery(sql);
        }

        public bool InsertNhanVien(string hoTen, string email, string soDienThoai, string username, string passwordHash, string vaiTroId, string trangThai)
        {
            string sql = @"
                INSERT INTO NhanVien (ho_ten, email, so_dien_thoai, username, password_hash, vai_tro_id, trang_thai)
                VALUES (@hoTen, @email, @soDienThoai, @username, @passwordHash, @vaiTroId, @trangThai)";
            
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@hoTen", hoTen),
                new SqlParameter("@email", email),
                new SqlParameter("@soDienThoai", soDienThoai ?? (object)DBNull.Value),
                new SqlParameter("@username", username),
                new SqlParameter("@passwordHash", passwordHash),
                new SqlParameter("@vaiTroId", vaiTroId),
                new SqlParameter("@trangThai", trangThai)
            };
            
            return ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool UpdateNhanVien(int maNhanVien, string hoTen, string email, string soDienThoai, string username, string passwordHash, string vaiTroId, string trangThai)
        {
            string sql = @"
                UPDATE NhanVien 
                SET ho_ten = @hoTen, 
                    email = @email, 
                    so_dien_thoai = @soDienThoai, 
                    username = @username, 
                    password_hash = @passwordHash, 
                    vai_tro_id = @vaiTroId, 
                    trang_thai = @trangThai
                WHERE ma_nhan_vien = @maNhanVien";
            
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@maNhanVien", maNhanVien),
                new SqlParameter("@hoTen", hoTen),
                new SqlParameter("@email", email),
                new SqlParameter("@soDienThoai", soDienThoai ?? (object)DBNull.Value),
                new SqlParameter("@username", username),
                new SqlParameter("@passwordHash", passwordHash),
                new SqlParameter("@vaiTroId", vaiTroId),
                new SqlParameter("@trangThai", trangThai)
            };
            
            return ExecuteNonQuery(sql, parameters) > 0;
        }
    }
}

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using JPC.DataAccess.DBConnection;
using JPC.DataAccess.Exceptions;
using JPC.DataAccess.Repositories.Interfaces.ERS;

namespace JPC.DataAccess.Repositories.Implementations.ERS
{
    public class UngTuyenRepository : IUngTuyenRepository
    {
        // ✅ Lấy danh sách tin theo mã doanh nghiệp
        public DataTable GetTinByDoanhNghiep(int dnId)
        {
            string query = @"
                SELECT t.tin_id, t.tieu_de, t.mo_ta_cong_viec, t.so_luong_tuyen,
                       t.muc_luong, t.khu_vuc_lam_viec, t.trang_thai
                FROM TinTuyenDung t
                WHERE t.dn_id = @dnId";

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["JobPlacementCenter"].ConnectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@dnId", dnId);
                using (var adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetUngVienByTin(int tinId)
        {
            string query = @"
        SELECT 
            uv.uv_id AS [Mã Ứng Viên],
            uv.ho_ten AS [Họ tên],
            uv.email AS [Email],
            uv.so_dien_thoai AS [Số điện thoại],
            uv.cccd AS [CCCD],
            uv.ngay_sinh AS [Ngày sinh],
            uv.que_quan AS [Quê quán],
            uv.vt_id AS [Vị trí chuyên môn],
            ut.ngay_nop AS [Ngày ứng tuyển],
            ut.trang_thai AS [Trạng thái]
        FROM UngTuyen ut
        INNER JOIN UngVien uv ON ut.uv_id = uv.uv_id
        WHERE ut.tin_id = @tinId";

            SqlParameter[] parameters = {
        new SqlParameter("@tinId", tinId)
    };

            return DBHelper.ExecuteTableFunctionDirect(query, parameters);
        }


        // ✅ Lấy tin theo mã DN và mã Tin
        public DataTable GetTinByDoanhNghiepAndTin(int dnId, int tinId)
        {
            string query = @"
                SELECT t.tin_id, t.tieu_de, t.mo_ta_cong_viec, t.so_luong_tuyen,
                       t.muc_luong, t.khu_vuc_lam_viec, t.trang_thai
                FROM TinTuyenDung t
                WHERE t.dn_id = @dnId AND t.tin_id = @tinId";

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["JobPlacementCenter"].ConnectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@dnId", dnId);
                cmd.Parameters.AddWithValue("@tinId", tinId);
                using (var adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable GetUngVienByDoanhNghiepAndTin(int dnId, int tinId)
        {
            string query = @"
        SELECT 
            uv.uv_id AS [Mã Ứng Viên],
            uv.ho_ten AS [Họ tên],
            uv.email AS [Email],
            uv.so_dien_thoai AS [Số điện thoại],
            uv.que_quan AS [Quê quán],
            ut.ngay_nop AS [Ngày nộp hồ sơ],
            ut.trang_thai AS [Trạng thái]
        FROM UngTuyen ut
        INNER JOIN UngVien uv ON ut.uv_id = uv.uv_id
        INNER JOIN TinTuyenDung t ON ut.tin_id = t.tin_id
        WHERE t.dn_id = @dnId AND ut.tin_id = @tinId";

            SqlParameter[] parameters = {
        new SqlParameter("@dnId", dnId),
        new SqlParameter("@tinId", tinId)
    };

            return DBHelper.ExecuteTableFunctionDirect(query, parameters);
        }

        public bool CapNhatTrangThaiUngVien(int uvId, int tinId, string trangThai)
        {
            string query = @"UPDATE UngTuyen 
                     SET trang_thai = @trang_thai
                     WHERE uv_id = @uv_id AND tin_id = @tin_id";

            SqlParameter[] parameters = {
        new SqlParameter("@trang_thai", trangThai),
        new SqlParameter("@uv_id", uvId),
        new SqlParameter("@tin_id", tinId)
    };

            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["JobPlacementCenter"].ConnectionString))
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddRange(parameters);
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Lỗi khi cập nhật trạng thái ứng viên.", ex);
            }
        }


    }
}

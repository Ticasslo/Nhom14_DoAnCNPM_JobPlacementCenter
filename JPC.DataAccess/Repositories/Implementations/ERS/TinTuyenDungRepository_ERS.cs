using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using JPC.DataAccess.DBConnection;
using JPC.DataAccess.Repositories.Interfaces.ERS;
using JPC.Models.DoanhNghiep;

namespace JPC.DataAccess.Repositories.Implementations.ERS
{
    public class TinTuyenDungRepository_ERS : JPC.DataAccess.DBConnection.DBConnection, ITinTuyenDungRepository_ERS
    {
        public int InsertTinTuyenDung(TinTuyenDung tin)
        {
            // ngày đăng = GETDATE(); trạng thái = 'inactive'; da_thanh_toan = 0; phi_id = 2
            var sql = @"
            INSERT INTO TinTuyenDung
            (dn_id, tieu_de, mo_ta_cong_viec, so_luong_tuyen, muc_luong,
             khu_vuc_lam_viec, hinh_thuc_lam_viec, kinh_nghiem_yeu_cau,
             han_nop_ho_so, ngay_dang, trang_thai, phi_id, da_thanh_toan)
            VALUES
            (@dn_id, @tieu_de, @mo_ta, @so_luong, @muc_luong,
             @khu_vuc, @hinh_thuc, @kinh_nghiem, @han_nop, GETDATE(), 'inactive', 2, 0);

            SELECT CAST(SCOPE_IDENTITY() AS INT);";

            var prms = new List<SqlParameter>
            {
                new SqlParameter("@dn_id", tin.DnId),
                new SqlParameter("@tieu_de", tin.TieuDe ?? (object)DBNull.Value),
                new SqlParameter("@mo_ta", tin.MoTaCongViec ?? (object)DBNull.Value),
                new SqlParameter("@so_luong", tin.SoLuongTuyen),
                new SqlParameter("@muc_luong", tin.MucLuong ?? (object)DBNull.Value),
                new SqlParameter("@khu_vuc", tin.KhuVucLamViec ?? (object)DBNull.Value),
                new SqlParameter("@hinh_thuc", tin.HinhThucLamViec),
                new SqlParameter("@kinh_nghiem", tin.KinhNghiemYeuCau),
                new SqlParameter("@han_nop", tin.HanNopHoSo.Date)
            };

            var obj = ExecuteScalar(sql, prms);
            return (obj == null || obj == System.DBNull.Value) ? 0 : (int)obj;
        }


        public DataTable GetTinByDoanhNghiep(int dnId)
        {
            string sql = @"
        SELECT 
            tin_id       AS [Mã tin],
            tieu_de      AS [Tiêu đề],
            mo_ta_cong_viec AS [Mô tả công việc],
            so_luong_tuyen  AS [Số lượng],
            muc_luong    AS [Mức lương],
            khu_vuc_lam_viec AS [Khu vực],
            hinh_thuc_lam_viec AS [Hình thức],
            kinh_nghiem_yeu_cau AS [Kinh nghiệm],
            han_nop_ho_so AS [Hạn nộp],
            trang_thai    AS [Trạng thái],
            da_thanh_toan AS [Thanh toán],
            ngay_dang     AS [Ngày đăng]
        FROM TinTuyenDung
        WHERE dn_id = @dn_id
        ORDER BY ngay_dang DESC";

            SqlParameter[] parameters =
            {
        new SqlParameter("@dn_id", SqlDbType.Int) { Value = dnId }
    };

            return DBHelper.ExecuteTableFunctionDirect(sql, parameters);
        }

    }
}
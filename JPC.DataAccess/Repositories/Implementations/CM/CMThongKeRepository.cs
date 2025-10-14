using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using JPC.DataAccess.DBConnection;
using JPC.DataAccess.Repositories.Interfaces.CM;

namespace JPC.DataAccess.Repositories.Implementations.CM
{
    public class CMThongKeRepository : JPC.DataAccess.DBConnection.DBConnection, ICMThongKeRepository
    {
        private static string Label(string groupBy)
        {
            // NhomNghe -> Nghe -> ViTriChuyenMon
            return groupBy == "VITRI" ? "v.ten_vi_tri"
                 : groupBy == "NGHE" ? "ng.ten_nghe"
                 : "nn.ten_nhom";
        }

        public void RunExpireJobPosts()
        {
            // nếu SP không tồn tại cũng không sao
            try { ExecuteNonQuery("EXEC SP_KiemTraTinHetHan"); } catch { /* ignore */ }
        }

        public DataTable ThongKeSoLuong(DateTime from, DateTime toExclusive, string groupBy)
        {
            string col = Label(groupBy);
            string sql = $@"
WITH src AS (
  SELECT DanhMuc={col}, SoLuong=COUNT(*)
  FROM UngTuyen ut
  JOIN TinTuyenDung t ON t.tin_id = ut.tin_id
  LEFT JOIN TinTuyenDung_ViTri tv ON tv.tin_id = t.tin_id
  LEFT JOIN ViTriChuyenMon v ON v.vt_id = tv.vt_id
  LEFT JOIN Nghe ng ON ng.nghe_id = v.nghe_id
  LEFT JOIN NhomNghe nn ON nn.nhom_id = ng.nhom_id
  WHERE ut.ngay_nop >= @from AND ut.ngay_nop < @to
  GROUP BY {col}
)
SELECT DanhMuc, SoLuong,
       CAST(100.0 * SoLuong / NULLIF(SUM(SoLuong) OVER(),0) AS DECIMAL(5,2)) AS TyLe
FROM src
ORDER BY SoLuong DESC;";
            var ps = new List<SqlParameter>{
                new SqlParameter("@from", SqlDbType.DateTime){Value=from},
                new SqlParameter("@to",   SqlDbType.DateTime){Value=toExclusive}
            };
            return ExecuteQuery(sql, ps);
        }

        public DataTable TyLeKetNoi(DateTime from, DateTime toExclusive, string groupBy)
        {
            string col = Label(groupBy);
            string sql = $@"
WITH base AS (
  SELECT DanhMuc={col},
         ThanhCong = CASE WHEN ut.trang_thai='TRUNG_TUYEN' THEN 1 ELSE 0 END
  FROM UngTuyen ut
  JOIN TinTuyenDung t ON t.tin_id = ut.tin_id
  LEFT JOIN TinTuyenDung_ViTri tv ON tv.tin_id = t.tin_id
  LEFT JOIN ViTriChuyenMon v ON v.vt_id = tv.vt_id
  LEFT JOIN Nghe ng ON ng.nghe_id = v.nghe_id
  LEFT JOIN NhomNghe nn ON nn.nhom_id = ng.nhom_id
  WHERE ut.ngay_nop >= @from AND ut.ngay_nop < @to
)
SELECT DanhMuc,
       COUNT(*) AS TongUngVien,
       SUM(ThanhCong) AS SoTrungTuyen,
       CAST(CASE WHEN COUNT(*)=0 THEN 0 ELSE 100.0*SUM(ThanhCong)/COUNT(*) END AS DECIMAL(5,2)) AS TyLe
FROM base
GROUP BY DanhMuc
ORDER BY TyLe DESC;";
            var ps = new List<SqlParameter>{
                new SqlParameter("@from", SqlDbType.DateTime){Value=from},
                new SqlParameter("@to",   SqlDbType.DateTime){Value=toExclusive}
            };
            return ExecuteQuery(sql, ps);
        }
    }
}

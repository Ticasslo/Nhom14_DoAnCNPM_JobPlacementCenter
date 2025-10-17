using JPC.DataAccess.DBConnection;
using JPC.DataAccess.Repositories.Interfaces.FO;
using JPC.Models.TaiChinh;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace JPC.DataAccess.Repositories.Implementations.FO
{
    public class HoaDonRepository : DBConnection.DBConnection, IHoaDonRepository
    {
        public int Insert(HoaDon h, SqlTransaction tran)
        {
            const string sql = @"
INSERT INTO HoaDon(loai_khach_hang, uv_id, ut_id, dn_id, tin_id, ten_khach_hang, phi_id, so_tien, ngay_lap_hoa_don, ma_nhan_vien_lap)
VALUES (@loai, @uv, @ut, @dn, @tin, @ten, @phi, @tien, @ngay, @nv);
SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using (var cmd = new SqlCommand(sql, tran.Connection, tran))
            {
                cmd.Parameters.AddWithValue("@loai", h.LoaiKhachHang ?? "doanh_nghiep");
                cmd.Parameters.AddWithValue("@uv", (object)h.UvId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ut", (object)h.UtId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@dn", (object)h.DnId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@tin", (object)h.TinId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ten", h.TenKhachHang ?? "");
                cmd.Parameters.AddWithValue("@phi", h.PhiId);
                cmd.Parameters.AddWithValue("@tien", h.SoTien);
                cmd.Parameters.AddWithValue("@ngay", h.NgayLapHoaDon);
                cmd.Parameters.AddWithValue("@nv", h.MaNhanVienLap);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public HoaDon GetById(int id)
        {
            const string sql = "SELECT * FROM HoaDon WHERE ma_hoa_don=@id";
            var dt = ExecuteQuery(sql, new List<SqlParameter> { new SqlParameter("@id", id) });
            if (dt.Rows.Count == 0) return null;
            var r = dt.Rows[0];
            return MapHoaDon(r);
        }

        public int InsertHoaDon(HoaDon hd)
        {
            const string sql = @"
INSERT INTO HoaDon(loai_khach_hang, uv_id, ut_id, dn_id, tin_id, ten_khach_hang, phi_id, so_tien, ngay_lap_hoa_don, ma_nhan_vien_lap)
VALUES (@loai, @uv, @ut, @dn, @tin, @ten, @phi, @tien, GETDATE(), @nv);
SELECT CAST(SCOPE_IDENTITY() AS INT);";

            var prms = new List<SqlParameter>
            {
                new SqlParameter("@loai", hd.LoaiKhachHang),
                new SqlParameter("@uv",   (object)hd.UvId ?? DBNull.Value),
                new SqlParameter("@ut",   (object)hd.UtId ?? DBNull.Value),
                new SqlParameter("@dn",   (object)hd.DnId ?? DBNull.Value),
                new SqlParameter("@tin",  (object)hd.TinId ?? DBNull.Value),
                new SqlParameter("@ten",  hd.TenKhachHang ?? string.Empty),
                new SqlParameter("@phi",  hd.PhiId),
                new SqlParameter("@tien", hd.SoTien),
                new SqlParameter("@nv",   hd.MaNhanVienLap)
            };
            var id = ExecuteScalar(sql, prms);
            return Convert.ToInt32(id);
        }

        public DataTable GetAll()
        {
            const string sql = @"
SELECT h.ma_hoa_don, h.loai_khach_hang, h.dn_id, dn.ten_doanh_nghiep,
       h.uv_id, uv.ho_ten AS ten_ung_vien,
       h.ut_id, h.tin_id, h.ten_khach_hang, h.phi_id, h.so_tien, 
       CAST(h.ngay_lap_hoa_don AS DATE) AS ngay_lap_hoa_don,
       h.ma_nhan_vien_lap, nv.ho_ten AS ten_nv_lap
FROM HoaDon h
LEFT JOIN DoanhNghiep dn ON dn.dn_id = h.dn_id
LEFT JOIN UngVien uv ON uv.uv_id = h.uv_id
LEFT JOIN NhanVien nv ON nv.ma_nhan_vien = h.ma_nhan_vien_lap
ORDER BY h.ma_hoa_don DESC";
            var dt = ExecuteQuery(sql);
            ApplyCaptions(dt);
            return dt;
        }

        public DataTable GetList(DateTime? ngay, int? dnId, int? maNvLap)
        {
            var sb = new System.Text.StringBuilder(@"
SELECT h.ma_hoa_don, h.loai_khach_hang, h.dn_id, dn.ten_doanh_nghiep,
       h.uv_id, uv.ho_ten AS ten_ung_vien,
       h.ut_id, h.tin_id, h.ten_khach_hang, h.phi_id, h.so_tien, 
       CAST(h.ngay_lap_hoa_don AS DATE) AS ngay_lap_hoa_don,
       h.ma_nhan_vien_lap, nv.ho_ten AS ten_nv_lap
FROM HoaDon h
LEFT JOIN DoanhNghiep dn ON dn.dn_id = h.dn_id
LEFT JOIN UngVien uv ON uv.uv_id = h.uv_id
LEFT JOIN NhanVien nv ON nv.ma_nhan_vien = h.ma_nhan_vien_lap
WHERE 1=1");

            var prms = new List<SqlParameter>();
            if (ngay.HasValue)
            {
                sb.Append(" AND CAST(h.ngay_lap_hoa_don AS DATE) = @d");
                prms.Add(new SqlParameter("@d", SqlDbType.Date) { Value = ngay.Value.Date });
            }
            if (dnId.HasValue)
            {
                sb.Append(" AND h.dn_id=@dn");
                prms.Add(new SqlParameter("@dn", dnId.Value));
            }
            if (maNvLap.HasValue)
            {
                sb.Append(" AND h.ma_nhan_vien_lap=@nv");
                prms.Add(new SqlParameter("@nv", maNvLap.Value));
            }
            sb.Append(" ORDER BY h.ma_hoa_don DESC");
            var dt = ExecuteQuery(sb.ToString(), prms);
            ApplyCaptions(dt);
            return dt;
        }

        public int UpdateBasic(int id, string tenKhachHang, decimal soTien, DateTime ngayLap, int maNvLap)
        {
            const string sql = @"
UPDATE HoaDon
SET ten_khach_hang=@ten, so_tien=@tien, ngay_lap_hoa_don=@ngay, ma_nhan_vien_lap=@nv
WHERE ma_hoa_don=@id";
            var prms = new List<SqlParameter>
            {
                new SqlParameter("@ten", tenKhachHang ?? string.Empty),
                new SqlParameter("@tien", soTien),
                new SqlParameter("@ngay", ngayLap),
                new SqlParameter("@nv",   maNvLap),
                new SqlParameter("@id",   id)
            };
            return ExecuteNonQuery(sql, prms);
        }

        public DataTable GetBaoCaoDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            const string sql = @"
SELECT 
    h.ma_hoa_don,
    h.ten_khach_hang,
    CASE WHEN h.loai_khach_hang='ung_vien' THEN N'Ứng viên' ELSE N'Doanh nghiệp' END AS doi_tuong,
    h.so_tien,
    CAST(h.ngay_lap_hoa_don AS date) AS ngay_thu
FROM HoaDon h
WHERE CAST(h.ngay_lap_hoa_don AS date) BETWEEN @from AND @to
ORDER BY h.ngay_lap_hoa_don DESC, h.ma_hoa_don DESC";
            var prms = new List<SqlParameter>
            {
                new SqlParameter("@from", SqlDbType.Date){ Value = tuNgay.Date },
                new SqlParameter("@to",   SqlDbType.Date){ Value = denNgay.Date }
            };
            return ExecuteQuery(sql, prms);
        }

        public HoaDon GetLatestByTinId(int tinId)
        {
            const string sql = @"
SELECT TOP(1) * 
FROM HoaDon 
WHERE tin_id=@id AND loai_khach_hang='doanh_nghiep'
ORDER BY ma_hoa_don DESC";
            var dt = ExecuteQuery(sql, new List<SqlParameter> { new SqlParameter("@id", tinId) });
            if (dt.Rows.Count == 0) return null;
            return MapHoaDon(dt.Rows[0]);
        }

        private static HoaDon MapHoaDon(DataRow r) => new HoaDon
        {
            MaHoaDon = Convert.ToInt32(r["ma_hoa_don"]),
            LoaiKhachHang = Convert.ToString(r["loai_khach_hang"]),
            UvId = r["uv_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(r["uv_id"]),
            UtId = r["ut_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(r["ut_id"]),
            DnId = r["dn_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(r["dn_id"]),
            TinId = r["tin_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(r["tin_id"]),
            TenKhachHang = Convert.ToString(r["ten_khach_hang"]),
            PhiId = Convert.ToInt32(r["phi_id"]),
            SoTien = Convert.ToDecimal(r["so_tien"]),
            NgayLapHoaDon = Convert.ToDateTime(r["ngay_lap_hoa_don"]),
            MaNhanVienLap = Convert.ToInt32(r["ma_nhan_vien_lap"])
        };

        private static void ApplyCaptions(DataTable dt)
        {
            if (dt == null) return;
            var map = new Dictionary<string, string>
            {
                ["ma_hoa_don"] = "Mã Hóa đơn",
                ["loai_khach_hang"] = "Loại khách hàng",
                ["dn_id"] = "Mã Doanh nghiệp",
                ["ten_doanh_nghiep"] = "Tên Doanh nghiệp",
                ["uv_id"] = "Mã Ứng viên",
                ["ten_ung_vien"] = "Tên Ứng viên",
                ["ut_id"] = "Mã Ứng tuyển",
                ["tin_id"] = "Mã Tin",
                ["ten_khach_hang"] = "Tên khách hàng",
                ["phi_id"] = "Mã Phí",
                ["so_tien"] = "Số tiền",
                ["ngay_lap_hoa_don"] = "Ngày lập hóa đơn",
                ["ma_nhan_vien_lap"] = "Mã Nhân viên lập hóa đơn",
                ["ten_nv_lap"] = "Tên Nhân viên lập hóa đơn"
            };
            foreach (var kv in map)
                if (dt.Columns.Contains(kv.Key))
                    dt.Columns[kv.Key].Caption = kv.Value;
        }
    }
}
using JPC.DataAccess.Repositories.Interfaces.FO;
using JPC.Models.TaiChinh;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.DataAccess.Repositories.Implementations.FO
{
    public class HoaDonRepository : IHoaDonRepository
    {
        private readonly string _cnn;
        public HoaDonRepository(string connectionString) => _cnn = connectionString;

        public int Insert(HoaDon h, SqlTransaction tran)
        {
            const string sql = @"
                INSERT INTO HoaDon
                (loai_khach_hang, uv_id, ut_id, dn_id, tin_id, ten_khach_hang, phi_id, so_tien, ngay_lap_hoa_don, ma_nhan_vien_lap)
                VALUES ('doanh_nghiep', NULL, NULL, @dn_id, @tin_id, @ten_khach_hang, @phi_id, @so_tien, @ngay, @nv);
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using (var cmd = new SqlCommand(sql, tran.Connection, tran))
            {
                cmd.Parameters.AddWithValue("@dn_id", (object)h.DnId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@tin_id", (object)h.TinId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ten_khach_hang", h.TenKhachHang ?? "");
                cmd.Parameters.AddWithValue("@phi_id", h.PhiId);
                cmd.Parameters.Add("@so_tien", SqlDbType.Decimal).Value = h.SoTien;
                cmd.Parameters.AddWithValue("@ngay", h.NgayLapHoaDon);
                cmd.Parameters.AddWithValue("@nv", h.MaNhanVienLap);
                return (int)cmd.ExecuteScalar();
            }
        }

        public HoaDon GetById(int id)
        {
            const string sql = "SELECT * FROM HoaDon WHERE ma_hoa_don=@id";
            using (var con = new SqlConnection(_cnn))
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    if (!rd.Read()) return null;
                    return new HoaDon
                    {
                        MaHoaDon = (int)rd["ma_hoa_don"],
                        LoaiKhachHang = (string)rd["loai_khach_hang"],
                        DnId = rd["dn_id"] as int?,
                        TinId = rd["tin_id"] as int?,
                        TenKhachHang = (string)rd["ten_khach_hang"],
                        PhiId = (int)rd["phi_id"],
                        SoTien = (decimal)rd["so_tien"],
                        NgayLapHoaDon = (DateTime)rd["ngay_lap_hoa_don"],
                        MaNhanVienLap = (int)rd["ma_nhan_vien_lap"]
                    };
                }
            }
        }
    }
}

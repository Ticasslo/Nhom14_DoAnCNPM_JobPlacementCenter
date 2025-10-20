using JPC.DataAccess.DBConnection;
using JPC.DataAccess.Repositories.Interfaces.FO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace JPC.DataAccess.Repositories.Implementations.FO
{
    public class TinTuyenDungRepository : DBConnection.DBConnection, ITinTuyenDungRepository
    {
        public (DateTime ngay_dang, DateTime han_nop_ho_so, int dn_id, string ten_dn) GetCoreInfo(int tinId)
        {
            const string sql = @"
                SELECT t.ngay_dang, t.han_nop_ho_so, t.dn_id, d.ten_doanh_nghiep
                FROM TinTuyenDung t
                JOIN DoanhNghiep d ON d.dn_id = t.dn_id
                WHERE t.tin_id = @id";

            var prms = new List<SqlParameter> { new SqlParameter("@id", tinId) };
            var dt = ExecuteQuery(sql, prms);

            if (dt.Rows.Count == 0)
                throw new Exception("Không tìm thấy tin tuyển dụng.");

            var r = dt.Rows[0];
            return (
                r.Field<DateTime>("ngay_dang"),
                r.Field<DateTime>("han_nop_ho_so"),
                r.Field<int>("dn_id"),
                r.Field<string>("ten_doanh_nghiep")
            );
        }

        public IEnumerable<(int tin_id, string display, DateTime ngay_dang, DateTime han_nop_ho_so)> GetUnpaidByDoanhNghiep(int dnId)
        {
            const string sql = @"
                SELECT t.tin_id, t.tieu_de, t.ngay_dang, t.han_nop_ho_so
                FROM TinTuyenDung t
                WHERE t.dn_id=@dn AND t.da_thanh_toan=0
                ORDER BY t.tin_id DESC;";

            var prms = new List<SqlParameter> { new SqlParameter("@dn", dnId) };
            var dt = ExecuteQuery(sql, prms);

            var list = new List<(int, string, DateTime, DateTime)>();
            foreach (DataRow r in dt.Rows)
            {
                var ngay = r.Field<DateTime>("ngay_dang");
                var han = r.Field<DateTime>("han_nop_ho_so");
                var display = $"{r.Field<string>("tieu_de")} [CHƯA THU] ({ngay:dd/MM/yyyy} → {han:dd/MM/yyyy})";
                list.Add((r.Field<int>("tin_id"), display, ngay, han));
            }
            return list;
        }

        // chạy trong transaction do Service kiểm soát
        public void MarkPaidAndActivate(int tinId, SqlTransaction tran)
        {
            const string sql = @"UPDATE TinTuyenDung 
                                 SET da_thanh_toan=1, trang_thai='active' 
                                 WHERE tin_id=@id";
            using (var cmd = new SqlCommand(sql, tran.Connection, tran))
            {
                cmd.Parameters.AddWithValue("@id", tinId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
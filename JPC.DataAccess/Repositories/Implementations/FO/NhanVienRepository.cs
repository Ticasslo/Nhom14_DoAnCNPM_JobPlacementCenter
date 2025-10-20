using JPC.DataAccess.DBConnection;
using JPC.DataAccess.Repositories.Interfaces.FO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace JPC.DataAccess.Repositories.Implementations.FO
{
    public class NhanVienRepository : DBConnection.DBConnection, INhanVienRepository
    {
        public IEnumerable<(int ma_nhan_vien, string ho_ten)> GetAllBasic()
        {
            const string sql = @"
                SELECT ma_nhan_vien, ho_ten
                FROM NhanVien
                WHERE trang_thai='active'
                ORDER BY ho_ten";

            var dt = ExecuteQuery(sql);

            foreach (DataRow r in dt.Rows)
                yield return (r.Field<int>("ma_nhan_vien"), r.Field<string>("ho_ten"));
        }

        public DataTable GetNhanViensActive()
        {
            const string sql = @"
                SELECT ma_nhan_vien, ho_ten
                FROM NhanVien
                WHERE trang_thai='active'
                ORDER BY ho_ten";

            var dt = ExecuteQuery(sql);

            //if (dt.Columns.Contains("ma_nhan_vien")) dt.Columns["ma_nhan_vien"].Caption = "Mã Nhân viên";
            //if (dt.Columns.Contains("ho_ten")) dt.Columns["ho_ten"].Caption = "Họ tên";

            return dt;
        }
    }
}
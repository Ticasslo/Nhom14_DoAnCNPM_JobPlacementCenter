using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using JPC.DataAccess.DBConnection;
using JPC.DataAccess.Repositories.Interfaces.CM;
using JPC.Models.TaiChinh;

namespace JPC.DataAccess.Repositories.Implementations.CM
{
    public class PhiDichVuRepository : JPC.DataAccess.DBConnection.DBConnection, IPhiDichVuRepository
    {
        public List<PhiDichVu> GetAll()
        {
            var dt = ExecuteQuery("SELECT phi_id, ten_dich_vu, so_tien FROM PhiDichVu ORDER BY phi_id");
            var list = new List<PhiDichVu>();
            foreach (DataRow r in dt.Rows)
                list.Add(new PhiDichVu((int)r["phi_id"], r["ten_dich_vu"].ToString(), (decimal)r["so_tien"]));
            return list;
        }

        public PhiDichVu GetById(int phiId)
        {
            var p = new List<SqlParameter> { new SqlParameter("@id", SqlDbType.Int) { Value = phiId } };
            var dt = ExecuteQuery("SELECT phi_id, ten_dich_vu, so_tien FROM PhiDichVu WHERE phi_id=@id", p);
            if (dt.Rows.Count == 0) return null;
            var r = dt.Rows[0];
            return new PhiDichVu((int)r["phi_id"], r["ten_dich_vu"].ToString(), (decimal)r["so_tien"]);
        }

        public int UpdatePrice(int phiId, decimal giaMoi)
        {
            var ps = new List<SqlParameter>{
                new SqlParameter("@id",  SqlDbType.Int){ Value = phiId },
                new SqlParameter("@gia", SqlDbType.Decimal){ Precision=18, Scale=2, Value = giaMoi }
            };
            return ExecuteNonQuery("UPDATE PhiDichVu SET so_tien=@gia WHERE phi_id=@id", ps);
        }
    }
}

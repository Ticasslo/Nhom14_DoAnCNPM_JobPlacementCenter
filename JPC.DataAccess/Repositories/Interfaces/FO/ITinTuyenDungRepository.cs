using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.DataAccess.Repositories.Interfaces.FO
{
    public interface ITinTuyenDungRepository
    {
        void MarkPaidAndActivate(int tinId, SqlTransaction tran);  // set da_thanh_toan=1, trang_thai='active'

        (DateTime ngay_dang, DateTime han_nop_ho_so, int dn_id, string ten_dn) GetCoreInfo(int tinId);
        IEnumerable<(int tin_id, string display, DateTime ngay_dang, DateTime han_nop_ho_so)>
            GetUnpaidByDoanhNghiep(int dnId);
    }
}

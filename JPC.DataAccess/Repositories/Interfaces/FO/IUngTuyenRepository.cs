using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.DataAccess.Repositories.Interfaces.FO
{
    public interface IUngTuyenRepository
    {
        DataTable GetHoSoUngTuyenChuaThuPhiByUv(int uvId); // ut_id, tin_id, display, ngay_nop
        void MarkPaid(int utId);
        bool HasInvoice(int utId);
        int GetInvoiceIdForUt(int utId); // 0 nếu chưa có
    }
}

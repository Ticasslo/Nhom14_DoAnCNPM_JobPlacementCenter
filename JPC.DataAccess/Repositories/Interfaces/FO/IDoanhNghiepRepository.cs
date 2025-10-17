using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.DataAccess.Repositories.Interfaces.FO
{
    public interface IDoanhNghiepRepository
    {
        IEnumerable<(int dn_id, string ten_doanh_nghiep, string dia_chi)> GetAllBasic();
        (int dn_id, string ten_doanh_nghiep, string dia_chi) GetById(int dnId);
        string GetDiaChiById(int dnId);
    }
}

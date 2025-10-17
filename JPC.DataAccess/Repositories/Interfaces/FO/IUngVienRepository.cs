using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.DataAccess.Repositories.Interfaces.FO
{
    public interface IUngVienRepository
    {
        DataTable GetAllUngVienBasic(); // uv_id, ho_ten, dia_chi (alias)
        string GetDiaChiById(int uvId);
    }
}
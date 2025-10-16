using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JPC.Models.DoanhNghiep;

namespace JPC.DataAccess.Repositories.Interfaces.ERS
{
    public interface ITinTuyenDungRepository
    {
        int InsertTinTuyenDung(TinTuyenDung tin); // trả về tin_id mới
        DataTable GetTinByDoanhNghiep(int dnId);

    }
}

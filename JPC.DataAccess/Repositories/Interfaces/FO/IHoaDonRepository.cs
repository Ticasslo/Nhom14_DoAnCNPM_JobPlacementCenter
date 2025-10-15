using JPC.Models.TaiChinh;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.DataAccess.Repositories.Interfaces.FO
{
    public interface IHoaDonRepository
    {
        int Insert(HoaDon h, SqlTransaction tran); // dùng transaction
        HoaDon GetById(int id);
    }
}

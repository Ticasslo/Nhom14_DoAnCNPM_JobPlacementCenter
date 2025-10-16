using JPC.Models.TaiChinh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.DataAccess.Repositories.Interfaces.FO
{
    public interface IPhiDichVuRepository
    {
        PhiDichVu GetById(int phiId);
    }
}

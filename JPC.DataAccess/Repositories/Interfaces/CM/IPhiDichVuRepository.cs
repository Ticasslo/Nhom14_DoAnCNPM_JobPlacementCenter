using System.Collections.Generic;
using JPC.Models.TaiChinh;

namespace JPC.DataAccess.Repositories.Interfaces.CM
{
    public interface IPhiDichVuRepository
    {
        List<PhiDichVu> GetAll();
        PhiDichVu GetById(int phiId);
        int UpdatePrice(int phiId, decimal giaMoi);
    }
}

using System.Collections.Generic;
using JPC.Models.TaiChinh;

namespace JPC.Business.Services.Interfaces.CM
{
    public interface ICMFeesService
    {
        List<PhiDichVu> GetAll();
        void UpdatePrice(int phiId, decimal giaMoi);
    }
}

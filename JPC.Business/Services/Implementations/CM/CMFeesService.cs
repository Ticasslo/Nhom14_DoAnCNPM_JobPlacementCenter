using System.Collections.Generic;
using JPC.Business.Exceptions;
using JPC.Business.Services.Interfaces.CM;
using JPC.DataAccess.Repositories.Implementations.CM;
using JPC.DataAccess.Repositories.Interfaces.CM;
using JPC.Models.TaiChinh;

namespace JPC.Business.Services.Implementations.CM
{
    public class CMFeesService : ICMFeesService
    {
        private readonly IPhiDichVuRepository _repo = new PhiDichVuRepository();

        public List<PhiDichVu> GetAll() => _repo.GetAll();

        public void UpdatePrice(int phiId, decimal giaMoi)
        {
            if (giaMoi < 0) throw new BusinessException("Giá mới phải >= 0.");
            _repo.UpdatePrice(phiId, giaMoi);
        }
    }
}

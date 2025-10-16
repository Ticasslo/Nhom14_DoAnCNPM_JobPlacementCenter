using JPC.Business.Services.Interfaces.CSS;
using JPC.DataAccess.Repositories.Implementations.CSS;
using JPC.DataAccess.Repositories.Interfaces.CSS;
using JPC.Models.DoanhNghiep;
using System;

namespace JPC.Business.Services.Implementations.CSS
{
    public class DoanhNghiepService : IDoanhNghiepService
    {
        private readonly IDoanhNghiepRepository repository;

        public DoanhNghiepService()
        {
            this.repository = new DoanhNghiepRepository();
        }

        public DoanhNghiep GetDoanhNghiepById(int dnId)
        {
            if (dnId <= 0)
                throw new ArgumentException("Mã doanh nghiệp không hợp lệ.", nameof(dnId));

            return repository.GetDoanhNghiepById(dnId);
        }
    }
}

using JPC.Business.Services.Implementations.ERS;
using JPC.Business.Services.Interfaces.ERS;
using JPC.DataAccess.Repositories.Implementations.ERS;
using JPC.DataAccess.Repositories.Interfaces.ERS;

namespace JPC.Business
{
    public static class ServiceFactory
    {
        public static IDoanhNghiepService_ERS CreateDoanhNghiepService()
        {
            IDoanhNghiepRepository_ERS repo = new DoanhNghiepRepository_ERS();
            return new DoanhNghiepService_ERS(repo);
        }
    }
}

using JPC.Models.DoanhNghiep;

namespace JPC.Business.Services.Interfaces.CSS
{
    public interface IDoanhNghiepService
    {
        DoanhNghiep GetDoanhNghiepById(int dnId);
    }
}

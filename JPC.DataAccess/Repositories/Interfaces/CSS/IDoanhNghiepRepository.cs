using JPC.Models.DoanhNghiep;

namespace JPC.DataAccess.Repositories.Interfaces.CSS
{
    public interface IDoanhNghiepRepository
    {
        DoanhNghiep GetDoanhNghiepById(int dnId);
    }
}

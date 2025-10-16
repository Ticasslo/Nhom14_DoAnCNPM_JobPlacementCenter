using JPC.Models.UngVien;

namespace JPC.DataAccess.Repositories.Interfaces.CSS
{
    public interface IUngTuyenRepository
    {
        int Create(UngTuyen ungTuyen);
        bool ExistsUngTuyen(int uvId, int tinId);
        UngTuyen GetUngTuyenById(int utId);
    }
}

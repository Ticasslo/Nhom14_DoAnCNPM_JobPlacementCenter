using JPC.Models.UngVien;

namespace JPC.Business.Services.Interfaces.CSS
{
    public interface IUngTuyenService
    {
        int GhiNhanUngTuyen(UngTuyen ungTuyen);
        bool KiemTraDaUngTuyen(int uvId, int tinId);
        UngTuyen GetUngTuyenById(int utId);
    }
}

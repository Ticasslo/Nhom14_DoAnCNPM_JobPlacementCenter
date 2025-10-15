using System.Data;

namespace JPC.DataAccess.Repositories.Interfaces.ERS
{
    public interface IUngTuyenRepository
    {
        // Tin tuyển dụng
        DataTable GetTinByDoanhNghiep(int dnId);
        DataTable GetTinByDoanhNghiepAndTin(int dnId, int tinId);

        // Ứng viên
        DataTable GetUngVienByTin(int tinId);
        DataTable GetUngVienByDoanhNghiepAndTin(int dnId, int tinId);

        // Cập nhật kết quả
        bool CapNhatTrangThaiUngVien(int uvId, int tinId, string trangThai);
    }
}

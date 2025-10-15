using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace JPC.DataAccess.Repositories.Interfaces.SA
{
    public interface INhanVienRepository
    {
        DataTable GetAllNhanVien();
        DataTable SearchNhanVien(string keyword);
        DataTable GetAllVaiTro();
        DataTable GetRoleDistribution();
        bool InsertNhanVien(string hoTen, string email, string soDienThoai, string username, string passwordHash, string vaiTroId, string trangThai);
        bool UpdateNhanVien(int maNhanVien, string hoTen, string email, string soDienThoai, string username, string passwordHash, string vaiTroId, string trangThai);
        // Password-only operations
        string GetPasswordHashById(int maNhanVien);
        bool UpdatePassword(int maNhanVien, string newPasswordHash);
    }
}

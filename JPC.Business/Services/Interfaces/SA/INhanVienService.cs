using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.Business.Services.Interfaces.SA
{
    public interface INhanVienService
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

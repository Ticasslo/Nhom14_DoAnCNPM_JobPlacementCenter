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
        bool InsertNhanVien(string hoTen, string email, string soDienThoai, string username, string passwordHash, string vaiTroId, string trangThai);
        bool UpdateNhanVien(int maNhanVien, string hoTen, string email, string soDienThoai, string username, string passwordHash, string vaiTroId, string trangThai);
    }
}

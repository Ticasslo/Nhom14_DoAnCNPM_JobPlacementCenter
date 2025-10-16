using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JPC.Business.Services.Interfaces.SA;
using JPC.DataAccess.Repositories.Interfaces.SA;
using JPC.DataAccess.Repositories.Implementations.SA;

namespace JPC.Business.Services.Implementations.SA
{
    public class NhanVienService : INhanVienService
    {
        private readonly INhanVienRepository _repo;

        public NhanVienService()
        {
            _repo = new NhanVienRepository();
        }

        public DataTable GetAllNhanVien()
        {
            return _repo.GetAllNhanVien();
        }

        public DataTable SearchNhanVien(string keyword)
        {
            return _repo.SearchNhanVien(keyword);
        }

        public DataTable GetAllVaiTro()
        {
            return _repo.GetAllVaiTro();
        }

        public DataTable GetRoleDistribution()
        {
            return _repo.GetRoleDistribution();
        }

        public bool InsertNhanVien(string hoTen, string email, string soDienThoai, string username, string passwordHash, string vaiTroId, string trangThai)
        {
            return _repo.InsertNhanVien(hoTen, email, soDienThoai, username, passwordHash, vaiTroId, trangThai);
        }

        public bool UpdateNhanVien(int maNhanVien, string hoTen, string email, string soDienThoai, string username, string passwordHash, string vaiTroId, string trangThai)
        {
            return _repo.UpdateNhanVien(maNhanVien, hoTen, email, soDienThoai, username, passwordHash, vaiTroId, trangThai);
        }

        public bool UpdatePassword(int maNhanVien, string newPasswordHash)
        {
            return _repo.UpdatePassword(maNhanVien, newPasswordHash);
        }
    }
}

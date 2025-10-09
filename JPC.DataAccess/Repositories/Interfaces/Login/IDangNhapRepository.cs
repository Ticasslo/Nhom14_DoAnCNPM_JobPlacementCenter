using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JPC.Models.QuanTri;

namespace JPC.DataAccess.Repositories.Interfaces.Login
{
    public interface IDangNhapRepository
    {
        NhanVien DangNhap(string username, string passwordHash, string expectedVaiTroId = null);
    }
}

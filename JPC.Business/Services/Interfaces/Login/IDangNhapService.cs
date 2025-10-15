using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JPC.Models.QuanTri;

namespace JPC.Business.Services.Interfaces.Login
{
    public interface IDangNhapService
    {
        NhanVien DangNhap(string username, string plainPassword, string expectedVaiTroId = null);
    }
}
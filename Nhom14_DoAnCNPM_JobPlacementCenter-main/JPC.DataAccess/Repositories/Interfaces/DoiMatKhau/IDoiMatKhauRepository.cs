using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.DataAccess.Repositories.Interfaces.Login
{
    public interface IDoiMatKhauRepository
    {
        bool CapNhatMatKhau(string username, string newPasswordHash);
    }
}
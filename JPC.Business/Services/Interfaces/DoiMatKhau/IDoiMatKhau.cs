using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.Business.Services.Interfaces.DoiMatKhau
{
    public interface IDoiMatKhauService
    {
        bool DoiMatKhau(string username, string oldPlainPassword, string newPlainPassword);
    }
}

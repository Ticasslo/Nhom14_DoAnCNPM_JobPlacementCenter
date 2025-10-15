using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.DataAccess.Repositories.Interfaces.FO
{
    public interface INhanVienRepository
    {
        IEnumerable<(int ma_nhan_vien, string ho_ten)> GetAllBasic();
    }
}

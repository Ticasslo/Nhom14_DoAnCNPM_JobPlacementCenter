using JPC.Models.DanhMucNghe;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.Business.Services.Interfaces.SA
{
    public interface INgheService
    {
        DataTable GetAllNghe();
        DataTable GetAllNgheForDisplay(); // Lấy tất cả nghề với nhom_id cho display
        DataTable GetActiveNgheByNhomId(int nhomId); // Lấy nghề active theo nhóm nghề
        DataTable SearchNghe(string keyword);
        Nghe GetNgheById(int id);
        bool InsertNghe(Nghe nghe);
        bool UpdateNghe(Nghe nghe);
    }
}

using JPC.Models.DanhMucNghe;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.DataAccess.Repositories.Interfaces.SA
{
    public interface INgheRepository
    {
        DataTable GetAllNghe();
        DataTable GetAllNgheForDisplay(); // Lấy tất cả nghề với nhom_id cho display
        DataTable GetActiveNgheByNhomId(int nhomId); // Lấy nghề active theo nhóm nghề
        DataTable SearchNghe(string keyword);
        Nghe GetNgheById(int id);
        bool InsertNghe(Nghe nghe);
        bool UpdateNghe(Nghe nghe);
        bool CheckDuplicateNghe(int nhomId, string tenNghe, int excludeId = 0);
        int CountActiveViTriInNghe(int ngheId); // Đếm số vị trí chuyên môn active
    }
}
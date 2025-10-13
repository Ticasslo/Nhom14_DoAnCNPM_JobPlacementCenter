using JPC.Models.DanhMucNghe;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.DataAccess.Repositories.Interfaces.SA
{
    public interface INhomNgheRepository
    {
        DataTable GetAllNhomNghe();
        DataTable GetActiveNhomNghe(); // Chỉ lấy active cho ComboBox
        DataTable SearchNhomNghe(string keyword);
        NhomNghe GetNhomNgheById(int id);
        bool InsertNhomNghe(NhomNghe nhomNghe);
        bool UpdateNhomNghe(NhomNghe nhomNghe);
        int CountActiveNgheInNhomNghe(int nhomId); // Đếm số nghề con active
        bool CheckDuplicateNhomNghe(string tenNhom, int excludeId = 0); // Kiểm tra trùng tên
    }
}

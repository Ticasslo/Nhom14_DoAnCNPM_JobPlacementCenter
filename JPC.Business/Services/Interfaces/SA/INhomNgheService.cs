using JPC.Models.DanhMucNghe;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.Business.Services.Interfaces.SA
{
    public interface INhomNgheService
    {
        DataTable GetAllNhomNghe();
        DataTable GetActiveNhomNghe(); // Lấy nhóm nghề active cho ComboBox
        DataTable SearchNhomNghe(string keyword);
        NhomNghe GetNhomNgheById(int id);
        bool InsertNhomNghe(NhomNghe nhomNghe);
        bool UpdateNhomNghe(NhomNghe nhomNghe);
    }
}

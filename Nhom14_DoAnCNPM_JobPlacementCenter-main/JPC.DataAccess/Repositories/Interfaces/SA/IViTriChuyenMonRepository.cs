using JPC.Models.DanhMucNghe;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.DataAccess.Repositories.Interfaces.SA
{
    public interface IViTriChuyenMonRepository
    {
        DataTable GetAllViTriChuyenMon();
        DataTable SearchViTriChuyenMon(string keyword);
        ViTriChuyenMon GetViTriChuyenMonById(int id);
        bool InsertViTriChuyenMon(ViTriChuyenMon viTri);
        bool UpdateViTriChuyenMon(ViTriChuyenMon viTri);
        bool CheckDuplicateViTriChuyenMon(int ngheId, string tenViTri, int excludeId = 0);
    }
}
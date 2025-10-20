using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JPC.Models.DoanhNghiep;

namespace JPC.Business.Services.Interfaces.ERS
{
    public interface ITinTuyenDungService_ERS
    {
        (bool Ok, string Message, int NewId) InsertTinTuyenDung(TinTuyenDung tin);
        DataTable GetTinByDoanhNghiep(int dnId);

    }
}
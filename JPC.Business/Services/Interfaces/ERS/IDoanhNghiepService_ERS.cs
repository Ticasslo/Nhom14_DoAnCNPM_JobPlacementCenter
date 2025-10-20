using JPC.Models.DoanhNghiep;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.Business.Services.Interfaces.ERS
{
    public interface IDoanhNghiepService_ERS
    {
        // Trả về (success, message, newId)
        (bool Ok, string Message, int NewId) DangKy(DoanhNghiep dn);
        List<DoanhNghiep> LayTatCa();
        DoanhNghiep TimTheoMa(int id);                      // ✅ thêm
        (bool ok, string msg) CapNhat(DoanhNghiep dn);      // ✅ thêm
    }
}
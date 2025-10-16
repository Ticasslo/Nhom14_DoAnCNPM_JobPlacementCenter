using System.Collections.Generic;
using JPC.Models.DoanhNghiep;

namespace JPC.DataAccess.Repositories.Interfaces.ERS
{
    public interface IDoanhNghiepRepository_ERS
    {
        List<DoanhNghiep> GetAll();
        DoanhNghiep GetById(int id);      // ✅ thêm dòng này
        int Update(DoanhNghiep dn);       // ✅ thêm dòng này
        int Insert(DoanhNghiep dn);                 // trả về số dòng ảnh hưởng
        int InsertAndReturnId(DoanhNghiep dn);      // trả về dn_id mới (tiện nếu muốn)
        bool ExistsByMST(string mst);
        bool ExistsByEmail(string email);           // (email không unique ở DB, nhưng nên check mềm)
    }
}
using JPC.Models.DoanhNghiep;
using System.Collections.Generic;

namespace JPC.DataAccess.Repositories.Interfaces.CSS
{
    public interface ITinTuyenDungRepository
    {
        IEnumerable<TinTuyenDung> GetTinTuyenDungActive();
        IEnumerable<TinTuyenDung> GetTinTuyenDungByViTri(int vtId);
        IEnumerable<TinTuyenDung> GetTinTuyenDungByNghe(int ngheId);
        IEnumerable<TinTuyenDung> GetTinTuyenDungByNhomNghe(int nhomId);
        IEnumerable<TinTuyenDung> GetTinTuyenDungChuaUngTuyen(int uvId);
        TinTuyenDung GetTinTuyenDungById(int tinId);
        IEnumerable<string> GetKyNangByTinAndViTri(int tinId, int vtId);
        IEnumerable<int> GetViTriByTin(int tinId);
    }
}

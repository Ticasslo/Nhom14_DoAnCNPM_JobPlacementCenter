using JPC.Models.DoanhNghiep;
using JPC.Models.UngVien;
using System.Collections.Generic;

namespace JPC.Business.Services.Interfaces.CSS
{
    public interface ITinTuyenDungService
    {
        IEnumerable<TinTuyenDung> GetTinTuyenDungActive();
        IEnumerable<TinTuyenDung> GetTinTuyenDungPhuHop(UngVien ungVien);
        TinTuyenDung GetTinTuyenDungById(int tinId);
        IEnumerable<string> GetKyNangByTinAndViTri(int tinId, int vtId);
        IEnumerable<int> GetViTriByTin(int tinId);
    }
}

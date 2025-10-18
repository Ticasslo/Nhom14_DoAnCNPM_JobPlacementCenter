using JPC.Models.UngVien;
using System.Collections.Generic;

namespace JPC.DataAccess.Repositories.Interfaces.CSS
{
	public interface IUngVienRepository
	{
		bool ExistsByCccd(string cccd);
		bool ExistsBySoDienThoai(string soDienThoai);
        int Create(UngVien entity);
		IEnumerable<UngVien> GetAllUngVien();
		IEnumerable<UngVien> SearchUngVien(string maUngVien, string hoTen, string email, string soDienThoai, string cccd);
		UngVien GetUngVienById(int uvId);
		bool UpdateUngVien(UngVien ungVien);
	}
}



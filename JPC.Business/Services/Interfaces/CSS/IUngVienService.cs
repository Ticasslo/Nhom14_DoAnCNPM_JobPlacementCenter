using JPC.Models.UngVien;
using System.Collections.Generic;

namespace JPC.Business.Services.Interfaces.CSS
{
	public interface IUngVienService
	{
		void DangKyUngVien(UngVien ungVien);
		IEnumerable<UngVien> GetAllUngVien();
		IEnumerable<UngVien> SearchUngVien(string maUngVien, string hoTen, string email, string soDienThoai, string cccd);
		UngVien GetUngVienById(int uvId);
		void CapNhatUngVien(UngVien ungVien);
	}
}



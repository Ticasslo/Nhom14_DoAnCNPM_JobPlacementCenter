using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using JPC.Business.Exceptions;
using JPC.Models.QuanTri;
using JPC.Business.Services.Interfaces.DoiMatKhau;
using JPC.DataAccess.Exceptions;
using JPC.DataAccess.Repositories.Implementations.Login;
using JPC.DataAccess.Repositories.Interfaces.Login;
using JPC.Models;


namespace JPC.Business.Services.Implementations.DoiMatKhau
{
	public class DoiMatKhauService : IDoiMatKhauService
	{
		private readonly IDoiMatKhauRepository doiMatKhauRepository;

		public DoiMatKhauService()
		{
			this.doiMatKhauRepository = new DoiMatKhauRepository();
		}

		public DoiMatKhauService(IDoiMatKhauRepository doiMatKhauRepository)
		{
			this.doiMatKhauRepository = doiMatKhauRepository ?? throw new ArgumentNullException(nameof(doiMatKhauRepository));
		}

		public bool DoiMatKhau(string username, string oldPlainPassword, string newPlainPassword)
		{
			if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(oldPlainPassword) || string.IsNullOrWhiteSpace(newPlainPassword))
				throw new BusinessException("Vui lòng nhập đầy đủ thông tin.");

			if (UserSession.NhanVien == null || !string.Equals(UserSession.Username, username, StringComparison.OrdinalIgnoreCase))
				throw new BusinessException("Không xác định được người dùng hiện tại. Vui lòng đăng nhập lại.");

			string oldHash = ComputeMD5(oldPlainPassword);
			if (!string.Equals(UserSession.NhanVien.PasswordHash, oldHash, StringComparison.Ordinal))
				throw new BusinessException("Mật khẩu cũ không chính xác. Vui lòng thử lại");

			string newHash = ComputeMD5(newPlainPassword);
			try
			{
				bool updated = doiMatKhauRepository.CapNhatMatKhau(username, newHash);
				if (updated)
				{
					UserSession.NhanVien.PasswordHash = newHash; // đồng bộ session
				}
				return updated;
			}
			catch (DataAccessException ex)
			{
				throw new BusinessException("Không thể đổi mật khẩu", ex);
			}
		}

		private static string ComputeMD5(string input)
		{
			using (var md5 = MD5.Create())
			{
				var bytes = Encoding.UTF8.GetBytes(input);
				var hashBytes = md5.ComputeHash(bytes);
				var sb = new StringBuilder(hashBytes.Length * 2);
				foreach (var b in hashBytes)
				{
					sb.Append(b.ToString("x2"));
				}
				return sb.ToString();
			}
		}
	}
}

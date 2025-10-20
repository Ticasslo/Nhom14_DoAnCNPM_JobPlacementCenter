using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using JPC.Business.Services.Interfaces.Login;
using JPC.Business.Exceptions;
using JPC.DataAccess.Exceptions;
using JPC.DataAccess.Repositories.Interfaces.Login;
using JPC.DataAccess.Repositories.Implementations.Login;
using JPC.Models.QuanTri;

namespace JPC.Business.Services.Implementations.Login
{
    public class DangNhapService : IDangNhapService
    {
        private readonly IDangNhapRepository repository;

        public DangNhapService()
        {
            this.repository = new DangNhapRepository();
        }

        public DangNhapService(IDangNhapRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public NhanVien DangNhap(string username, string plainPassword, string expectedVaiTroId = null)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(plainPassword))
                return null;

            string passwordHash = ComputeSHA256(plainPassword);

            try
            {
                return repository.DangNhap(username, passwordHash, expectedVaiTroId);
            }
            catch (DataAccessException ex)
            {
                throw new BusinessException("Không thể đăng nhập vào hệ thống.", ex);
            }
            catch (Exception ex)
            {
                throw new BusinessException("Lỗi không xác định tại tầng nghiệp vụ.", ex);
            }
        }

        private static string ComputeSHA256(string input)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(input);
                var hashBytes = sha256.ComputeHash(bytes);
                var sb = new StringBuilder(hashBytes.Length * 2);
                foreach (var b in hashBytes)
                {
                    sb.Append(b.ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}

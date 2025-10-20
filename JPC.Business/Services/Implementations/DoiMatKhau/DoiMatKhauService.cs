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
using JPC.Models;
using JPC.DataAccess.Repositories.Interfaces.Login;
using JPC.DataAccess.Repositories.Implementations.Login;
using System.Text.RegularExpressions;


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

            // Xác thực mật khẩu cũ bằng cách so sánh với hash trong UserSession
            string oldHash = ComputeSHA256(oldPlainPassword);
            if (!string.Equals(UserSession.NhanVien.PasswordHash, oldHash, StringComparison.OrdinalIgnoreCase))
                throw new BusinessException("Mật khẩu cũ không chính xác. Vui lòng thử lại");

            string newHash = ComputeSHA256(newPlainPassword);
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

        private static string ComputeSHA256(string input)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(input);
                var hashBytes = sha256.ComputeHash(bytes);
                var sb = new StringBuilder(hashBytes.Length * 2);
                foreach (var b in hashBytes)
                {
                    sb.Append(b.ToString("X2")); // X2 = chữ hoa để đồng nhất với SQL Server HASHBYTES
                }
                return sb.ToString();
            }
        }
    }
        /// <summary>
        /// Đánh giá độ mạnh mật khẩu (in-memory, không phụ thuộc DB).
        /// Nếu muốn thay bằng DB, chỉ cần thay hàm IsCommon(...) là xong.
        /// </summary>
        public class PasswordStrengthService : IPasswordStrengthService
        {
            // Rút gọn một danh sách mk phổ biến (có thể mở rộng/đổi sang DB sau)
            private static readonly HashSet<string> _common =
                new HashSet<string>(StringComparer.OrdinalIgnoreCase)
                {
                "123456","123456789","password","qwerty","111111","12345678",
                "abc123","Password1","iloveyou","admin","123123","letmein",
                "welcome","monkey","dragon","qwerty123","zaq12wsx"
                };

            public PasswordStrengthResult Evaluate(string password, string username = null, string fullName = null)
            {
                var tips = new List<string>();
                if (string.IsNullOrEmpty(password))
                    return new PasswordStrengthResult(0, "Trống", false, tips);

                int score = 0;

                // 1) Độ dài
                if (password.Length >= 16) score += 40;
                else if (password.Length >= 12) score += 30;
                else if (password.Length >= 8) score += 15;
                else { score += 5; tips.Add("Tăng độ dài (≥ 12 ký tự)."); }

                // 2) Đa dạng ký tự
                if (Regex.IsMatch(password, "[a-z]")) score += 10; else tips.Add("Thêm chữ thường.");
                if (Regex.IsMatch(password, "[A-Z]")) score += 10; else tips.Add("Thêm chữ hoa.");
                if (Regex.IsMatch(password, "[0-9]")) score += 10; else tips.Add("Thêm chữ số.");
                if (Regex.IsMatch(password, "[^a-zA-Z0-9]")) score += 15; else tips.Add("Thêm ký tự đặc biệt.");

                // 3) Phạt mẫu dễ đoán
                if (Regex.IsMatch(password, @"(.)\1{2,}")) { score -= 10; tips.Add("Tránh lặp ≥3 ký tự."); }
                var easySeq = new[] { "0123", "1234", "2345", "3456", "4567", "5678", "6789", "abcd", "qwer", "asdf", "zxcv" };
                if (easySeq.Any(s => password.IndexOf(s, StringComparison.OrdinalIgnoreCase) >= 0))
                { score -= 10; tips.Add("Tránh chuỗi liên tiếp/“qwerty”."); }

                // 4) Không chứa username/họ tên
                if (!string.IsNullOrWhiteSpace(username) &&
                    password.IndexOf(username, StringComparison.OrdinalIgnoreCase) >= 0)
                { score -= 20; tips.Add("Không chứa tên đăng nhập."); }

                if (!string.IsNullOrWhiteSpace(fullName))
                {
                    foreach (var part in fullName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                                 .Where(p => p.Length >= 3))
                    {
                        if (password.IndexOf(part, StringComparison.OrdinalIgnoreCase) >= 0)
                        { score -= 20; tips.Add("Không chứa họ tên."); break; }
                    }
                }

                bool isCommon = IsCommon(password);
                if (isCommon) { score = Math.Min(score, 20); tips.Add("Không dùng mật khẩu phổ biến."); }

                score = Math.Max(0, Math.Min(100, score));
                var label = score >= 80 ? "Rất mạnh"
                          : score >= 60 ? "Mạnh"
                          : score >= 40 ? "Khá"
                          : score >= 20 ? "Yếu"
                          : "Rất yếu";

                return new PasswordStrengthResult(score, label, isCommon, tips);
            }

            private static bool IsCommon(string password)
                => !string.IsNullOrWhiteSpace(password) && _common.Contains(password);
        }
    
}

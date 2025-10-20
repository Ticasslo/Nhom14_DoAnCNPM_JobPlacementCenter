using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.Business.Services.Interfaces.DoiMatKhau
{
    public interface IDoiMatKhauService
    {
        bool DoiMatKhau(string username, string oldPlainPassword, string newPlainPassword);
    }

    // Password strength service
    public interface IPasswordStrengthService
    {
        // username / fullName dùng để phạt khi MK chứa thông tin người dùng
        PasswordStrengthResult Evaluate(string password, string username = null, string fullName = null);
    }

    public sealed class PasswordStrengthResult
    {
        public int Score { get; }                  // 0..100
        public string Label { get; }               // Rất yếu / Yếu / Khá / Mạnh / Rất mạnh
        public bool IsCommon { get; }              // Có nằm trong danh sách phổ biến
        public IReadOnlyList<string> Tips { get; } // Gợi ý cải thiện

        public PasswordStrengthResult(int score, string label, bool isCommon, IReadOnlyList<string> tips)
        {
            Score = score; Label = label; IsCommon = isCommon; Tips = tips;
        }
    }
}

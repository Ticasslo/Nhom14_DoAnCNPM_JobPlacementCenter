using JPC.Business.Exceptions;
using JPC.Business.Services.Interfaces.CSS;
using JPC.DataAccess.Repositories.Implementations.CSS;
using JPC.DataAccess.Repositories.Interfaces.CSS;
using JPC.Models.UngVien;
using System;
using System.Collections.Generic;

namespace JPC.Business.Services.Implementations.CSS
{
    public class UngVienService : IUngVienService
    {
        private readonly IUngVienRepository repository;

        public UngVienService()
        {
            this.repository = new UngVienRepository();
        }

        private static string NormalizeSpaces(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return s;
            return System.Text.RegularExpressions.Regex.Replace(s.Trim(), @"\s+", " ");
        }

        private static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            // Mẫu đơn giản, đủ dùng cho hầu hết trường hợp
            return System.Text.RegularExpressions.Regex.IsMatch(
                email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        }

        private static bool IsDigitsOnly(string s)
        {
            if (string.IsNullOrEmpty(s)) return false;
            if (s.Length != 10) return false; // Đảm bảo đúng 10 ký tự
            foreach (var ch in s)
                if (!char.IsDigit(ch)) return false;
            return true;
        }

        private static bool IsValidDob(DateTime dob)
        {
            var today = DateTime.Today;
            if (dob.Date > today) return false;       // Không ở tương lai
            var age = today.Year - dob.Year;
            if (dob.Date > today.AddYears(-age)) age--;
            return age >= 0 && age <= 60;            // chặn giá trị "phi thực tế"
        }

        public void DangKyUngVien(UngVien ungVien)
        {
            if (ungVien == null) throw new ArgumentNullException(nameof(ungVien));

            // Chuẩn hóa dữ liệu đầu vào
            ungVien.HoTen = NormalizeSpaces(ungVien.HoTen);
            ungVien.Email = NormalizeSpaces(ungVien.Email);
            ungVien.Cccd = NormalizeSpaces(ungVien.Cccd);
            ungVien.SoDienThoai = NormalizeSpaces(ungVien.SoDienThoai);
            ungVien.QueQuan = NormalizeSpaces(ungVien.QueQuan);

            // Kiểm tra bắt buộc
            if (string.IsNullOrWhiteSpace(ungVien.HoTen) ||
                string.IsNullOrWhiteSpace(ungVien.Email) ||
                string.IsNullOrWhiteSpace(ungVien.Cccd) ||
                string.IsNullOrWhiteSpace(ungVien.SoDienThoai) ||
                string.IsNullOrWhiteSpace(ungVien.QueQuan) ||
                !ungVien.VtId.HasValue)
            {
                throw new DomainValidationException("REQUIRED_MISSING", "Vui lòng nhập/chọn đầy đủ thông tin bắt buộc.");
            }

            // Kiểm tra định dạng email
            if (!IsValidEmail(ungVien.Email))
                throw new DomainValidationException("INVALID_EMAIL", "Email không hợp lệ.");

            // SĐT: chỉ chứa chữ số và đúng 10 ký tự
            if (!IsDigitsOnly(ungVien.SoDienThoai))
                throw new DomainValidationException("INVALID_PHONE", "Số điện thoại phải gồm đúng 10 chữ số.");

            // CCCD Việt Nam: 12 chữ số
            if (!System.Text.RegularExpressions.Regex.IsMatch(ungVien.Cccd, @"^\d{12}$"))
                throw new DomainValidationException("INVALID_CCCD", "CCCD phải gồm đúng 12 chữ số.");

            // Ngày sinh: không ở tương lai, tuổi không “phi thực tế” (< 60)
            if (!IsValidDob(ungVien.NgaySinh))
                throw new DomainValidationException("INVALID_DOB", "Ngày sinh không hợp lệ.");

            // Kiểm tra trùng CCCD
            if (repository.ExistsByCccd(ungVien.Cccd)) throw new DomainValidationException("DUP_CCCD", "CCCD đã được đăng ký.");

            // Kiểm tra trùng số điện thoại
            if (repository.ExistsBySoDienThoai(ungVien.SoDienThoai)) throw new DomainValidationException("DUP_PHONE", "Số điện thoại đã được đăng ký.");

            // Lưu
            repository.Create(ungVien);
        }

        public IEnumerable<UngVien> GetAllUngVien()
        {
            return repository.GetAllUngVien();
        }

        public IEnumerable<UngVien> SearchUngVien(string maUngVien, string hoTen, string email, string soDienThoai, string cccd)
        {
            return repository.SearchUngVien(maUngVien, hoTen, email, soDienThoai, cccd);
        }

        public UngVien GetUngVienById(int uvId)
        {
            if (uvId <= 0)
                throw new ArgumentException("Mã ứng viên không hợp lệ.", nameof(uvId));

            return repository.GetUngVienById(uvId);
        }

        public void CapNhatUngVien(UngVien ungVien)
        {
            if (ungVien == null) throw new ArgumentNullException(nameof(ungVien));

            // Chuẩn hóa dữ liệu đầu vào
            ungVien.HoTen = NormalizeSpaces(ungVien.HoTen);
            ungVien.Email = NormalizeSpaces(ungVien.Email);
            ungVien.Cccd = NormalizeSpaces(ungVien.Cccd);
            ungVien.SoDienThoai = NormalizeSpaces(ungVien.SoDienThoai);
            ungVien.QueQuan = NormalizeSpaces(ungVien.QueQuan);

            // Kiểm tra bắt buộc
            if (string.IsNullOrWhiteSpace(ungVien.HoTen) ||
                string.IsNullOrWhiteSpace(ungVien.Email) ||
                string.IsNullOrWhiteSpace(ungVien.Cccd) ||
                string.IsNullOrWhiteSpace(ungVien.SoDienThoai) ||
                string.IsNullOrWhiteSpace(ungVien.QueQuan) ||
                !ungVien.VtId.HasValue)
            {
                throw new DomainValidationException("REQUIRED_MISSING", "Vui lòng điền đầy đủ thông tin cần chỉnh sửa.");
            }

            // Kiểm tra định dạng email
            if (!IsValidEmail(ungVien.Email))
                throw new DomainValidationException("INVALID_EMAIL", "Email không hợp lệ.");

            // SĐT: chỉ chứa chữ số và đúng 10 ký tự
            if (!IsDigitsOnly(ungVien.SoDienThoai))
                throw new DomainValidationException("INVALID_PHONE", "Số điện thoại phải gồm đúng 10 chữ số.");

            // CCCD Việt Nam: 12 chữ số
            if (!System.Text.RegularExpressions.Regex.IsMatch(ungVien.Cccd, @"^\d{12}$"))
                throw new DomainValidationException("INVALID_CCCD", "CCCD phải gồm đúng 12 chữ số.");

            // Ngày sinh: không ở tương lai, tuổi không "phi thực tế" (< 120)
            if (!IsValidDob(ungVien.NgaySinh))
                throw new DomainValidationException("INVALID_DOB", "Ngày sinh không hợp lệ.");

            // Kiểm tra trùng CCCD (trừ ứng viên hiện tại)
            var existingUngVien = repository.GetUngVienById(ungVien.UvId);
            if (existingUngVien == null)
                throw new DomainValidationException("NOT_FOUND", "Không tìm thấy ứng viên cần chỉnh sửa.");

            if (existingUngVien.Cccd != ungVien.Cccd && repository.ExistsByCccd(ungVien.Cccd))
                throw new DomainValidationException("DUP_CCCD", "CCCD đã được sử dụng bởi ứng viên khác.");

            // Kiểm tra trùng số điện thoại (trừ ứng viên hiện tại)
            if (existingUngVien.SoDienThoai != ungVien.SoDienThoai && repository.ExistsBySoDienThoai(ungVien.SoDienThoai))
                throw new DomainValidationException("DUP_PHONE", "Số điện thoại đã được sử dụng bởi ứng viên khác.");

            // Cập nhật
            if (!repository.UpdateUngVien(ungVien))
                throw new DomainValidationException("UPDATE_FAILED", "Cập nhật thông tin ứng viên thất bại.");
        }
    }
}



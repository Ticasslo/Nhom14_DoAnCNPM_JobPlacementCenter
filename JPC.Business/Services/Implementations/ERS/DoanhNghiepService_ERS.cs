using System.Collections.Generic;
using System.Text.RegularExpressions;
using JPC.Business.Services.Interfaces.ERS;
using JPC.DataAccess.Repositories.Interfaces.ERS;
using JPC.Models.DoanhNghiep;

namespace JPC.Business.Services.Implementations.ERS
{
    public class DoanhNghiepService_ERS : IDoanhNghiepService_ERS
    {
        private readonly IDoanhNghiepRepository_ERS _repo;

        public DoanhNghiepService_ERS(IDoanhNghiepRepository_ERS repo)
        {
            _repo = repo;
        }

        public List<DoanhNghiep> LayTatCa()
        {
            return _repo.GetAll();
        }


        public (bool Ok, string Message, int NewId) DangKy(DoanhNghiep dn)
        {
            // 1) Bắt buộc
            if (string.IsNullOrWhiteSpace(dn.TenDoanhNghiep))
                return (false, "Vui lòng nhập Tên doanh nghiệp.", 0);
            if (string.IsNullOrWhiteSpace(dn.Email))
                return (false, "Vui lòng nhập Email.", 0);
            if (string.IsNullOrWhiteSpace(dn.MaSoThue))
                return (false, "Vui lòng nhập Mã số thuế.", 0);

            // 2) Validate định dạng
            if (!Regex.IsMatch(dn.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                return (false, "Email không hợp lệ.", 0);

            if (!string.IsNullOrWhiteSpace(dn.SoDienThoai) &&
                !Regex.IsMatch(dn.SoDienThoai, @"^\d{9,11}$"))
                return (false, "Số điện thoại phải là 9–11 chữ số.", 0);

            // MST: 10 số hoặc dạng 10-3
            if (!Regex.IsMatch(dn.MaSoThue, @"^\d{10}$") &&
                !Regex.IsMatch(dn.MaSoThue, @"^\d{10}-\d{3}$"))
                return (false, "Mã số thuế không hợp lệ (10 số hoặc 10-3).", 0);

            // 3) Kiểm tra trùng
            if (_repo.ExistsByMST(dn.MaSoThue))
                return (false, "Mã số thuế đã tồn tại.", 0);
            if (!string.IsNullOrWhiteSpace(dn.Email) && _repo.ExistsByEmail(dn.Email))
                return (false, "Email đã được sử dụng.", 0);

            // 4) Lưu & trả id mới
            var id = _repo.InsertAndReturnId(dn);
            return (true, "Đăng ký hồ sơ doanh nghiệp thành công.", id);
        }

        public DoanhNghiep TimTheoMa(int id)
        {
            return _repo.GetById(id);
        }

        public (bool ok, string msg) CapNhat(DoanhNghiep dn)
        {
            var old = _repo.GetById(dn.DnId);
            if (old == null) return (false, "Không tìm thấy doanh nghiệp.");

            // kiểm tra có thay đổi không
            if (old.TenDoanhNghiep == dn.TenDoanhNghiep &&
                old.DiaChi == dn.DiaChi &&
                old.SoDienThoai == dn.SoDienThoai &&
                old.Email == dn.Email &&
                old.LinhVuc == dn.LinhVuc)
                return (false, "Không có thay đổi để lưu.");

            var rows = _repo.Update(dn);
            return rows > 0 ? (true, "Cập nhật thành công!") : (false, "Cập nhật thất bại!");
        }

    }
}
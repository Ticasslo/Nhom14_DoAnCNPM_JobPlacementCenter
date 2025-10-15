using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.Models.QuanTri
{
    public class NhanVien
    {
        private int maNhanVien;
        private string hoTen;
        private string email;
        private string soDienThoai;
        private string username;
        private string passwordHash;
        private string vaiTroId;
        private string trangThai;

        public NhanVien()
        {
            this.maNhanVien = 0;
            this.hoTen = string.Empty;
            this.email = string.Empty;
            this.soDienThoai = string.Empty;
            this.username = string.Empty;
            this.passwordHash = string.Empty;
            this.vaiTroId = string.Empty;
            this.trangThai = "active";
        }

        public NhanVien(int maNhanVien, string hoTen, string email, string soDienThoai,
                        string username, string passwordHash, string vaiTroId, string trangThai)
        {
            this.maNhanVien = maNhanVien;
            this.hoTen = hoTen ?? string.Empty;
            this.email = email ?? string.Empty;
            this.soDienThoai = soDienThoai ?? string.Empty;
            this.username = username ?? string.Empty;
            this.passwordHash = passwordHash ?? string.Empty;
            this.vaiTroId = vaiTroId ?? string.Empty;
            this.trangThai = string.IsNullOrWhiteSpace(trangThai) ? "active" : trangThai;
        }

        public int MaNhanVien { get { return this.maNhanVien; } set { this.maNhanVien = value; } }
        public string HoTen { get { return this.hoTen; } set { this.hoTen = value ?? string.Empty; } }
        public string Email { get { return this.email; } set { this.email = value ?? string.Empty; } }
        public string SoDienThoai { get { return this.soDienThoai; } set { this.soDienThoai = value ?? string.Empty; } }
        public string Username { get { return this.username; } set { this.username = value ?? string.Empty; } }
        public string PasswordHash { get { return this.passwordHash; } set { this.passwordHash = value ?? string.Empty; } }
        public string VaiTroId { get { return this.vaiTroId; } set { this.vaiTroId = value ?? string.Empty; } }
        public string TrangThai { get { return this.trangThai; } set { this.trangThai = value ?? "active"; } }
    }
}

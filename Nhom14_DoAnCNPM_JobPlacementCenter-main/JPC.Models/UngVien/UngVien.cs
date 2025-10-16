using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.Models.UngVien
{
    public class UngVien
    {
        private int uvId;
        private string hoTen;
        private string email;
        private string soDienThoai;
        private string cccd;
        private DateTime ngaySinh;
        private string queQuan;
        private int? vtId;
        private DateTime ngayTao;

        public UngVien()
        {
            this.uvId = 0;
            this.hoTen = string.Empty;
            this.email = string.Empty;
            this.soDienThoai = string.Empty;
            this.cccd = string.Empty;
            this.ngaySinh = DateTime.MinValue;
            this.queQuan = string.Empty;
            this.vtId = null;
            this.ngayTao = DateTime.Now;
        }

        public UngVien(int uvId, string hoTen, string email, string soDienThoai,
                       string cccd, DateTime ngaySinh, string queQuan, int? vtId, DateTime ngayTao)
        {
            this.uvId = uvId;
            this.hoTen = hoTen ?? string.Empty;
            this.email = email ?? string.Empty;
            this.soDienThoai = soDienThoai ?? string.Empty;
            this.cccd = cccd ?? string.Empty;
            this.ngaySinh = ngaySinh;
            this.queQuan = queQuan ?? string.Empty;
            this.vtId = vtId;
            this.ngayTao = ngayTao;
        }

        public int UvId { get { return this.uvId; } set { this.uvId = value; } }
        public string HoTen { get { return this.hoTen; } set { this.hoTen = value ?? string.Empty; } }
        public string Email { get { return this.email; } set { this.email = value ?? string.Empty; } }
        public string SoDienThoai { get { return this.soDienThoai; } set { this.soDienThoai = value ?? string.Empty; } }
        public string Cccd { get { return this.cccd; } set { this.cccd = value ?? string.Empty; } }
        public DateTime NgaySinh { get { return this.ngaySinh; } set { this.ngaySinh = value; } }
        public string QueQuan { get { return this.queQuan; } set { this.queQuan = value ?? string.Empty; } }
        public int? VtId { get { return this.vtId; } set { this.vtId = value; } }
        public DateTime NgayTao { get { return this.ngayTao; } set { this.ngayTao = value; } }
    }
}

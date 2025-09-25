using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.Models.DoanhNghiep
{
    public class DoanhNghiep
    {
        private int dnId;
        private string tenDoanhNghiep;
        private string diaChi;
        private string soDienThoai;
        private string email;
        private string maSoThue;
        private string linhVuc;
        private DateTime ngayTao;

        public DoanhNghiep()
        {
            this.dnId = 0;
            this.tenDoanhNghiep = string.Empty;
            this.diaChi = string.Empty;
            this.soDienThoai = string.Empty;
            this.email = string.Empty;
            this.maSoThue = string.Empty;
            this.linhVuc = string.Empty;
            this.ngayTao = DateTime.Now;
        }

        public DoanhNghiep(int dnId, string tenDoanhNghiep, string diaChi, string soDienThoai,
                           string email, string maSoThue, string linhVuc, DateTime ngayTao)
        {
            this.dnId = dnId;
            this.tenDoanhNghiep = tenDoanhNghiep ?? string.Empty;
            this.diaChi = diaChi ?? string.Empty;
            this.soDienThoai = soDienThoai ?? string.Empty;
            this.email = email ?? string.Empty;
            this.maSoThue = maSoThue ?? string.Empty;
            this.linhVuc = linhVuc ?? string.Empty;
            this.ngayTao = ngayTao;
        }

        public int DnId { get { return this.dnId; } set { this.dnId = value; } }
        public string TenDoanhNghiep { get { return this.tenDoanhNghiep; } set { this.tenDoanhNghiep = value ?? string.Empty; } }
        public string DiaChi { get { return this.diaChi; } set { this.diaChi = value ?? string.Empty; } }
        public string SoDienThoai { get { return this.soDienThoai; } set { this.soDienThoai = value ?? string.Empty; } }
        public string Email { get { return this.email; } set { this.email = value ?? string.Empty; } }
        public string MaSoThue { get { return this.maSoThue; } set { this.maSoThue = value ?? string.Empty; } }
        public string LinhVuc { get { return this.linhVuc; } set { this.linhVuc = value ?? string.Empty; } }
        public DateTime NgayTao { get { return this.ngayTao; } set { this.ngayTao = value; } }
    }
}

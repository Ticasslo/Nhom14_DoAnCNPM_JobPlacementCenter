using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.Models.TaiChinh
{
    public class TinTuyenDungDTO
    {
        public int TinId { get; set; }
        public string TieuDe { get; set; }
        public System.DateTime NgayDang { get; set; }
        public System.DateTime HanNopHoSo { get; set; }

        // Hóa đơn gần nhất (nếu có)
        public int? MaHoaDon { get; set; }
        public decimal? SoTienHoaDon { get; set; }

        // Text hiển thị lên combobox
        public string Display { get; set; }
    }
}
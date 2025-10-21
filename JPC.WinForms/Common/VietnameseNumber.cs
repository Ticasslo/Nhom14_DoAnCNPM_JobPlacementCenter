using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom14_DoAnCNPM_JobPlacementCenter_Code.Common
{
    public static class VietnameseNumber
    {
        private static readonly string[] chuSo =
            { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };

        private static string Doc3ChuSo(int n, bool docDayDu)
        {
            int tram = n / 100;
            int chuc = (n / 10) % 10;
            int donvi = n % 10;

            var parts = new List<string>();

            if (docDayDu || tram > 0)
            {
                parts.Add(chuSo[tram] + " trăm");
            }

            if (chuc > 1)
            {
                parts.Add(chuSo[chuc] + " mươi");
                if (donvi == 1) parts.Add("mốt");
                else if (donvi == 5) parts.Add("lăm");
                else if (donvi > 0) parts.Add(chuSo[donvi]);
            }
            else if (chuc == 1)
            {
                parts.Add("mười");
                if (donvi == 5) parts.Add("lăm");
                else if (donvi > 0) parts.Add(chuSo[donvi]);
            }
            else // chuc == 0
            {
                if (donvi > 0)
                {
                    if (tram > 0 || docDayDu) parts.Add("lẻ");
                    parts.Add(chuSo[donvi]);
                }
            }

            return string.Join(" ", parts);
        }

        public static string ToWords(long number)
        {
            if (number == 0) return "không";

            // Chia theo từng block 3 chữ số (nghìn/triệu/tỷ/…)
            string[] donViLon = { "", "nghìn", "triệu", "tỷ", "nghìn tỷ", "triệu tỷ" };

            var parts = new List<string>();
            int i = 0;
            bool docDayDu = false;

            while (number > 0)
            {
                int block = (int)(number % 1000);
                if (block != 0)
                {
                    string blockText = Doc3ChuSo(block, docDayDu);
                    string unit = donViLon[i];
                    if (!string.IsNullOrEmpty(unit))
                        parts.Insert(0, unit);
                    parts.Insert(0, blockText);
                    docDayDu = true; // các block sau sẽ đọc đầy đủ (có thể dùng "lẻ"/"trăm")
                }
                number /= 1000;
                i++;
            }

            // Làm gọn khoảng trắng
            var result = string.Join(" ", parts).Replace("  ", " ").Trim();
            return result;
        }

        public static string ToCurrencyWords(decimal amount)
        {
            // thường hóa đơn là số nguyên đồng
            long v = (long)Math.Round(amount, MidpointRounding.AwayFromZero);
            var words = ToWords(v);
            return words;
        }
    }
}
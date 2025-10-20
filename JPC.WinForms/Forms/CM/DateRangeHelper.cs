using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.CM
{
    public class DateRangeHelper
    {
        public static (DateTime from, DateTime to) Build(string type, int period, int year)
        {
            if (type == "THANG") { var f = new DateTime(year, period, 1); return (f, f.AddMonths(1)); }
            if (type == "QUY") { var m = (period - 1) * 3 + 1; var f = new DateTime(year, m, 1); return (f, f.AddMonths(3)); }
            return (new DateTime(year, 1, 1), new DateTime(year + 1, 1, 1));
        }
    }
}

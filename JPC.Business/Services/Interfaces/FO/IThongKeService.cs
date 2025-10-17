using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.Business.Services.Interfaces.FO
{
    public interface IThongKeService
    {
        DataTable LayHoaDon(DateTime tuNgay, DateTime denNgay);
        decimal TinhTongTien(DataTable dt);
    }
}
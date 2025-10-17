using JPC.Business.Services.Interfaces.FO;
using JPC.DataAccess.Repositories.Interfaces.FO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.Business.Services.Implementations.FO
{
    public class ThongKeService : IThongKeService
    {
        private readonly IHoaDonRepository _hoaDonRepo;
        public ThongKeService(IHoaDonRepository hoaDonRepo)
        {
            _hoaDonRepo = hoaDonRepo;
        }

        public DataTable LayHoaDon(DateTime tuNgay, DateTime denNgay)
            => _hoaDonRepo.GetBaoCaoDoanhThu(tuNgay, denNgay);

        public decimal TinhTongTien(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0) return 0m;
            return dt.AsEnumerable().Sum(r => r.Field<decimal>("so_tien"));
        }
    }
}
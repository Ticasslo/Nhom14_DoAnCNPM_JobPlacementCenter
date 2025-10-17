using JPC.Models.TaiChinh;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.DataAccess.Repositories.Interfaces.FO
{
    public interface IHoaDonRepository
    {
        int Insert(HoaDon h, SqlTransaction tran); // dùng transaction
        HoaDon GetById(int id);
        HoaDon GetLatestByTinId(int tinId);
        int InsertHoaDon(HoaDon hd);

        DataTable GetList(DateTime? ngay, int? dnId, int? maNvLap);
        DataTable GetAll();
        int UpdateBasic(int id, string tenKhachHang, decimal soTien, DateTime ngayLap, int maNvLap);
        DataTable GetBaoCaoDoanhThu(DateTime tuNgay, DateTime denNgay);
    }
}

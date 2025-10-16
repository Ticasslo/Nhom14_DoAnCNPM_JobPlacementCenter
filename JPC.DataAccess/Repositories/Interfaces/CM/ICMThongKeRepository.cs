using System;
using System.Data;

namespace JPC.DataAccess.Repositories.Interfaces.CM
{
    public interface ICMThongKeRepository
    {
        // groupBy: "NHOM" | "NGHE" | "VITRI"
        DataTable ThongKeSoLuong(DateTime from, DateTime toExclusive, string groupBy);
        DataTable TyLeKetNoi(DateTime from, DateTime toExclusive, string groupBy);
        void RunExpireJobPosts(); // optional: EXEC SP_KiemTraTinHetHan
    }
}

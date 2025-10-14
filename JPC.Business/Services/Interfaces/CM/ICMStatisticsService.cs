using System;
using System.Data;

namespace JPC.Business.Services.Interfaces.CM
{
    public interface ICMStatisticsService
    {
        DataTable ThongKeSoLuong(DateTime from, DateTime toExclusive, string groupBy);
        DataTable TyLeKetNoi(DateTime from, DateTime toExclusive, string groupBy);
        void RunExpireJobPosts();
    }
}

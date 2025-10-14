using System;
using System.Data;
using JPC.Business.Services.Interfaces.CM;
using JPC.DataAccess.Repositories.Implementations.CM;
using JPC.DataAccess.Repositories.Interfaces.CM;

namespace JPC.Business.Services.Implementations.CM
{
    public class CMStatisticsService : ICMStatisticsService
    {
        private readonly ICMThongKeRepository _repo = new CMThongKeRepository();

        public DataTable ThongKeSoLuong(DateTime f, DateTime t, string g) => _repo.ThongKeSoLuong(f, t, g);
        public DataTable TyLeKetNoi(DateTime f, DateTime t, string g) => _repo.TyLeKetNoi(f, t, g);
        public void RunExpireJobPosts() => _repo.RunExpireJobPosts();
    }
}

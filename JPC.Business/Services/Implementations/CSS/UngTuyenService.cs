using JPC.Business.Services.Interfaces.CSS;
using JPC.DataAccess.Repositories.Implementations.CSS;
using JPC.DataAccess.Repositories.Interfaces.CSS;
using JPC.Models.UngVien;
using System;

namespace JPC.Business.Services.Implementations.CSS
{
    public class UngTuyenService : IUngTuyenService
    {
        private readonly IUngTuyenRepository repository;

        public UngTuyenService()
        {
            this.repository = new UngTuyenRepository();
        }

        public int GhiNhanUngTuyen(UngTuyen ungTuyen)
        {
            if (ungTuyen == null)
                throw new ArgumentNullException(nameof(ungTuyen));

            if (ungTuyen.UvId <= 0)
                throw new ArgumentException("Mã ứng viên không hợp lệ.", nameof(ungTuyen.UvId));

            if (ungTuyen.TinId <= 0)
                throw new ArgumentException("Mã tin tuyển dụng không hợp lệ.", nameof(ungTuyen.TinId));

            // Kiểm tra ứng viên đã ứng tuyển tin này chưa
            if (repository.ExistsUngTuyen(ungTuyen.UvId, ungTuyen.TinId))
                throw new InvalidOperationException("Ứng viên đã ứng tuyển tin tuyển dụng này rồi.");

            // Tạo ứng tuyển mới
            return repository.Create(ungTuyen);
        }

        public bool KiemTraDaUngTuyen(int uvId, int tinId)
        {
            if (uvId <= 0)
                throw new ArgumentException("Mã ứng viên không hợp lệ.", nameof(uvId));

            if (tinId <= 0)
                throw new ArgumentException("Mã tin tuyển dụng không hợp lệ.", nameof(tinId));

            return repository.ExistsUngTuyen(uvId, tinId);
        }

        public UngTuyen GetUngTuyenById(int utId)
        {
            if (utId <= 0)
                throw new ArgumentException("Mã ứng tuyển không hợp lệ.", nameof(utId));

            return repository.GetUngTuyenById(utId);
        }
    }
}

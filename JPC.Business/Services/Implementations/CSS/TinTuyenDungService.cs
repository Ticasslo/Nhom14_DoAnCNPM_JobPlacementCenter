using JPC.Business.Services.Interfaces.CSS;
using JPC.DataAccess.Repositories.Implementations.CSS;
using JPC.DataAccess.Repositories.Interfaces.CSS;
using JPC.Models.DanhMucNghe;
using JPC.Models.DoanhNghiep;
using JPC.Models.UngVien;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JPC.Business.Services.Implementations.CSS
{
    public class TinTuyenDungService : ITinTuyenDungService
    {
        private readonly ITinTuyenDungRepository repository;
        private readonly IDanhMucNgheService danhMucNgheService;

        public TinTuyenDungService()
        {
            this.repository = new TinTuyenDungRepository();
            this.danhMucNgheService = new DanhMucNgheService();
        }

        public IEnumerable<TinTuyenDung> GetTinTuyenDungActive()
        {
            return repository.GetTinTuyenDungActive();
        }

        public IEnumerable<TinTuyenDung> GetTinTuyenDungPhuHop(UngVien ungVien)
        {
            if (ungVien == null)
                throw new ArgumentNullException(nameof(ungVien));

            var result = new List<TinTuyenDung>();

            // Lấy tất cả tin tuyển dụng chưa ứng tuyển
            var allTinChuaUngTuyen = repository.GetTinTuyenDungChuaUngTuyen(ungVien.UvId);

            if (ungVien.VtId.HasValue)
            {
                // Ưu tiên 1: Tin có vị trí chuyên môn giống với ứng viên
                var tinCungViTri = repository.GetTinTuyenDungByViTri(ungVien.VtId.Value)
                    .Where(t => allTinChuaUngTuyen.Any(x => x.TinId == t.TinId))
                    .ToList();

                result.AddRange(tinCungViTri);

                // Ưu tiên 2: Tin cùng nghề với ứng viên
                var viTriUngVien = GetViTriChuyenMonById(ungVien.VtId.Value);
                if (viTriUngVien != null)
                {
                    var tinCungNghe = repository.GetTinTuyenDungByNghe(viTriUngVien.NgheId)
                        .Where(t => !result.Any(x => x.TinId == t.TinId) && 
                                   allTinChuaUngTuyen.Any(x => x.TinId == t.TinId))
                        .ToList();

                    result.AddRange(tinCungNghe);

                    // Ưu tiên 3: Tin cùng nhóm nghề với ứng viên
                    var ngheUngVien = GetNgheById(viTriUngVien.NgheId);
                    if (ngheUngVien != null)
                    {
                        var tinCungNhomNghe = repository.GetTinTuyenDungByNhomNghe(ngheUngVien.NhomId)
                            .Where(t => !result.Any(x => x.TinId == t.TinId) && 
                                       allTinChuaUngTuyen.Any(x => x.TinId == t.TinId))
                            .ToList();

                        result.AddRange(tinCungNhomNghe);
                    }
                }
            }

            // Thêm các tin khác còn lại
            var tinConLai = allTinChuaUngTuyen
                .Where(t => !result.Any(x => x.TinId == t.TinId))
                .ToList();

            result.AddRange(tinConLai);

            // Sắp xếp theo độ phù hợp và ưu tiên TP.HCM
            return result.OrderByDescending(t => GetDoPhuHop(t, ungVien))
                        .ThenByDescending(t => t.KhuVucLamViec?.Contains("TP.HCM") == true)
                        .ThenByDescending(t => t.NgayDang);
        }

        public TinTuyenDung GetTinTuyenDungById(int tinId)
        {
            if (tinId <= 0)
                throw new ArgumentException("Mã tin tuyển dụng không hợp lệ.", nameof(tinId));

            return repository.GetTinTuyenDungById(tinId);
        }

        public IEnumerable<string> GetKyNangByTinAndViTri(int tinId, int vtId)
        {
            if (tinId <= 0)
                throw new ArgumentException("Mã tin tuyển dụng không hợp lệ.", nameof(tinId));

            if (vtId <= 0)
                throw new ArgumentException("Mã vị trí chuyên môn không hợp lệ.", nameof(vtId));

            return repository.GetKyNangByTinAndViTri(tinId, vtId);
        }

        public IEnumerable<int> GetViTriByTin(int tinId)
        {
            if (tinId <= 0)
                throw new ArgumentException("Mã tin tuyển dụng không hợp lệ.", nameof(tinId));

            return repository.GetViTriByTin(tinId);
        }

        private int GetDoPhuHop(TinTuyenDung tin, UngVien ungVien)
        {
            int doPhuHop = 0;

            // Kiểm tra vị trí chuyên môn
            if (ungVien.VtId.HasValue)
            {
                var viTriTin = repository.GetViTriByTin(tin.TinId);
                if (viTriTin.Contains(ungVien.VtId.Value))
                {
                    doPhuHop += 100; // Điểm cao nhất cho vị trí chuyên môn giống nhau
                }
                else
                {
                    // Kiểm tra cùng nghề
                    var viTriUngVien = GetViTriChuyenMonById(ungVien.VtId.Value);
                    if (viTriUngVien != null)
                    {
                        foreach (var vtId in viTriTin)
                        {
                            var viTriTinItem = GetViTriChuyenMonById(vtId);
                            if (viTriTinItem != null && viTriTinItem.NgheId == viTriUngVien.NgheId)
                            {
                                doPhuHop += 50; // Điểm cho cùng nghề
                                break;
                            }
                        }

                        // Kiểm tra cùng nhóm nghề
                        if (doPhuHop == 0)
                        {
                            var ngheUngVien = GetNgheById(viTriUngVien.NgheId);
                            if (ngheUngVien != null)
                            {
                                foreach (var vtId in viTriTin)
                                {
                                    var viTriTinItem = GetViTriChuyenMonById(vtId);
                                    if (viTriTinItem != null)
                                    {
                                        var ngheTin = GetNgheById(viTriTinItem.NgheId);
                                        if (ngheTin != null && ngheTin.NhomId == ngheUngVien.NhomId)
                                        {
                                            doPhuHop += 25; // Điểm cho cùng nhóm nghề
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            // Ưu tiên TP.HCM
            if (tin.KhuVucLamViec?.Contains("TP.HCM") == true)
            {
                doPhuHop += 10;
            }

            return doPhuHop;
        }

        // Helper methods để lấy thông tin vị trí chuyên môn và nghề
        private ViTriChuyenMon GetViTriChuyenMonById(int vtId)
        {
            return danhMucNgheService.GetViTriChuyenMonById(vtId);
        }

        private Nghe GetNgheById(int ngheId)
        {
            return danhMucNgheService.GetNgheById(ngheId);
        }
    }
}

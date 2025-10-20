using JPC.Business.Exceptions;
using JPC.DataAccess.Repositories.Implementations.CSS;
using JPC.DataAccess.Repositories.Implementations.ERS;
using JPC.DataAccess.Repositories.Interfaces.CSS;
using JPC.DataAccess.Repositories.Interfaces.ERS;
using System;
using System.Collections.Generic;
using System.Data;

namespace JPC.Business.Services.Implementations.ERS
{
    /// <summary>
    /// Service xử lý nghiệp vụ liên quan đến ứng tuyển, 
    /// bao gồm lấy danh sách ứng viên và cập nhật kết quả tuyển dụng.
    /// </summary>
    public class UngTuyenService_ERS
    {
        private readonly IUngTuyenRepository_ERS _repository;

        public UngTuyenService_ERS()
        {
            _repository = new UngTuyenRepository_ERS();
        }

        // 🔹 Lấy danh sách tin theo doanh nghiệp
        public DataTable LayTinTheoDoanhNghiep(int dnId)
        {
            try
            {
                return _repository.GetTinByDoanhNghiep(dnId);
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Lỗi khi lấy danh sách tin doanh nghiệp: {ex.Message}", ex);
            }
        }

        // 🔹 Lấy tin cụ thể theo doanh nghiệp và mã tin
        public DataTable LayTinTheoDoanhNghiepVaTin(int dnId, int tinId)
        {
            try
            {
                return _repository.GetTinByDoanhNghiepAndTin(dnId, tinId);
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Lỗi khi lấy tin cụ thể: {ex.Message}", ex);
            }
        }

        // 🔹 Lấy danh sách ứng viên theo mã tin
        public DataTable GetUngVienByTin(int tinId)
        {
            try
            {
                return _repository.GetUngVienByTin(tinId);
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Lỗi khi lấy danh sách ứng viên: {ex.Message}", ex);
            }
        }

        // 🔹 Lấy danh sách ứng viên theo doanh nghiệp và mã tin
        public DataTable LayUngVienTheoDoanhNghiepVaTin(int dnId, int tinId)
        {
            try
            {
                return _repository.GetUngVienByDoanhNghiepAndTin(dnId, tinId);
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Lỗi khi lấy ứng viên theo tin: {ex.Message}", ex);
            }
        }

        // 🔹 Cập nhật trạng thái kết quả tuyển dụng
        public bool CapNhatKetQuaTuyenDung(List<(int uvId, int tinId, string trangThai)> updates)
        {
            bool success = true;

            foreach (var item in updates)
            {
                bool ok = _repository.CapNhatTrangThaiUngVien(item.uvId, item.tinId, item.trangThai);
                if (!ok) success = false;
            }

            return success;
        }
    }
}
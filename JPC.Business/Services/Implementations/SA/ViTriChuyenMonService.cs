using JPC.Business.Exceptions;
using JPC.Business.Services.Interfaces.SA;
using JPC.DataAccess.Repositories.Implementations.SA;
using JPC.DataAccess.Repositories.Interfaces.SA;
using JPC.Models.DanhMucNghe;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.Business.Services.Implementations.SA
{
    public class ViTriChuyenMonService : IViTriChuyenMonService
    {
        private readonly IViTriChuyenMonRepository _viTriChuyenMonRepository;

        public ViTriChuyenMonService()
        {
            _viTriChuyenMonRepository = new ViTriChuyenMonRepository();
        }

        public DataTable GetAllViTriChuyenMon()
        {
            try
            {
                return _viTriChuyenMonRepository.GetAllViTriChuyenMon();
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Lỗi khi lấy danh sách vị trí chuyên môn: {ex.Message}", ex);
            }
        }

        public DataTable SearchViTriChuyenMon(string keyword)
        {
            try
            {
                return _viTriChuyenMonRepository.SearchViTriChuyenMon(keyword);
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Lỗi khi tìm kiếm vị trí chuyên môn: {ex.Message}", ex);
            }
        }

        public ViTriChuyenMon GetViTriChuyenMonById(int id)
        {
            try
            {
                return _viTriChuyenMonRepository.GetViTriChuyenMonById(id);
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Lỗi khi lấy thông tin vị trí chuyên môn: {ex.Message}", ex);
            }
        }

        public bool InsertViTriChuyenMon(ViTriChuyenMon viTri)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(viTri.TenViTri))
                {
                    throw new BusinessException("Tên vị trí chuyên môn không được để trống");
                }

                if (viTri.NgheId <= 0)
                {
                    throw new BusinessException("Vui lòng chọn nghề");
                }

                // Kiểm tra trùng tên trong cùng nghề
                if (_viTriChuyenMonRepository.CheckDuplicateViTriChuyenMon(viTri.NgheId, viTri.TenViTri))
                {
                    throw new BusinessException("Tên vị trí chuyên môn đã tồn tại trong nghề này");
                }

                return _viTriChuyenMonRepository.InsertViTriChuyenMon(viTri);
            }
            catch (BusinessException)
            {
                throw; // Re-throw BusinessException
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Lỗi khi thêm vị trí chuyên môn: {ex.Message}", ex);
            }
        }

        public bool UpdateViTriChuyenMon(ViTriChuyenMon viTri)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(viTri.TenViTri))
                {
                    throw new BusinessException("Tên vị trí chuyên môn không được để trống");
                }

                if (viTri.NgheId <= 0)
                {
                    throw new BusinessException("Vui lòng chọn nghề");
                }

                // Kiểm tra trùng tên trong cùng nghề (loại trừ ID hiện tại)
                if (_viTriChuyenMonRepository.CheckDuplicateViTriChuyenMon(viTri.NgheId, viTri.TenViTri, viTri.VtId))
                {
                    throw new BusinessException("Tên vị trí chuyên môn đã tồn tại trong nghề này");
                }

                return _viTriChuyenMonRepository.UpdateViTriChuyenMon(viTri);
            }
            catch (BusinessException)
            {
                throw; // Re-throw BusinessException
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Lỗi khi cập nhật vị trí chuyên môn: {ex.Message}", ex);
            }
        }

        public bool CheckDuplicateViTriChuyenMon(int ngheId, string tenViTri, int excludeId = 0)
        {
            try
            {
                return _viTriChuyenMonRepository.CheckDuplicateViTriChuyenMon(ngheId, tenViTri, excludeId);
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Lỗi khi kiểm tra trùng lặp vị trí chuyên môn: {ex.Message}", ex);
            }
        }
    }
}

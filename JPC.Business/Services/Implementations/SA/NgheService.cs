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
    public class NgheService : INgheService
    {
        private readonly INgheRepository _ngheRepository;
        private readonly INhomNgheRepository _nhomNgheRepository;

        public NgheService()
        {
            _ngheRepository = new NgheRepository();
            _nhomNgheRepository = new NhomNgheRepository();
        }

        public DataTable GetAllNghe()
        {
            try
            {
                return _ngheRepository.GetAllNghe();
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Lỗi khi lấy danh sách nghề: {ex.Message}", ex);
            }
        }

        public DataTable GetAllNgheForDisplay()
        {
            try
            {
                return _ngheRepository.GetAllNgheForDisplay();
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Lỗi khi lấy danh sách nghề cho display: {ex.Message}", ex);
            }
        }

        public DataTable GetActiveNgheByNhomId(int nhomId)
        {
            try
            {
                return _ngheRepository.GetActiveNgheByNhomId(nhomId);
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Lỗi khi lấy danh sách nghề active theo nhóm: {ex.Message}", ex);
            }
        }

        public DataTable SearchNghe(string keyword)
        {
            try
            {
                return _ngheRepository.SearchNghe(keyword);
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Lỗi khi tìm kiếm nghề: {ex.Message}", ex);
            }
        }

        public Nghe GetNgheById(int id)
        {
            try
            {
                return _ngheRepository.GetNgheById(id);
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Lỗi khi lấy thông tin nghề: {ex.Message}", ex);
            }
        }

        public bool InsertNghe(Nghe nghe)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(nghe.TenNghe))
                {
                    throw new BusinessException("Tên nghề không được để trống");
                }

                if (nghe.NhomId <= 0)
                {
                    throw new BusinessException("Vui lòng chọn nhóm nghề");
                }

                // Kiểm tra trùng tên trong cùng nhóm
                if (_ngheRepository.CheckDuplicateNghe(nghe.NhomId, nghe.TenNghe))
                {
                    throw new BusinessException("Tên nghề đã tồn tại trong nhóm nghề này");
                }

                return _ngheRepository.InsertNghe(nghe);
            }
            catch (BusinessException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Lỗi khi thêm nghề: {ex.Message}", ex);
            }
        }

        public bool UpdateNghe(Nghe nghe)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(nghe.TenNghe))
                {
                    throw new BusinessException("Tên nghề không được để trống");
                }

                if (nghe.NhomId <= 0)
                {
                    throw new BusinessException("Vui lòng chọn nhóm nghề");
                }

                // Kiểm tra trùng tên trong cùng nhóm (loại trừ ID hiện tại)
                if (_ngheRepository.CheckDuplicateNghe(nghe.NhomId, nghe.TenNghe, nghe.NgheId))
                {
                    throw new BusinessException("Tên nghề đã tồn tại trong nhóm nghề này");
                }

                // Kiểm tra nếu set thành Inactive mà có vị trí chuyên môn con
                if (nghe.TrangThai.ToLower() == "inactive")
                {
                    int countViTri = _ngheRepository.CountActiveViTriInNghe(nghe.NgheId);
                    if (countViTri > 0)
                    {
                        throw new BusinessException($"Không thể vô hiệu hóa nghề này vì còn có {countViTri} vị trí chuyên môn đang sử dụng");
                    }
                }

                return _ngheRepository.UpdateNghe(nghe);
            }
            catch (BusinessException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Lỗi khi cập nhật nghề: {ex.Message}", ex);
            }
        }
    }
}

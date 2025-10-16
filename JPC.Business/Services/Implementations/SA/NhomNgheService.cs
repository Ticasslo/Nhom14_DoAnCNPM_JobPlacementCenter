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
    public class NhomNgheService : INhomNgheService
    {
        private readonly INhomNgheRepository _nhomNgheRepository;

        public NhomNgheService()
        {
            _nhomNgheRepository = new NhomNgheRepository();
        }

        public DataTable GetAllNhomNghe()
        {
            try
            {
                return _nhomNgheRepository.GetAllNhomNghe();
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Lỗi khi lấy danh sách nhóm nghề: {ex.Message}", ex);
            }
        }

        public DataTable SearchNhomNghe(string keyword)
        {
            try
            {
                return _nhomNgheRepository.SearchNhomNghe(keyword);
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Lỗi khi tìm kiếm nhóm nghề: {ex.Message}", ex);
            }
        }

        public NhomNghe GetNhomNgheById(int id)
        {
            try
            {
                return _nhomNgheRepository.GetNhomNgheById(id);
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Lỗi khi lấy thông tin nhóm nghề: {ex.Message}", ex);
            }
        }

        public bool InsertNhomNghe(NhomNghe nhomNghe)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(nhomNghe.TenNhom))
                {
                    throw new BusinessException("Tên nhóm nghề không được để trống");
                }

                return _nhomNgheRepository.InsertNhomNghe(nhomNghe);
            }
            catch (BusinessException)
            {
                throw; // Re-throw BusinessException
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Lỗi khi thêm nhóm nghề: {ex.Message}", ex);
            }
        }

        public bool UpdateNhomNghe(NhomNghe nhomNghe)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(nhomNghe.TenNhom))
                {
                    throw new BusinessException("Tên nhóm nghề không được để trống");
                }

                return _nhomNgheRepository.UpdateNhomNghe(nhomNghe);
            }
            catch (BusinessException)
            {
                throw; // Re-throw BusinessException
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Lỗi khi cập nhật nhóm nghề: {ex.Message}", ex);
            }
        }

        public bool DeleteNhomNghe(int id)
        {
            try
            {
                return _nhomNgheRepository.DeleteNhomNghe(id);
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Lỗi khi xóa nhóm nghề: {ex.Message}", ex);
            }
        }
    }
}

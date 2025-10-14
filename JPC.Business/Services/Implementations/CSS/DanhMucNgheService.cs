using JPC.Business.Services.Interfaces.CSS;
using JPC.DataAccess.Repositories.Implementations.CSS;
using JPC.DataAccess.Repositories.Interfaces.CSS;
using JPC.Models.DanhMucNghe;
using System;
using System.Collections.Generic;

namespace JPC.Business.Services.Implementations.CSS
{
	public class DanhMucNgheService : IDanhMucNgheService
	{
		private readonly IDanhMucNgheRepository repository;

		public DanhMucNgheService()
		{
			this.repository = new DanhMucNgheRepository();
		}

		public IEnumerable<NhomNghe> GetAllNhomNghe()
		{
			return repository.GetAllNhomNghe();
		}

		public IEnumerable<Nghe> GetNgheByNhom(int nhomId)
		{
			if (nhomId <= 0)
				throw new ArgumentException("Mã nhóm nghề không hợp lệ.", nameof(nhomId));

			return repository.GetNgheByNhom(nhomId);
		}

		public IEnumerable<ViTriChuyenMon> GetViTriByNghe(int ngheId)
		{
			if (ngheId <= 0)
				throw new ArgumentException("Mã nghề không hợp lệ.", nameof(ngheId));

			return repository.GetViTriByNghe(ngheId);
		}

		public Nghe GetNgheById(int ngheId)
		{
			if (ngheId <= 0)
				throw new ArgumentException("Mã nghề không hợp lệ.", nameof(ngheId));

			return repository.GetNgheById(ngheId);
		}

		public ViTriChuyenMon GetViTriChuyenMonById(int vtId)
		{
			if (vtId <= 0)
				throw new ArgumentException("Mã vị trí chuyên môn không hợp lệ.", nameof(vtId));

			return repository.GetViTriChuyenMonById(vtId);
		}
	}
}



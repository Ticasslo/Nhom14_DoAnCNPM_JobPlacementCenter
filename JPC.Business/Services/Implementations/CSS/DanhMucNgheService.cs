using JPC.Business.Services.Interfaces.CSS;
using JPC.DataAccess.Repositories.Implementations.CSS;
using JPC.DataAccess.Repositories.Interfaces.CSS;
using JPC.Models.DanhMucNghe;
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
			return repository.GetNgheByNhom(nhomId);
		}

		public IEnumerable<ViTriChuyenMon> GetViTriByNghe(int ngheId)
		{
			return repository.GetViTriByNghe(ngheId);
		}
	}
}



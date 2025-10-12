using JPC.Models.DanhMucNghe;
using System.Collections.Generic;

namespace JPC.Business.Services.Interfaces.CSS
{
	public interface IDanhMucNgheService
	{
		IEnumerable<NhomNghe> GetAllNhomNghe();
		IEnumerable<Nghe> GetNgheByNhom(int nhomId);
		IEnumerable<ViTriChuyenMon> GetViTriByNghe(int ngheId);
	}
}



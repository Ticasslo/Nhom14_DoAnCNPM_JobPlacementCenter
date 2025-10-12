using JPC.Models.DanhMucNghe;
using System.Collections.Generic;

namespace JPC.DataAccess.Repositories.Interfaces.CSS
{
	public interface IDanhMucNgheRepository
	{
		IEnumerable<NhomNghe> GetAllNhomNghe();
		IEnumerable<Nghe> GetNgheByNhom(int nhomId);
		IEnumerable<ViTriChuyenMon> GetViTriByNghe(int ngheId);
	}
}



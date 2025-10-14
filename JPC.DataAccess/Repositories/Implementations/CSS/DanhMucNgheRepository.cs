using JPC.DataAccess.DBConnection;
using JPC.DataAccess.Repositories.Interfaces.CSS;
using JPC.Models.DanhMucNghe;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace JPC.DataAccess.Repositories.Implementations.CSS
{
	public class DanhMucNgheRepository : DBConnection.DBConnection, IDanhMucNgheRepository
	{
		public IEnumerable<NhomNghe> GetAllNhomNghe()
		{
			var result = new List<NhomNghe>();
			var dt = ExecuteQuery("SELECT nhom_id, ten_nhom, trang_thai FROM NhomNghe WHERE trang_thai='active' ORDER BY ten_nhom");
			foreach (DataRow row in dt.Rows)
			{
				result.Add(new NhomNghe(
					Convert.ToInt32(row["nhom_id"]),
					Convert.ToString(row["ten_nhom"]),
					Convert.ToString(row["trang_thai"])));
			}
			return result;
		}

		public IEnumerable<Nghe> GetNgheByNhom(int nhomId)
		{
			var result = new List<Nghe>();
			var parameters = new List<SqlParameter>
			{
				new SqlParameter("@nhomId", SqlDbType.Int) { Value = nhomId }
			};
			var dt = ExecuteQuery(
				"SELECT nghe_id, nhom_id, ten_nghe, trang_thai FROM Nghe WHERE nhom_id=@nhomId AND trang_thai='active' ORDER BY ten_nghe",
				parameters
			);
			foreach (DataRow row in dt.Rows)
			{
				result.Add(new Nghe(
					Convert.ToInt32(row["nghe_id"]),
					Convert.ToInt32(row["nhom_id"]),
					Convert.ToString(row["ten_nghe"]),
					Convert.ToString(row["trang_thai"])));
			}
			return result;
		}

		public IEnumerable<ViTriChuyenMon> GetViTriByNghe(int ngheId)
		{
			var result = new List<ViTriChuyenMon>();
			var parameters = new List<SqlParameter>
			{
				new SqlParameter("@ngheId", SqlDbType.Int) { Value = ngheId }
			};
			var dt = ExecuteQuery(
				"SELECT vt_id, nghe_id, ten_vi_tri, trang_thai FROM ViTriChuyenMon WHERE nghe_id=@ngheId AND trang_thai='active' ORDER BY ten_vi_tri",
				parameters
			);
			foreach (DataRow row in dt.Rows)
			{
				result.Add(new ViTriChuyenMon(
					Convert.ToInt32(row["vt_id"]),
					Convert.ToInt32(row["nghe_id"]),
					Convert.ToString(row["ten_vi_tri"]),
					Convert.ToString(row["trang_thai"])));
			}
			return result;
		}

		public Nghe GetNgheById(int ngheId)
		{
			var parameters = new List<SqlParameter>
			{
				new SqlParameter("@ngheId", SqlDbType.Int) { Value = ngheId }
			};
			var dt = ExecuteQuery(
				"SELECT nghe_id, nhom_id, ten_nghe, trang_thai FROM Nghe WHERE nghe_id=@ngheId AND trang_thai='active'",
				parameters
			);
			
			if (dt.Rows.Count > 0)
			{
				var row = dt.Rows[0];
				return new Nghe(
					Convert.ToInt32(row["nghe_id"]),
					Convert.ToInt32(row["nhom_id"]),
					Convert.ToString(row["ten_nghe"]),
					Convert.ToString(row["trang_thai"]));
			}
			return null;
		}

		public ViTriChuyenMon GetViTriChuyenMonById(int vtId)
		{
			var parameters = new List<SqlParameter>
			{
				new SqlParameter("@vtId", SqlDbType.Int) { Value = vtId }
			};
			var dt = ExecuteQuery(
				"SELECT vt_id, nghe_id, ten_vi_tri, trang_thai FROM ViTriChuyenMon WHERE vt_id=@vtId AND trang_thai='active'",
				parameters
			);
			
			if (dt.Rows.Count > 0)
			{
				var row = dt.Rows[0];
				return new ViTriChuyenMon(
					Convert.ToInt32(row["vt_id"]),
					Convert.ToInt32(row["nghe_id"]),
					Convert.ToString(row["ten_vi_tri"]),
					Convert.ToString(row["trang_thai"]));
			}
			return null;
		}
	}
}



using JPC.DataAccess.DBConnection;
using JPC.DataAccess.Repositories.Interfaces.CSS;
using JPC.Models.DoanhNghiep;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace JPC.DataAccess.Repositories.Implementations.CSS
{
    public class TinTuyenDungRepository : DBConnection.DBConnection, ITinTuyenDungRepository
    {
        public IEnumerable<TinTuyenDung> GetTinTuyenDungActive()
        {
            var result = new List<TinTuyenDung>();
            string sql = @"SELECT tin_id, dn_id, tieu_de, mo_ta_cong_viec, so_luong_tuyen, muc_luong, 
                         khu_vuc_lam_viec, hinh_thuc_lam_viec, kinh_nghiem_yeu_cau, ngay_dang, 
                         han_nop_ho_so, trang_thai, phi_id, da_thanh_toan
                         FROM TinTuyenDung 
                         WHERE trang_thai = 'active' AND da_thanh_toan = 1 
                         AND han_nop_ho_so >= CAST(GETDATE() AS DATE)
                         ORDER BY ngay_dang DESC";

            var dt = ExecuteQuery(sql);
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new TinTuyenDung(
                    Convert.ToInt32(row["tin_id"]),
                    Convert.ToInt32(row["dn_id"]),
                    Convert.ToString(row["tieu_de"]),
                    Convert.ToString(row["mo_ta_cong_viec"]),
                    Convert.ToInt32(row["so_luong_tuyen"]),
                    Convert.ToString(row["muc_luong"]),
                    Convert.ToString(row["khu_vuc_lam_viec"]),
                    Convert.ToString(row["hinh_thuc_lam_viec"]),
                    Convert.ToInt32(row["kinh_nghiem_yeu_cau"]),
                    Convert.ToDateTime(row["ngay_dang"]),
                    Convert.ToDateTime(row["han_nop_ho_so"]),
                    Convert.ToString(row["trang_thai"]),
                    Convert.ToInt32(row["phi_id"]),
                    Convert.ToBoolean(row["da_thanh_toan"])
                ));
            }
            return result;
        }

        public IEnumerable<TinTuyenDung> GetTinTuyenDungByViTri(int vtId)
        {
            var result = new List<TinTuyenDung>();
            string sql = @"SELECT DISTINCT t.tin_id, t.dn_id, t.tieu_de, t.mo_ta_cong_viec, t.so_luong_tuyen, 
                         t.muc_luong, t.khu_vuc_lam_viec, t.hinh_thuc_lam_viec, t.kinh_nghiem_yeu_cau, 
                         t.ngay_dang, t.han_nop_ho_so, t.trang_thai, t.phi_id, t.da_thanh_toan
                         FROM TinTuyenDung t
                         INNER JOIN TinTuyenDung_ViTri tv ON t.tin_id = tv.tin_id
                         WHERE t.trang_thai = 'active' AND t.da_thanh_toan = 1 
                         AND t.han_nop_ho_so >= CAST(GETDATE() AS DATE)
                         AND tv.vt_id = @vtId
                         ORDER BY t.ngay_dang DESC";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@vtId", SqlDbType.Int) { Value = vtId }
            };

            var dt = ExecuteQuery(sql, parameters);
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new TinTuyenDung(
                    Convert.ToInt32(row["tin_id"]),
                    Convert.ToInt32(row["dn_id"]),
                    Convert.ToString(row["tieu_de"]),
                    Convert.ToString(row["mo_ta_cong_viec"]),
                    Convert.ToInt32(row["so_luong_tuyen"]),
                    Convert.ToString(row["muc_luong"]),
                    Convert.ToString(row["khu_vuc_lam_viec"]),
                    Convert.ToString(row["hinh_thuc_lam_viec"]),
                    Convert.ToInt32(row["kinh_nghiem_yeu_cau"]),
                    Convert.ToDateTime(row["ngay_dang"]),
                    Convert.ToDateTime(row["han_nop_ho_so"]),
                    Convert.ToString(row["trang_thai"]),
                    Convert.ToInt32(row["phi_id"]),
                    Convert.ToBoolean(row["da_thanh_toan"])
                ));
            }
            return result;
        }

        public IEnumerable<TinTuyenDung> GetTinTuyenDungByNghe(int ngheId)
        {
            var result = new List<TinTuyenDung>();
            string sql = @"SELECT DISTINCT t.tin_id, t.dn_id, t.tieu_de, t.mo_ta_cong_viec, t.so_luong_tuyen, 
                         t.muc_luong, t.khu_vuc_lam_viec, t.hinh_thuc_lam_viec, t.kinh_nghiem_yeu_cau, 
                         t.ngay_dang, t.han_nop_ho_so, t.trang_thai, t.phi_id, t.da_thanh_toan
                         FROM TinTuyenDung t
                         INNER JOIN TinTuyenDung_ViTri tv ON t.tin_id = tv.tin_id
                         INNER JOIN ViTriChuyenMon v ON tv.vt_id = v.vt_id
                         WHERE t.trang_thai = 'active' AND t.da_thanh_toan = 1 
                         AND t.han_nop_ho_so >= CAST(GETDATE() AS DATE)
                         AND v.nghe_id = @ngheId
                         ORDER BY t.ngay_dang DESC";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@ngheId", SqlDbType.Int) { Value = ngheId }
            };

            var dt = ExecuteQuery(sql, parameters);
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new TinTuyenDung(
                    Convert.ToInt32(row["tin_id"]),
                    Convert.ToInt32(row["dn_id"]),
                    Convert.ToString(row["tieu_de"]),
                    Convert.ToString(row["mo_ta_cong_viec"]),
                    Convert.ToInt32(row["so_luong_tuyen"]),
                    Convert.ToString(row["muc_luong"]),
                    Convert.ToString(row["khu_vuc_lam_viec"]),
                    Convert.ToString(row["hinh_thuc_lam_viec"]),
                    Convert.ToInt32(row["kinh_nghiem_yeu_cau"]),
                    Convert.ToDateTime(row["ngay_dang"]),
                    Convert.ToDateTime(row["han_nop_ho_so"]),
                    Convert.ToString(row["trang_thai"]),
                    Convert.ToInt32(row["phi_id"]),
                    Convert.ToBoolean(row["da_thanh_toan"])
                ));
            }
            return result;
        }

        public IEnumerable<TinTuyenDung> GetTinTuyenDungByNhomNghe(int nhomId)
        {
            var result = new List<TinTuyenDung>();
            string sql = @"SELECT DISTINCT t.tin_id, t.dn_id, t.tieu_de, t.mo_ta_cong_viec, t.so_luong_tuyen, 
                         t.muc_luong, t.khu_vuc_lam_viec, t.hinh_thuc_lam_viec, t.kinh_nghiem_yeu_cau, 
                         t.ngay_dang, t.han_nop_ho_so, t.trang_thai, t.phi_id, t.da_thanh_toan
                         FROM TinTuyenDung t
                         INNER JOIN TinTuyenDung_ViTri tv ON t.tin_id = tv.tin_id
                         INNER JOIN ViTriChuyenMon v ON tv.vt_id = v.vt_id
                         INNER JOIN Nghe n ON v.nghe_id = n.nghe_id
                         WHERE t.trang_thai = 'active' AND t.da_thanh_toan = 1 
                         AND t.han_nop_ho_so >= CAST(GETDATE() AS DATE)
                         AND n.nhom_id = @nhomId
                         ORDER BY t.ngay_dang DESC";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@nhomId", SqlDbType.Int) { Value = nhomId }
            };

            var dt = ExecuteQuery(sql, parameters);
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new TinTuyenDung(
                    Convert.ToInt32(row["tin_id"]),
                    Convert.ToInt32(row["dn_id"]),
                    Convert.ToString(row["tieu_de"]),
                    Convert.ToString(row["mo_ta_cong_viec"]),
                    Convert.ToInt32(row["so_luong_tuyen"]),
                    Convert.ToString(row["muc_luong"]),
                    Convert.ToString(row["khu_vuc_lam_viec"]),
                    Convert.ToString(row["hinh_thuc_lam_viec"]),
                    Convert.ToInt32(row["kinh_nghiem_yeu_cau"]),
                    Convert.ToDateTime(row["ngay_dang"]),
                    Convert.ToDateTime(row["han_nop_ho_so"]),
                    Convert.ToString(row["trang_thai"]),
                    Convert.ToInt32(row["phi_id"]),
                    Convert.ToBoolean(row["da_thanh_toan"])
                ));
            }
            return result;
        }

        public IEnumerable<TinTuyenDung> GetTinTuyenDungChuaUngTuyen(int uvId)
        {
            var result = new List<TinTuyenDung>();
            string sql = @"SELECT t.tin_id, t.dn_id, t.tieu_de, t.mo_ta_cong_viec, t.so_luong_tuyen, 
                         t.muc_luong, t.khu_vuc_lam_viec, t.hinh_thuc_lam_viec, t.kinh_nghiem_yeu_cau, 
                         t.ngay_dang, t.han_nop_ho_so, t.trang_thai, t.phi_id, t.da_thanh_toan
                         FROM TinTuyenDung t
                         WHERE t.trang_thai = 'active' AND t.da_thanh_toan = 1 
                         AND t.han_nop_ho_so >= CAST(GETDATE() AS DATE)
                         AND t.tin_id NOT IN (
                             SELECT tin_id FROM UngTuyen WHERE uv_id = @uvId
                         )
                         ORDER BY t.ngay_dang DESC";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@uvId", SqlDbType.Int) { Value = uvId }
            };

            var dt = ExecuteQuery(sql, parameters);
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new TinTuyenDung(
                    Convert.ToInt32(row["tin_id"]),
                    Convert.ToInt32(row["dn_id"]),
                    Convert.ToString(row["tieu_de"]),
                    Convert.ToString(row["mo_ta_cong_viec"]),
                    Convert.ToInt32(row["so_luong_tuyen"]),
                    Convert.ToString(row["muc_luong"]),
                    Convert.ToString(row["khu_vuc_lam_viec"]),
                    Convert.ToString(row["hinh_thuc_lam_viec"]),
                    Convert.ToInt32(row["kinh_nghiem_yeu_cau"]),
                    Convert.ToDateTime(row["ngay_dang"]),
                    Convert.ToDateTime(row["han_nop_ho_so"]),
                    Convert.ToString(row["trang_thai"]),
                    Convert.ToInt32(row["phi_id"]),
                    Convert.ToBoolean(row["da_thanh_toan"])
                ));
            }
            return result;
        }

        public TinTuyenDung GetTinTuyenDungById(int tinId)
        {
            string sql = @"SELECT tin_id, dn_id, tieu_de, mo_ta_cong_viec, so_luong_tuyen, muc_luong, 
                         khu_vuc_lam_viec, hinh_thuc_lam_viec, kinh_nghiem_yeu_cau, ngay_dang, 
                         han_nop_ho_so, trang_thai, phi_id, da_thanh_toan
                         FROM TinTuyenDung WHERE tin_id = @tinId";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@tinId", SqlDbType.Int) { Value = tinId }
            };

            var dt = ExecuteQuery(sql, parameters);
            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                return new TinTuyenDung(
                    Convert.ToInt32(row["tin_id"]),
                    Convert.ToInt32(row["dn_id"]),
                    Convert.ToString(row["tieu_de"]),
                    Convert.ToString(row["mo_ta_cong_viec"]),
                    Convert.ToInt32(row["so_luong_tuyen"]),
                    Convert.ToString(row["muc_luong"]),
                    Convert.ToString(row["khu_vuc_lam_viec"]),
                    Convert.ToString(row["hinh_thuc_lam_viec"]),
                    Convert.ToInt32(row["kinh_nghiem_yeu_cau"]),
                    Convert.ToDateTime(row["ngay_dang"]),
                    Convert.ToDateTime(row["han_nop_ho_so"]),
                    Convert.ToString(row["trang_thai"]),
                    Convert.ToInt32(row["phi_id"]),
                    Convert.ToBoolean(row["da_thanh_toan"])
                );
            }
            return null;
        }

        public IEnumerable<string> GetKyNangByTinAndViTri(int tinId, int vtId)
        {
            var result = new List<string>();
            string sql = @"SELECT ten_ky_nang FROM TinTuyenDung_KyNang 
                         WHERE tin_id = @tinId AND vt_id = @vtId";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@tinId", SqlDbType.Int) { Value = tinId },
                new SqlParameter("@vtId", SqlDbType.Int) { Value = vtId }
            };

            var dt = ExecuteQuery(sql, parameters);
            foreach (DataRow row in dt.Rows)
            {
                result.Add(Convert.ToString(row["ten_ky_nang"]));
            }
            return result;
        }

        public IEnumerable<int> GetViTriByTin(int tinId)
        {
            var result = new List<int>();
            string sql = @"SELECT vt_id FROM TinTuyenDung_ViTri WHERE tin_id = @tinId";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@tinId", SqlDbType.Int) { Value = tinId }
            };

            var dt = ExecuteQuery(sql, parameters);
            foreach (DataRow row in dt.Rows)
            {
                result.Add(Convert.ToInt32(row["vt_id"]));
            }
            return result;
        }
    }
}
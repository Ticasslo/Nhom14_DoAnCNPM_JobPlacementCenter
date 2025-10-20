using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using JPC.DataAccess.Exceptions;

namespace JPC.DataAccess.DBConnection
{
    public class DBConnection
    {
        protected readonly SqlConnection sqlConn;

        public DBConnection()
        {
            string strCnn = ConfigurationManager.ConnectionStrings["JobPlacementCenter"]?.ConnectionString
                ?? throw new InvalidOperationException("Missing connection string in App.config");
            this.sqlConn = new SqlConnection(strCnn);


            //string strCnn = @"Data Source=tcp:THANHNHAN\MSSQLSERVER01;
            //  Initial Catalog=JobPlacementCenter;
            //  User ID=sa;Password=123456;
            //  Encrypt=False;TrustServerCertificate=True;
            //  MultipleActiveResultSets=True";
            //this.sqlConn = new SqlConnection(strCnn);


            //string strCnn = @"Data Source=tcp:LAPTOP-DEJAVU;Initial Catalog=JobPlacementCenter;
            //                    Integrated Security = True; Encrypt=False;
            //                    TrustServerCertificate=True; MultipleActiveResultSets=True";
            //this.sqlConn = new SqlConnection(strCnn);

            //string strCnn = @"Data Source=LAPTOP-TNT38BSB\KHAHP;Initial Catalog=JobPlacementCenter;
            //                    Integrated Security = True; Encrypt=False;
            //                    TrustServerCertificate=True; MultipleActiveResultSets=True";
            //this.sqlConn = new SqlConnection(strCnn);


        }

        // SELECT → DataTable
        public DataTable ExecuteQuery(string sqlStr, List<SqlParameter> parameters = null)
        {
            try
            {
                var dt = new DataTable();
                using (var da = new SqlDataAdapter(sqlStr, this.sqlConn))
                {
                    da.SelectCommand.CommandType = CommandType.Text;
                    if (parameters != null && parameters.Count > 0)
                        da.SelectCommand.Parameters.AddRange(parameters.ToArray());

                    // SqlDataAdapter sẽ tự mở/đóng kết nối nếu cần
                    da.Fill(dt);
                }
                return dt;
            }
            catch (SqlException ex)
            {
                throw new DataAccessException("Lỗi khi truy vấn dữ liệu.", ex);
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Lỗi không xác định khi truy vấn dữ liệu.", ex);
            }
        }

        // INSERT/UPDATE/DELETE → số dòng ảnh hưởng
        public int ExecuteNonQuery(string sqlStr, List<SqlParameter> parameters = null)
        {
            try
            {
                using (var cmd = new SqlCommand(sqlStr, this.sqlConn))
                {
                    cmd.CommandType = CommandType.Text;
                    if (parameters != null && parameters.Count > 0)
                        cmd.Parameters.AddRange(parameters.ToArray());

                    this.sqlConn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new DataAccessException("Lỗi khi cập nhật dữ liệu.", ex);
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Lỗi không xác định khi cập nhật dữ liệu.", ex);
            }
            finally
            {
                if (this.sqlConn.State == ConnectionState.Open)
                    this.sqlConn.Close();
            }
        }

        // Giá trị đơn (COUNT, SUM, SCOPE_IDENTITY, …)
        public object ExecuteScalar(string sqlStr, List<SqlParameter> parameters = null)
        {
            try
            {
                using (var cmd = new SqlCommand(sqlStr, this.sqlConn))
                {
                    cmd.CommandType = CommandType.Text;
                    if (parameters != null && parameters.Count > 0)
                        cmd.Parameters.AddRange(parameters.ToArray());

                    this.sqlConn.Open();
                    return cmd.ExecuteScalar();
                }
            }
            catch (SqlException ex)
            {
                throw new DataAccessException("Lỗi khi lấy giá trị đơn.", ex);
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Lỗi không xác định khi lấy giá trị đơn.", ex);
            }
            finally
            {
                if (this.sqlConn.State == ConnectionState.Open)
                    this.sqlConn.Close();
            }
        }

        public DBConnection(string connectionString)
        {
            sqlConn = new SqlConnection(connectionString);
        }
    }
}

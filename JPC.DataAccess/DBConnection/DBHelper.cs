using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.DataAccess.DBConnection
{
    public class DBHelper
    {
        private static readonly string connectionString = GetConnectionString();

        private static string GetConnectionString()
        {
            var cs = ConfigurationManager.ConnectionStrings["JobPlacementCenter"];
            if (cs == null || string.IsNullOrWhiteSpace(cs.ConnectionString))
                throw new InvalidOperationException("Không tìm thấy connectionStrings['JobPlacementCenter'] trong App.config của startup project.");
            return cs.ConnectionString;
        }

        // SP trả DataTable (dùng với sp có SELECT), có thể kèm OUTPUT và RETURN VALUE
        public static (DataTable Data, int ReturnValue) ExecuteStoredProcedureWithOutput(
            string procedureName,
            SqlParameter[] parameters = null)
        {
            var dt = new DataTable();

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(procedureName, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                if (parameters != null && parameters.Length > 0)
                    command.Parameters.AddRange(parameters);             // gồm cả @out param nếu có

                // Thêm tham số RETURN VALUE (nếu muốn lấy)
                var ret = new SqlParameter("@RETURN_VALUE", SqlDbType.Int)
                {
                    Direction = ParameterDirection.ReturnValue
                };
                command.Parameters.Add(ret);

                using (var adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dt);  // sau Fill, OUTPUT & RETURN VALUE sẽ có Value
                }

                int returnValue = (command.Parameters["@RETURN_VALUE"].Value == DBNull.Value)
                    ? 0
                    : Convert.ToInt32(command.Parameters["@RETURN_VALUE"].Value);

                return (dt, returnValue);
            }
        }


        // SP trả NonQuery (không trả bảng - dùng với sp ko có SELECT), có thể kèm OUTPUT và RETURN VALUE
        public static (int Rows, int ReturnValue) ExecuteStoredProcedureNonQuery(
            string procedureName,
            SqlParameter[] parameters = null)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(procedureName, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                if (parameters != null && parameters.Length > 0)
                    command.Parameters.AddRange(parameters);

                var ret = new SqlParameter("@RETURN_VALUE", SqlDbType.Int)
                {
                    Direction = ParameterDirection.ReturnValue
                };
                command.Parameters.Add(ret);

                connection.Open();
                int rows = command.ExecuteNonQuery();

                int returnValue = (command.Parameters["@RETURN_VALUE"].Value == DBNull.Value)
                    ? 0
                    : Convert.ToInt32(command.Parameters["@RETURN_VALUE"].Value);

                return (rows, returnValue);
            }
        }


        // Thực hiện Function trả về giá trị đơn
        public static object ExecuteScalarFunction(string functionName, SqlParameter[] parameters = null)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT dbo.{functionName}(";

                if (parameters != null)
                {
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        sql += $"@param{i}";
                        if (i < parameters.Length - 1) sql += ",";
                    }
                }
                sql += ")";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    if (parameters != null)
                    {
                        for (int i = 0; i < parameters.Length; i++)
                        {
                            command.Parameters.Add($"@param{i}", parameters[i].SqlDbType).Value = parameters[i].Value;
                        }
                    }

                    connection.Open();
                    return command.ExecuteScalar();
                }
            }
        }

        // Thực hiện Table-Valued Function trả về table
        public static DataTable ExecuteTableFunction(string functionName, SqlParameter[] parameters = null)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM dbo.{functionName}(";

                if (parameters != null)
                {
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        sql += $"@param{i}";
                        if (i < parameters.Length - 1) sql += ",";
                    }
                }
                sql += ")";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    if (parameters != null)
                    {
                        for (int i = 0; i < parameters.Length; i++)
                        {
                            command.Parameters.Add($"@param{i}", parameters[i].SqlDbType).Value = parameters[i].Value;
                        }
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        public static DataTable ExecuteTableFunctionDirect(string sql, SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }
    }
}

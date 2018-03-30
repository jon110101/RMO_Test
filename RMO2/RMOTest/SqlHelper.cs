using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMO
{
    class SqlHelper
    {
        private static readonly string connStr =
            ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, null);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        throw e;
                    }
                }
            }
        }

        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {


                foreach (SqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }

        public static int ExecuteQuery(string cmdText, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = cmdText;
                cmd.Parameters.AddRange(parameters);
                int i = cmd.ExecuteNonQuery();
                conn.Close();
                return i;
            }
        }

        public static object ExecuteScalar(string cmdText, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = cmdText;
                cmd.Parameters.AddRange(parameters);
                object obj = cmd.ExecuteScalar(); 
                conn.Close();
                return obj;
            }
        }

        public static DataTable ExecuteDataTable(string cmdText, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = cmdText;
                cmd.Parameters.AddRange(parameters);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                conn.Close();
                return dt;
            }
        }

        public static DataTable ExecuteDataTable(string sqlStr)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                conn.Close();
                return dt;
            }
        }

        public static DataSet ExecuteDataSet(string sqlStr)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(sqlStr, conn);
                DataSet ds = new DataSet();               
                da.Fill(ds);
                conn.Close();
                return ds;
            }
        }

        public static bool ExecuteQueryTrans(string cmdtext, params SqlParameter[] parameters)
        {
            int i = 0;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand();
                cm.Connection = conn;
                conn.Open();
                System.Data.SqlClient.SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    cm.CommandText = cmdtext;
                    cm.Parameters.AddRange(parameters);
                    cm.Transaction = trans;
                    i = cm.ExecuteNonQuery();
                    trans.Commit();
                }
                catch
                {
                    trans.Rollback();
                }
                finally
                {
                    conn.Close();
                    trans.Dispose();
                    conn.Dispose();
                }
            }         
            return i > 0;
        }
        
        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="tableName">DataSet结果中的表名</param>
        /// <returns>DataSet</returns>
        public static Dictionary<string, object> RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName)
        {
            Dictionary<string, object> _ht = new Dictionary<string, object>();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = storedProcName;
                    cmd.Connection = conn;

                    cmd.CommandType = CommandType.StoredProcedure;

                    foreach (SqlParameter parameter in parameters)
                    {
                        if (parameter != null)
                        {
                            // 检查未分配值的输出参数,将其分配以DBNull.Value.
                            if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                                (parameter.Value == null))
                            {
                                parameter.Value = DBNull.Value;
                            }
                            cmd.Parameters.Add(parameter);
                        }
                    }

                    conn.Open();
                   int i=cmd.ExecuteNonQuery();
                   if (cmd.Parameters.Contains("@Error_Msg"))
                      _ht["Error_Msg"] = cmd.Parameters["@Error_Msg"].Value.ToString();
                   if (cmd.Parameters.Contains("@Email_Warning_Info"))
                      _ht["Email_Warning_Info"] = cmd.Parameters["@Email_Warning_Info"].Value.ToString();
                   if (cmd.Parameters.Contains("@Bil_Id"))
                      _ht["Bil_Id"] = cmd.Parameters["@Bil_Id"].Value.ToString();
                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.Message, ex);
                }
                finally
                {
                    conn.Close();
                }
            }
            return _ht;
        }

      
    }
}

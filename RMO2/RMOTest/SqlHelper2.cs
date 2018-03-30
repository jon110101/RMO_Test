using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace RMO
{
    class SqlHelper
    {
        private static readonly string _connStr =
            ConfigurationManager.ConnectionStrings["connStr1"].ConnectionString;

        public static int ExecuteQuery(string cmdText, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = cmdText;
                cmd.Parameters.AddRange(parameters);
                int rst = cmd.ExecuteNonQuery();
                conn.Close();
                return rst;
            }
        }

        public static object ExecuteScalar(string cmdText, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = cmdText;
                cmd.Parameters.AddRange(parameters);
                conn.Close();
                return cmd.ExecuteScalar();
            }
        }

        public static DataTable ExecuteDataTable(string cmdText, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
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
            using (SqlConnection conn = new SqlConnection(_connStr))
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
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(sqlStr, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conn.Close();
                return ds;
            }
        }
    }
}

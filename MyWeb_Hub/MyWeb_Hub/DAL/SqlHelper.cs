using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyWeb_Hub.DAL
{
    public class SqlHelper
    {
        public static string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();
        private static SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn.ConnectionString = connString;//System.Configuration.ConfigurationSettings.AppSettings["ConnString"];
                conn.Open();
                conn.Close();
            }
            catch
            {
                throw new Exception("无法连接数据库");
            }
            return conn;
        }
        public static int GetNonQuery(string sqlstr)
        {
            SqlConnection conn = GetConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlstr, conn);
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public static DataSet GetDataSet(string sql)
        {
            SqlConnection conn = GetConnection();
            try
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                conn.Dispose();
                conn.Close();
            }
        }

        public static SqlDataReader GetDataReader(string sql)
        {
            SqlConnection conn = GetConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {

            }
        }
        public static int UserNumber(string sql)
        {
            SqlConnection conn = GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            conn.Dispose();
            conn.Close();
            return count;
        }
    }
}
using MyWeb_Hub.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyWeb_Hub.DAL
{
    public class UserDAL
    {
        public int RegisterUserDAL(UserModels zhuce)
        {
            if (GetOnly(zhuce.UserName))
            {
                string sql1 = "insert into [Chat].[dbo].[User] (name,pwd) values  ('{0}','{1}')";
                string sql = " insert into[Chat].[dbo].[GroupChat] ([roomName],[userName],[Time]) values('room1','"+ zhuce.UserName + "','"+DateTime.Now.ToString()+"')";
                sql1 = string.Format(sql1, zhuce.UserName, zhuce.PassWord);           
                int a = SqlHelper.GetNonQuery(sql1);
                if (a > 0)
                {
                     return 1;
                }
                else
                {
                     return 0;
                }
            }
            else
            {
                return 3;
            }
                   
        }
        /// <summary>
        /// 账号是否唯一
        /// </summary>
        /// <returns></returns>
        public bool GetOnly(string Name)
        {
            string sql= "SELECT *  FROM [Chat].[dbo].[User]   where name='"+Name+"'";
            int n = SqlHelper.UserNumber(sql);
            if (n > 0)
            {
                return false;
            }
            else
            {
                return true;                
            }           
        }
        public int GetLogin(UserModels zhuce)
        {
            string sql = "SELECT *  FROM [Chat].[dbo].[User]   where name='" + zhuce.UserName + "'and pwd='"+zhuce.PassWord+"'";
            int n = SqlHelper.UserNumber(sql);
            if (n > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int UpdataConnectionID(UserModels zhuce ,string connectionID)
        {
            string sql = "  update [Chat].[dbo].[User] set  connectionId= '"+connectionID+"' where  name='"+zhuce.UserName+"'";
            int n = SqlHelper.GetNonQuery(sql);
            if (n > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public string QueryConnId(string name)
        {
            string sql = "  select connectionId from [Chat].[dbo].[User] WHERE name = '"+name+"'";
            string connId = "";
            SqlDataReader dr = SqlHelper.GetDataReader(sql);
            if (dr.Read())
            {
                connId = dr[0].ToString();
            }
            return connId;
        }

        public string QueryUserNameDAL(string connectionId)
        {
            string sql = "  select name from [Chat].[dbo].[User] WHERE connectionId = '" + connectionId+ "'";
            string name = "";
            SqlDataReader dr = SqlHelper.GetDataReader(sql);
            if (dr.Read())
            {
                name = dr[0].ToString();
            }
            return name;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MyWeb_Hub.DAL
{
    public class FriendsListDAL
    {
        public int AddFriendsDAL(string UserName,string FriendsName)
        {
            if (GetOnly(UserName, FriendsName))
            {
                string sql = "insert into [Chat].[dbo].[FriendsList] ([UserName],[FriendsName],[State] ,[Time]) values  ('{0}','{1}','好友','{2}')";
                string sql1 = "insert into [Chat].[dbo].[FriendsList] ([UserName],[FriendsName],[State] ,[Time]) values  ('{0}','{1}','好友','{2}')";
                sql1 = string.Format(sql1, UserName, FriendsName, DateTime.Now.ToString());
                sql = string.Format(sql, FriendsName, UserName, DateTime.Now.ToString());
                int a = SqlHelper.GetNonQuery(sql1);
                int b = SqlHelper.GetNonQuery(sql);
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
        /// 是否已经是好友
        /// </summary>
        /// <returns></returns>
        public bool GetOnly(string Name,string FriendsName)
        {
            string sql = "SELECT *  FROM [Chat].[dbo].[FriendsList]  where [UserName]='" + Name + "' and [FriendsName] = '"+FriendsName+"'";
            DataSet ds= SqlHelper.GetDataSet(sql);
            DataTable dt = ds.Tables[0];
            int n = dt.Rows.Count;
            if (n > 0)
            {
                return false;
            } 
            else
            {
                return true;
            }
        }
    }
}
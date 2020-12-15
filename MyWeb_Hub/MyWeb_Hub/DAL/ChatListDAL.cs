using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace MyWeb_Hub.DAL
{
    public class ChatListDAL
    {
        public DataSet GetFriendsList(string name)
        {
            string sql = "SELECT *  FROM [Chat].[dbo].[FriendsList] where [UserName]='" + name+ "'";
            DataSet ds = SqlHelper.GetDataSet(sql);
            return ds;
        }
        public DataSet GetRoomList(string name)
        {
            string sql = "SELECT *  FROM [Chat].[dbo].[GroupChat] where userName='" + name + "' and roomName !='room1'";
            DataSet ds = SqlHelper.GetDataSet(sql);
            return ds;
        }
    }
}
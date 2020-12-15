using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MyWeb_Hub.DAL;

namespace MyWeb_Hub.BLL
{
    public class ChatListBLL
    {
        /// <summary>
        /// 获取好友列表
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string[] GetFriendsList(string name)
        {
            DataSet ds = new ChatListDAL().GetFriendsList(name);
            DataTable dt = ds.Tables[0];
            int len = dt.Rows.Count;
            string[] str = new string[len];
            for (int i = 0; i < len; i++)
            {
                str[i] = dt.Rows[i]["FriendsName"].ToString();
            }
            return str;
        }

        public string[] GetRoomList(string name)
        {
            DataSet ds = new ChatListDAL().GetRoomList(name);
            DataTable dt = ds.Tables[0];
            int len = dt.Rows.Count;
            string[] str = new string[len];
            for (int i = 0; i < len; i++)
            {
                str[i] = dt.Rows[i]["roomName"].ToString();
            }
            return str;
        }
    }
}
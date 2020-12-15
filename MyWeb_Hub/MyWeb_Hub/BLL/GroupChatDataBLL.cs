using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MyWeb_Hub.DAL;
using MyWeb_Hub.Models;

namespace MyWeb_Hub.BLL
{
    public class GroupChatDataBLL
    {
        /// <summary>
        /// 把聊天数据写入数据库
        /// </summary>
        /// <param name="chatDataModels"></param>
        /// <returns></returns>
        public int AddChatDataBLL(GroupChatDataModels groupChatDataModels)
        {
            int a = new GroupChatDataDAL().AddGroupChatDataDAL(groupChatDataModels);
            if (a > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public DataTable GetRoomDataBLL(string name)
        {
            DataSet ds = new ChatListDAL().GetRoomList(name);
            DataTable dt = ds.Tables[0];
            int len = dt.Rows.Count;
            
            return dt;
        }

    }
}
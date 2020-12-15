using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MyWeb_Hub.Models;

namespace MyWeb_Hub.DAL
{
    public class GroupChatDataDAL
    {
        public int AddGroupChatDataDAL(GroupChatDataModels groupChatDataModels)
        {
            string sql1 = "insert into [Chat].[dbo].[GroupChatData]([roomName],[sendName],[msg],[time]) values  ('{0}','{1}','{2}','{3}')";
            sql1 = string.Format(sql1,groupChatDataModels.roomName,groupChatDataModels.sendName,groupChatDataModels.msg,DateTime.Now.ToString());
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
        public DataSet GetRoomData(string name)
        {
            string sql = "  SELECT TOP 100 *  FROM [Chat].[dbo].[GroupChatData]    where roomName='"+name+"'  order by time desc";
            DataSet ds = SqlHelper.GetDataSet(sql);
            return ds;
        }
    }
}
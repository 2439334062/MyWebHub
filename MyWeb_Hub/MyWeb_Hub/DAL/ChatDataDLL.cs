using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MyWeb_Hub.Models;

namespace MyWeb_Hub.DAL
{
    public class ChatDataDLL
    {

        /// <summary>
        /// 将聊天数据写入数据库
        /// </summary>
        /// <param name="chatDataModels"></param>
        /// <returns></returns>
        public int AddChatDataDAL(ChatDataModels chatDataModels)
        {            
                string sql1 = "insert into [Chat].[dbo].[chatdata] (Sender,Receiver,Time,Msg) values  ('{0}','{1}','{2}','{3}')";
                sql1 = string.Format(sql1, chatDataModels.Sender, chatDataModels.Receiver,DateTime.Now.ToString(),chatDataModels.Msg);
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
        /// <summary>
        /// 查询最近的一百条数据   倒序的
        /// </summary>
        /// <returns></returns>
        public DataSet QueryChatDataDAL(string sender,string receiver)
        {
            string sql = "SELECT TOP 100 [id] ,[Sender] ,[Receiver] ,[Time] FROM [Chat].[dbo].[chatdata] where Sender='{1}',Receiver='{2}' order by id desc";
            sql = string.Format(sql,sender,receiver);
            DataSet ds = SqlHelper.GetDataSet(sql);
            return ds;
        }
    }
}
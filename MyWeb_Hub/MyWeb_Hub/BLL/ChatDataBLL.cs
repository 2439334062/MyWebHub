using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyWeb_Hub.DAL;
using MyWeb_Hub.Models;

namespace MyWeb_Hub.BLL
{
    public class ChatDataBLL
    {
        /// <summary>
        /// 把聊天数据写入数据库
        /// </summary>
        /// <param name="chatDataModels"></param>
        /// <returns></returns>
        public int AddChatDataBLL(ChatDataModels chatDataModels)
        {
            int a = new ChatDataDLL().AddChatDataDAL(chatDataModels);
            if (a > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

    }
}
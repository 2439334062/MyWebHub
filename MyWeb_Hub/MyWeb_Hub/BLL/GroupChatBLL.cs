using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyWeb_Hub.DAL;

namespace MyWeb_Hub.BLL
{
    public class GroupChatBLL
    {
        public int AddChatBLL(string roomName, string UserName)
        {
            int a = new GroupChatDAL().AddRoomDAL(roomName,UserName);
            return a;
        }
    }
}
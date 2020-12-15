using System;
using System.Collections.Generic;
using System.Linq;
using MyWeb_Hub.DAL;
using System.Web;

namespace MyWeb_Hub.BLL
{
    public class FriendsListBLL
    {
        public int AddFriendsBLL(string UserName, string FriendsName)
        {
            UserDAL userDAL = new UserDAL();
            if (userDAL.GetOnly(FriendsName))
            {
                int c = 4;
                return c;
            }
            int a = new FriendsListDAL().AddFriendsDAL(UserName,FriendsName);            
            return a;
        }
    }
}
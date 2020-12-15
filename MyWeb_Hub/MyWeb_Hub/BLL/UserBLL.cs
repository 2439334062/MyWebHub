using MyWeb_Hub.DAL;
using MyWeb_Hub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWeb_Hub.BLL
{
    public class UserBLL
    {
        public int RegiterUserBLL(UserModels RegiterUser)//用户注册
        {
            int judge = new UserDAL().RegisterUserDAL(RegiterUser);
            return judge;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="LoginUser"></param>
        /// <returns></returns>
        public int LoginUserBLL(UserModels LoginUser)
        {
            int judge = new UserDAL().GetLogin(LoginUser);
            return judge;
        }
        /// <summary>
        /// 用户登录成功后更新connectionId
        /// </summary>
        /// <param name="LoginUser"></param>
        /// <param name="connectionId"></param>
        /// <returns></returns>
        public int UpdataConnectionIdBLL(UserModels LoginUser,string connectionId)
        {
            int judge = new UserDAL().UpdataConnectionID(LoginUser,connectionId);
            return judge;
        }
        /// <summary>
        /// 获取目前登录的用户的connectionId
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string QueryConnIdBLL(string name)
        {
            string connId = new UserDAL().QueryConnId(name);
            return connId;
        }
        /// <summary>
        /// 通过connectionId获取用户名
        /// </summary>
        /// <param name="connectionId"></param>
        /// <returns></returns>
        public string QueryUserNameBLL(string connectionId)
        {
            string name = new UserDAL().QueryUserNameDAL(connectionId);
            return name;
        }
    }
}
using Microsoft.AspNet.SignalR;
using MyWeb_Hub.BLL;
using MyWeb_Hub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWeb_Hub.Controllers
{
    public class HubController : Controller
    {
        public ActionResult Login()
        {

            return View();
        }
        #region 01-代理模式页面
        /// <summary>
        /// 代理模式页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region 02-非代理模式页面
        /// <summary>
        /// 非代理模式页面
        /// </summary>
        /// <returns></returns>
        public ActionResult NoProxyIndex()
        {
            return View();
        }
        #endregion

        /// <summary>
        /// 有界面的
        /// </summary>
        /// <returns></returns>
        public ActionResult Home()
        {
            return View();
        }

        /****************************************************下面是第三方调用方法****************************************************************/


        #region 01-向所有人发送消息
        /// <summary>
        /// 向所有人发送消息
        /// </summary>
        /// <param name="myConnectionId">当前用户的登录标记</param>
        /// <param name="msg">发送的信息</param>
        public string MySendAll(string myConnectionId, string msg)
        {
            //Hub模式
            var hub = GlobalHost.ConnectionManager.GetHubContext<MySpecHub1>();
            hub.Clients.AllExcept(myConnectionId).receiveMsg($"用户【{myConnectionId}】发来消息：{msg}");
            return "ok";
        }
        #endregion
        #region 02-注册功能

        [HttpPost]
        public ActionResult RegisterUser(UserModels Register)
        {

            Register = new UserModels()
            {
                UserName = Request.Params["UserName"],
                PassWord = Request.Params["PassWord"],
            };
            UserBLL ret = new UserBLL();

            //switch (ret.RegiterUserBLL(Register))
            //{
            //    case '1':
            //        return Content("<script>alert('注册成功');</script>");
            //    case '0':
            //        return Content("<script>alert('注册失败');</script>");
            //    default:
            //        return Content("<script>alert('账号已存在');window.location.href='../Hub/Login';</script>");
            //}

            if (ret.RegiterUserBLL(Register) == 1)//判断是否插入成功
            {
                return Content("<script>alert('注册成功');window.location.href='../Hub/Home';</script>");
            }
            else if(ret.RegiterUserBLL(Register)==0)
            {

                return Content("<script>alert('注册失败');window.location.href='../Hub/Home';</script>");

            }
            else
            {
                return Content("<script>alert('账号已存在');window.location.href='../Hub/Home';</script>");
            }
        }
        #endregion

        #region  登录-01
        [HttpPost]
        public ActionResult LoginUser(UserModels LoginU)
        {
            LoginU = new UserModels()
            {
                UserName = Request.Params["UserName"],
                PassWord = Request.Params["PassWord"],
            };
            UserBLL ret = new UserBLL();
            if (ret.LoginUserBLL(LoginU) == 1)
            {
                return Content("<script>alert('登录成功11');</script>");
            }
            else
            {
                return Content("<script>alert('登录失败22');</script>");
            }
           
        }
        #endregion

        #region
        public string MyLogin(string myConnectionId, string UserName,string PassWord)
        {
            //Hub模式
            UserModels LoginU;
            LoginU = new UserModels()
            {
                UserName = UserName,
                PassWord = PassWord,
            };
            UserBLL ret = new UserBLL();
            if (ret.LoginUserBLL(LoginU) == 1)
            {
                //把ConnectionId存入数据库
                UserBLL connId = new UserBLL();
                connId.UpdataConnectionIdBLL(LoginU,myConnectionId);
                return "ok";
               
            }
            else
            {
                return "fail";
            }

          
            
            
        }
        #endregion
    }
}
using MyWeb_Hub.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Data;

namespace MyWeb_Hub.Models
{
    public class MySpecHub1 : Hub
    {


        #region 01-连接成功的时候调用
        /// <summary>
        /// 连接成功的时候调用
        /// </summary>
        /// <returns></returns>
        public override Task OnConnected()
        {
            //调用客户端的方法通知所有人包括自己
            Clients.All.LoginSuccessNotice($"用户【{this.Context.ConnectionId}】登录成功", this.Context.ConnectionId);
            //回传给客户端自己的CId
            Clients.Client(this.Context.ConnectionId).ReceiveOwnCid(this.Context.ConnectionId);
            return base.OnConnected();
        }
        #endregion

        #region 02-连接断开的时候调用
        /// <summary>
        /// 连接断开的时候调用
        /// </summary>
        /// <param name="stopCalled"></param>
        /// <returns></returns>
        public override Task OnDisconnected(bool stopCalled)
        {
            //除去自己以外的消息
            Clients.AllExcept(this.Context.ConnectionId).receiveMsg($"用户【{this.Context.ConnectionId}】已经离开");
            return base.OnDisconnected(stopCalled);
        }
        #endregion

        #region 03-重新连接的时候调用
        /// <summary>
        /// 重新连接的时候调用
        /// </summary>
        /// <returns></returns>
        public override Task OnReconnected()
        {
            return base.OnReconnected();
        }
        #endregion

        /**************************************下面是自定义的服务器端方法*************************************************/

        #region 01-点对点发送消息
        /// <summary>
        /// 点对点发送消息
        /// </summary>
        /// <param name="receiveId"></param>
        /// <param name="msg"></param>
        public void SendSingleMsg(string receiveId, string msg)
        {
            Clients.Client(receiveId).receiveMsg($"用户【{this.Context.ConnectionId}】发来消息：{msg}");
        }
        /// <summary>
        /// 点对点发送消息，获取数据库里面的connectionId来发送消息
        /// 并把消息写入数据库
        /// </summary>
        /// <param name="connid"></param>
        /// <param name="msg"></param>
        public void SendConnIdMsg(string name,string msg)
        {
            UserBLL ret = new UserBLL();
            string connid = ret.QueryConnIdBLL(name);
            string Sender = this.Context.ConnectionId;
            string SenderName = new UserBLL().QueryUserNameBLL(Sender);
            ChatDataModels chatDataModels;
            chatDataModels = new ChatDataModels()
            {
                Sender = SenderName,
                Receiver = name,
                Msg = msg
            };
        
            int a = new ChatDataBLL().AddChatDataBLL(chatDataModels);
            Clients.Client(connid).receiveMsg($"{name} 账号【{this.Context.ConnectionId}】发来消息：{msg}");
        }
        /// <summary>
        /// 点对点发送消息，获取数据库里面的connectionId来发送消息 
        ///
        /// </summary>
        /// <param name="name"></param>
        /// <param name="msg"></param>
        //public void SendConnIdDataMsg(string name, string msg)
        //{
        //    UserBLL ret = new UserBLL();
        //    string connid = ret.QueryConnIdBLL(name);
        //    Clients.Client(connid).receiveMsg($"{name} 账号【{this.Context.ConnectionId}】发来消息：{msg}----");
        //}
        #endregion

        #region 02-群发消息
        /// <summary>
        /// 群发消息
        /// </summary>
        /// <param name="msg"></param>
        [HubMethodName(nameof(SendAllMsg))]
        public void SendAllMsg(string msg)
        {
            
            //除去自己以外的消息（不需要自己存储ConnectionId）
            Clients.AllExcept(this.Context.ConnectionId).receiveMsg($"用户【{this.Context.ConnectionId}】发来消息：{msg}");
        }
        #endregion

        #region 03-进入指定组
        /// <summary>
        /// 进入指定组
        /// </summary>
        /// <param name="roomName">组的名称</param>
        [HubMethodName(nameof(EnterRoom))]
        public void EnterRoom(string roomName)
        {
            //进入组
            Groups.Add(this.Context.ConnectionId, roomName);
            //告诉自己进入成功
            string SenderId = this.Context.ConnectionId;
            string sendName = new UserBLL().QueryUserNameBLL(SenderId);
            
            Clients.Client(this.Context.ConnectionId).receiveMsg($"用户【{sendName}】成功进入房间：【{roomName}】");
        }
        #endregion

        #region 04-向指定组发送消息
        /// <summary>
        /// 向指定组发送消息
        /// </summary>
        /// <param name="roomName">组名</param>
        /// <param name="msg">内容</param>
        //[HubMethodName(nameof(SendRoomNameMsg))]
        //public void SendRoomNameMsg(string roomName, string msg)
        //{
        //    //向指定组发送消息，如果这个组包含自己，将自己除外
        //    Clients.Group(roomName, this.Context.ConnectionId).receiveMsg($"用户【{this.Context.ConnectionId}】发来消息：{msg}");
        //}
        /// <summary>
        /// 向指定组发送消息并写入数据库
        /// </summary>
        /// <param name="roomName">组名</param>
        /// <param name="msg">内容</param>
        [HubMethodName(nameof(SendRoomNameMsg))]
        public void SendRoomNameMsg(string roomName, string msg)
        {
            string SenderId = this.Context.ConnectionId;
            string sendName = new UserBLL().QueryUserNameBLL(SenderId);
            GroupChatDataModels groupChatDataModels;
            groupChatDataModels = new GroupChatDataModels()
            {
                roomName = roomName,
                sendName = sendName,
                msg= msg
            };
            int a = new GroupChatDataBLL().AddChatDataBLL(groupChatDataModels);
            //向指定组发送消息，如果这个组包含自己，将自己除外
            Clients.Group(roomName, this.Context.ConnectionId).receiveMsg($"用户【{this.Context.ConnectionId}】发来消息：{msg}");
        }


        #endregion



        #region 发起添加好友申请
        public void AddFriends(string friendsName)
        {
            string userName = new UserBLL().QueryUserNameBLL(this.Context.ConnectionId);
            int a = new FriendsListBLL().AddFriendsBLL(userName, friendsName);
            if (a == 1)
            {
                Clients.Client(this.Context.ConnectionId).aaa("ok");
            }
            else if(a==3)
            {
                Clients.Client(this.Context.ConnectionId).bbb("已经是好友");
            }
            else if(a==4)
            {
                Clients.Client(this.Context.ConnectionId).bbb("用户未注册");
            }
            else
            {
                Clients.Client(this.Context.ConnectionId).aaa("on");

            }
        }
        #endregion

        #region 创建或加入群聊
        public void AddGroupChat(string roomName)
        {
            string userName = new UserBLL().QueryUserNameBLL(this.Context.ConnectionId);
            int a = new GroupChatBLL().AddChatBLL(roomName, userName);
            if (a > 0)
            {

            }
        }
        #endregion

        #region 获取好友和群聊
        public void GetChatList(string name)
        {
            string[] str = new ChatListBLL().GetFriendsList(name);
            string connid = this.Context.ConnectionId;
            string[] str1 = new ChatListBLL().GetRoomList(name);
            for (int i = 0; i < str1.Length; i++)
            {
                Clients.Client(connid).receiveRoomList($"{str1[i]}");//输出群聊
               // Clients.Client(connid).dataMsg($"{str1[i]}");//输出群聊
               // DataTable dt = new GroupChatDataBLL().GetRoomDataBLL("room1");
               // int len = dt.Rows.Count;
               // string[] strMsg = new string[len];
               //// Groups.Add(this.Context.ConnectionId, "room1");
               // for (int j = len - 1; j > 0; j--)
               // {
               //     strMsg[j] = dt.Rows[j]["msg"].ToString();
               //     //Clients.Client(this.Context.ConnectionId).bbb($"{strMsg[j]}");
               //     Clients.Client(connid).dataMsg($"{strMsg[j]}");//输出群聊
               //     //Clients.Client(connid).receiveMsg($"{strMsg[j]}");//输出群聊
               // }
            }
            for (int i =0;i<str.Length;i++)
            {
                Clients.Client(connid).receiveList($"{str[i]}");
            }
            

        }
        #endregion

        #region  查询聊天数据
        private void GatRoomData()
        {
            DataTable dt = new GroupChatDataBLL().GetRoomDataBLL("room1");
            int len = dt.Rows.Count;
            string[] strMsg = new string[len]; 
            for (int j = len - 1; j > 0; j--)
            {
                Clients.Client(this.Context.ConnectionId).receiveDataMsg($"{strMsg[j]}");//输出群聊
            }
        }

        #endregion
    }
}
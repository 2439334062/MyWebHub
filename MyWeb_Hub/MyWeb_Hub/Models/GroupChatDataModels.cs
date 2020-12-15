using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWeb_Hub.Models
{
    public class GroupChatDataModels
    {
        public string roomName { get; set; }
        public string sendName { get; set; }
        public string msg { get; set; }
        public DateTime time { get; set; }
    }
}
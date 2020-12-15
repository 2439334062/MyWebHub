using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWeb_Hub.Models
{
    public class ChatDataModels
    {
        public int ID { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public DateTime Time { get; set; }
        public string Msg { get; set; }
    }
}
using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using MyWeb_Hub.Models;

[assembly: OwinStartup(typeof(MyWeb_Hub.Startup1))]

namespace MyWeb_Hub
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            // 有关如何配置应用程序的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkID=316888
            app.MapSignalR();
        }
    }
}

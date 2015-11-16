using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using SignalR.App_Start;
using Microsoft.AspNet.SignalR;
[assembly: OwinStartup(typeof(SignalR.Startup))]

namespace SignalR
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            GlobalHost.Configuration.ConnectionTimeout = TimeSpan.FromSeconds(30);
            GlobalHost.Configuration.DisconnectTimeout = TimeSpan.FromHours(24);
            GlobalHost.Configuration.KeepAlive = TimeSpan.FromSeconds(10);
            app.MapSignalR();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}   

using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(SignalRWebApi.Startup))]

namespace SignalRWebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            HttpConfiguration configuration = new HttpConfiguration();
            WebApiConfig.Register(configuration);
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SignalR
{
    public class ApiWithHubController : HubController<ChatHub>
    {
        public string Get()
        {
           HubContext.Clients.All.broadCastMessage("api", "hello");
            var apicontext = ControllerContext;
            return "";
        }

    }
}
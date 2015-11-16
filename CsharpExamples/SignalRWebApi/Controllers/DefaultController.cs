using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SignalRWebApi.Controllers
{
    public class DefaultController : HubController<MyHub>
    {
        public string Get()
        {
            var hubcontext = HubContext;
            var controlercontext = ControllerContext;
            return "Works";
        }

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace WebApi
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ClaimsAuthorizeAttribute : AuthorizeAttribute
    {
        private string claimType;
        private string claimValue;
        public ClaimsAuthorizeAttribute(string type, string value)
        {
            this.claimType = type;
            this.claimValue = value;
        }

        public override void OnAuthorization(HttpActionContext filterContext)
        {
            var user = HttpContext.Current.User as ClaimsPrincipal;
            if (user.HasClaim(claimType, claimValue))
            {
                base.OnAuthorization(filterContext);
            }
            else
            {
                if (user.Identity.IsAuthenticated)
                {
                    filterContext.Response = new System.Net.Http.HttpResponseMessage(HttpStatusCode.Forbidden);
                }
                else
                {
                    base.HandleUnauthorizedRequest(filterContext);
                }
            }
        }
    }
}

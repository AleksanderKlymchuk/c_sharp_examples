using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WebApi
{
    public class AuthorizationProvider:OAuthAuthorizationServerProvider
    {


        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
       

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            if (context.UserName.Equals(ConfigurationManager.AppSettings.Get("Name")) && context.Password.Equals(ConfigurationManager.AppSettings.Get("Password")))
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("username", context.UserName));
                identity.AddClaim(new Claim("role", "admin"));
                AuthenticationProperties properties = new AuthenticationProperties(new Dictionary<string, string> { 
                {"role","admin"},
                });
                var ticket = new AuthenticationTicket(identity, properties);
                context.Validated(ticket);
            }
               

        }
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }
    }
}

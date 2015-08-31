using Microsoft.Practices.Unity;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;


//using System.Web.OData.Builder;
//using System.Web.OData.Extensions;


namespace WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            //var container = new UnityContainer();
            //container.RegisterType<IEmployee, EmployeeService>(new HierarchicalLifetimeManager());
            //config.DependencyResolver = new UnityResolver(container);
            //var cors = new EnableCorsAttribute("*", "*", "*");
            //config.EnableCors();
            //config.EnableQuerySupport();
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}

using Microsoft.Practices.Unity;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;
using Unity.WebApi;
using WebApi.Controllers;

namespace WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IEmployee, EmployeeService>(new HierarchicalLifetimeManager());
         

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            //GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}
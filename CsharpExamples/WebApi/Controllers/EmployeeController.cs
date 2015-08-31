using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using System.Web.Script.Serialization;
using System.Net.Http.Headers;
using Newtonsoft.Json;



namespace WebApi.Controllers
{
     /// <summary>
     /// claims  authorization with owin middleware token based authentication example 1
     /// </summary>
    [ClaimsAuthorize("role", "admin")]
   
    public class EmployeeController :  BasseController
    {
        
        public EmployeeController(IDataService iDataService)
        {
            base.iDataService = iDataService;
        }

       
       

    }
}

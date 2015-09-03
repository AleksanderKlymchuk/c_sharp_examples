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
using System.Threading;
using System.Net.Http.Formatting;



namespace WebApi.Controllers
{
     /// <summary>
     /// claims  authorization with owin middleware token based authentication example 1
     /// </summary>
    [ClaimsAuthorize("role", "admin")]
   
    public class EmployeeController : ApiController
    {

        IDataService iDataService;
        public EmployeeController(IDataService iDataService)
        {
            this.iDataService = iDataService;
        }


       
        public virtual async Task<IHttpActionResult> Get()
        {
            
            return new HttpResult(await iDataService.GetAllAsync(), Request, HttpStatusCode.OK);
        }
        [Route("api/gettest")]
        public IHttpActionResult GetTest()
        {

            return new HttpResult(HttpStatusCode.Unauthorized);
        }
        

        [Route("api/getallasync")]
        public virtual async Task<IHttpActionResult> GetAllAsync()
        {
            return new HttpResult(await iDataService.GetAllAsync(), Request, HttpStatusCode.OK);
        }
        [Route("api/getallsync")]
        public virtual IHttpActionResult GetAllSync()
        {
            //return Ok(iDataService.GetAllSync());
            return new HttpResult(iDataService.GetAllSync(), Request, HttpStatusCode.OK);
        }


        public async Task<IHttpActionResult> Get(int Id)
        {
            return new HttpResult(await iDataService.Get(Id), Request, HttpStatusCode.OK);
            //return Ok( await iDataService.Get(Id));

        }
        public IHttpActionResult Post([FromBody]Employee employee)
        {
            iDataService.Add(employee);
            return Ok();
        }
        public IHttpActionResult Put([FromBody]Employee employee, int Id)
        {
            try
            {
                iDataService.Update(employee, Id);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }
        public IHttpActionResult Delete(int id)
        {
            try
            {
                iDataService.Delete(id);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }
       

    }
    public class HttpResult : IHttpActionResult
    {
        private ObjectContent content;
        private HttpStatusCode code;
        private HttpRequestMessage request;
        public HttpResult(object content, HttpRequestMessage request, HttpStatusCode code)
        {
            this.request = request;
            this.code = code;
            this.content = new ObjectContent(content.GetType(), content, new JsonMediaTypeFormatter());
        }
        public HttpResult( HttpRequestMessage request, HttpStatusCode code)
        {
            this.request = request;
            this.code = code;
           
        }

        public HttpResult( HttpStatusCode code)
        {
            this.code = code;

        }

        public Task<System.Net.Http.HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                Content =content,
                StatusCode = code,
                RequestMessage = request
            };

            return Task.FromResult(response);
        }

    }
}

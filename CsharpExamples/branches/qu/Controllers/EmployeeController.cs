using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
//using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using System.Web.Script.Serialization;
using System.Diagnostics;
using System.Net.Http.Headers;
using Newtonsoft.Json;



namespace WebApi.Controllers
{
     /// <summary>
     /// claims  authorization with owin middleware
     /// </summary>
    [ClaimsAuthorize("role", "admin")]
   
    public class EmployeeController :  ApiController
    {
        IEmployee iEmployee;

        
        public EmployeeController()
        {
            this.iEmployee = new EmployeeService();
        }
        private JsonSerializerSettings settings = new JsonSerializerSettings( )
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            PreserveReferencesHandling = PreserveReferencesHandling.All,
            Culture = System.Globalization.CultureInfo.GetCultureInfo("da-DK")
        };

        public async Task <IHttpActionResult> Get()
        {
            //string json = new WebClient().DownloadString("");
            //Employee emp = new JavaScriptSerializer().Deserialize<Employee>(json);
            Debug.WriteLine("Hello");
        
            return Ok(await iEmployee.Get());
        }
        [Route("api/getallasync")]
        public async Task<IHttpActionResult> GetAllAsync()
        {
            //string json = new WebClient().DownloadString("");
            //Employee emp = new JavaScriptSerializer().Deserialize<Employee>(json);

            return Ok(await iEmployee.GetAllAsync());
        }
        [Route("api/getallsync")]
        public IHttpActionResult GetAllSync()
        {
            return Ok(iEmployee.GetAllSync());
        }

        [Route("api/getcar")]
        public async Task<IHttpActionResult> GetCar()
        {

                var client = new HttpClient();
          
                client.BaseAddress = new Uri("http://localhost:41573/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/car");
                if (response.IsSuccessStatusCode)
                {
                    Car car = JsonConvert.DeserializeObject<Car>(response.Content.ReadAsStringAsync().Result);

                    response.Dispose();
                    client.Dispose();
                    return Ok(car);
                }
                
                return NotFound();    
        
                
        }
        //public PageResult<Employee> Get(ODataQueryOptions<Employee> options)
        //{
        //    ODataQuerySettings settings = new ODataQuerySettings()
        //    {
        //        PageSize = 1
        //    };

        //    IQueryable results = options.ApplyTo(iEmployee.Get().AsQueryable(), settings);

        //    return new PageResult<Employee>(
        //        results as IEnumerable<Employee>,
        //        Request.GetNextPageLink(),
        //        Request.GetInlineCount());
        //}
        //[Queryable(PageSize=2)]
        //public IQueryable<Employee> Get()
        //{
        //    return iEmployee.Get().AsQueryable();
        //}
        public IHttpActionResult Get(int Id)
        {
            Employee employee=iEmployee.Get(Id);
            if (employee!=null) 
            return Ok<Employee>(iEmployee.Get(Id));

            return NotFound();
        }
        public IHttpActionResult Post([FromBody]Employee employee)
        {
            iEmployee.Add(employee);
            return Ok();
        }
        public IHttpActionResult Put([FromBody]Employee employee,int Id)
        {
            try
            {
                iEmployee.Update(employee, Id);
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
                iEmployee.Delete(id);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
            
        }

    }
}

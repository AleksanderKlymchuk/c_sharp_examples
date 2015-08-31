using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApi.Controllers
{
    public abstract class BasseController : ApiController
    {

        protected IDataService iDataService;

       
        [Route("api/getallasync")]
        public virtual  async Task<IHttpActionResult> GetAllAsync()
        {
            return Ok(await iDataService.GetAllAsync());
        }
        [Route("api/getallsync")]
        public virtual IHttpActionResult GetAllSync()
        {
            return Ok(iDataService.GetAllSync());
        }


        public async Task<IHttpActionResult> Get(int Id)
        {

            return Ok( await iDataService.Get(Id));
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
        public  IHttpActionResult Delete(int id)
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
}

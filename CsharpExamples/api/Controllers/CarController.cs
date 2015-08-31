using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.Controllers
{
    public class CarController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok(new Car(){name="ford",year=new DateTime(2014,1,23)});
        }
    }
}

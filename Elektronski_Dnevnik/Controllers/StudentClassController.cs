using Elektronski_Dnevnik.Models;
using Elektronski_Dnevnik.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Elektronski_Dnevnik.Controllers
{[RoutePrefix("api/studentclass")]
[Authorize(Roles ="administrator")]
    public class StudentClassController : ApiController
    {
        private IClassService classService;
        public StudentClassController(IClassService classService)
        {
            this.classService = classService;
        }
        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult GetById(int ID)
        {
            StudentClass class1 = classService.GetById(ID);
            if (class1 != null)
            {
                return Ok(class1);
            }

            return BadRequest();
        }
        
    }
}

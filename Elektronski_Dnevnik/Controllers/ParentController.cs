using Elektronski_Dnevnik.Converters;
using Elektronski_Dnevnik.Models;
using Elektronski_Dnevnik.Models.DTOs;
using Elektronski_Dnevnik.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Elektronski_Dnevnik.Controllers

{
    [Authorize(Roles = "administrator")]
    [RoutePrefix("api/parents")]
    public class ParentController : ApiController
    {
        private IParentService parentService;
        public ParentController(IParentService parentService)
        {
            this.parentService = parentService;
        }
        [HttpGet]
        [Route("")]
        public List<ParentDTO> GetParents()
        {
            IEnumerable<Parent> usersEntityList = parentService.GetAllParents().ToList();

            var usersDtoList = usersEntityList
                .Select(person => new ParentDTO
                {
                    Id = person.Id,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Email = person.Email
                }).ToList();
            return usersDtoList;
        }
        [Authorize(Roles = "administrator")]
        [Route("{id:guid}")]
        [HttpGet]
        public IHttpActionResult GetParent(string id)
        {
            ParentDTO parent = parentService.GetByParentId(id).ToParentDTO(); ;
            if (parent != null)
            {
                return Ok(parent);
            }

            return BadRequest();
        }
        [Route("{id:int}")]
        public IHttpActionResult DeleteParent(string id)
        {
            Parent parent = parentService.GetByParentId(id);
            
            if (parent != null)
            {
                parentService.Delete(parent);
                return Ok();
            }

            return BadRequest();
        }
       
        [ResponseType(typeof(void))]
        [Route("{id:int}")]
        public IHttpActionResult PutParent(string id, [FromBody]ParentDTO parent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != parent.Id)
            {
                return BadRequest();
            }

            Parent savedParent = parentService.Update(parent);

            if (savedParent == null) { return NotFound(); }
            return StatusCode(HttpStatusCode.NoContent);

        }
        


    }
}

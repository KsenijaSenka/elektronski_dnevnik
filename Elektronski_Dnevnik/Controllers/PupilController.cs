using Elektronski_Dnevnik.Filters;
using Elektronski_Dnevnik.Models;
using Elektronski_Dnevnik.Models.DTOs;
using Elektronski_Dnevnik.Controllers;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Elektronski_Dnevnik.Services;
using Elektronski_Dnevnik.Converters;

namespace Elektronski_Dnevnik.Controllers
{[RoutePrefix("api/pupils")]
    public class PupilController : ApiController
    {
        private IPupilService pupilService;
        public PupilController(IPupilService pupilService)
        {
            this.pupilService = pupilService;
        }
        public static Logger logger = LogManager.GetCurrentClassLogger();

        

        [Authorize(Roles ="teacher")]
        [Route("")]
        [HttpGet]
        public List<PupilDTO> GetPupils()
        {
            IEnumerable<Pupil> usersEntityList = pupilService.GetAllPupils().ToList();
           
            var usersDtoList = usersEntityList
                .Select(person => new PupilDTO
                {
                    PupilId = person.Id,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Grade=person.Grade
                }).ToList();
            return  usersDtoList;
        }
        
        [Authorize(Roles = "administrator")]
        [Route("{id:guid}")]
        [HttpGet]
         public IHttpActionResult GetPupil(string id)
         {
             PupilDTO pupil = pupilService.GetById(id).ToPupilDTO(); ;
             if (pupil != null)
             {
                 return Ok(pupil);
             }

             return BadRequest();
         }
        [Authorize(Roles = "administrator")]
        [Route("{id:guid}")]        
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPupil(string id, [FromBody]PupilDTO pupil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != pupil.PupilId)
            {
                return BadRequest();
            }

            Pupil savedPupil = pupilService.Update(pupil);

            if (savedPupil == null) { return NotFound(); }
            return StatusCode(HttpStatusCode.NoContent);
            
        }
        [Authorize(Roles = "administrator")]
        [Route("{id:guid}")]        
        public IHttpActionResult Delete(string id)
        {
            Pupil pupil = pupilService.GetById(id);
           
            if (pupil != null)
            {
                pupilService.Delete(pupil);
                logger.Warn("Administrator has deleted a pupil.");
                return Ok();
            }

            return BadRequest();
        }

        

        
    }
}

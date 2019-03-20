using Elektronski_Dnevnik.Models;
using Elektronski_Dnevnik.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Elektronski_Dnevnik.Services;
using Elektronski_Dnevnik.Models.DTOs;
using Elektronski_Dnevnik.Converters;

namespace Elektronski_Dnevnik.Controllers
{[RoutePrefix("api/subjects")]
    public class SubjectController : ApiController
    {
        private ISubjectService subjectService;
        public SubjectController(ISubjectService subjectService)
        {
            this.subjectService = subjectService;
        }
        [Authorize(Roles = "administrator")]
        [HttpGet]
        [Route("")]
        public List<SubjectDTO> GetSubjects()
        {
            IEnumerable<Subject> subjectsEntityList = subjectService.GetAllSubjects().ToList();

            var subjectsDtoList =subjectsEntityList
                .Select(subject => new SubjectDTO
                {
                    SubjectID = subject.SubjectID,
                    SubjectName = subject.SubjectName,
                    ClassesPerWeek = subject.ClassesPerWeek,
                    
                }).ToList();
            return subjectsDtoList;
        }
        [Authorize(Roles = "administrator")]
        [Route("{id:int}")]
        [ResponseType(typeof(SubjectDTO))]
        public IHttpActionResult GetSubject(int id)
        {
            SubjectDTO subject = subjectService.GetById(id);
            if (subject != null)
            {
                return Ok(subject);
            }

            return BadRequest();
        }
        
        [Authorize(Roles = "administrator")]
        [Route("")]
        public IHttpActionResult PostSubject(SubjectDTO subject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Subject newSubject = subjectService.Create(subject);
            return Ok();
        }
        
        [Authorize(Roles = "administrator")]
        [Route("{id:int}")]
         public IHttpActionResult DeleteSubject(int id)
         {
             Subject subject = subjectService.GetBySubjectId(id);
            
             if (subject != null)
             {
                 subjectService.Delete(subject);
                 return Ok();
             }

             return BadRequest();
         }
        
        [Authorize(Roles = "administrator")]
        [Route("{id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSubject(int id, SubjectDTO subject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subject.SubjectID)
            {
                return BadRequest();
            }

            Subject savedSubject = subjectService.Update(subject);

            if (savedSubject == null) { return NotFound(); }
            return StatusCode(HttpStatusCode.NoContent);
            
        }


    }
}

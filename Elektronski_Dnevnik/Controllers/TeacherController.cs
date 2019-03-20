using Elektronski_Dnevnik.Converters;
using Elektronski_Dnevnik.Models;
using Elektronski_Dnevnik.Models.DTOs;
using Elektronski_Dnevnik.Services;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Elektronski_Dnevnik.Controllers
{[RoutePrefix("api/teachers")]
    public class TeacherController : ApiController
    {
        private ITeacherService teacherService;
        public TeacherController(ITeacherService teacherService)
        {
            this.teacherService = teacherService;
        }
        public static Logger logger = LogManager.GetCurrentClassLogger();
        [Authorize(Roles = "administrator")]
        [Route("")]
        [HttpGet]
        public List<TeacherDTO> GetTeachers()
        {
            IEnumerable<Teacher> usersEntityList = teacherService.GetAllTeachers().ToList();
            
            var usersDtoList = usersEntityList
                .Select(person => new TeacherDTO
                {
                    ID = person.Id,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    UserName=person.UserName,
                    Email=person.Email
                }).ToList();
            return usersDtoList;
        }
        [Authorize(Roles = "administrator")]
        [Route("{id:guid}")]
        [HttpGet]
        public IHttpActionResult GetTeacher(string id)
        {
            TeacherDTO teacher = teacherService.GetById(id).ToTeacherDTO(); ;
            if (teacher != null)
            {
                return Ok(teacher);
            }

            return BadRequest();
        }
        [Authorize(Roles = "administrator")]
        [Route("{id:guid}")]
        public IHttpActionResult DeleteTeacher(string id)
        {
            Teacher teacher = teacherService.GetById(id);
           
            if (teacher != null)
            {
                teacherService.Delete(teacher);
                logger.Warn("Administrator has deleted a teacher.");
                return Ok();
            }

            return BadRequest();
        }
        
        [Authorize(Roles = "administrator")]
        [Route("{id:guid}")]
        [ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult PutTeacher(string id, TeacherDTO teacher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != teacher.ID)
            {
                return BadRequest();
            }

            Teacher savedTeacher = teacherService.Update(teacher);

            if (savedTeacher == null) { return NotFound(); }
            return StatusCode(HttpStatusCode.NoContent);

        }

    }
}

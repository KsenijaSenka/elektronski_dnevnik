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
using System.Web.Security;

namespace Elektronski_Dnevnik.Controllers
{
    [Authorize(Roles="administrator")]
    [RoutePrefix("api/subjteachclass")]
    public class SubjectTeacherClassController : ApiController
        
    {
        private IPnoService pnoService;
        private IClassService classService;
        private ITeacherService teacherService;
        private ISubjectService subjectService;
        public SubjectTeacherClassController(IPnoService pnoService, IClassService classService,
            ITeacherService teacherService, ISubjectService subjectService)
        {
            this.pnoService = pnoService;
            this.classService = classService;
            this.teacherService = teacherService;
            this.subjectService = subjectService;
        }
        [Route("ppo/{subjectTeachID:int}/class/{classID:int}")]
        [HttpPost]
        public IHttpActionResult PostSubjTeachClass( SubjectTeachClassDTO ppo, int subjectTeachID,int classID) 
        {
            
        
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
            TeacherSubject teacherSubject = teacherService.GetTeacherSubject( subjectTeachID);
            if (teacherSubject == null)
            { return BadRequest("There is no teacher with the given id."); }
            StudentClass class1 = classService.GetById(classID);

            TeacherSubjectClass noviPredmet = pnoService.CreatePPO(ppo);
                return Ok();
            }
        [Route("pp/{teacherID:guid}/subject/{subjectid:int}")]
        [HttpPost]
        public IHttpActionResult PostTeachSubject(TeacherSubjectDTO pp,string teacherID, int subjectid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Teacher teacher = teacherService.GetById(teacherID);
            SubjectDTO subject = subjectService.GetById(subjectid);
            Subject subject1 = subject.ToSubject();
            TeacherSubject teacherSubject = pnoService.CreatePP(pp);
            return Ok();
        }

        
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetSubjTeachClass(int TeacherSubjectClassID)
        {
                                
            TeacherSubjectClass pno = pnoService.GetById(TeacherSubjectClassID);
            if (pno != null)
            {
                return Ok(pno);
            }

            return BadRequest();
        }

    }
}

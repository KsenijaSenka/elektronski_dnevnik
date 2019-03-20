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
using NLog;
using Elektronski_Dnevnik.Converters;
using System.Security.Claims;
using Microsoft.AspNet.Identity;

namespace Elektronski_Dnevnik.Controllers
{
    [RoutePrefix("api/marks")]
    public class MarkController : ApiController
    {
        private IMarkService markService;
        private IPupilService pupilService;
        private ITeacherService pnoService;
        private ISubjectService subjectService;
        public MarkController(IMarkService markService,IPupilService pupilService,ITeacherService pnoService,ISubjectService subjectService)
        {
            this.markService = markService;
            this.pupilService = pupilService;
            this.pnoService = pnoService;
            this.subjectService = subjectService;
        }
        [Authorize(Roles = "administrator")]
        [Route("")]
        [HttpGet]
        public List<MarksDTO> GetMarks()
        {
            IEnumerable<Marks> marksEntityList = markService.GetAllMarks().ToList();

            var marksDtoList = marksEntityList
                .Select(mark => new MarksDTO
                {
                    MarkID = mark.MarkID,
                    Mark = mark.Mark,
                    Midterm = mark.Midterm

                }).ToList();
            return marksDtoList;
        }
        [Authorize(Roles = "administrator")]
        [Route("{id:int}")]
        [ResponseType(typeof(MarksDTO))]
        public IHttpActionResult GetMark(int id)
        {
            MarksDTO mark = markService.GetById(id);
            if (mark != null)
            {
                return Ok(mark); 
            }

            return BadRequest();
        }
        [Route("{pupilId:guid}")]
        [HttpGet]
        [Authorize (Roles=("pupil"))]
        public IHttpActionResult GetMarksByPupil(string pupilId)
        {
            IEnumerable<Marks> marksEntityList = markService.GetAllMarks().ToList();
            
            var marksDtoList = marksEntityList
                .Select(mark => new MarksDTO
                {
                    MarkID = mark.MarkID,
                    Mark = mark.Mark,
                    Midterm = mark.Midterm,
                   
                }).ToList();

            
            List<MarksDTO> studentMarks = marksDtoList.FindAll(x => x.PupilID == pupilId);
            if (pupilId == null)
            { return BadRequest(); }
                return Ok(studentMarks);
        }
        [Route("pupil/{pupilId:guid}/parent/{parentId:guid}")]
        [HttpGet]
        [Authorize(Roles = ("parent"))]
        public IHttpActionResult GetPupilMarksByParent(string parentId, string pupilId)
        {
            IEnumerable<Marks> marksEntityList = markService.GetAllMarks().ToList();

            var marksDtoList = marksEntityList
                .Select(mark => new MarksDTO
                {
                    MarkID = mark.MarkID,
                    Mark = mark.Mark,
                    Midterm = mark.Midterm,

                }).ToList();


            List<MarksDTO> studentMarks = marksDtoList.
                FindAll(x => x.PupilID == pupilId&x.ParentID==parentId);
            if (pupilId == null)
            { return BadRequest(); }
            return Ok(studentMarks);
        }


        public static Logger logger = LogManager.GetCurrentClassLogger();
        
        [Authorize(Roles ="teacher")]
        [Route("subject/{subjectid:int}/teacher/{teacherID:guid}/pupil/{pupilID:Guid}")]
        [HttpPost]
        public IHttpActionResult PostMark(PostMarkDTO mark, int subjectID,string teacherID, string pupilID) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Pupil pupil = pupilService.GetById(pupilID);
            if (pupil == null)
            { return BadRequest("There is no pupil with the given id."); }
            Teacher pno = pnoService.GetById(teacherID);
            if (pno == null) {
                return BadRequest
            ("There is no teacher with the given id.");
            }
            SubjectDTO subject = subjectService.GetById(subjectID);
            if(subject==null)
            { return BadRequest("There is no subject with the given id."); }
            string userName;
            string userId;
            if ((ClaimsPrincipal)RequestContext.Principal != null)
            {
                                              

                userId = ((ClaimsPrincipal)RequestContext.Principal)
                .FindFirst(x => x.Type == "UserId").Value;
                
                userName = ((ClaimsPrincipal)RequestContext.Principal)
                   .FindFirst(x => x.Type == "Username").Value; }
            
            if (RequestContext.Principal.IsInRole("teacher") == false)
            { return BadRequest(); }
                Marks newMark = markService.Create(mark);
               
                return Ok(); 
        }
        
        [Authorize(Roles = "administrator")]
        [Route("{id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMark(int id, PostMarkDTO mark)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mark.MarkID)
            {
                return BadRequest();
            }

            Marks savedMark = markService.Update(mark);
            logger.Warn("Administrator has changed a mark!");
            if (savedMark == null) { return NotFound(); }
            return StatusCode(HttpStatusCode.NoContent);

        }
        
        [Route("{id:int}")]
        [Authorize(Roles = "administrator")]
        public IHttpActionResult DeleteMark(int id)
        {
            Marks mark = markService.GetMarkById(id);
           
            
            if (mark != null)
            {
                markService.Delete(mark);
                logger.Warn("Administrator has deleted a mark!");
                return Ok();
            }

            return BadRequest("There is no mark with the given id."); 
            
            
        }




       
        
    }
    }


using Elektronski_Dnevnik.Models;
using Elektronski_Dnevnik.Models.DTOs;
using Elektronski_Dnevnik.Repositories;
using Elektronski_Dnevnik.Controllers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Elektronski_Dnevnik.Services;

namespace Elektronski_Dnevnik.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        
        private IUserService service;

        public AccountController(IUserService userService)
        {
            this.service = userService;
        }
        public static Logger logger = LogManager.GetCurrentClassLogger();

        [Authorize(Roles = "administrator")]
        [Route("register-pupil")]
        public async Task<IHttpActionResult> RegisterPupil(PupilRegDTO userModel)
        {
            
            var result = await service.RegisterPupil(userModel);

            if (result == null)
            {
                return BadRequest(ModelState);
            }
            logger.Info("Administrator created a new account with password.");
            return Ok();
        }

        
        [Authorize(Roles = "administrator")]
        [Route("register-pupil")]
        public async Task<IHttpActionResult> RegisterTeacher(UserRegDTO userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await service.RegisterTeacher(userModel);

            if (result == null)
            {
                return BadRequest(ModelState);
            }
            logger.Info("AdminUser created a new account with password.");
            return Ok();
        }
        
        [Authorize(Roles = "administrator")]
        [Route("register-parent")]
        public async Task<IHttpActionResult> RegisterParent(UserRegDTO userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await service.RegisterParent(userModel);

            if (result == null)
            {
                return BadRequest(ModelState);
            }
            logger.Info("AdminUser created a new account with password.");
            return Ok();
        }
                
        [AllowAnonymous]
        [Route("register-admin")]
        public async Task<IHttpActionResult> RegisterAdmin(UserRegDTO userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await service.RegisterAdmin(userModel);

            if (result == null)
            {
                return BadRequest(ModelState);
            }
            logger.Info("User created a new account with password.");
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
      

    }
}
    
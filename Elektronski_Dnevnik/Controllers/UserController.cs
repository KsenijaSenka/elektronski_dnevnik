using Elektronski_Dnevnik.Models;
using Elektronski_Dnevnik.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Security;
using Elektronski_Dnevnik.Services;
using Elektronski_Dnevnik.Models.DTOs;
using System.ComponentModel.DataAnnotations;
using NLog;
using Elektronski_Dnevnik.Converters;

namespace Elektronski_Dnevnik.Controllers
{[Authorize (Roles="administrator")]
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        private IUserService usersService;
        public UserController(IUserService usersService)
        {
            this.usersService = usersService;
        }
        
        
           
        [Route("{id:guid}")]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            UserDTO user = usersService.GetById(id);
            if (user != null)
            {
                return Ok(user);
            }

            return BadRequest();
        }
        //[Route("by-username/{username}")]
        [ResponseType(typeof(ApplicationUser))]
        public IHttpActionResult DeleteUser(string userName)
        {
            IEnumerable<ApplicationUser> users = usersService.GetAllUsers();
            ApplicationUser foundUser = users.FirstOrDefault(user => user.UserName.ToLower() == userName.ToLower());
            if (foundUser != null)

            {
                usersService.Delete(foundUser);
                logger.Warn("Administrator has deleted a user.");
                return Ok();
            }
            return BadRequest();
        }

                               
        //[Route("by-firstname/{firstname}")]
        [ResponseType(typeof(ApplicationUser))]
        public IHttpActionResult GetByFirstName(string firstName)
        {
            IEnumerable<ApplicationUser> users = usersService.GetAllUsers();
            ApplicationUser foundUser = users.FirstOrDefault(user => user.FirstName.ToLower() == firstName.ToLower());
            if (foundUser != null)

            {
                return Ok(foundUser);
            }
            return BadRequest();

        }
        //[Route("by-lastname/{lastname}")]
        [ResponseType(typeof(ApplicationUser))]
        public IHttpActionResult GetByLastName(string lastName)
        {
            IEnumerable<ApplicationUser> users = usersService.GetAllUsers();
            ApplicationUser foundUser = users.FirstOrDefault(user => user.LastName.ToLower() == lastName.ToLower());
            if (foundUser != null)

            {
                return Ok(foundUser);
            }
            return BadRequest();

        }
        //[Route("by-username/{username}")]
        //[ResponseType(typeof(ApplicationUser))]
        public IHttpActionResult GetByUserName(string userName)
        {
            IEnumerable<ApplicationUser> users = usersService.GetAllUsers();
            ApplicationUser foundUser = users.FirstOrDefault(user => user.UserName.ToLower() == userName.ToLower());
            if (foundUser != null)
            {  UserDTO user = foundUser.ToUserDTO();
            
                return Ok(user);
            }
            return BadRequest();

        }
        //[Route("by-email")]
        [ResponseType(typeof(ApplicationUser))]
        public IHttpActionResult GetByEmail([FromUri] string email)
        {
            IEnumerable<ApplicationUser> users = usersService.GetAllUsers();
            ApplicationUser foundUser = users.FirstOrDefault(user => user.Email == email);

            if (foundUser != null)
            {
                return Ok(foundUser);
            }

            return BadRequest();
        }

        public static Logger logger = LogManager.GetCurrentClassLogger();

    
}}






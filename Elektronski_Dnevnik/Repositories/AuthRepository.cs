using Elektronski_Dnevnik.Models;
using Elektronski_Dnevnik.Models.DTOs;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using System.Web;

namespace Elektronski_Dnevnik.Repositories
{
    public class AuthRepository : IAuthRepository ,IDisposable
    {
        private UserManager<ApplicationUser> _userManager;

        public AuthRepository(DbContext context)
        {
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
        }


       
        public async Task<IdentityResult> RegisterTeacher(Teacher teacher, string password)
        {
            var result = await _userManager.CreateAsync(teacher, password);
            _userManager.AddToRole(teacher.Id, "teacher");

            

            return result;
        }
        public async Task<IdentityResult> RegisterParent(Parent parent, string password)
        {
            var result = await _userManager.CreateAsync(parent, password);
            _userManager.AddToRole(parent.Id, "parent");

            
            return result;
        }
        public async Task<IdentityResult> RegisterPupil(Pupil pupil, string password)
        {
            var result = await _userManager.CreateAsync(pupil, password);
            _userManager.AddToRole(pupil.Id, "pupil");
            
            return result;
        }
        public async Task<IdentityResult> RegisterAdminUser(AdminUser userModel, string password)
        {
            var result = await _userManager.CreateAsync(userModel, password);
            _userManager.AddToRole(userModel.Id, "administrator");
            
            return result;
        }

        public async Task<ApplicationUser> FindUser(string userName, string password)
        {
            ApplicationUser user = await _userManager.FindAsync(userName, password);
            return user;
        }
        
        public async Task<ApplicationUser> FindName(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            
            return user;
        }
    
           

            

        public async Task<IList<string>> FindRoles(string userId)
        {
            return await _userManager.GetRolesAsync(userId);
        }

        public void Dispose()
        {
            if (_userManager != null)
            {
                _userManager.Dispose();
                _userManager = null;
            }
        }

    }

}

        
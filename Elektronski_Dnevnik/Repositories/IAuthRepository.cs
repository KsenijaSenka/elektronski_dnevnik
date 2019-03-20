using Elektronski_Dnevnik.Models;
using Elektronski_Dnevnik.Models.DTOs;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Elektronski_Dnevnik.Repositories
{
    public interface IAuthRepository : IDisposable
    {
        
        Task<IdentityResult> RegisterParent(Parent parent, string password);
        Task<IdentityResult> RegisterTeacher(Teacher teacher, string password);
        Task<IdentityResult> RegisterPupil(Pupil pupil, string password);
        Task<IdentityResult> RegisterAdminUser(AdminUser userModel, string password);
        Task<ApplicationUser> FindUser(string userName, string password);
        Task<IList<string>> FindRoles(string userId);

       
    }
}
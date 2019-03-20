using Elektronski_Dnevnik.Models;
using Elektronski_Dnevnik.Models.DTOs;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektronski_Dnevnik.Services
{
    public interface IUserService
    {
        
        Task<IdentityResult> RegisterParent(UserRegDTO user);
        Task<IdentityResult> RegisterPupil(PupilRegDTO user);
        Task<IdentityResult> RegisterAdmin(UserRegDTO user);
        Task<IdentityResult> RegisterTeacher(UserRegDTO user);
        
        void Delete(ApplicationUser user);
        IEnumerable<ApplicationUser> GetAllUsers();
        
      
        UserDTO GetById(string id);
        
    }
}

using Elektronski_Dnevnik.Converters;
using Elektronski_Dnevnik.Models;
using Elektronski_Dnevnik.Models.DTOs;
using Elektronski_Dnevnik.Repositories;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Elektronski_Dnevnik.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork context;
        public UserService(IUnitOfWork context)
        { this.context = context; }
        public async Task<IdentityResult> RegisterAdmin(UserRegDTO userModel)
        {
            AdminUser user = new AdminUser
            {
                UserName = userModel.UserName,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                ShortName = "admin"
            };

            return await context.AuthRepository.RegisterAdminUser(user, userModel.Password);
        }
        public async Task<IdentityResult> RegisterPupil(PupilRegDTO userModel)
        {
            Pupil user = new Pupil
            {
                UserName = userModel.UserName,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Grade=userModel.Grade,
                Parent=userModel.Parent
                
            };
            return await context.AuthRepository.RegisterPupil(user, userModel.Password);
        }


        public async Task<IdentityResult> RegisterParent(UserRegDTO userModel)
        {
            Parent user = new Parent
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                UserName = userModel.UserName,
                
           };

    return await context.AuthRepository.RegisterParent(user, userModel.Password);}

        public async Task<IdentityResult> RegisterTeacher(UserRegDTO userModel)
        {
            Teacher user = new Teacher
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                UserName = userModel.UserName,
                          };

            return await context.AuthRepository.RegisterTeacher(user, userModel.Password);
        }


        public void Delete(ApplicationUser user)
        {
            context.UsersRepository.Delete(user);
            context.Save();
        }
        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            return context.UsersRepository.Get();
        }

       
      
          public UserDTO GetById(string id)
          {
              return context.UsersRepository.GetByID(id).ToUserDTO(); 

          }

       
    }
}
    

    

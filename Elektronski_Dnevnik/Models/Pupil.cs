using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Elektronski_Dnevnik.Models
{
    public class Pupil : ApplicationUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
       
        
        public  Parent Parent { get; set; }

        
        
        
        public  ICollection<Teacher> Teachers { get; set; }

        public  ICollection<Marks> Marks { get; set; }
        


        [Range(1, 8)]
        public int Grade { get; set; }
        
        public virtual StudentClass StudentClass { get; set; }

        
    } 
}
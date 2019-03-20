using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Elektronski_Dnevnik.Models
{
    public abstract class ApplicationUser : IdentityUser
    {
        
        [StringLength(30, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 60 character in length.")]
        public string FirstName { get; set; }

        
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 60 character in length.")]
        public string LastName { get; set; }
      

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
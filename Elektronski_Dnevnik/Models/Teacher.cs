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
    public class Teacher : ApplicationUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        
        
        public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; }

        
    }
        public class TeacherSubject
        {
        [Key]
        public int TeacherSubjectID { get; set; }
            
            public virtual Teacher Teacher { get; set; }
            public int SubjectID { get; set; }
            public virtual Subject Subject { get; set; }
        public virtual ICollection<TeacherSubjectClass> TeacherSubjectClasses { get; set; }
        }
    public class TeacherSubjectClass
    {
        public int TeacherSubjectClassID { get; set; }
        public int TeacherSubjectID { get; set; }
        public virtual TeacherSubject TeacherSubject { get; set; }
        public int ClassID { get; set; }
        public virtual StudentClass StudentClass { get; set; }
    }




}
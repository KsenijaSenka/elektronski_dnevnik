using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elektronski_Dnevnik.Models.DTOs
{
    public class TeacherDTO
    {
        
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public string UserName { get; internal set; }
        public string ID { get; set; }
        public string Email { get; set; }
    }
}
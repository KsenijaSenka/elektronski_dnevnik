using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elektronski_Dnevnik.Models.DTOs
{
    public class UserDTO
    {
        public object Id { get; internal set; }
        public object Name { get; internal set; }
        public object Surname { get; set; }
        public object EmailAddress { get; internal set; }
    }
}
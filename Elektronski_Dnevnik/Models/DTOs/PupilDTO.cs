using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Elektronski_Dnevnik.Models.DTOs
{
    public class PupilDTO
    {
        
        [StringLength(30, ErrorMessage = " The first name must have a least {2} characters and at most {1} characters  .", MinimumLength = 2)]
        public string FirstName { get; set; }

       
        [StringLength(30, ErrorMessage = " The last name must have a least {2} characters and at most {1} characters  .", MinimumLength = 2)]
        public string LastName { get; set; }

        
        [StringLength(30, ErrorMessage = " The username must have a least {2} characters and at most {1} characters  .", MinimumLength = 2)]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Range(1, 8)]
        public int Grade { get; set; }

        public Parent Roditelj { get; set; }
        public string PupilId { get;  set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Elektronski_Dnevnik.Models.DTOs
{
    public class UserRegDTO
    {
        [Required(ErrorMessage="The first name is required.")]
        [StringLength(30, ErrorMessage = " The first name must have a least {2} characters and at most {1} characters .", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The last name is required.")]
        [StringLength(30, ErrorMessage = " The last name must have a least {2} characters and at most {1} characters .", MinimumLength = 2)]
        public string LastName { get; set; }

            [Required(ErrorMessage = "The username is required.")]
        [StringLength(30, ErrorMessage = " The username must have a least {2} characters and at most {1} characters .", MinimumLength = 2)]
        [Display(Name = "Username")]
            public string UserName { get; set; }

            [Required(ErrorMessage = "The password is required.")]
            [StringLength(30, ErrorMessage = "The password must have a least {2} characters and at most {1} characters  .", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [Required(ErrorMessage = "The password is required.")]
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and the confirmed password do not match.")]
            public string ConfirmPassword { get; set; }
        }
    }

using Elektronski_Dnevnik.Models;
using Elektronski_Dnevnik.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elektronski_Dnevnik.Converters
{
    public static class ExtensionToUserDTO
    {
        public static UserDTO ToUserDTO(this ApplicationUser user)
        {
            return new UserDTO {
                Id = user.Id,
                Name = user.FirstName,
                Surname=user.LastName,
                EmailAddress=user.Email
            };
        }
    }
}
using Elektronski_Dnevnik.Models;
using Elektronski_Dnevnik.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elektronski_Dnevnik.Converters
{
    public static class ExtensionToParentDTO
    {
        public static ParentDTO ToParentDTO(this Parent parent)
        {
            return new ParentDTO
            {
                Id = parent.Id,
                FirstName = parent.FirstName,
                LastName = parent.LastName,
                Email=parent.Email

            };
        }
    }
}
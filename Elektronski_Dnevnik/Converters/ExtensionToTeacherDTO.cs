using Elektronski_Dnevnik.Models;
using Elektronski_Dnevnik.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elektronski_Dnevnik.Converters
{
    public static class ExtensionToTeacherDTO
    {
        public static TeacherDTO ToTeacherDTO(this Teacher nastavnik)
        {
            return new TeacherDTO
            {
                ID = nastavnik.Id,
                FirstName=nastavnik.FirstName,
                LastName = nastavnik.LastName,
                UserName=nastavnik.UserName,
                Email=nastavnik.Email,
                //PredmetiNastavnika = nastavnik.PredmetiNastavnika,
            };
        }
    }
}
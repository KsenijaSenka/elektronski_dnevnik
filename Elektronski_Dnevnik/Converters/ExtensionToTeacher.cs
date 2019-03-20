using Elektronski_Dnevnik.Models;
using Elektronski_Dnevnik.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elektronski_Dnevnik.Converters
{
    public static class ExtensionToTeacher
    {
        public static Teacher ToTeacher(this TeacherDTO nastavnik)
        {
            return new Teacher
            {
                Id = nastavnik.ID,
                FirstName=nastavnik.FirstName,
                LastName = nastavnik.LastName,
                UserName=nastavnik.UserName,
                Email=nastavnik.Email,
                //PredmetiNastavnika = nastavnik.PredmetiNastavnika,
            };
        }
    }
}
using Elektronski_Dnevnik.Models;
using Elektronski_Dnevnik.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elektronski_Dnevnik.Converters
{
    public static class ExtensionToSubjectDTO
    {
        public static SubjectDTO ToSubjectDTO(this Subject predmet)
        {
            return new SubjectDTO
            {
                SubjectID = predmet.SubjectID,
                SubjectName = predmet.SubjectName,
                ClassesPerWeek = predmet.ClassesPerWeek,
            };
        }
    }
}
    

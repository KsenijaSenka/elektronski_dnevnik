using Elektronski_Dnevnik.Models;
using Elektronski_Dnevnik.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elektronski_Dnevnik.Converters
{
    public static class ExtensionToPredNastOdeljDTO
    {public static SubjectTeachClassDTO ToPredNastOdeljDTO(this TeacherSubjectClass ppo)
        {
            return new SubjectTeachClassDTO
            {
                TeacherSubjectClassID = ppo.TeacherSubjectClassID,
                TeacherSubjectID = ppo.TeacherSubjectID,
                ClassID = ppo.ClassID,
            };
}
        }
}
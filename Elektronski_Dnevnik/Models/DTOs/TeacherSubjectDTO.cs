using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elektronski_Dnevnik.Models.DTOs
{
    public class TeacherSubjectDTO
    {
        public int TeacherSubjectID { get; set; }
        public int SubjectID { get; set; }
        public string TeacherID { get; set; }
    }
}
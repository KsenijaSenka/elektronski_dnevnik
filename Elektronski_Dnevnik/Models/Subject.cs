using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Elektronski_Dnevnik.Models
{
    public class Subject
    {
       

        public Subject(){}
        

        public int SubjectID { get; set; }
        
        public string SubjectName { get; set; }
        
        public int ClassesPerWeek { get; set; }

        

        
        public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; }
        
        

        
        
        
    }
}
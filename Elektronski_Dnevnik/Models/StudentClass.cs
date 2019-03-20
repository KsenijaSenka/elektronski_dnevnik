using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Elektronski_Dnevnik.Models
{
    public class StudentClass
    { public int ClassID { get; set; }
        [Required]
        public int No { get; set; }
        [Range(1,8)]
        public int Grade { get; set; }
        
        public virtual ICollection<Pupil> Pupils { get; set; }
        
        public virtual ICollection<TeacherSubjectClass> TeacherSubjectClasses { get; set; }
        
  }
    
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Elektronski_Dnevnik.Models.DTOs
{
    public class SubjectDTO
    {
        

        public int SubjectID { get; set; }
        
        public string SubjectName { get; set; }
        [Range(1,5)]
        public int ClassesPerWeek { get; set; }
    }
}
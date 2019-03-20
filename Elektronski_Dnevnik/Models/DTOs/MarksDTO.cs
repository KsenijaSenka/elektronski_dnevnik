using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Elektronski_Dnevnik.Models
{
    public class MarksDTO
    {
        public int MarkID { get; set; }

        [Range(1,5)]
        [Required(ErrorMessage = "Unesite ocenu od 1 do 5.")]
        public int Mark { get; set; }

       

        public string ParentID { get; set; }
        public string PupilID { get; set; }
       
        public int Midterm { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Elektronski_Dnevnik.Models.DTOs
{
    public class PostMarkDTO
    {
        public int MarkID { get; set; }

        [Range(1, 5)]
        [Required(ErrorMessage = "Enter a grade between 1 and 5.")]
        public int Mark { get; internal set; }
        [Range(1, 2)]
        [Required(ErrorMessage = "Enter a midterm, 1 or 2.")]
        public int Midterm { get; set; }
        
    }
}
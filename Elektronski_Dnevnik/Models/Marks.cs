using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Elektronski_Dnevnik.Models
{
    
    public class Marks
    {
        public Marks()
        {
        }
        public int MarkID { get; set; }
        [Range(1,5)]
        public int Mark { get; set; }

        
        //public virtual Subject Subject { get; set; }

        
        //public virtual Teacher Teacher { get; set; }

        
        //public virtual Pupil Pupil { get; set; }
        [Range(1,2)]
        public int Midterm { get; set; }
       

        
    }

}
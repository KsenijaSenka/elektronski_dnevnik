using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Elektronski_Dnevnik.Models.DTOs
{
    public class PupilRegDTO:UserRegDTO
    {
        [Range(1, 8)]
        public int Grade { get; set; }

        public Parent Parent { get; set; }

    }
}
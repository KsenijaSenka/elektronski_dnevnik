using Elektronski_Dnevnik.Models;
using Elektronski_Dnevnik.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elektronski_Dnevnik.Converters
{
    public static class ExtensionToPostMarkDTO
    {
        public static MarksDTO ToPostMarkDTO(this Marks mark)
        {
            return new MarksDTO
            {
                MarkID = mark.MarkID,
                Mark = mark.Mark,
               
                Midterm = mark.Midterm,
                
            };
        }
    }
}
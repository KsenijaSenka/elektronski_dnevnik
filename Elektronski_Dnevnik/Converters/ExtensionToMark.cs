using Elektronski_Dnevnik.Models;
using Elektronski_Dnevnik.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elektronski_Dnevnik.Converters
{
    public static class ExtensionToMark
    {public static Marks ToMark(this PostMarkDTO mark)
        {
            return new Marks
            {
                MarkID = mark.MarkID,
                 Mark=mark.Mark,
                 
                 Midterm=mark.Midterm,
        
            };
        }
    }
}
    

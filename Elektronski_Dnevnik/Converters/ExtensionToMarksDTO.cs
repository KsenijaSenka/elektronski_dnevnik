using Elektronski_Dnevnik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elektronski_Dnevnik.Converters
{
    public static class ExtensionToMarksDTO
    {
        public static MarksDTO ToMarksDTO(this Marks mark,  Pupil pupil, Parent parent )
        {
            return new MarksDTO
            {
                MarkID = mark.MarkID,
                Mark = mark.Mark,
                
                Midterm = mark.Midterm,
                PupilID=pupil.Id,
                ParentID=parent.Id

            };
        }
    }
}
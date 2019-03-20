using Elektronski_Dnevnik.Models;
using Elektronski_Dnevnik.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elektronski_Dnevnik.Converters
{
    public static class ExtensionToUcenik
    {
        public static Pupil ToPupil(this PupilDTO ucenik)
        {
            return new Pupil
            {
                Id = ucenik.PupilId,
                FirstName = ucenik.FirstName,
                LastName = ucenik.LastName,
                UserName=ucenik.UserName,
                Parent = ucenik.Roditelj,
                Grade = ucenik.Grade
            };
        }
    }
}
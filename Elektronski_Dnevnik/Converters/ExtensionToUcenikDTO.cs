using Elektronski_Dnevnik.Models;
using Elektronski_Dnevnik.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elektronski_Dnevnik.Converters
{
    public static class ExtensionToUcenikDTO
    {
        public static PupilDTO ToPupilDTO(this Pupil ucenik)
        {
            return new PupilDTO
            {
                PupilId = ucenik.Id,
                FirstName = ucenik.FirstName,
                LastName = ucenik.LastName,
                UserName=ucenik.UserName,
                Roditelj = ucenik.Parent,
                Grade = ucenik.Grade
            };
        }
    }
}
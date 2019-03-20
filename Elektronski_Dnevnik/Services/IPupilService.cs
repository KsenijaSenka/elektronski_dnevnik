using Elektronski_Dnevnik.Models;
using Elektronski_Dnevnik.Models.DTOs;
using System.Collections.Generic;

namespace Elektronski_Dnevnik.Services
{
    public interface IPupilService
    {
        IEnumerable<Pupil> GetAllPupils();
        Pupil GetById(string id);
        Pupil Update(PupilDTO pupil);
        void Delete(Pupil pupil);
        
    }
}
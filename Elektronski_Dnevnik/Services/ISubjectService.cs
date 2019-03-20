using System.Collections.Generic;
using Elektronski_Dnevnik.Models;
using Elektronski_Dnevnik.Models.DTOs;

namespace Elektronski_Dnevnik.Services
{
    public interface ISubjectService
    {
        SubjectDTO GetById(int Id);
        Subject GetBySubjectId(int id);
        IEnumerable<Subject> GetAllSubjects();
        Subject Create(SubjectDTO subject);
        Subject Update(SubjectDTO subject);
        void Delete(Subject subject);
    }
}
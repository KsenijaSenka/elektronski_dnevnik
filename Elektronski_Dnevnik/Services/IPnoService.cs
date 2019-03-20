using Elektronski_Dnevnik.Models;
using Elektronski_Dnevnik.Models.DTOs;

namespace Elektronski_Dnevnik.Services
{
    public interface IPnoService
    {
        TeacherSubjectClass GetById(int Id);
        TeacherSubjectClass CreatePPO(SubjectTeachClassDTO pno);
        TeacherSubject CreatePP(TeacherSubjectDTO pp);
       
    }
}
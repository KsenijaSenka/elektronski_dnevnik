using Elektronski_Dnevnik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektronski_Dnevnik.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<ApplicationUser> UsersRepository { get; }
        IAuthRepository AuthRepository { get; }
        IGenericRepository<Subject> SubjectRepository { get; }
       
        IGenericRepository<StudentClass> ClassRepository{ get;}
        IGenericRepository<Marks> MarkRepository { get; }
        
        IGenericRepository<Teacher> TeachersRepository { get; }
        IGenericRepository<Pupil> PupilsRepository { get; }
        IGenericRepository<Parent> ParentRepository { get; }
        IGenericRepository<TeacherSubjectClass> PnoRepository { get; }
        IGenericRepository<TeacherSubject> TeacherSubjectRepository { get; }
        void Save();
    
        

       
    }
}

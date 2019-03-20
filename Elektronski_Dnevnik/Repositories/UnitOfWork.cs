using Elektronski_Dnevnik.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Unity.Attributes;

namespace Elektronski_Dnevnik.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private DbContext context;
        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }
        [Dependency]
        public IGenericRepository<ApplicationUser> UsersRepository { get; set; }

        [Dependency]
        public IAuthRepository AuthRepository { get; set; }
        [Dependency]
        public IGenericRepository<Marks> MarkRepository { get; set; }
        [Dependency]
        public IGenericRepository<StudentClass> ClassRepository { get; set; }
        [Dependency]
        public IGenericRepository<Subject> SubjectRepository { get; set; }

        [Dependency]
        public IGenericRepository<Teacher> TeachersRepository { get; set; }
        [Dependency]
        public IGenericRepository<Pupil> PupilsRepository { get; set; }
        [Dependency]
        public IGenericRepository<Parent> ParentRepository { get; set; }
        [Dependency]
        public IGenericRepository<TeacherSubjectClass> PnoRepository { get; set; }
        [Dependency]
        public IGenericRepository<TeacherSubject> TeacherSubjectRepository { get; }
        public void Save()
        {
            context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
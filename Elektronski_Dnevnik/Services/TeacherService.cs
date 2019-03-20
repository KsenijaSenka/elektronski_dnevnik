using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Elektronski_Dnevnik.Models;
using Elektronski_Dnevnik.Models.DTOs;
using Elektronski_Dnevnik.Repositories;
using Elektronski_Dnevnik.Converters;

namespace Elektronski_Dnevnik.Services
{
    public class TeacherService : ITeacherService
    {
        private IUnitOfWork context;
        public TeacherService(IUnitOfWork context)
        { this.context = context; }

        public void Delete(Teacher teacher)
        {
               context.UsersRepository.Delete(teacher);
                context.Save();
                                }

        public IEnumerable<Teacher> GetAllTeachers()
        {
            return context.TeachersRepository.Get();
            
        }

       

        public Teacher GetById(string id)
        {
            return context.TeachersRepository.GetByID(id);
               
            
        }
        public TeacherSubject GetTeacherSubject(int id)
        { return context.TeacherSubjectRepository.GetByID(id); }

        public Teacher Update(TeacherDTO teacher)
        { 

                var teacher1 = teacher.ToTeacher();
                context.TeachersRepository.Update(teacher1);
                context.Save();
                return teacher1;
                       
        }
    }
}
using Elektronski_Dnevnik.Models;
using Elektronski_Dnevnik.Models.DTOs;
using System;
using System.Collections.Generic;

namespace Elektronski_Dnevnik.Services
{
    public interface ITeacherService
    {
        void Delete(Teacher teacher);
        IEnumerable<Teacher> GetAllTeachers();
        TeacherSubject GetTeacherSubject(int id);
        
        Teacher Update(TeacherDTO teacher);
        Teacher GetById(string id);
        

    }
}
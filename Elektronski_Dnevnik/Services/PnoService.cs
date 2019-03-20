using Elektronski_Dnevnik.Converters;
using Elektronski_Dnevnik.Models;
using Elektronski_Dnevnik.Models.DTOs;
using Elektronski_Dnevnik.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elektronski_Dnevnik.Services
{
    public class PnoService:IPnoService
    {
        private IUnitOfWork context;
        public PnoService(IUnitOfWork context)
        { this.context = context; }

        public TeacherSubjectClass GetById(int id)

        { return context.PnoRepository.GetByID(id);
             
        }
        public TeacherSubject CreatePP(TeacherSubjectDTO pp)
        {
            TeacherSubject pp1 = new TeacherSubject
            {
                
                TeacherSubjectID = pp.TeacherSubjectID,
                SubjectID = pp.SubjectID,
            };
            context.TeacherSubjectRepository.Insert(pp1);
            context.Save();
            return pp1;
        }

        public TeacherSubjectClass CreatePPO(SubjectTeachClassDTO pno)
        {
            
           
            TeacherSubjectClass subject1 = new TeacherSubjectClass
            {
                TeacherSubjectClassID = pno.TeacherSubjectClassID,
                TeacherSubjectID = pno.TeacherSubjectID,
                ClassID = pno.ClassID,
            };


            context.PnoRepository.Insert(subject1);
            context.Save();
            return subject1;
        }

       
    }
}
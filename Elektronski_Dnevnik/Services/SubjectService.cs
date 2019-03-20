using Elektronski_Dnevnik.Converters;
using Elektronski_Dnevnik.Models;
using Elektronski_Dnevnik.Models.DTOs;
using Elektronski_Dnevnik.Repositories;
using Elektronski_Dnevnik.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elektronski_Dnevnik.Services
{


    public class SubjectService : ISubjectService
    {
        private IUnitOfWork context;
        public SubjectService(IUnitOfWork context)
        { this.context = context; }
        public IEnumerable<Subject> GetAllSubjects()
        {
            return context.SubjectRepository.Get();
        }


        public SubjectDTO GetById(int id)
                                                      
            { return context.SubjectRepository.GetByID(id).ToSubjectDTO(); }
        public Subject GetBySubjectId(int id)
        {
            return context.SubjectRepository.GetByID(id);


        }

        public Subject Create(SubjectDTO subject)
        {
            Subject subject1 = new Subject
            {
                SubjectID = subject.SubjectID,
                SubjectName = subject.SubjectName,
                ClassesPerWeek=subject.ClassesPerWeek
            };


            context.SubjectRepository.Insert(subject1);
            context.Save();
            return subject1;
        }

        public Subject Update(SubjectDTO subject)

        {
            
            var subject1 = subject.ToSubject();
            context.SubjectRepository.Update(subject1);
            context.Save();
            return subject1;
        }
        public void Delete(Subject subject)
        {
            context.SubjectRepository.Delete(subject);
            context.Save();
        }

        
       
    }
}

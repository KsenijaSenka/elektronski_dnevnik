using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Elektronski_Dnevnik.Converters;
using Elektronski_Dnevnik.Models;
using Elektronski_Dnevnik.Models.DTOs;
using Elektronski_Dnevnik.Repositories;

namespace Elektronski_Dnevnik.Services
{
    public class PupilService : IPupilService
    {
        private IUnitOfWork context;
        public PupilService(IUnitOfWork context)
        { this.context = context; }
        public IEnumerable<Pupil> GetAllPupils()
        {
            return context.PupilsRepository.Get();
        }
        public void Delete(Pupil pupil)
        {
            context.UsersRepository.Delete(pupil);
            context.Save();
            
        }

        public Pupil GetById(string id)
        {
            return context.PupilsRepository.GetByID(id);
                
            
        }

       

        public Pupil Update(PupilDTO pupil)
        {                                

                var pupil1 = pupil.ToPupil();
                context.PupilsRepository.Update(pupil1);
                context.Save();
                return pupil1;
            
            
        }
    }
}
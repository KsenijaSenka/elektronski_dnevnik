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
    public class ParentService : IParentService
    {
        private IUnitOfWork context;
        public ParentService(IUnitOfWork context)
        { this.context = context; }
        public IEnumerable<Parent> GetAllParents()
        {
            return context.ParentRepository.Get();
        }
        public Parent GetByParentId(string id)
        {
            return context.ParentRepository.GetByID(id);
        }
        public ParentDTO GetById(string id)
        {
            return context.ParentRepository.GetByID(id).ToParentDTO();
            
        }

       

        public void Delete(Parent parent1)
        {
            context.UsersRepository.Delete(parent1);
            context.Save();
            
        }

        public Parent Update(ParentDTO parent)
        {
            var parent1 = parent.ToParent();
            context.ParentRepository.Update(parent1);
            context.Save();
            return parent1;
            
        }

       
    }
}
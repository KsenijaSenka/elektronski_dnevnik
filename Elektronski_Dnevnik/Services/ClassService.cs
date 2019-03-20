using Elektronski_Dnevnik.Models;
using Elektronski_Dnevnik.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elektronski_Dnevnik.Services
{
    public class ClassService : IClassService
    {
        private IUnitOfWork context;
        public ClassService(IUnitOfWork context)
        {
            this.context = context;
        }
        public StudentClass GetById(int id)
        {
            return context.ClassRepository.GetByID(id);
        }
    }
}
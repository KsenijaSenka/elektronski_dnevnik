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
    public class MarkService : IMarkService
    {
        private IUnitOfWork context;
        public MarkService(IUnitOfWork context)
        { this.context = context; }

        public IEnumerable<Marks> GetAllMarks()
        { return context.MarkRepository.Get(); }

        public Marks Create(PostMarkDTO mark)
        {
            var mark1 = mark.ToMark();
            context.MarkRepository.Insert(mark1);
            context.Save();
            return mark1;
        }

        public MarksDTO GetById(int id)

        {  return context.MarkRepository.GetByID(id).ToPostMarkDTO(); }

        public Marks GetMarkById(int id)

        { return context.MarkRepository.GetByID(id); }



        public Marks Update(PostMarkDTO mark)

        {
            
            var mark1 = mark.ToMark();
            context.MarkRepository.Update(mark1);
            context.Save();
            return mark1;
        }
        public void Delete(Marks mark)
        {
            context.MarkRepository.Delete(mark);
            context.Save();
        }

      
    }
}
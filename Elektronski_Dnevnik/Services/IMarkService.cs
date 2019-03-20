using Elektronski_Dnevnik.Models;
using Elektronski_Dnevnik.Models.DTOs;
using System.Collections.Generic;

namespace Elektronski_Dnevnik.Services
{
    public interface IMarkService
    {
        IEnumerable<Marks> GetAllMarks();
        Marks Create(PostMarkDTO mark);
         MarksDTO GetById(int id);
        Marks GetMarkById(int id);
        Marks Update(PostMarkDTO mark);
        void Delete(Marks mark);
        
    }
}
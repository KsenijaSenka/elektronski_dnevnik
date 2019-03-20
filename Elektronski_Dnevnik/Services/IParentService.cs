using Elektronski_Dnevnik.Models;
using Elektronski_Dnevnik.Models.DTOs;
using System.Collections.Generic;

namespace Elektronski_Dnevnik.Services
{
    public interface IParentService
    {
        void Delete(Parent parent1);
        Parent Update(ParentDTO parent);
        
        ParentDTO GetById(string id);
        IEnumerable <Parent> GetAllParents();
        Parent GetByParentId(string id);
    }
}
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoozeFitness.Data
{
    public interface IRepository<T>
    {
        
        T GetById(int id);
       IEnumerable<T> GetAll();
        void Add(T entity);
    
        void Delete(int id);

        void Delete(T entity);

        void DisposeContext();

        
    }
}

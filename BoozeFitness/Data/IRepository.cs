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
        
        Task<T> GetByIdAsync(int id);
        IEnumerable<T> GetAll();
        Task AddAsync(T entity);
    
        Task DeleteAsync(int id);

        Task DeleteAsync(T entity);

        void DisposeContext();

        
    }
}

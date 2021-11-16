using HospitalClassLibrary.GraphicalEditor.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalClassLibrary.GraphicalEditor.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task SaveChanges();
    }
}

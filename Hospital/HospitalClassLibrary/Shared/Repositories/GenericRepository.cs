using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalClassLibrary.Data;
using HospitalClassLibrary.GraphicalEditor.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalClassLibrary.Shared.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext Context;

        public GenericRepository(AppDbContext context)
        {
            Context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public async Task CreateAsync(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
            await SaveChanges();
        }

        public async Task UpdateAsync(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await SaveChanges();
        }

        public async Task DeleteAsync(T entity)
        {
            Context.Set<T>().Remove(entity);
            await SaveChanges();
        }

        public async Task SaveChanges()
        {
            await Context.SaveChangesAsync();
        }
    }
}

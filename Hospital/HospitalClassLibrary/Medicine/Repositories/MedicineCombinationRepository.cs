using HospitalClassLibrary.Data;
using HospitalClassLibrary.Medicine.Models;
using HospitalClassLibrary.Medicine.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalClassLibrary.Medicine.Repositories
{
    public class MedicineCombinationRepository : IMedicineCombinationRepository
    {
        private readonly AppDbContext _dataContext;
        public MedicineCombinationRepository(AppDbContext dataContext) => _dataContext = dataContext;

        public Task CreateAsync(MedicineCombination entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(MedicineCombination entity)
        {
            _dataContext.MedicineCombination.Remove(entity);
            _dataContext.SaveChanges();
        }

        public Task DeleteAsync(MedicineCombination entity)
        {
            throw new NotImplementedException();
        }

        public List<MedicineCombination> GetAll()
        {
            return _dataContext.MedicineCombination.ToList();
        }

        public Task<IEnumerable<MedicineCombination>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public List<MedicineCombination> GetByFirstMedicineId(int firstMedicineId)
        {
            return _dataContext.MedicineCombination.Where(m => m.FirstMedicineId == firstMedicineId).ToList();
        }

        public Task<MedicineCombination> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(MedicineCombination entity)
        {
            _dataContext.MedicineCombination.Add(entity);
            _dataContext.SaveChanges();
            return true;
        }

        public Task SaveChanges()
        {
            throw new NotImplementedException();
        }

        public bool Update(MedicineCombination entity)
        {
            bool success = false;
            var result = _dataContext.MedicineCombination.SingleOrDefault(m => m.Id == entity.Id);
            if (result != null)
            {
                _dataContext.Update(entity);
                _dataContext.SaveChanges();
                success = true;
            }
            return success;
        }

        public Task UpdateAsync(MedicineCombination entity)
        {
            throw new NotImplementedException();
        }
    }
}

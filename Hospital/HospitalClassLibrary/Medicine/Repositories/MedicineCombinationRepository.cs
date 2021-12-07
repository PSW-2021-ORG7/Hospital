using backend.DAL;
using backend.Model;
using backend.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Repositories
{
    public class MedicineCombinationRepository : IMedicineCombinationRepository
    {
        private readonly DrugStoreContext _dataContext;
        public MedicineCombinationRepository(DrugStoreContext dataContext) => _dataContext = dataContext;

        public void Delete(MedicineCombination entity)
        {
            _dataContext.MedicineCombination.Remove(entity);
            _dataContext.SaveChanges();
        }

        public List<MedicineCombination> GetAll()
        {
            return _dataContext.MedicineCombination.ToList();
        }

        public List<MedicineCombination> GetByFirstMedicineId(int firstMedicineId)
        {
            return _dataContext.MedicineCombination.Where(m => m.FirstMedicineId == firstMedicineId).ToList();
        }

        public bool Save(MedicineCombination entity)
        {
            _dataContext.MedicineCombination.Add(entity);
            _dataContext.SaveChanges();
            return true;
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
    }
}

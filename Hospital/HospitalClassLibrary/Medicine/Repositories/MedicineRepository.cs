using HospitalClassLibrary.Data;
using HospitalClassLibrary.Medicine.DTOs;
using HospitalClassLibrary.Medicine.Models;
using HospitalClassLibrary.Medicine.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HospitalClassLibrary.Medicine.Repositories
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly AppDbContext _dataContext;

        public MedicineRepository(AppDbContext dataContext) => _dataContext = dataContext;

        public bool MedicineExists(MedicineQuantityCheck DTO)
        {
            if (_dataContext.Medicine.Any(m => m.Id.Equals(DTO.MedicineId)  && m.DosageInMilligrams.Equals(DTO.DosageInMg))) return true;
            return false;
        }

        public void Delete(Models.Medicine medicine)
        {
            _dataContext.Medicine.Remove(medicine);
            _dataContext.SaveChanges();
        }

        public List<Models.Medicine> GetAll() { 
            return _dataContext.Medicine.Include(m => m.Ingredients).ToList();
         }

       public Models.Medicine GetByName(string name)
        {
            return _dataContext.Medicine.Include(m => m.Ingredients).SingleOrDefault(m => m.Name == name);
        }

        public bool Save(Models.Medicine medicine)
        {
            if (_dataContext.Medicine.Any(m => m.Name == medicine.Name && m.DosageInMilligrams == medicine.DosageInMilligrams)) return false;
            ExcludeIngredientDuplicates(medicine);
            _dataContext.Add(medicine);
            _dataContext.SaveChanges();
            return true;
        }

        private void ExcludeIngredientDuplicates(Models.Medicine medicine)
        {
            var duplicates = _dataContext.Ingredient
                .AsEnumerable()
                .Where(i => medicine.Ingredients.Any(m => m.Name.Equals(i.Name)))
                .ToList();
            foreach (Ingredient duplicate in duplicates)
            {
                var itemToRemove = medicine.Ingredients.Single(m => m.Name == duplicate.Name);
                medicine.Ingredients.Remove(itemToRemove);
            }
        }

        public bool Update(Models.Medicine medicine)
        {
            bool success = false;
            var result = _dataContext.Medicine.SingleOrDefault(m => m.Id == medicine.Id);
            if (result != null)
            {
                _dataContext.Update(medicine);
                _dataContext.SaveChanges();
                success = true;
            }
            return success;

        }

        public Models.Medicine GetByID(int id)
        {
            return _dataContext.Medicine.Include(m => m.Ingredients).SingleOrDefault(m => m.Id.Equals(id));
        }
    }
}

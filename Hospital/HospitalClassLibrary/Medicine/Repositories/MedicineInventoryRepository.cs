using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalClassLibrary.Medicine.Repositories
{
    public class MedicineInventoryRepository : IMedicineInventoryRepository
    {
        private readonly DrugStoreContext _dataContext;

        public MedicineInventoryRepository(DrugStoreContext dataContext) => _dataContext = dataContext;

        public bool CheckMedicineQuantity(MedicineInventory medicineInventory)
        {
            if (_dataContext.MedicineInventory.Any(m => m.MedicineId.Equals(medicineInventory.MedicineId) 
            && m.Quantity <= medicineInventory.Quantity)) return true;
            return false;
        }

        public void Delete(MedicineInventory entity)
        {
            _dataContext.MedicineInventory.Remove(entity);
            _dataContext.SaveChanges();
        }

        public List<MedicineInventory> GetAll()
        {
            return _dataContext.MedicineInventory.ToList();
        }

        public bool Save(MedicineInventory entity)
        {
            _dataContext.MedicineInventory.Add(entity);
            _dataContext.SaveChanges();
            return true;
        }

        public bool Update(MedicineInventory entity)
        {
            var result = _dataContext.MedicineInventory.SingleOrDefault(m => m.MedicineId == entity.MedicineId);
            if (result != null)
            {
                result.Quantity = entity.Quantity;
                if (result.Quantity < 0) return false;
                _dataContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool ReduceMedicineQuantity(MedicineInventory entity)
        {
            var medicines = GetAll();
            var result = medicines.SingleOrDefault(m => m.MedicineId == entity.MedicineId);
            if (result != null)
            {
                result.Quantity -= entity.Quantity;
                if (result.Quantity < 0) return false;
                _dataContext.SaveChanges();
                return true;
            }
            return false;
        }



    }
}

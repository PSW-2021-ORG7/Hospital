using HospitalClassLibrary.Medicine.Models;
using HospitalClassLibrary.Medicine.Repositories.Interfaces;
using System.Collections.Generic;

namespace backend.Services
{
    public class MedicineInventoryService
    {
        IMedicineInventoryRepository medicineInventoryRepository;
        public MedicineInventoryService(IMedicineInventoryRepository medicineInventoryRepository)
        {
            this.medicineInventoryRepository = medicineInventoryRepository;
        }

        public void Save(MedicineInventory medicineInventory)
        {
            medicineInventoryRepository.Save(medicineInventory);
        }

        public bool Update(MedicineInventory medicineInventory)
        {
            if (medicineInventoryRepository.Update(medicineInventory)) return true;
            return false;
        }

        public bool ReduceMedicineQuantity(MedicineInventory medicineInventory)
        {
            bool updated = medicineInventoryRepository.ReduceMedicineQuantity(medicineInventory);
            if (updated) return true;
            return false;
        }

        public List<MedicineInventory> UpdateMultipleMedicines(List<MedicineInventory> medicines)
        {
            List<MedicineInventory> medicinesUnableToUpdate = new List<MedicineInventory>();
            foreach (MedicineInventory medicine in medicines)
            {
                if (!medicineInventoryRepository.Update(medicine)) medicinesUnableToUpdate.Add(medicine);
            }
            return medicinesUnableToUpdate;
        }

        public bool DeleteMedicineInventory(MedicineInventory medicineInventory)
        {
            medicineInventoryRepository.Delete(medicineInventory);
            return true; //napomena!
        }
    }
}

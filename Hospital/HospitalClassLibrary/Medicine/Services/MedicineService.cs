using HospitalClassLibrary.Medicine.DTOs;
using HospitalClassLibrary.Medicine.Models;
using HospitalClassLibrary.Medicine.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace HospitalClassLibrary.Medicine.Services
{
    public class MedicineService
    {
        IMedicineRepository medicineRepository;
        IMedicineInventoryRepository medicineInventoryRepository;

        public MedicineService(IMedicineRepository medicineRepository, IMedicineInventoryRepository medicineInventoryRepository) { 
            this.medicineRepository = medicineRepository;
            this.medicineInventoryRepository = medicineInventoryRepository;
        }

        public List<Models.Medicine> GetAll() => medicineRepository.GetAll();

        public bool Save(Models.Medicine medicine) {
            if (medicineRepository.Save(medicine)) return true;
            return false;
        }


        public Models.Medicine GetByNameAndDose(string name, int dose)
        {
            return medicineRepository.GetByNameAndDose(name, dose);
        }

        public Models.Medicine GetByName(string name)
        {
            return medicineRepository.GetByName(name);
        }

        public Models.Medicine GetByID(int id)
        {
            return medicineRepository.GetByID(id);
        }

        public List<Models.Medicine> MedicineSearchResults(MedicineSearchParams searchParams)
        {
            return medicineRepository.GetAll().Where(m => m.Name.ToLower().Contains(searchParams.Name.ToLower())
                                                          && m.Description.ToLower().Contains(searchParams.Description.ToLower())
                                                          && m.Manufacturer.ToLower().Contains(searchParams.Manufacturer.ToLower())
                                                          && m.Ingredients.Any(i => i.Name.ToLower().Contains(searchParams.Ingredient.ToLower())))
                                                 .ToList();
        }

        public bool MedicineExists(Models.Medicine medicine)
        {
            return medicineRepository.MedicineExists(medicine);
        }
    }
}

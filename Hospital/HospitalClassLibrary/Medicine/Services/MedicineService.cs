using HospitalClassLibrary.Medicine.Models;
using HospitalClassLibrary.Medicine.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public bool CheckMedicineQuantity(MedicineQuantityCheck DTO)
        {
            if (medicineRepository.MedicineExists(DTO))
               if(medicineInventoryRepository.CheckMedicineQuantity(new MedicineInventory(DTO.MedicineId,DTO.Quantity)))
                    return true;
            return false;
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

        //public List<Models.Medicine> MedicineFilterDosageResults(MedicineDosageFilter option)
        //{
        //    int from;
        //    int to;
        //    switch((int)option)
        //    {
        //        case 0: from = 0; to = 200; break;
        //        case 1: from = 200; to = 400; break;
        //        case 2: from = 400; to = 600; break;
        //        default: from = 600; to = int.MaxValue; break;
        //    }

        //    return medicineRepository.GetAll().Where(m => m.DosageInMilligrams >= from && m.DosageInMilligrams <= to).ToList();
        //}
    }
}

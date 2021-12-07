using HospitalClassLibrary.Medicine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalClassLibrary.Medicine.Repositories.Interfaces
{
    public interface IMedicineInventoryRepository : IGenericRepository<MedicineInventory>
    {
        public bool CheckMedicineQuantity(MedicineInventory medicineInventory);
        public bool ReduceMedicineQuantity(MedicineInventory entity);
    }
}

using HospitalClassLibrary.Medicine.Models;

namespace HospitalClassLibrary.Medicine.Repositories.Interfaces
{
    public interface IMedicineInventoryRepository : IGenericRepository<MedicineInventory>
    {
        bool CheckMedicineQuantity(MedicineInventory medicineInventory);
        bool ReduceMedicineQuantity(MedicineInventory entity);
    }
}

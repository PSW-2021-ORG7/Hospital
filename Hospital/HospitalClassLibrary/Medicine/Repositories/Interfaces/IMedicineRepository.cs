using HospitalClassLibrary.Medicine.DTOs;

namespace HospitalClassLibrary.Medicine.Repositories.Interfaces
{
    public interface IMedicineRepository : IGenericRepository<Models.Medicine>
    {
         bool MedicineExists(MedicineQuantityCheck DTO);
         Models.Medicine GetByName(string name);
         Models.Medicine GetByID(int id);
    }
}

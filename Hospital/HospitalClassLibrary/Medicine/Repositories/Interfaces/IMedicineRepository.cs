using HospitalClassLibrary.Medicine.DTOs;

namespace HospitalClassLibrary.Medicine.Repositories.Interfaces
{
    public interface IMedicineRepository : IGenericRepository<Models.Medicine>
    {
         bool MedicineExists(Models.Medicine medicine);
         Models.Medicine GetByName(string name);
         Models.Medicine GetByID(int id);
         Models.Medicine GetByNameAndDose(string name, int dose);
    }
}

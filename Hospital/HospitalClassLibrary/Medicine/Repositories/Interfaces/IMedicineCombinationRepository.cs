using HospitalClassLibrary.Medicine.Models;
using System.Collections.Generic;

namespace HospitalClassLibrary.Medicine.Repositories.Interfaces
{
    public interface IMedicineCombinationRepository : IGenericRepository<MedicineCombination>
    {
        List<MedicineCombination> GetByFirstMedicineId(int firstMedicineId);
    }
}

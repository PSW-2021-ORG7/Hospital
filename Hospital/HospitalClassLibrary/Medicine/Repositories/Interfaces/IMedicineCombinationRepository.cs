using HospitalClassLibrary.Medicine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalClassLibrary.Medicine.Repositories.Interfaces
{
    public interface IMedicineCombinationRepository : IGenericRepository<MedicineCombination>
    {
        List<MedicineCombination> GetByFirstMedicineId(int firstMedicineId);
    }
}

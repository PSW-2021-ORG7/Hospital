using System;
using System.Collections.Generic;

namespace HospitalClassLibrary.Medicine.Repositories.Interfaces
{
    public interface IMedicineRepository : IGenericRepository<Models.Medicine>
    {
         bool MedicineExists(MedicineQuantityCheck DTO);
         Models.Medicine GetByName(string name);
         Models.Medicine GetByID(int id);
    }
}

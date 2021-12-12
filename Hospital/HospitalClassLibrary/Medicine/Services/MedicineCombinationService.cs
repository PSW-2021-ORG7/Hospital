using HospitalClassLibrary.Medicine.Models;
using HospitalClassLibrary.Medicine.Repositories.Interfaces;
using System.Collections.Generic;

namespace backend.Services
{
    public class MedicineCombinationService
    {
        private IMedicineCombinationRepository _medicineCombinationRepository;

        public MedicineCombinationService(IMedicineCombinationRepository medicineCombinationRepository)
        {
            this._medicineCombinationRepository = medicineCombinationRepository;
        }

        public bool Save(int id, int m)
        {
            return _medicineCombinationRepository.Save(new MedicineCombination(id, m));
        }

        public List<MedicineCombination> GetMedicinesCombination(int firstMedicineId)
        {
            return _medicineCombinationRepository.GetByFirstMedicineId(firstMedicineId);
        }
    }
}

using backend.Model;
using backend.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return _medicineCombinationRepository.Save(new Model.MedicineCombination(id, m));
        }

        public List<MedicineCombination> GetMedicinesCombination(int firstMedicineId)
        {
            return _medicineCombinationRepository.GetByFirstMedicineId(firstMedicineId);
        }
    }
}

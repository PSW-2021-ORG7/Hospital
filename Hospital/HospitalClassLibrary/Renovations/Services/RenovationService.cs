using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalClassLibrary.Renovations.Models;
using HospitalClassLibrary.Renovations.Repositories.Interfaces;
using HospitalClassLibrary.Renovations.Services.Interfaces;

namespace HospitalClassLibrary.Renovations.Services
{
    public class RenovationService : IRenovationService
    {
        private readonly ISplitRenovationRepository _splitRenovationRepository;

        public RenovationService(ISplitRenovationRepository splitRenovationRepository)
        {
            _splitRenovationRepository = splitRenovationRepository;
        }

        public async Task<IEnumerable<SplitRenovation>> GetAll()
        {
            return await _splitRenovationRepository.GetAllAsync();
        }

        public async Task Create(SplitRenovation r)
        {
            await _splitRenovationRepository.CreateAsync(r);
        }

        public async Task Delete(SplitRenovation r)
        {
            await _splitRenovationRepository.DeleteAsync(r);
        }

    }
}

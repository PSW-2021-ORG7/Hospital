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
        private readonly IMergeRenovationRepository _mergeRenovationRepository;

        public RenovationService(ISplitRenovationRepository splitRenovationRepository, IMergeRenovationRepository mergeRenovationRepository)
        {
            _splitRenovationRepository = splitRenovationRepository;
            _mergeRenovationRepository = mergeRenovationRepository;
        }

        public async Task<IEnumerable<SplitRenovation>> GetAllSplitRenovations()
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

        public async Task<IEnumerable<MergeRenovation>> GetAllMergeRenovations()
        {
            return await _mergeRenovationRepository.GetAllAsync();
        }

        public async Task Create(MergeRenovation r)
        {
            await _mergeRenovationRepository.CreateAsync(r);
        }

        public async Task Delete(MergeRenovation r)
        {
            await _mergeRenovationRepository.CreateAsync(r);
        }
    }
}

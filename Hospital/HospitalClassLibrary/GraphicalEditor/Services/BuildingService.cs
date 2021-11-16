using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalClassLibrary.GraphicalEditor.Models;
using HospitalClassLibrary.GraphicalEditor.Repositories.Interfaces;
using HospitalClassLibrary.GraphicalEditor.Services.Interfaces;

namespace HospitalClassLibrary.GraphicalEditor.Services
{
    public class BuildingService : IBuildingService
    {
        private readonly IBuildingRepository _buildingRepository;

        public BuildingService(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }

        public async Task<Building> GetById(int id)
        {
            return await _buildingRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Building>> GetAll()
        {
            return await _buildingRepository.GetAllAsync();
        }

        public async Task Create(Building b)
        {
            await _buildingRepository.CreateAsync(b);
        }

        public async Task Update(Building b)
        {
            await _buildingRepository.UpdateAsync(b);
        }

        public async Task Delete(Building b)
        {
            await _buildingRepository.DeleteAsync(b);
        }
    }
}

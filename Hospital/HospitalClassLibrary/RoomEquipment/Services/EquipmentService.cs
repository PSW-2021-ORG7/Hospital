using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalClassLibrary.RoomEquipment.Models;
using HospitalClassLibrary.RoomEquipment.Repositories.Interfaces;
using HospitalClassLibrary.RoomEquipment.Services.Interfaces;

namespace HospitalClassLibrary.RoomEquipment.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public EquipmentService(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }
        public async Task<Equipment> GetById(int id)
        {
            return await _equipmentRepository.GetByIdAsync(id);
        }
        public async Task<IEnumerable<Equipment>> GetAll()
        {
            return await _equipmentRepository.GetAllAsync();
        }

        public async Task Create(Equipment e)
        {
            await _equipmentRepository.CreateAsync(e);
        }
        public async Task Update(Equipment e)
        {
            await _equipmentRepository.UpdateAsync(e);
        }

        public async Task Delete(Equipment e)
        {
            await _equipmentRepository.DeleteAsync(e);
        }
    }
}

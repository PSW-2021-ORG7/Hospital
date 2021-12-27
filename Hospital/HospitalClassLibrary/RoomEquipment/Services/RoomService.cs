using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalClassLibrary.RoomEquipment.Models;
using HospitalClassLibrary.RoomEquipment.Repositories.Interfaces;
using HospitalClassLibrary.RoomEquipment.Services.Interfaces;

namespace HospitalClassLibrary.RoomEquipment.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<Room> GetById(int id)
        {
            return await _roomRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Room>> GetAll()
        {
            return await _roomRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Room>> GetAll(int buildingId)
        {
            return await _roomRepository.GetAll(buildingId);
        }

        public async Task<Room> GetRoomWithEquipment(int id)
        {
            return await _roomRepository.GetRoomWithEquipment(id);
        }

        public async Task Create(Room r)
        {
            await _roomRepository.CreateAsync(r);
        }

        public async Task Update(Room r)
        {
            await _roomRepository.UpdateAsync(r);
        }

        public async Task Delete(Room r)
        {
            await _roomRepository.DeleteAsync(r);
        }

    }
}

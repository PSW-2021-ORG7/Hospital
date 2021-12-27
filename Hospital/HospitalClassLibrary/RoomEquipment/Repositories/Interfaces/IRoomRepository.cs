using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalClassLibrary.RoomEquipment.Models;
using HospitalClassLibrary.Shared.Repositories;

namespace HospitalClassLibrary.RoomEquipment.Repositories.Interfaces
{
    public interface IRoomRepository : IGenericRepository<Room>
    {
        Task<IEnumerable<Room>> GetAll(int buildingId);
        Task<Room> GetRoomWithEquipment(int id);
        int GetDoctorId(int roomId);
        Task<int> GetRoomId(string name);
    }
}

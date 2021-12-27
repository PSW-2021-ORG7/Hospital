using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalClassLibrary.RoomEquipment.Models;

namespace HospitalClassLibrary.RoomEquipment.Services.Interfaces
{
    public interface IRoomService
    {
        Task<Room> GetById(int id);
        Task<IEnumerable<Room>> GetAll();
        Task<IEnumerable<Room>> GetAll(int buildingId);
        Task<Room> GetRoomWithEquipment(int id);
        Task Create(Room r);
        Task Update(Room r);
        Task Delete(Room r);
    }
}

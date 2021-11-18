using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalClassLibrary.GraphicalEditor.Models;

namespace HospitalClassLibrary.GraphicalEditor.Services.Interfaces
{
    public interface IRoomService
    {
        Task<Room> GetById(int id);
        Task<IEnumerable<Room>> GetAll();
        Task<IEnumerable<Room>> GetAll(int buildingId);
        Task<IEnumerable<Room>> GetRoomsWithEquipment(int id);
        Task Create(Room r);
        Task Update(Room r);
        Task Delete(Room r);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalClassLibrary.GraphicalEditor.Models;
using HospitalClassLibrary.Shared.Repositories;

namespace HospitalClassLibrary.GraphicalEditor.Repositories.Interfaces
{
    public interface IRoomRepository : IGenericRepository<Room>
    {
        Task<IEnumerable<Room>> GetAll(int buildingId);
        Task<Room> GetRoomWithEquipment(int id);
    }
}

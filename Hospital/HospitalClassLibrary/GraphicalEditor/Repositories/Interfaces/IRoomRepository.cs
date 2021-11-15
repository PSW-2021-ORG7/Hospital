using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalClassLibrary.GraphicalEditor.Models;

namespace HospitalClassLibrary.GraphicalEditor.Repositories.Interfaces
{
    public interface IRoomRepository
    {
        Task<List<Room>> GetAllRooms();
        Task<Room> GetRoomById(String id);
        Task<int> PutRoom(String id, Room room);
    }
}

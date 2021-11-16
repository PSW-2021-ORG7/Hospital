using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hospital_Class_Library.Graphical_Editor.Models;

namespace Hospital_Class_Library.Graphical_Editor.Interfaces
{
    public interface IRoomRepository
    {
        Task<List<Room>> GetAllRooms();
        Task<Room> GetRoomById(String id);
        Task<int> PutRoom(String id, Room room);
    }
}

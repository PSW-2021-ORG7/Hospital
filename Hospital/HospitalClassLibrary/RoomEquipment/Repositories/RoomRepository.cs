using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalClassLibrary.Data;
using HospitalClassLibrary.RoomEquipment.Models;
using HospitalClassLibrary.RoomEquipment.Repositories.Interfaces;
using HospitalClassLibrary.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HospitalClassLibrary.RoomEquipment.Repositories
{
    public class RoomRepository : GenericRepository<Room>, IRoomRepository
    {
        public RoomRepository(AppDbContext context) : base(context)
        {
        }

        public new async Task<Room> GetByIdAsync(int id)
        {
            return await Context.Room.Where(r => r.Id == id).Include(r => r.RoomDimensions).Include(r => r.Equipment).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Room>> GetAll(int buildingId)
        {
            return await Context.Room.Where(r => r.BuildingId == buildingId).Select(r => r).Include(r => r.RoomDimensions).ToListAsync();
        }

        public int GetDoctorId(int roomId)
        {
            var rooms = Context.Room.Where(r => r.Id == roomId).Include(r => r.Doctor).ToList();

            if (rooms.Count <= 0) return -1;
            if (rooms.First().Doctor == null)
            {
                return -1;
            }
            return rooms.First().Doctor.Id;

        }

        public async Task<int> GetRoomId(string name)
        {
            return await Context.Room.Where(r => r.Name == name).Select(r => r.Id).FirstOrDefaultAsync();
        }

        public async Task<Room> GetRoomWithEquipment(int id)
        {
            var rooms = await Context.Room.Where(r => r.Id == id).Include(r => r.Equipment)
                .ThenInclude(e => e.EquipmentItem).ToListAsync();

            return rooms.First();
        }
    }

}

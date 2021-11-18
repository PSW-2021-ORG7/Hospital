using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalClassLibrary.Data;
using HospitalClassLibrary.GraphicalEditor.Models;
using HospitalClassLibrary.GraphicalEditor.Repositories.Interfaces;
using HospitalClassLibrary.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HospitalClassLibrary.GraphicalEditor.Repositories
{
    public class RoomRepository : GenericRepository<Room>, IRoomRepository
    {
        public RoomRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Room>> GetAll(int buildingId)
        {
            return await Context.Rooms.Where(r => r.BuildingId == buildingId).Select(r => r).ToListAsync();
        }

        public async Task<IEnumerable<Room>> GetRoomsWithEquipment(int id)
        {
            return await Context.Rooms.Where(r => r.Id == id).Select(r => r).Include(r => r.Equipment).ThenInclude(e=>e.EquipmentItem).ToListAsync();
        }
    }

}

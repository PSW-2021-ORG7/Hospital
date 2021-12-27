using HospitalClassLibrary.Data;
using HospitalClassLibrary.RoomEquipment.Models;
using HospitalClassLibrary.RoomEquipment.Repositories.Interfaces;
using HospitalClassLibrary.Shared.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HospitalClassLibrary.RoomEquipment.Repositories
{
    public class EquipmentRepository : GenericRepository<Equipment>, IEquipmentRepository
    {
        public EquipmentRepository(AppDbContext context) : base(context)
        {
        }

        public new async Task<IEnumerable<Equipment>> GetAllAsync()
        {
            return await Context.Equipment.Include(e => e.EquipmentItem).Include(e=>e.Room).ToListAsync();
        }
    }
}

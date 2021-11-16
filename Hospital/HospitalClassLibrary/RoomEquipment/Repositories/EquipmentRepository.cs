using HospitalClassLibrary.Data;
using HospitalClassLibrary.RoomEquipment.Models;
using HospitalClassLibrary.RoomEquipment.Repositories.Interfaces;
using HospitalClassLibrary.Shared.Repositories;

namespace HospitalClassLibrary.RoomEquipment.Repositories
{
    public class EquipmentRepository : GenericRepository<Equipment>, IEquipmentRepository
    {
        public EquipmentRepository(AppDbContext context) : base(context)
        {
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalClassLibrary.RoomEquipment.Models;
using HospitalClassLibrary.Shared.Repositories;

namespace HospitalClassLibrary.RoomEquipment.Repositories.Interfaces
{
    public interface IEquipmentRepository : IGenericRepository<Equipment>
    {
    }
}

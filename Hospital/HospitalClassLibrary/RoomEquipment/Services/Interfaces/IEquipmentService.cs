using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalClassLibrary.RoomEquipment.Models;

namespace HospitalClassLibrary.RoomEquipment.Services.Interfaces
{
    public interface IEquipmentService
    {
        Task<Equipment> GetById(int id);
        Task<IEnumerable<Equipment>> GetAll();
        Task Create(Equipment e);
        Task Update(Equipment e);
        Task Delete(Equipment e);
    }
}

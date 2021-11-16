using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalClassLibrary.GraphicalEditor.Models;

namespace HospitalClassLibrary.GraphicalEditor.Repositories.Interfaces
{
    public interface IRoomRepository : IGenericRepository<Room>
    {
        Task<IEnumerable<Room>> GetAll(int buildingId);
    }
}

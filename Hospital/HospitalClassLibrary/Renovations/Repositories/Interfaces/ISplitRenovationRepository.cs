using HospitalClassLibrary.Renovations.Models;
using HospitalClassLibrary.Shared.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalClassLibrary.Renovations.Repositories.Interfaces
{
    public interface ISplitRenovationRepository : IGenericRepository<SplitRenovation>
    {
        Task<IEnumerable<SplitRenovation>> GetAllByRoomIdAsync(int roomId);
    }
}

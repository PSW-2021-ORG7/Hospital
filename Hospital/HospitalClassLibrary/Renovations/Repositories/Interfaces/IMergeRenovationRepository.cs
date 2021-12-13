using HospitalClassLibrary.Renovations.Models;
using HospitalClassLibrary.Shared.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalClassLibrary.Renovations.Repositories.Interfaces
{
    public interface IMergeRenovationRepository : IGenericRepository<MergeRenovation>
    {
        Task<IEnumerable<MergeRenovation>> GetAllByRoomIdAsync(int roomId);
    }
}

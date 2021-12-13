using HospitalClassLibrary.Renovations.Models;
using HospitalClassLibrary.Shared.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalClassLibrary.Shared.Models;

namespace HospitalClassLibrary.Renovations.Repositories.Interfaces
{
    public interface IMergeRenovationRepository : IGenericRepository<MergeRenovation>
    {
        Task<IEnumerable<MergeRenovation>> GetAllByRoomIdAsync(int roomId);
        Task<IEnumerable<DateTimeRange>> GetAllDates(int firstRoomId, int secondRoomId);
    }
}

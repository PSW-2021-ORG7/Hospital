using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalClassLibrary.Renovations.Models;
using HospitalClassLibrary.Shared.Models;
using HospitalClassLibrary.Shared.Repositories;

namespace HospitalClassLibrary.Renovations.Repositories.Interfaces
{
    public interface ISplitRenovationRepository : IGenericRepository<SplitRenovation>
    {
        Task<IEnumerable<SplitRenovation>> GetAllByRoomIdAsync(int roomId);
        Task<IEnumerable<DateTimeRange>> GetAllDates(int firstRoomId, int secondRoomId);
    }
}

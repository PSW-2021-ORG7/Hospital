using HospitalClassLibrary.Data;
using HospitalClassLibrary.Renovations.Models;
using HospitalClassLibrary.Renovations.Repositories.Interfaces;
using HospitalClassLibrary.Shared.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalClassLibrary.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalClassLibrary.Renovations.Repositories
{
    public class MergeRenovationRepository : GenericRepository<MergeRenovation>, IMergeRenovationRepository
    {
        public MergeRenovationRepository(AppDbContext context) : base(context)
        {
        }

        public new async Task<IEnumerable<MergeRenovation>> GetAllAsync()
        {
            return await Context.MergeRenovation.Include(r => r.NewRoomInfo).ToListAsync();
        }

        public async Task<IEnumerable<MergeRenovation>> GetAllByRoomIdAsync(int roomId)
        {
            return await Context.MergeRenovation.Where(
                r => r.FirstOldRoomId == roomId ||
                r.SecondOldRoomId == roomId)
                .ToListAsync();
        }
        
        public async Task<IEnumerable<DateTimeRange>> GetAllDates(int firstRoomId, int secondRoomId)
        {
            return await Context.MergeRenovation.Where(r => r.FirstOldRoomId == firstRoomId || r.FirstOldRoomId == secondRoomId || r.SecondOldRoomId == firstRoomId || r.SecondOldRoomId == secondRoomId)
                .Select(r => new DateTimeRange(){Start = r.Start, End = r.End}).ToListAsync();
        }

    }
}

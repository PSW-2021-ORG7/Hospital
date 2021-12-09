using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalClassLibrary.Data;
using HospitalClassLibrary.Renovations.Models;
using HospitalClassLibrary.Renovations.Repositories.Interfaces;
using HospitalClassLibrary.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HospitalClassLibrary.Renovations.Repositories
{
    public class SplitRenovationRepository : GenericRepository<SplitRenovation>, ISplitRenovationRepository
    {
        public SplitRenovationRepository(AppDbContext context) : base(context)
        {
        }

        public new async Task<IEnumerable<SplitRenovation>> GetAllAsync()
        {
            return await Context.SplitRenovation.Include(r => r.FirstNewRoomInfo).Include(r => r.SecondNewRoomInfo).ToListAsync();
        }
    }
}

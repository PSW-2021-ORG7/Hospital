using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalClassLibrary.Data;
using HospitalClassLibrary.Schedule.Models;
using HospitalClassLibrary.Schedule.Repositories.Interfaces;
using HospitalClassLibrary.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HospitalClassLibrary.Schedule.Repositories
{
    public class HolidayRepository : GenericRepository<Holiday>, IHolidayRepository
    {
        public HolidayRepository(AppDbContext context) : base(context)
        {
        }

        public new async Task<Holiday> GetByIdAsync(int id)
        {
            return await Context.Holiday.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Holiday>> GetAllByDoctorId(int doctorId)
        {
            return await Context.Holiday.AsNoTracking().Where(h => h.DoctorId == doctorId).ToListAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalClassLibrary.Data;
using HospitalClassLibrary.Schedule.Models;
using HospitalClassLibrary.Schedule.Repositories.Interfaces;
using HospitalClassLibrary.Shared.Models;
using HospitalClassLibrary.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HospitalClassLibrary.Schedule.Repositories
{
    public class ShiftRepository : GenericRepository<Shift>, IShiftRepository
    {
        public ShiftRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Shift>> GetAllAsync(DateTimeRange dateTimeRange)
        {
            return await Context.Shift.Where(
                s =>
                (dateTimeRange.Start == DateTime.MinValue || s.Start >= dateTimeRange.Start) &&
                (dateTimeRange.End == DateTime.MinValue || s.End <= dateTimeRange.End)
            ).ToListAsync();
        }
}
}

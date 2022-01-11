using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalClassLibrary.Data;
using HospitalClassLibrary.Schedule.Models;
using HospitalClassLibrary.Shared.Repositories;
using HospitalClassLibrary.Schedule.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace HospitalClassLibrary.Schedule.Repositories
{
    public class OnCallShiftRepository : GenericRepository<OnCallShift>, IOnCallShiftRepository
    {
        public OnCallShiftRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<OnCallShift>> GetAllOnCallShiftsByDoctorId(int doctorId)
        {
            return await Context.OnCallShift.Where(o => o.DoctorId == doctorId).ToListAsync();
        }

        public async Task<IEnumerable<OnCallShift>> GetOnCallShiftByStartDate(DateTime start)
        {
            return await Context.OnCallShift.Where(o => o.Start == start).ToListAsync();
        }
    }
}

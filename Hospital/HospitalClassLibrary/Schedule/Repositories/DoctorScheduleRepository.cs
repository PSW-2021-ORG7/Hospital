using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalClassLibrary.Data;
using HospitalClassLibrary.Schedule.Models;
using HospitalClassLibrary.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HospitalClassLibrary.Schedule.Repositories.Interfaces
{
    public class DoctorScheduleRepository : GenericRepository<DoctorSchedule>, IDoctorScheduleRepository
    {
        public DoctorScheduleRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<DoctorSchedule> GetScheduleByDoctorId(int id)
        {
            return await Context.DoctorSchedule.Where(ds => ds.Id == id).Include(ds => ds.Holidays).Include(ds => ds.OnCallShifts).Include(ds => ds.Workdays).ThenInclude(w => w.Appointments).Include(ds => ds.Workdays).ThenInclude(w => w.Shift).FirstOrDefaultAsync();
        }
    }
}

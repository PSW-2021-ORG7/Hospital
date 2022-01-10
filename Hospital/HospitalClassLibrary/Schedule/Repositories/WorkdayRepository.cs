using HospitalClassLibrary.Data;
using HospitalClassLibrary.Schedule.Models;
using HospitalClassLibrary.Schedule.Repositories.Interfaces;
using HospitalClassLibrary.Shared.Models;
using HospitalClassLibrary.Shared.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HospitalClassLibrary.Schedule.Repositories
{
    public class WorkdayRepository : GenericRepository<Workday>, IWorkdayRepository
    {
        public WorkdayRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Workday>> GetWorkdays(DateTimeRange dateTimeRange, int doctorId)
        {
            return await Context.Workday.Where(w => w.DoctorId == doctorId && w.Shift.Start >= dateTimeRange.Start && w.Shift.End <= dateTimeRange.End).Include(w => w.Appointments).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointments(DateTimeRange dateTimeRange, int srcRoomDoctorId, int dstRoomDoctorId)
        {
            var srcRoomDoctorWorkdays = await GetWorkdays(dateTimeRange, srcRoomDoctorId);
            var dstRoomDoctorWorkdays = await GetWorkdays(dateTimeRange, dstRoomDoctorId);
            var allWorkdays = (srcRoomDoctorWorkdays ?? Enumerable.Empty<Workday>()).Concat(dstRoomDoctorWorkdays ?? Enumerable.Empty<Workday>()).ToList();

            return  allWorkdays.SelectMany(w => w.Appointments);
        }

        public async Task<IEnumerable<Shift>> GetAllShiftsByDoctorId(int doctorId)
        {
            return await Context.Workday.Where(w => w.DoctorId == doctorId).
                Join(Context.Shift, w => w.ShiftId, s => s.Id,
                (w, s) => new Shift
                {
                    Id = s.Id,
                    Start = s.Start,
                    End = s.End,
                    Name = s.Name
                }).ToListAsync();

        }


    }
}

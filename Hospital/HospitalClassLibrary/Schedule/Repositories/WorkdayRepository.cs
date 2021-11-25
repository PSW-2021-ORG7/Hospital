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

        public IEnumerable<Appointment> GetAppointments(DateTimeRange dateTimeRange, int srcRoomDoctorId, int dstRoomDoctorId)
        {
            var srcRoomDoctorWorkdays = GetWorkdays(dateTimeRange, srcRoomDoctorId).Result;
            var dstRoomDoctorWorkdays = GetWorkdays(dateTimeRange, dstRoomDoctorId).Result;
            var allWorkdays = (srcRoomDoctorWorkdays ?? Enumerable.Empty<Workday>()).Concat(dstRoomDoctorWorkdays ?? Enumerable.Empty<Workday>()).ToList();

            return  allWorkdays.SelectMany(w => w.Appointments);
        }
    }
}

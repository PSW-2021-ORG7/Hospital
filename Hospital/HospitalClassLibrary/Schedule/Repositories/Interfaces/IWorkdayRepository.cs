using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalClassLibrary.Schedule.Models;
using HospitalClassLibrary.Shared.Models;
using HospitalClassLibrary.Shared.Repositories;

namespace HospitalClassLibrary.Schedule.Repositories.Interfaces
{
    public interface IWorkdayRepository : IGenericRepository<Workday>
    {
        Task<IEnumerable<Workday>> GetWorkdays(DateTimeRange dateTimeRange, int doctorId);
        Task<IEnumerable<Appointment>> GetAppointments(DateTimeRange dateTimeRange, int srcRoomDoctorId, int dstRoomDoctorId);
        Task<IEnumerable<object>> GetAllShiftsByDoctorId(int doctorId);
        Task<IEnumerable<Workday>> GetWorkdaysByShiftId(int shiftId);
    }
}

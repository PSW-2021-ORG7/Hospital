using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalClassLibrary.Schedule.Models;
using HospitalClassLibrary.Shared.Models;

namespace HospitalClassLibrary.Schedule.Services.Interfaces
{
    public interface IWorkdayService
    {
        ICollection<DateTimeRange> GetAvailableTimeSlots(TimeSlotsRequirements requirements);
        Task<IEnumerable<Workday>> GetWorkdays(DateTimeRange dateRange, int doctorId);
    }
}

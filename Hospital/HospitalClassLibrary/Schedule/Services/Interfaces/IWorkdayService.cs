using System.Collections.Generic;
using HospitalClassLibrary.Schedule.Models;
using HospitalClassLibrary.Shared.Models;

namespace HospitalClassLibrary.Schedule.Services.Interfaces
{
    public interface IWorkdayService
    {
        ICollection<DateTimeRange> GetAvailableTimeSlots(TimeSlotsRequirements requirements);
    }
}

using System.Collections.Generic;
using HospitalClassLibrary.RoomEquipment.Models;
using HospitalClassLibrary.Shared.Models;

namespace HospitalClassLibrary.Schedule.Services.Interfaces
{
    public interface IWorkdayService
    {
        ICollection<DateTimeRange> GetAvailableTimeSlots(EquipmentTransferRequirements requirements);
    }
}

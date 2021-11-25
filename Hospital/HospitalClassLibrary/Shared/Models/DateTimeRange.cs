using System;
using HospitalClassLibrary.RoomEquipment.Models;
using HospitalClassLibrary.Schedule.Models;

namespace HospitalClassLibrary.Shared.Models
{
    public class DateTimeRange
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public bool OverlapsWith(Appointment appointment)
        {
            return Overlaps(appointment.StartTime, appointment.EndTime);
        }

        public bool OverlapsWith(EquipmentTransfer transfer)
        {
            return Overlaps(transfer.TransferDate, transfer.TransferDate.AddMinutes(transfer.TransferDuration));
        }

        private bool Overlaps(DateTime start, DateTime end)
        {
            return start < End && Start < end;
        }
    }
}

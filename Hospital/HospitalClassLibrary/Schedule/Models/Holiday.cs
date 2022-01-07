using System;
using static HospitalClassLibrary.Shared.Constants;

namespace HospitalClassLibrary.Schedule.Models
{
    public class Holiday
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public bool CanDoctorTakeHoliday()
        {
            var definedHoliday = (End - Start).Days;
            var availableOffDays = MaxOffDays - Doctor.UsedOffDays;

            return definedHoliday <= availableOffDays;
        }

        public bool Overlaps(Holiday holiday)
        {
            return Start < holiday.End && holiday.Start < End;
        }
    }
}

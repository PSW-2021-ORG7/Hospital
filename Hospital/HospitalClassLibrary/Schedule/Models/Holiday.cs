using System;
using static HospitalClassLibrary.Shared.Constants;

namespace HospitalClassLibrary.Schedule.Models
{
    public class Holiday
    {
        public int Id { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
        public int DoctorId { get; private set; }
        public Doctor Doctor { get; private set; }
        public string Description { get; private set; }

        public Holiday()
        {
        }

        public Holiday(int id, DateTime start, DateTime end, int doctorId, Doctor doctor, string description)
        {
            Id = id;
            Start = start;
            End = end;
            DoctorId = doctorId;
            Doctor = doctor;
            Description = description;
            Validate();
        }

        private void Validate()
        {
            if (Doctor == null)
            {
                throw new ArgumentException("Doctor doesn't exist");
            }

            if (!CanDoctorTakeHoliday() || Start > End)
            {
                throw new ArgumentException("Not valid");
            }
        }

        private bool CanDoctorTakeHoliday()
        {
            var definedHoliday = (End - Start).Days;
            var availableOffDays = MaxOffDays - Doctor.UsedOffDays;

            return definedHoliday <= availableOffDays;
        }

        public bool Overlaps(Holiday holiday)
        {
            return Start <= holiday.End && holiday.Start <= End;
        }
    }
}

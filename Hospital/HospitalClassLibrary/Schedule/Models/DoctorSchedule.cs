using System;
using System.Collections.Generic;

namespace HospitalClassLibrary.Schedule.Models
{
    public class DoctorSchedule
    {
        public int Id { get; private set; }

        public int DoctorId { get; private set; }

        public ICollection<Holiday> Holidays { get; private set; }

        public ICollection<OnCallShift> OnCallShifts { get; private set; }

        public ICollection<Workday> Workdays { get; private set; }

        public DoctorSchedule() { }

        public DoctorSchedule(int id, int doctorId)
        {
            Id = id;
            DoctorId = doctorId;
        }

        public DoctorSchedule(int id, int doctorId, ICollection<Holiday> holidays, ICollection<OnCallShift> onCallShifts, ICollection<Workday> workdays)
        {
            Id = id;
            DoctorId = doctorId;
            Holidays = holidays;
            OnCallShifts = onCallShifts;
            Workdays = workdays;
            Validate();
        }

        private void Validate()
        {
            if (DoctorId < 1)
            {
                throw new ArgumentException("Doctor doesn't exist");
            }
        }
    }
}

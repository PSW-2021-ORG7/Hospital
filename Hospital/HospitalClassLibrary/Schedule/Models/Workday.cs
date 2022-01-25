using System;
using System.Collections.Generic;

namespace HospitalClassLibrary.Schedule.Models
{
    public class Workday
    {
        public int Id { get; private set; }

        public int DoctorId { get; private set; }

        public int ShiftId { get; private set; }
        public Shift Shift { get; private set; }

        public ICollection<Appointment> Appointments { get; private set; }

        public Workday() { }

        public Workday(int id, int doctorId, int shiftId)
        {
            Id = id;
            DoctorId = doctorId;
            ShiftId = shiftId;
        }

        public Workday(int id, int doctorId, int shiftId, Shift shift,
            ICollection<Appointment> appointments)
        {
            Id = id;
            DoctorId = doctorId;
            ShiftId = shiftId;
            Shift = shift;
            Appointments = appointments;
            Validate();
        }

        private void Validate()
        {
            if (DoctorId < 1)
            {
                throw new ArgumentException("Doctor doesn't exist");
            }

            if (Shift == null)
            {
                throw new ArgumentException("Shift doesn't exist");
            }
        }
    }
}

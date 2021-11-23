using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalClassLibrary.Schedule.Models
{
    public class Workday
    {
        public int Id { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public int ShiftId { get; set; }
        public Shift Shift { get; set; }

        public ICollection<Appointment> Appointments { get; set; }

    }
}

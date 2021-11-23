using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalClassLibrary.Schedule.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}

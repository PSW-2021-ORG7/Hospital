using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalClassLibrary.Schedule.Models
{
    public class OnCallShift
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public int DoctorId { get; set; }
    }
}

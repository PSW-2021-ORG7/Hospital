using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalClassLibrary.Schedule.Models
{
    public class ShiftWorkday
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Name { get; set; }
        public int WorkdayId { get; set; }
    }
}

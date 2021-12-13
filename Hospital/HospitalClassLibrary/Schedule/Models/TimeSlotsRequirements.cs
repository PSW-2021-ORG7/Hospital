using System;

namespace HospitalClassLibrary.Schedule.Models
{
    public class TimeSlotsRequirements
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public TimeSpan Duration { get; set; }
        public int FirstRoomId { get; set; }
        public int SecondRoomId { get; set; }
    }
}

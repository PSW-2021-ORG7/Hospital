using System;

namespace HospitalClassLibrary.Schedule.Models
{
    public class Shift
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Name { get; set; }

        public bool IsOverlapping(DateTime start, DateTime end)
        {
            if (Start >= start &&
                Start <= end ||
                End >= start &&
                End <= end ||
                start >= Start &&
                start <= End ||
                end >= Start &&
                end <= End)
                return true;

            return false;
        }
    }
}

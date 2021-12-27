using System;

namespace HospitalClassLibrary.Shared.Models
{
    public class DateTimeRange
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public bool Includes(DateTime date)
        {
            return Start <= date && date <= End;
        }

        public bool Overlaps(DateTime start, DateTime end)
        {
            return start < End && Start < end;
        }
    }
}

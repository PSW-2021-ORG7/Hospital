using System;

namespace HospitalAPI.DTOs
{
    public class HolidayDto
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int DoctorId { get; set; }
        public string Description { get; set; }
    }
}

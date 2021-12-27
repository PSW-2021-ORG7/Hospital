using System;

namespace HospitalClassLibrary.Renovations.Models
{
    public class MergeRenovation
    {
        public int Id { get; set; }
        public int FirstOldRoomId { get; set; }
        public int SecondOldRoomId { get; set; }
        public NewRoomInfo NewRoomInfo { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

    }
}

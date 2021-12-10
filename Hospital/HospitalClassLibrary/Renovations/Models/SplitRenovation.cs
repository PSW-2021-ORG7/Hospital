using System;

namespace HospitalClassLibrary.Renovations.Models
{
    public class SplitRenovation
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public NewRoomInfo FirstNewRoomInfo { get; set; }
        public NewRoomInfo SecondNewRoomInfo { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string EquipmentDestination { get; set; }
    }
}

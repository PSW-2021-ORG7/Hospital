using System;

namespace HospitalClassLibrary.RoomEquipment.Models
{
    public class EquipmentTransferRequirements
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Duration { get; set; }
        public int SrcRoomId { get; set; }
        public int DstRoomId { get; set; }
    }
}

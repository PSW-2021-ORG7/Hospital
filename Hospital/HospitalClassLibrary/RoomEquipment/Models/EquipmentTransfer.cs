using System;
using HospitalClassLibrary.GraphicalEditor.Models;

namespace HospitalClassLibrary.RoomEquipment.Models
{
    public class EquipmentTransfer
    {
        public int Id { get; set; }

        public int SourceRoomId { get; set; }
        public Room SourceRoom { get; set; }

        public int DestinationRoomId { get; set; }
        public Room DestinationRoom { get; set; }

        public DateTime TransferDate { get; set; }
        public int TransferDuration { get; set; }

        public int EquipmentId { get; set; }
        public Equipment Equipment { get; set; }

        public int Quantity { get; set; }
    }
}

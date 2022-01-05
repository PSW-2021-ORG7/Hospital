using HospitalClassLibrary.RoomEquipment.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HospitalClassLibrary.Events.EventEquipmentTransfer
{
    [Table(nameof(EquipmentTransferEvent), Schema = "Events")]
    public class EquipmentTransferEvent : Event
    {
        public int SourceRoomId { get; set; }

        public int DestinationRoomId { get; set; }

        public DateTime TransferDate { get; set; }
        public int TransferDuration { get; set; }

        public int EquipmentId { get; set; }

        public int Quantity { get; set; }
    }
}

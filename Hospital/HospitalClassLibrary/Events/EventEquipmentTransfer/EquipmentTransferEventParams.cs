using HospitalClassLibrary.Events.LogEvent;
using HospitalClassLibrary.RoomEquipment.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalClassLibrary.Events.EventEquipmentTransfer
{
    public class EquipmentTransferEventParams : EventParams
    {
        private EquipmentTransfer e;

        public EquipmentTransferEventParams()
        {
        }

        public int SourceRoomId { get; set; }

        public int DestinationRoomId { get; set; }

        public DateTime TransferDate { get; set; }
        public int TransferDuration { get; set; }

        public int EquipmentId { get; set; }

        public int Quantity { get; set; }

        public EquipmentTransferEventParams(EquipmentTransfer e)
        {
            SourceRoomId = e.SourceRoomId;
            DestinationRoomId = e.DestinationRoomId;
            TransferDate = e.TransferDate;
            TransferDuration = e.TransferDuration;
            EquipmentId = e.EquipmentId;
            Quantity = e.Quantity;
        }
    }
}

using HospitalClassLibrary.Events.LogEvent;
using HospitalClassLibrary.RoomEquipment.Models;
using HospitalClassLibrary.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalClassLibrary.Events.EventEquipmentTransfer
{
    public class EquipmentTransferEventParams : EventParams
    {
        public EquipmentTransferEventParams(){}

        public int SourceRoomId { get; set; }

        public int DestinationRoomId { get; set; }

        public DateTime TransferDate { get; set; }
        public int TransferDuration { get; set; }

        public int EquipmentId { get; set; }

        public int Quantity { get; set; }

        public EquipmentTransferEventParams(EquipmentTransfer e)
        {
            SourceRoomId = e.TransferLocationInfo.SourceRoomId;
            DestinationRoomId = e.TransferLocationInfo.DestinationRoomId;
            TransferDate = e.TransferDateInfo.TransferDate;
            TransferDuration = e.TransferDateInfo.TransferDuration;
            EquipmentId = e.TransferEquipmentInfo.EquipmentId;
            Quantity = e.TransferEquipmentInfo.Quantity;
        }
    }
}

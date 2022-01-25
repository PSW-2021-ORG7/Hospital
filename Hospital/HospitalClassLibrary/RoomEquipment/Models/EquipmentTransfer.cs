using HospitalClassLibrary.Shared.Models;
using System;

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

        public Quantity Quantity { get; set; }

        public EquipmentTransfer() {}

        public EquipmentTransfer(int id, int sourceRoomId, int destinationRoomId,
            DateTime transferDate, int transferDuration, int equipmentId, Quantity quantity)
        {
            Id = id;
            SourceRoomId = sourceRoomId;
            DestinationRoomId = destinationRoomId;
            TransferDate = transferDate;
            TransferDuration = transferDuration;
            EquipmentId = equipmentId;
            Quantity = quantity;
            Validate();
        }

        private void Validate()
        {
            if (SourceRoomId == DestinationRoomId)
            {
                throw new Exception("Cannot make transfer to the same room!");
            }
            if (!Quantity.Validate())
            {
                throw new Exception("Quantity must be a positive number!");
            }
            //if (SourceRoom.Equipment doesn't have that much quantity)
        }


    }
}

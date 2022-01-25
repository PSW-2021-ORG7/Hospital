using HospitalClassLibrary.Shared.Models;
using System;

namespace HospitalClassLibrary.RoomEquipment.Models
{
    public class EquipmentTransfer
    {
        public int Id { get; set; }
        public TransferLocationInfo TransferLocationInfo{ get; private set; }
        public TransferEquipmentInfo TransferEquipmentInfo { get; private set; }
        public TransferDateInfo TransferDateInfo { get; private set; }

        public EquipmentTransfer() {}

        public EquipmentTransfer(int id, int sourceRoomId, int destinationRoomId,
            DateTime transferDate, int transferDuration, int equipmentId, int quantity)
        {
            Id = id;
            TransferLocationInfo = new TransferLocationInfo(sourceRoomId, destinationRoomId);
            TransferEquipmentInfo = new TransferEquipmentInfo(equipmentId, quantity);
            TransferDateInfo = new TransferDateInfo(transferDate, transferDuration);
            Validate();
        }

        private void Validate()
        {
            if (!TransferLocationInfo.Validate())
            {
                throw new Exception("Invalid transfer rooms!");
            }
            if (!TransferEquipmentInfo.Validate())
            {
                throw new Exception("Invalid equipment information!");
            }
            if (!TransferDateInfo.Validate())
            {
                throw new Exception("Invalid dates for transfer!");
            }
        }


    }
}

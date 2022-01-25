using HospitalClassLibrary.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalClassLibrary.RoomEquipment.Models
{
    public class TransferLocationInfo : ValueObject
    {
        public TransferLocationInfo(int sourceRoomId, int destinationRoomId)
        {
            SourceRoomId = sourceRoomId;
            DestinationRoomId = destinationRoomId;
        }

        public int SourceRoomId { get; private set; }
        public Room SourceRoom { get; private set; }

        public int DestinationRoomId { get; private set; }
        public Room DestinationRoom { get; private set; }

        public bool Validate()
        {
            if (SourceRoomId == DestinationRoomId)
                return false;
            return true;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return SourceRoomId;
            yield return DestinationRoomId;

        }
    }
}

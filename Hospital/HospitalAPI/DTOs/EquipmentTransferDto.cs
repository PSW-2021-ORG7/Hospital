using HospitalClassLibrary.RoomEquipment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.DTOs
{
    public class EquipmentTransferDto
    {
        public int Id { get; set; }

        public int SourceRoomId { get; set; }
        public string SourceRoomName { get; set; }
        public RoomType SourceRoomType { get; set; }

        public int DestinationRoomId { get; set; }
        public string DestinationRoomName { get; set; }
        public RoomType DestinationRoomType { get; set; }

        public DateTime TransferDate { get; set; }
        public int TransferDuration { get; set; }

        public int EquipmentId { get; set; }

        public int Quantity { get; set; }
    }
}

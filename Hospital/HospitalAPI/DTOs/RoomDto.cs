using System.Collections.Generic;
using HospitalClassLibrary.RoomEquipment.Models;

namespace HospitalAPI.DTOs
{
    public class RoomDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RoomStatus Status { get; set; }
        public RoomType Type { get; set; }
        public int Floor { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public int BuildingId { get; set; }
        public ICollection<EquipmentDto> Equipment { get; set; }
    }
}

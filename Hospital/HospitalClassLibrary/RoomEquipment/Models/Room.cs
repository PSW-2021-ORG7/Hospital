using System.Collections.Generic;
using HospitalClassLibrary.GraphicalEditor.Models;
using HospitalClassLibrary.Schedule.Models;

namespace HospitalClassLibrary.RoomEquipment.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RoomStatus Status { get; set; }
        public RoomType Type { get; set; }
        public int Floor { get; set; }

        public RoomDimensions RoomDimensions { get; set; }

        public int BuildingId { get; set; }
        public ICollection<Equipment> Equipment { get; set; }
        public Doctor Doctor { get; set; }
    }
}

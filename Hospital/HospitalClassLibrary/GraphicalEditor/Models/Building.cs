using System.Collections.Generic;
using HospitalClassLibrary.RoomEquipment.Models;

namespace HospitalClassLibrary.GraphicalEditor.Models
{
    public class Building
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }
}

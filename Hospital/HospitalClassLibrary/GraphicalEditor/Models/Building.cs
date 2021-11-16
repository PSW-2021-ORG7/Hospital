using System.Collections.Generic;

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

using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Class_Library.Graphical_Editor.Models
{
    public class Room
    {
        public string Id { get; set; }
        [ForeignKey("Building")]
        public string BuildingId { get; set; }
        public string Name { get; set; }
        public RoomStatus Status { get; set; }
        public RoomType Type { get; set; }
        public int FreeBeds { get; set; }
        public int Floor { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
    }
}

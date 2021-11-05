using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Class_Library.Graphical_Editor.Models
{
    public class RoomDimensions
    {
        [ForeignKey("Room")]
        public string Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
    }
}

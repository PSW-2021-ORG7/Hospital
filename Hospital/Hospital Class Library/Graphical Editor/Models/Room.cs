namespace Hospital_Class_Library.Graphical_Editor.Models
{
    public class Room
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public RoomStatus Status { get; set; }
        public RoomType Type { get; set; }
        public int FreeBeds { get; set; }
        public RoomDimensions RoomDimensions { get; set; }
    }
}

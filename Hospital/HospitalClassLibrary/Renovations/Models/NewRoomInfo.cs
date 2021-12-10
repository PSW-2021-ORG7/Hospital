using HospitalClassLibrary.RoomEquipment.Models;

namespace HospitalClassLibrary.Renovations.Models
{
    public class NewRoomInfo
    {
        public int Id { get; set; }
        public string RoomName { get; set; }
        public RoomType RoomType { get; set; }
        public RoomStatus RoomStatus { get; set; }
    }
}

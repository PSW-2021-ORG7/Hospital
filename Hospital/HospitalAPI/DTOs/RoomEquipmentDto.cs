using HospitalClassLibrary.GraphicalEditor.Models;

namespace HospitalAPI.DTOs
{
    public class RoomEquipmentDto
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public RoomType RoomType { get; set; }
        public int RoomFloor { get; set; }
        public int EquipmentItemId { get; set; }
        public string EquipmentItemName { get; set; }
        public string EquipmentItemDescription { get; set; }
        public int Quantity { get; set; }
    }
}

namespace HospitalClassLibrary.RoomEquipment.Models
{
    public class Equipment
    {
        public int Id { get; set; }

        public int RoomId { get; set; }
        public Room Room { get; set; }

        public int EquipmentItemId { get; set; }
        public EquipmentItem EquipmentItem { get; set; }

        public int Quantity { get; set; }
        public int ReservedQuantity { get; set; }

        public bool Validate()
        {
            if(ReservedQuantity > Quantity)
                return false;
            return true;
        }

        public int GetAvailableQuantityForTransfer()
        {
            return Quantity - ReservedQuantity;
        }
    }
}

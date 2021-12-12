using System.ComponentModel.DataAnnotations;

namespace HospitalClassLibrary.Medicine.Models
{
    public class MedicineInventory
    {
        public MedicineInventory(int medicineId)
        {
            MedicineId = medicineId;
            Quantity = 0;
        }

        public MedicineInventory(int medicineId,int quantity)
        {
            MedicineId = medicineId;
            Quantity = quantity;
        }
        public MedicineInventory()
        {

        }

        [Key]
        public int MedicineId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}

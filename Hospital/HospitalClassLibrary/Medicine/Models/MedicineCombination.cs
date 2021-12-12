using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalClassLibrary.Medicine.Models
{
    [Table("MedicineCombination")]
    public class MedicineCombination
    {
        [Key]
        public int Id { get; set; }

        public int FirstMedicineId { get; set; }
        public Medicine FirstMedicine { get; set; }

        public int SecondMedicineId { get; set; }
        public Medicine SecondMedicine { get; set; }

        public MedicineCombination()
        {

        }
        public MedicineCombination(int firstId, int secondId)
        {
            FirstMedicineId = firstId;
            SecondMedicineId = secondId;
        }
    }
}

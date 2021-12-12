using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalClassLibrary.Medicine.Models
{
    [Table("Ingredient")]
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Medicine> Medicines { get; set; }
    }
}

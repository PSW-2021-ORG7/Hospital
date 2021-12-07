using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HospitalClassLibrary.Medicine.Models
{
    [Table("Medicine")]
    public class Medicine
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]

        public int Id { get; private set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public int DosageInMilligrams { get; set; }

        public string Manufacturer { get; set; }

        [Required]
        public List<string> SideEffects { get; set; }

        [Required]
        public List<string> PossibleReactions { get; set; }

        [Required]
        public string WayOfConsumption { get; set; }

        public string PotentialDangers { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        public Medicine() { }

    }
}

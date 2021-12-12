using HospitalClassLibrary.Medicine.Models;
using System.Collections.Generic;

namespace HospitalAPI.DTOs.Medicine
{
    public class NewMedicineDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int DosageInMilligrams { get; set; }
        public string Manufacturer { get; set; }
        public List<string> SideEffects { get; set; }
        public List<string> PossibleReactions { get; set; }
        public string WayOfConsumption { get; set; }
        public string PotentialDangers { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<int> MedicinesToCombineWith { get; set; }
    }
}

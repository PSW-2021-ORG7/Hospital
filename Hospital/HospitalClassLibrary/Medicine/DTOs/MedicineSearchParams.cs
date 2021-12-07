using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DTO
{
    public class MedicineSearchParams
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public string Ingredient { get; set; }

    }
}

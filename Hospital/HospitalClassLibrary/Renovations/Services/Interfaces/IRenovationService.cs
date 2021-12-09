using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalClassLibrary.Renovations.Models;

namespace HospitalClassLibrary.Renovations.Services.Interfaces
{
    public interface IRenovationService
    {
        Task<IEnumerable<SplitRenovation>> GetAll();
        Task Create(SplitRenovation r);
        Task Delete(SplitRenovation r);
    }
}

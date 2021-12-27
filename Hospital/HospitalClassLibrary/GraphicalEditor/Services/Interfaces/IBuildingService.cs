using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalClassLibrary.GraphicalEditor.Models;

namespace HospitalClassLibrary.GraphicalEditor.Services.Interfaces
{
    public interface IBuildingService
    {
        Task<Building> GetById(int id);
        Task<IEnumerable<Building>> GetAll();
        Task Create(Building b);
        Task Update(Building b);
        Task Delete(Building b);
    }
}

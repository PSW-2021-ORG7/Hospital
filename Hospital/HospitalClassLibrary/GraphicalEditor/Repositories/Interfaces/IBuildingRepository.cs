using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalClassLibrary.GraphicalEditor.Models;

namespace HospitalClassLibrary.GraphicalEditor.Repositories.Interfaces
{
    public interface IBuildingRepository
    {
        Task<List<Building>> GetAllBuildings();
        Task<Building> GetBuildingById(String id);
        Task<int> PutBuilding(String id, Building building);
    }
}

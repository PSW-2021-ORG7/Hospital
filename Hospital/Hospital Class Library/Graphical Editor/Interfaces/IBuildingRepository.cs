using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hospital_Class_Library.Graphical_Editor.Models;

namespace Hospital_Class_Library.Graphical_Editor.Interfaces
{
    public interface IBuildingRepository
    {
        Task<List<Building>> GetAllBuildings();
        Task<Building> GetBuildingById(String id);
        Task<int> PutBuilding(String id, Building building);
    }
}

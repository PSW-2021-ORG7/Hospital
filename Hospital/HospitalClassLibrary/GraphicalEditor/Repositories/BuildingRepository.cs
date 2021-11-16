using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalClassLibrary.Data;
using HospitalClassLibrary.GraphicalEditor.Models;
using HospitalClassLibrary.GraphicalEditor.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalClassLibrary.GraphicalEditor.Repositories
{
    public class BuildingRepository : GenericRepository<Building>, IBuildingRepository
    {
        public BuildingRepository(AppDbContext context) : base(context)
        {
        }
    }
}

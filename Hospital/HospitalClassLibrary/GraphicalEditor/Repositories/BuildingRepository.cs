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
    public class BuildingRepository : IBuildingRepository
    {
        private readonly AppDbContext _context;
        public BuildingRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Building>> GetAllBuildings()
        {
            return await _context.Buildings.ToListAsync();
        }

        public async Task<Building> GetBuildingById(int id)
        {
            return await _context.Buildings.FindAsync(id);
        }

        public async Task<int> PutBuilding(int id, Building building)
        {
            _context.Entry(building).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuildingExists(id))
                {
                    return -1;
                }

                throw;
            }

            return 0;
        }
        private bool BuildingExists(int id)
        {
            return _context.Buildings.Any(e => e.Id == id);
        }
    }
}

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
    public class RoomRepository: IRoomRepository
    {
        private readonly AppDbContext _context;

        public RoomRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Room>> GetAllRooms()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task<Room> GetRoomById(int id)
        {
            return await _context.Rooms.FindAsync(id);
        }

        public async Task<List<Room>> GetRooms(int buildingId)
        {
            return await _context.Rooms.Where(r => r.BuildingId == buildingId).Select(r => r).ToListAsync();
        }

        public async Task<int> PutRoom(int id, Room room)
        {
            _context.Entry(room).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(id))
                {
                    return -1;
                }

                throw;
            }

            return 0;
        }
        private bool RoomExists(int id)
        {
            return _context.Rooms.Any(e => e.Id == id);
        }


    }

   

}

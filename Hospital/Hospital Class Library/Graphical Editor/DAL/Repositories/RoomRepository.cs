using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital_Class_Library.Graphical_Editor.Interfaces;
using Hospital_Class_Library.Graphical_Editor.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Class_Library.Graphical_Editor.DAL.Repositories
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

        public async Task<Room> GetRoomById(string id)
        {
            return await _context.Rooms.FindAsync(id);
        }

        public async Task<List<Room>> GetRooms(string buildingId)
        {
            return await _context.Rooms.Where(r => r.BuildingId == buildingId).Select(r => r).ToListAsync();
        }

        public async Task<int> PutRoom(string id, Room room)
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
        private bool RoomExists(String id)
        {
            return _context.Rooms.Any(e => e.Id == id);
        }


    }

   

}

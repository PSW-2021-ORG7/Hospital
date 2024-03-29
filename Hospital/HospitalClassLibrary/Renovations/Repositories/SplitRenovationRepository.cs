﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalClassLibrary.Data;
using HospitalClassLibrary.Renovations.Models;
using HospitalClassLibrary.Renovations.Repositories.Interfaces;
using HospitalClassLibrary.Shared.Models;
using HospitalClassLibrary.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HospitalClassLibrary.Renovations.Repositories
{
    public class SplitRenovationRepository : GenericRepository<SplitRenovation>, ISplitRenovationRepository
    {
        public SplitRenovationRepository(AppDbContext context) : base(context)
        {
        }

        public new async Task<IEnumerable<SplitRenovation>> GetAllAsync()
        {
            return await Context.SplitRenovation.Include(r => r.FirstNewRoomInfo).Include(r => r.SecondNewRoomInfo).ToListAsync();
        }

        public async Task<IEnumerable<SplitRenovation>> GetAllByRoomIdAsync(int roomId)
        {
            return await Context.SplitRenovation.Where(r => r.RoomId == roomId).ToListAsync();
        }
        
        public async Task<IEnumerable<DateTimeRange>> GetAllDates(int firstRoomId, int secondRoomId)
        {
            return await Context.SplitRenovation.Where(r => r.RoomId == firstRoomId || r.RoomId == secondRoomId).Select(r => new DateTimeRange() { Start = r.Start, End = r.End }).ToListAsync();
        }
    }
}

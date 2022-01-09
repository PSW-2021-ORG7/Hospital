using System;
using System.Collections.Generic;
using System.Text;
using HospitalClassLibrary.Data;
using HospitalClassLibrary.Schedule.Models;
using HospitalClassLibrary.Schedule.Repositories.Interfaces;
using HospitalClassLibrary.Shared.Repositories;

namespace HospitalClassLibrary.Schedule.Repositories
{
    public class ShiftRepository : GenericRepository<Shift>, IShiftRepository
    {
        public ShiftRepository(AppDbContext context) : base(context)
        {
        }
    }
}

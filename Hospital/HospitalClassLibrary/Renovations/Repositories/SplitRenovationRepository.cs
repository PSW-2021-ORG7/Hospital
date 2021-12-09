using System;
using System.Collections.Generic;
using System.Text;
using HospitalClassLibrary.Data;
using HospitalClassLibrary.Renovations.Models;
using HospitalClassLibrary.Renovations.Repositories.Interfaces;
using HospitalClassLibrary.Shared.Repositories;

namespace HospitalClassLibrary.Renovations.Repositories
{
    public class SplitRenovationRepository : GenericRepository<SplitRenovation>, ISplitRenovationRepository
    {
        public SplitRenovationRepository(AppDbContext context) : base(context)
        {
        }
    }
}

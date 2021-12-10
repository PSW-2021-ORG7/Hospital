using HospitalClassLibrary.Data;
using HospitalClassLibrary.Renovations.Models;
using HospitalClassLibrary.Renovations.Repositories.Interfaces;
using HospitalClassLibrary.Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalClassLibrary.Renovations.Repositories
{
    public class MergeRenovationRepository : GenericRepository<MergeRenovation>, IMergeRenovationRepository
    {
        public MergeRenovationRepository(AppDbContext context) : base(context)
        {
        }

    }
}

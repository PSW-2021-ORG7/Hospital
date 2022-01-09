using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HospitalClassLibrary.Schedule.Models;
using HospitalClassLibrary.Shared.Models;
using HospitalClassLibrary.Shared.Repositories;

namespace HospitalClassLibrary.Schedule.Repositories.Interfaces
{
    public interface IShiftRepository : IGenericRepository<Shift>
    {
        Task<IEnumerable<Shift>> GetAllAsync(DateTimeRange dateTimeRange);
    }
}

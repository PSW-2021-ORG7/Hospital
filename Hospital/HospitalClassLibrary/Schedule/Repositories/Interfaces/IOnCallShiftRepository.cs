using HospitalClassLibrary.Schedule.Models;
using HospitalClassLibrary.Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLibrary.Schedule.Repositories.Interfaces
{
    public interface IOnCallShiftRepository : IGenericRepository<OnCallShift>
    {
        Task<IEnumerable<OnCallShift>> GetAllOnCallShiftsByDoctorId(int doctorId);

        Task<IEnumerable<OnCallShift>> GetOnCallShiftByStartDate(DateTime start);

    }
}

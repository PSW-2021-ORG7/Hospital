using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HospitalClassLibrary.Schedule.Models;
using HospitalClassLibrary.Shared.Repositories;

namespace HospitalClassLibrary.Schedule.Repositories.Interfaces
{
    public interface IDoctorScheduleRepository : IGenericRepository<DoctorSchedule>
    {
        Task<DoctorSchedule> GetScheduleByDoctorId(int doctorId);
    }
}

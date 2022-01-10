using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalClassLibrary.Schedule.Models;

namespace HospitalClassLibrary.Schedule.Services.Interfaces
{
    public interface IHolidayService
    {
        Task Create(Holiday holiday);
        Task Update(Holiday holiday);
        Task<IEnumerable<Holiday>> GetAllByDoctorId(int doctorId);
        Task<bool> HasOverlappingHoliday(Holiday holiday);
    }
}

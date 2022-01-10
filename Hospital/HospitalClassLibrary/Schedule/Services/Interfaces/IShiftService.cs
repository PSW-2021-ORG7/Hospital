using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HospitalClassLibrary.Schedule.Models;
using HospitalClassLibrary.Shared.Models;

namespace HospitalClassLibrary.Schedule.Services.Interfaces
{
    public interface IShiftService
    {
        Task<IEnumerable<Shift>> GetAll(DateTimeRange dateTimeRange);
        Task Create(Shift s);
        Task Update(Shift s);
        Task Delete(Shift s);

        Task<IEnumerable<Shift>> GetAllShiftsByDoctorId(int id);
    }
}

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

        Task<IEnumerable<object>> GetAllShiftsByDoctorId(int id);
        Task<Shift> GetById(int id);
        Task<IEnumerable<OnCallShift>> GetAllOnCallShiftsByDoctorId(int id);
        Task<IEnumerable<OnCallShift>> GetOnCallShiftByStartDate(DateTime start);
        Task Create(OnCallShift s);
        Task Update(OnCallShift s);
        Task Delete(OnCallShift s);
        Task<IEnumerable<OnCallShift>> GetAllOnCallShiftsForDateTimeRange(DateTimeRange dateTimeRange);
    }
}

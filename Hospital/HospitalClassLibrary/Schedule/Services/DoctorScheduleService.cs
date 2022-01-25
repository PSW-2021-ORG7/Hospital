using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HospitalClassLibrary.Schedule.Models;
using HospitalClassLibrary.Schedule.Repositories.Interfaces;
using HospitalClassLibrary.Schedule.Services.Interfaces;

namespace HospitalClassLibrary.Schedule.Services
{
    public class DoctorScheduleService : IDoctorScheduleService
    {
        private readonly IDoctorScheduleRepository _doctorScheduleRepository;
        private readonly IWorkdayRepository _workdayRepository;

        public DoctorScheduleService(IDoctorScheduleRepository doctorScheduleRepository, IWorkdayRepository workdayRepository, IOnCallShiftRepository onCallShiftRepository)
        {
            _doctorScheduleRepository = doctorScheduleRepository;
            _workdayRepository = workdayRepository;
        }

        public Task<DoctorSchedule> GetByDoctorId(int id)
        {
            return _doctorScheduleRepository.GetScheduleByDoctorId(id);
        }

        public async Task UpdateWorkday(Workday workday)
        {
            await _workdayRepository.UpdateAsync(workday);
        }

        public async Task<bool> CanCreateEntity(int doctorId, DateTime start, DateTime end)
        {
            DoctorSchedule schedule = await _doctorScheduleRepository.GetScheduleByDoctorId(doctorId);
            foreach (Workday workday in schedule.Workdays)
            {
                if (workday.Shift.IsOverlapping(start, end))
                    return false;
            }

            foreach (Holiday holiday in schedule.Holidays)
            {
                if (holiday.IsOverlapping(start, end))
                    return false;
            }

            foreach (OnCallShift onCallShift in schedule.OnCallShifts)
            {
                if (onCallShift.IsOverlapping(start, end))
                    return false;
            }

            return true;
        }

    }
}

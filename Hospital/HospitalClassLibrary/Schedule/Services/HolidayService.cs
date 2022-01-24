﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalClassLibrary.Schedule.Models;
using HospitalClassLibrary.Schedule.Repositories.Interfaces;
using HospitalClassLibrary.Schedule.Services.Interfaces;
using HospitalClassLibrary.Shared.Models;

namespace HospitalClassLibrary.Schedule.Services
{
    public class HolidayService : IHolidayService
    {
        private readonly IHolidayRepository _holidayRepository;
        private readonly IWorkdayRepository _workdayRepository;

        public HolidayService(IHolidayRepository holidayRepository, IWorkdayRepository workdayRepository)
        {
            _holidayRepository = holidayRepository;
            _workdayRepository = workdayRepository;
        }

        public async Task Create(Holiday holiday)
        {
            await DeleteWorkdaysInHolidayDateRange(holiday);

            await _holidayRepository.CreateAsync(holiday);
        }

        public async Task Update(Holiday holiday)
        {
            await DeleteWorkdaysInHolidayDateRange(holiday);

            await _holidayRepository.UpdateAsync(holiday);
        }

        private async Task DeleteWorkdaysInHolidayDateRange(Holiday holiday)
        {
            var workdays = _workdayRepository.GetWorkdays(new DateTimeRange() { Start = holiday.Start, End = holiday.End }, holiday.DoctorId).Result;
            foreach (var workday in workdays)
            {
                await _workdayRepository.DeleteAsync(workday);
            }
        }

        public async Task Delete(Holiday holiday)
        {
            await _holidayRepository.DeleteAsync(holiday);
        }

        public Task<IEnumerable<Holiday>> GetAllByDoctorId(int doctorId)
        {
            return _holidayRepository.GetAllByDoctorId(doctorId);
        }

        public async Task<bool> HasOverlappingHoliday(Holiday holiday)
        {
            var existingHoliday = await _holidayRepository.GetAllByDoctorId(holiday.DoctorId);
            existingHoliday = existingHoliday.Where(h => h.Id != holiday.Id);
            return existingHoliday.Any(holiday.Overlaps);
        }

    }
}
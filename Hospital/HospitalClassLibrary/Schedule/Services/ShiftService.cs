using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalClassLibrary.Schedule.Models;
using HospitalClassLibrary.Schedule.Repositories.Interfaces;
using HospitalClassLibrary.Schedule.Services.Interfaces;
using HospitalClassLibrary.Shared.Models;

namespace HospitalClassLibrary.Schedule.Services
{
    public class ShiftService : IShiftService
    {
        private readonly IShiftRepository _shiftRepository;
        private readonly IOnCallShiftRepository _onCallShiftRepository;
        private readonly IWorkdayRepository _workdayRepository;

        public ShiftService(IShiftRepository shiftRepository, IWorkdayRepository workdayRepository, IOnCallShiftRepository onCallShiftRepository)
        {
            _shiftRepository = shiftRepository;
            _onCallShiftRepository = onCallShiftRepository;
            _workdayRepository = workdayRepository;
        }

        public async Task<IEnumerable<Shift>> GetAll(DateTimeRange dateTimeRange)
        {
            return await _shiftRepository.GetAllAsync(dateTimeRange);
        }

        public async Task Create(Shift s)
        {
            await _shiftRepository.CreateAsync(s);
        }

        public async Task Update(Shift s)
        {
            await _shiftRepository.UpdateAsync(s);
        }

        public async Task Delete(Shift s)
        {
            var workdays = _workdayRepository.GetWorkdaysByShiftId(s.Id).Result;
            foreach (var workday in workdays)
            {
                await _workdayRepository.DeleteAsync(workday);
            }

            await _shiftRepository.DeleteAsync(s);
        }

        public async Task<IEnumerable<object>> GetAllShiftsByDoctorId(int id)
        {
            return await _workdayRepository.GetAllShiftsByDoctorId(id);
        }

        public async Task<Shift> GetById(int id)
        {
            return await _shiftRepository.GetByIdAsync(id);
        }
        public async Task<IEnumerable<OnCallShift>> GetAllOnCallShiftsByDoctorId(int id)
        {
            return await _onCallShiftRepository.GetAllOnCallShiftsByDoctorId(id);
        }

        public async Task<IEnumerable<OnCallShift>> GetOnCallShiftByStartDate(DateTime start)
        {
            return await _onCallShiftRepository.GetOnCallShiftByStartDate(start);
        }

        public async Task Create(OnCallShift ocs)
        {
            bool hasTheSameDate = false;
            var onCallShifts = _onCallShiftRepository.GetAllOnCallShiftsByDoctorId(ocs.DoctorId).Result;
            foreach (var onCallShift in onCallShifts)
            {
                if(onCallShift.Start == ocs.Start)
                {
                    hasTheSameDate = true;
                }
            }
            if(hasTheSameDate== false)
            {
                await _onCallShiftRepository.CreateAsync(ocs);
            }

        }

        public async Task Update(OnCallShift ocs)
        {
            await _onCallShiftRepository.UpdateAsync(ocs);
        }

        public async Task Delete(OnCallShift ocs)
        {
            await _onCallShiftRepository.DeleteAsync(ocs);
        }

    }
}

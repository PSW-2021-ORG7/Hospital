using System;
using System.Collections.Generic;
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
            await _shiftRepository.DeleteAsync(s);
        }

        public async Task<IEnumerable<Shift>> GetAllShiftsByDoctorId(int id)
        {
            return await _workdayRepository.GetAllShiftsByDoctorId(id);
        }

        public async Task<IEnumerable<OnCallShift>> GetAllOnCallShiftsByDoctorId(int id)
        {
            return await _onCallShiftRepository.GetAllOnCallShiftsByDoctorId(id);
        }
        public async Task Create(OnCallShift ocs)
        {
            await _onCallShiftRepository.CreateAsync(ocs);
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

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
        private readonly IWorkdayRepository _workdayRepository;

        public ShiftService(IShiftRepository shiftRepository, IWorkdayRepository workdayRepository)
        {
            _shiftRepository = shiftRepository;
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

        public async Task<Shift> GetById(int id)
        {
            return await _shiftRepository.GetByIdAsync(id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HospitalClassLibrary.Schedule.Models;
using HospitalClassLibrary.Schedule.Repositories.Interfaces;
using HospitalClassLibrary.Schedule.Services.Interfaces;

namespace HospitalClassLibrary.Schedule.Services
{
    public class ShiftService : IShiftService
    {
        private readonly IShiftRepository _shiftRepository;

        public ShiftService(IShiftRepository shiftRepository)
        {
            _shiftRepository = shiftRepository;
        }

        public async Task<IEnumerable<Shift>> GetAll()
        {
            return await _shiftRepository.GetAllAsync();
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
    }
}

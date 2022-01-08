using System.Linq;
using System.Threading.Tasks;
using HospitalClassLibrary.Schedule.Models;
using HospitalClassLibrary.Schedule.Repositories.Interfaces;
using HospitalClassLibrary.Schedule.Services.Interfaces;

namespace HospitalClassLibrary.Schedule.Services
{
    public class HolidayService : IHolidayService
    {
        private readonly IHolidayRepository _holidayRepository;

        public HolidayService(IHolidayRepository holidayRepository)
        {
            _holidayRepository = holidayRepository;
        }

        public async Task Create(Holiday holiday)
        {
            // TODO: Cancel shifts in date range
            await _holidayRepository.CreateAsync(holiday);
        }

        public async Task<bool> HasOverlappingHoliday(Holiday holiday)
        {
            var existingHoliday = await _holidayRepository.GetAllByDoctorId(holiday.DoctorId);
            return existingHoliday.Any(holiday.Overlaps);
        }
    }
}

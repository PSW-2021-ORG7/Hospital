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
    }
}

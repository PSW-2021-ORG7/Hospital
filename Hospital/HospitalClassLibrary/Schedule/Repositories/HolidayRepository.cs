using HospitalClassLibrary.Data;
using HospitalClassLibrary.Schedule.Models;
using HospitalClassLibrary.Schedule.Repositories.Interfaces;
using HospitalClassLibrary.Shared.Repositories;

namespace HospitalClassLibrary.Schedule.Repositories
{
    public class HolidayRepository : GenericRepository<Holiday>, IHolidayRepository
    {
        public HolidayRepository(AppDbContext context) : base(context)
        {
        }
    }
}

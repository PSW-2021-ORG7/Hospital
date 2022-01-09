using HospitalClassLibrary.Data;
using HospitalClassLibrary.Schedule.Models;
using HospitalClassLibrary.Schedule.Repositories.Interfaces;
using HospitalClassLibrary.Shared.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalClassLibrary.Schedule.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(AppDbContext context) : base(context) {}

        public async Task<Doctor> GetDoctorForRoom(int roomId)
        {
            return await Context.Doctor.Where(d => d.RoomId == roomId).FirstOrDefaultAsync();
        }
    }
}

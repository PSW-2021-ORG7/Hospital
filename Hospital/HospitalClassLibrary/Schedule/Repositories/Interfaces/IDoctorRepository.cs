using HospitalClassLibrary.Schedule.Models;
using HospitalClassLibrary.Shared.Repositories;
using System.Threading.Tasks;

namespace HospitalClassLibrary.Schedule.Repositories.Interfaces
{
    public interface IDoctorRepository : IGenericRepository<Doctor>
    {
        Task<Doctor> GetDoctorForRoom(int roomId);
    }
}

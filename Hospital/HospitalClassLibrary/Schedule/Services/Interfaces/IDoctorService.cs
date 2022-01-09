using System.Threading.Tasks;
using HospitalClassLibrary.Schedule.Models;

namespace HospitalClassLibrary.Schedule.Services.Interfaces
{
    public interface IDoctorService
    {
        Task<Doctor> GetById(int id);
        Task<Doctor> GetDoctorForRoom(int roomId);
    }
}

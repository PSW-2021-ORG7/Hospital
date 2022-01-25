using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HospitalClassLibrary.Schedule.Models;
using HospitalClassLibrary.Schedule.Repositories.Interfaces;
using HospitalClassLibrary.Schedule.Services.Interfaces;

namespace HospitalClassLibrary.Schedule.Services
{
    public class DoctorScheduleService : IDoctorScheduleService
    {
        private readonly IDoctorScheduleRepository _doctorScheduleRepository;

        public DoctorScheduleService(IDoctorScheduleRepository doctorScheduleRepository)
        {
            _doctorScheduleRepository = doctorScheduleRepository;
        }

        public Task<DoctorSchedule> GetByDoctorId(int id)
        {
            return _doctorScheduleRepository.GetScheduleByDoctorId(id);
        }
    }
}

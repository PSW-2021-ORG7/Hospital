using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalClassLibrary.Schedule.Models;
using HospitalClassLibrary.Schedule.Services.Interfaces;

namespace HospitalAPI.Controllers
{
    [Route("api/doctorSchedule")]
    [ApiController]
    public class DoctorScheduleController : ControllerBase
    {
        private readonly IDoctorScheduleService _doctorScheduleService;

        public DoctorScheduleController(IDoctorScheduleService doctorScheduleService)
        {
            _doctorScheduleService = doctorScheduleService;
        }

        [HttpGet("{id}")]
        public async Task<DoctorSchedule> GetByDoctorId(int id)
        {
            return await _doctorScheduleService.GetByDoctorId(id);
        }
    }
}

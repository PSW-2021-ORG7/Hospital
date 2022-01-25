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

        [HttpPut("workdays")]
        public async Task<IActionResult> PutShift([FromBody] Workday workday)
        {
            if (!await _doctorScheduleService.CanCreateEntity(workday.DoctorId, workday.Shift.Start, workday.Shift.End))
            {
                return BadRequest("Chosen workday can not be updated!");
            }

            await _doctorScheduleService.UpdateWorkday(workday);

            return Created("api/workdays", workday);
        }
    }
}

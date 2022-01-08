using System;
using System.Threading.Tasks;
using HospitalAPI.DTOs;
using HospitalClassLibrary.Schedule.Models;
using HospitalClassLibrary.Schedule.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidayController : ControllerBase
    {
        private readonly IHolidayService _holidayService;
        private readonly IDoctorService _doctorService;

        public HolidayController(IHolidayService holidayService, IDoctorService doctorService)
        {
            _holidayService = holidayService;
            _doctorService = doctorService;
        }

        [HttpPost]
        public async Task<IActionResult> PostHoliday(HolidayDto holiday)
        {
            try
            {
                var doctor = await _doctorService.GetById(holiday.DoctorId);
                var newHoliday = new Holiday(holiday.Id, holiday.Start, holiday.End, holiday.DoctorId, doctor, holiday.Description);

                if (_holidayService.HasOverlappingHoliday(newHoliday).Result)
                {
                    return Conflict("Doctor has scheduled holiday at the requested date");
                }

                await _holidayService.Create(newHoliday);
                return Ok();
            } 
            catch(ArgumentException)
            {
                return BadRequest("Not valid");
            }
        }
    }
}

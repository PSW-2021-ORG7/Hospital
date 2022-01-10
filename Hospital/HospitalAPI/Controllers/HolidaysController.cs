using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HospitalAPI.DTOs;
using HospitalClassLibrary.Schedule.Models;
using HospitalClassLibrary.Schedule.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidaysController : ControllerBase
    {
        private readonly IHolidayService _holidayService;
        private readonly IDoctorService _doctorService;
        private readonly IMapper _mapper;

        public HolidaysController(IHolidayService holidayService, IDoctorService doctorService, IMapper mapper)
        {
            _holidayService = holidayService;
            _doctorService = doctorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<HolidayDto>> GetAllByDoctorId([FromQuery] int doctorId)
        {
            var holidays = await _holidayService.GetAllByDoctorId(doctorId);
            return _mapper.Map<IEnumerable<HolidayDto>>(holidays);
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

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHoliday(int id, HolidayDto holidayDto)
        {
            if (id != holidayDto.Id)
            {
                return BadRequest();
            }

            var doctor = await _doctorService.GetById(holidayDto.DoctorId);
            var holiday = new Holiday(holidayDto.Id, holidayDto.Start, holidayDto.End, holidayDto.DoctorId, doctor, holidayDto.Description);
            await _holidayService.Update(holiday);

            return Ok();
        }

    }
}

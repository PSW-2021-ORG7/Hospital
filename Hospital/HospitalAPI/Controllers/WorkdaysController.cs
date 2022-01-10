using HospitalClassLibrary.Schedule.Models;
using HospitalClassLibrary.Schedule.Services.Interfaces;
using HospitalClassLibrary.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalAPI.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class WorkdaysController : Controller
        {

            private readonly IWorkdayService _workdayService;

            public WorkdaysController(IWorkdayService workdayService)
            {
                _workdayService = workdayService;
            }

            [HttpGet]
            public async Task<IEnumerable<Workday>> GetWorkdays([FromQuery] DateTime start, [FromQuery] DateTime end, [FromQuery] int doctorId)
            {
                return await _workdayService.GetWorkdays(new DateTimeRange() {Start = start, End = end}, doctorId);
            }

            [HttpPost]
            public async Task<IActionResult> PostWorkday([FromBody] Workday workday)
            {
                if (workday is null)
                    return BadRequest();

                await _workdayService.Create(workday);

                return Created("api/workdays", workday);
            }

            [HttpPut]
            public async Task<IActionResult> PutShift([FromBody] Workday workday)
            {
                if (workday is null)
                    return BadRequest();

                await _workdayService.Update(workday);

                return NoContent();
            }
    }
}

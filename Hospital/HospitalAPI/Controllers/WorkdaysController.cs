using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalClassLibrary.Schedule.Models;
using HospitalClassLibrary.Schedule.Services.Interfaces;
using HospitalClassLibrary.Shared.Models;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkdaysController : ControllerBase
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

    }
}

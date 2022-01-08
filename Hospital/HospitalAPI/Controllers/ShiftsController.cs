using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalClassLibrary.Schedule.Models;
using HospitalClassLibrary.Schedule.Services.Interfaces;

namespace HospitalAPI.Controllers
{
    [Route("api/shifts")]
    [ApiController]
    public class ShiftsController : Controller
    {
        private readonly IShiftService _shiftService;

        public ShiftsController(IShiftService shiftService)
        {
            _shiftService = shiftService;
        }

        [HttpGet]
        public async Task<IEnumerable<Shift>> GetShifts()
        {
            return await _shiftService.GetAll();
        }

        [HttpPost]
        public async Task<IActionResult> PostShift(Shift shift)
        {
            await _shiftService.Create(shift);

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> PutShift(Shift shift)
        {
            await _shiftService.Update(shift);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteShift(Shift shift)
        {
            await _shiftService.Delete(shift);

            return NoContent();
        }
    }
}

using AutoMapper;
using HospitalAPI.DTOs;
using HospitalClassLibrary.Schedule.Models;
using HospitalClassLibrary.Schedule.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : Controller
    {

        private readonly IDoctorService _doctorService;
        private readonly IMapper _mapper;

        public DoctorController(IDoctorService doctorService, IMapper mapper)
        {
            _doctorService = doctorService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<DoctorRoomDto>> GetDoctorForRoom([FromQuery(Name = "roomId")] int roomId)
        {

            var doctor = await _doctorService.GetDoctorForRoom(roomId);
            if (doctor == null)
            {
                return NotFound();
            }
            return _mapper.Map<DoctorRoomDto>(doctor);
        }
    }
}

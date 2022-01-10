using AutoMapper;
using HospitalAPI.DTOs;
using HospitalClassLibrary.Schedule.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : Controller
    {

        private readonly IDoctorService _doctorService;
        private readonly IMapper _mapper;

        public DoctorsController(IDoctorService doctorService, IMapper mapper)
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

        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorDto>> GetDoctor(int id)
        {

            var doctor = await _doctorService.GetDoctor(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return _mapper.Map<DoctorDto>(doctor);
        }

    }
}

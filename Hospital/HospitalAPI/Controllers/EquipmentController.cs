using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HospitalAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using HospitalClassLibrary.RoomEquipment.Services.Interfaces;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;
        private readonly IMapper _mapper;

        public EquipmentController(IEquipmentService equipmentService, IMapper mapper)
        {
            _equipmentService = equipmentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<RoomEquipmentDto>> GetEquipment()
        {
            var equipment = await _equipmentService.GetAll();
            return _mapper.Map<IEnumerable<RoomEquipmentDto>>(equipment);
        }

    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HospitalAPI.DTOs;
using HospitalClassLibrary.GraphicalEditor.Models;
using HospitalClassLibrary.GraphicalEditor.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public RoomsController(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }

        [HttpGet] 
        public async Task<IEnumerable<Room>> GetRooms([FromQuery(Name ="buildingId")] int buildingId)
        {
            return await _roomService.GetAll(buildingId);
        }

        [HttpGet("{id}/equipment")]
        public async Task<RoomDto> GetRoomWithEquipment(int id)
        {
            var room = await _roomService.GetRoomWithEquipment(id);
            return _mapper.Map<RoomDto>(room);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, Room room)
        {
            if (id != room.Id)
            {
                return BadRequest();
            }

            await _roomService.Update(room);

            return NoContent();
        }

    }
}

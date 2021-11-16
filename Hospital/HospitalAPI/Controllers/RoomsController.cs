using System.Collections.Generic;
using System.Threading.Tasks;
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

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet] 
        public async Task<IEnumerable<Room>> GetRooms([FromQuery(Name ="buildingId")] int buildingId)
        {
            return await _roomService.GetAll(buildingId);
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

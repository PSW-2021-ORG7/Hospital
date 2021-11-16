using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalClassLibrary.GraphicalEditor.Models;
using HospitalClassLibrary.GraphicalEditor.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomRepository _roomsRepo;

        public RoomsController(IRoomRepository roomsRepo)
        {
            _roomsRepo = roomsRepo;
        }

        [HttpGet] // GET: Rooms
        //public IActionResult Get([FromQuery(Name = "page")] int page)
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms([FromQuery(Name ="buildingId")] int buildingId)
        {
            return await _roomsRepo.GetAllRooms();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, Room room)
        {
            if (id != room.Id)
            {
                return BadRequest();
            }

            if ((await _roomsRepo.PutRoom(id, room)) == -1)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}

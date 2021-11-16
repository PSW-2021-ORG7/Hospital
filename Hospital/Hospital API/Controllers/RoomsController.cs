using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital_Class_Library.Graphical_Editor.DAL;
using Hospital_Class_Library.Graphical_Editor.Models;
using Hospital_Class_Library.Graphical_Editor.Interfaces;

namespace Hospital_API.Controllers
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
        //public IActionResult Get([FromQuery(Name = "page")] string page)
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms([FromQuery(Name ="buildingId")] string buildingId)
        {
            return await _roomsRepo.GetAllRooms();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(String id, Room room)
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

using System.Threading.Tasks;
using HospitalClassLibrary.Renovations.Models;
using HospitalClassLibrary.Renovations.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class RenovationsController : ControllerBase
    {
        private readonly IRenovationService _renovationService;

        public RenovationsController(IRenovationService renovationService)
        {
            _renovationService = renovationService;
        }

        [HttpPost("splitRenovations")]
        public async Task<IActionResult> PostSplitRenovation(SplitRenovation renovation)
        {
            if (renovation == null)
            {
                return BadRequest();
            }

            if (renovation.FirstNewRoomInfo.RoomName == renovation.SecondNewRoomInfo.RoomName)
            {
                return BadRequest("New room names must be unique");
            }

            await _renovationService.Create(renovation);

            return NoContent();
        }

    }
}

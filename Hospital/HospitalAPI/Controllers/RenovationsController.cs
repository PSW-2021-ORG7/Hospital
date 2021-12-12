using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;

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


        [HttpPost("mergeRenovations")]
        public async Task<IActionResult> PostMergeRenovation(MergeRenovation renovation)
        {
            if (renovation == null)
            {
                return BadRequest();
            }

            //TODO: Check if room name already exists

            if (!await _renovationService.CanBeMerged(renovation))
            {
                return BadRequest("Chosen rooms cannot be merged");
            }

            await _renovationService.Create(renovation);

            return NoContent();
        }


        [HttpGet("splitRenovations")]
        public async Task<IEnumerable<SplitRenovation>> GetSplitRenovations()
        {
            return await _renovationService.GetAllSplitRenovations();
        }

        [HttpGet("mergeRenovations")]
        public async Task<IEnumerable<MergeRenovation>> GetMergeRenovations()
        {
            return await _renovationService.GetAllMergeRenovations();
        }

    }
}

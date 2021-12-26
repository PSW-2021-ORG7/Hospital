using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalClassLibrary.Renovations.Models;
using HospitalClassLibrary.Renovations.Services.Interfaces;
using HospitalClassLibrary.Shared.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class RenovationsController : ControllerBase
    {
        private readonly IRenovationService _renovationService;
        private readonly ICancellationService _cancellationService;

        public RenovationsController(IRenovationService renovationService, ICancellationService cancellationService)
        {
            _renovationService = renovationService;
            _cancellationService = cancellationService;
        }

        [HttpPost("splitRenovations")]
        public async Task<IActionResult> PostSplitRenovation(SplitRenovation renovation)
        {
            if (renovation == null)
            {
                return BadRequest();
            }

            if (_renovationService.HasScheduledRenovations(renovation.RoomId).Result)
            {
                return BadRequest($"Room with id {renovation.RoomId} already has a scheduled renovation");
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

            if (_renovationService.HasScheduledRenovations(renovation.FirstOldRoomId).Result)
            {
                return BadRequest($"Room with id {renovation.FirstOldRoomId} already has a scheduled renovation");
            }

            if (_renovationService.HasScheduledRenovations(renovation.SecondOldRoomId).Result)
            {
                return BadRequest($"Room with id {renovation.SecondOldRoomId} already has a scheduled renovation");
            }

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

        [HttpGet("splitRenovations/{id}")]
        public async Task<IEnumerable<SplitRenovation>> GetSplitRenovationsForRoom(int id)
        {
            return await _renovationService.GetAllSplitRenovationsByRoomId(id);
        }

        [HttpGet("mergeRenovations/{id}")]
        public async Task<IEnumerable<MergeRenovation>> GetMergeRenovationsForRoom(int id)
        {
            return await _renovationService.GetAllMergeRenovationsByRoomId(id);
        }

        [HttpDelete("splitRenovations")]
        public async Task<IActionResult> DeleteSplitRenovation(SplitRenovation renovation)
        {
            if (await _cancellationService.CanBeCancelled(renovation.Start))
            {
                return BadRequest("Chosen renovation cannot be canceled");
            }

            await _renovationService.Delete(renovation);

            return NoContent();
        }

        [HttpDelete("mergeRenovations")]
        public async Task<IActionResult> DeleteMergeRenovation(MergeRenovation renovation)
        {
            if (await _cancellationService.CanBeCancelled(renovation.Start))
            {
                return BadRequest("Chosen renovation cannot be canceled");
            }

            await _renovationService.Delete(renovation);

            return NoContent();
        }
    }
}

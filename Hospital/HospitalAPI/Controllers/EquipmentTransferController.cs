 using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using HospitalAPI.DTOs;
using HospitalClassLibrary.RoomEquipment.Models;
using HospitalClassLibrary.RoomEquipment.Services.Interfaces;
using HospitalClassLibrary.Shared.Services.Interfaces;
using HospitalClassLibrary.Shared.Models;

namespace HospitalAPI.Controllers
{
    [Route("api/transfers")]
    [ApiController]
    public class EquipmentTransferController : ControllerBase
    {
        private readonly IEquipmentTransferService _equipmentTransferService;
        private readonly ICancellationService _cancellationService;
        private readonly IMapper _mapper;

        public EquipmentTransferController(IEquipmentTransferService equipmentTransferService, ICancellationService cancellationService, IMapper mapper)
        {
            _equipmentTransferService = equipmentTransferService;
            _cancellationService = cancellationService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> PostTransfer(EquipmentTransferDto e)
        {
            try
            {
                var equipmentTransfer = new EquipmentTransfer(e.Id, e.SourceRoomId, e.DestinationRoomId,
                    e.TransferDate, e.TransferDuration, e.EquipmentId, e.Quantity);

                await _equipmentTransferService.Create(equipmentTransfer);

                return NoContent();
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet]
        public async Task<IEnumerable<EquipmentTransferDto>> GetTransfers()
        {
            var transfers = await _equipmentTransferService.GetAll();
            return _mapper.Map<IEnumerable<EquipmentTransferDto>>(transfers);
        }

        [HttpGet("room/{id}")]
        public async Task<IEnumerable<EquipmentTransferDto>> GetTransfersForRoom(int id)
        {
            var transfers = await _equipmentTransferService.GetAllByRoomId(id);
            return _mapper.Map<IEnumerable<EquipmentTransferDto>>(transfers);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTransfer(EquipmentTransferDto e)
        {
            var transfer = _mapper.Map<EquipmentTransfer>(e);
            
            if (!await _cancellationService.CanBeCancelled(transfer.TransferDateInfo.TransferDate))
            {
                return BadRequest("Chosen equipment transfer cannot be canceled");
            }
            

            await _equipmentTransferService.Delete(transfer);

            return NoContent();
        }
    }
}

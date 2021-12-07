using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using HospitalAPI.DTOs;
using HospitalClassLibrary.RoomEquipment.Models;
using HospitalClassLibrary.RoomEquipment.Services.Interfaces;

namespace HospitalAPI.Controllers
{
    [Route("api/transfers")]
    [ApiController]
    public class EquipmentTransferController : ControllerBase
    {
        private readonly IEquipmentTransferService _equipmentTransferService;
        private readonly IMapper _mapper;

        public EquipmentTransferController(IEquipmentTransferService equipmentTransferService, IMapper mapper)
        {
            _equipmentTransferService = equipmentTransferService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> PostTransfer(EquipmentTransfer transfer)
        {
            if (transfer == null)
            {
                return BadRequest();
            }

            await _equipmentTransferService.Create(transfer);

            return NoContent();
        }

        [HttpGet]
        public async Task<IEnumerable<EquipmentTransferDto>> GetTransfers()
        {
            var transfers = await _equipmentTransferService.GetAll();
            return _mapper.Map<IEnumerable<EquipmentTransferDto>>(transfers);
        }
    }
}

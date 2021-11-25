using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HospitalClassLibrary.RoomEquipment.Models;
using HospitalClassLibrary.RoomEquipment.Services.Interfaces;

namespace HospitalAPI.Controllers
{
    [Route("api/transfers")]
    [ApiController]
    public class EquipmentTransferController : ControllerBase
    {
        private readonly IEquipmentTransferService _equipmentTransferService;

        public EquipmentTransferController(IEquipmentTransferService equipmentTransferService)
        {
            _equipmentTransferService = equipmentTransferService;
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
    }
}

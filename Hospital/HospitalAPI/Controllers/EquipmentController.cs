using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalClassLibrary.RoomEquipment.Models;
using Microsoft.AspNetCore.Mvc;
using HospitalClassLibrary.RoomEquipment.Services.Interfaces;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;

        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        [HttpGet]
        public async Task<IEnumerable<Equipment>> GetEquipment()
        {
            return await _equipmentService.GetAll();
        }
    }
}

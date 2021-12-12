using AutoMapper;
using AutoMapper.Configuration;
using backend.Services;
using HospitalAPI.DTOs.Medicine;
using HospitalClassLibrary.Medicine.DTOs;
using HospitalClassLibrary.Medicine.Models;
using HospitalClassLibrary.Medicine.Repositories.Interfaces;
using HospitalClassLibrary.Medicine.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MedicineController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private MedicineService _medicineService;
        private MedicineInventoryService _medicineInventoryService;
        private MedicineCombinationService _medicineCombinationService;

        public MedicineController(IConfiguration configuration, IMapper mapper, IMedicineRepository medicineRepository,
            IMedicineInventoryRepository medicineInventoryRepository, IMedicineCombinationRepository medicineCombinationRepository)
        {
            _configuration = configuration;
            _mapper = mapper;
            _medicineService = new MedicineService(medicineRepository, medicineInventoryRepository);
            _medicineInventoryService = new MedicineInventoryService(medicineInventoryRepository);
            _medicineCombinationService = new MedicineCombinationService(medicineCombinationRepository);
        }

        [HttpGet("test")]
        public IActionResult GetTest()
        {


            return Ok("It works");
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_medicineService.GetAll());
        }


        [HttpPost]
        public IActionResult CreateMedicine([FromBody] NewMedicineDTO medicineDTO)
        {
            Medicine medicine = _mapper.Map<Medicine>(medicineDTO);

            if (_medicineService.Save(medicine))
            {
                _medicineInventoryService.Save(new MedicineInventory(medicine.Id));
                foreach (int m in medicineDTO.MedicinesToCombineWith)
                {
                    _medicineCombinationService.Save(medicine.Id, m);
                }
                return Ok("Succesfully added medicine");
            }
            return BadRequest("Medicine with that name and dosage already exists");
        }


        [HttpGet("find/{name}/{dose}")]
        public ActionResult<Medicine> GetMedicineByNameAndDose(string name, int dose)
        {
            Medicine medicine = _medicineService.GetByNameAndDose(name, dose);

            if (medicine == null) return NotFound("This medicine doesn't exist.");
            return medicine;
        }

        /*
        [HttpGet("request/{name}/{dose}")]

        public IActionResult RequestSpecification(string name, int dose)
        {
            return Ok(JsonConvert.SerializeObject(_medicineService.RequestSpecification(name, dose)));
        }
        */


        // INVENTORY

        [HttpPost]
        [Route("/inventory/check")]
        public IActionResult CheckIfAvailable([FromBody] MedicineQuantityCheck medicineQuantityCheck)
        {
            if (_medicineService.CheckMedicineQuantity(medicineQuantityCheck))
                return Ok(true);

            return BadRequest(false);
        }


        [HttpPut]
        [Route("/inventory/{id}")]
        public IActionResult UpdateInventory([FromBody] MedicineInventory medicineInventory)
        {
            return Ok(_medicineInventoryService.Update(medicineInventory));
        }

    }

}

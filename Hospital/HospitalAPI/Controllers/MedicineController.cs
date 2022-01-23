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
    [Route("api/[controller]")]
    [ApiController] 
    public class MedicineController : Controller
    {
        private readonly IMapper _mapper;
        private MedicineService _medicineService;
        private MedicineInventoryService _medicineInventoryService;
        private MedicineCombinationService _medicineCombinationService;

        public MedicineController(IMapper mapper, IMedicineRepository medicineRepository,
            IMedicineInventoryRepository medicineInventoryRepository, IMedicineCombinationRepository medicineCombinationRepository)
        {
       
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

       [HttpGet("{id}")]
        public IActionResult FindMedicineByID(int id)
        {
            Medicine medicine = _medicineService.GetByID(id);
            if (medicine != null) return Ok(medicine);
            else return NotFound();

        }



        [HttpPut("inventory/order/{quantity}")]
        public IActionResult ProcessOrder([FromBody] Medicine medicine, int quantity)
        {

            if (_medicineService.MedicineExists(medicine))
            {
                Medicine foundMedicine = _medicineService.GetByNameAndDose(medicine.Name, medicine.DosageInMilligrams);
                return Ok(_medicineInventoryService.Update(new MedicineInventory(foundMedicine.Id, quantity)));
            }
            else
                if (_medicineService.Save(medicine))
                return Ok(_medicineInventoryService.Save(new MedicineInventory(medicine.Id, quantity)));


            return BadRequest(false);

        }

    }

}

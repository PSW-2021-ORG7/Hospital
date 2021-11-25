using System.Threading.Tasks;
using HospitalClassLibrary.RoomEquipment.Models;
using HospitalClassLibrary.RoomEquipment.Repositories.Interfaces;
using HospitalClassLibrary.RoomEquipment.Services.Interfaces;

namespace HospitalClassLibrary.RoomEquipment.Services
{
    public class EquipmentTransferService : IEquipmentTransferService
    {
        private readonly IEquipmentTransferRepository _equipmentTransferRepository;
        private readonly IEquipmentRepository _equipmentRepository;

        public EquipmentTransferService(IEquipmentTransferRepository equipmentTransferRepository, IEquipmentRepository equipmentRepository)
        {
            _equipmentTransferRepository = equipmentTransferRepository;
            _equipmentRepository = equipmentRepository;
        }

        public async Task Create(EquipmentTransfer e)
        {
            await _equipmentTransferRepository.CreateAsync(e);

            var equipment = await _equipmentRepository.GetByIdAsync(e.EquipmentId);
            equipment.ReservedQuantity += e.Quantity;
            await _equipmentRepository.UpdateAsync(equipment);
        }
    }
}

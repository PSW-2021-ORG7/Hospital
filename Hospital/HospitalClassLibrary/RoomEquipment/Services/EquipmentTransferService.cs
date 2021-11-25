using System.Threading.Tasks;
using HospitalClassLibrary.RoomEquipment.Models;
using HospitalClassLibrary.RoomEquipment.Repositories.Interfaces;
using HospitalClassLibrary.RoomEquipment.Services.Interfaces;

namespace HospitalClassLibrary.RoomEquipment.Services
{
    public class EquipmentTransferService : IEquipmentTransferService
    {
        private readonly IEquipmentTransferRepository _equipmentTransferRepository;

        public EquipmentTransferService(IEquipmentTransferRepository equipmentTransferRepository)
        {
            _equipmentTransferRepository = equipmentTransferRepository;
        }

        public async Task Create(EquipmentTransfer e)
        {
            await _equipmentTransferRepository.CreateAsync(e);
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalClassLibrary.Events.EventEquipmentTransfer;
using HospitalClassLibrary.Events.LogEvent;
using HospitalClassLibrary.RoomEquipment.Models;
using HospitalClassLibrary.RoomEquipment.Repositories.Interfaces;
using HospitalClassLibrary.RoomEquipment.Services.Interfaces;

namespace HospitalClassLibrary.RoomEquipment.Services
{
    public class EquipmentTransferService : IEquipmentTransferService
    {
        private readonly IEquipmentTransferRepository _equipmentTransferRepository;
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly ILogEventService<EquipmentTransferEventParams> _logEquipmentTransferEventService;

        public EquipmentTransferService(IEquipmentTransferRepository equipmentTransferRepository, IEquipmentRepository equipmentRepository
            , ILogEventService<EquipmentTransferEventParams> logEquipmentTransferEventService)
        {
            _equipmentTransferRepository = equipmentTransferRepository;
            _equipmentRepository = equipmentRepository;
            _logEquipmentTransferEventService = logEquipmentTransferEventService;
        }

        public async Task Create(EquipmentTransfer e)
        {
            await _equipmentTransferRepository.CreateAsync(e);
            var eventparams = new EquipmentTransferEventParams(e);
            _logEquipmentTransferEventService.LogEvent(eventparams);
            var equipment = await _equipmentRepository.GetByIdAsync(e.EquipmentId);
            equipment.ReservedQuantity += e.Quantity;
            await _equipmentRepository.UpdateAsync(equipment);
        }

        public async Task Delete(EquipmentTransfer e)
        {
            await _equipmentTransferRepository.DeleteAsync(e);
        }

        public async Task<IEnumerable<EquipmentTransfer>> GetAll()
        {
            return await _equipmentTransferRepository.GetAllAsync();
        }

        public async Task<IEnumerable<EquipmentTransfer>> GetAllByRoomId(int roomId)
        {
            return await _equipmentTransferRepository.GetAllByRoomIdAsync(roomId);
        }
    }
}

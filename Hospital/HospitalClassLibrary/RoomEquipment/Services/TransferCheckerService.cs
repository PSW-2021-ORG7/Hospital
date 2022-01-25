using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HospitalClassLibrary.RoomEquipment.Models;
using HospitalClassLibrary.RoomEquipment.Repositories.Interfaces;
using HospitalClassLibrary.RoomEquipment.Services.Interfaces;
using static HospitalClassLibrary.Shared.Constants;

namespace HospitalClassLibrary.RoomEquipment.Services
{
    public class TransferCheckerService : ITransferCheckerService
    {
        private readonly IEquipmentTransferRepository _equipmentTransferRepository;
        private readonly IEquipmentRepository _equipmentRepository;

        public TransferCheckerService(IEquipmentTransferRepository equipmentTransferRepository, IEquipmentRepository equipmentRepository)
        {
            _equipmentTransferRepository = equipmentTransferRepository;
            _equipmentRepository = equipmentRepository;
        }

        public async Task DoWork(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await CheckTransfers();

                await Task.Delay(TwoHours, stoppingToken);
            }
        }

        public async Task CheckTransfers()
        {
            foreach (var transfer in _equipmentTransferRepository.GetAllAsync().Result)
            {
                if (transfer.TransferDateInfo.TransferDate > DateTime.Now) continue;
  
                await UpdateSrcRoomEquipment(transfer);

                //Feature envy
                var dstRoomEquipment = transfer.TransferLocationInfo.DestinationRoom.Equipment.FirstOrDefault(e => e.EquipmentItem.Name == transfer.TransferEquipmentInfo.Equipment.EquipmentItem.Name);
                if (dstRoomEquipment == null)
                {
                    await CreateNewEquipmentInDstRoom(transfer);
                }
                else
                {
                    await UpdateDstRoomEquipment(dstRoomEquipment, transfer);
                }

                await _equipmentTransferRepository.DeleteAsync(transfer);
            }
        }

        private async Task UpdateSrcRoomEquipment(EquipmentTransfer transfer)
        {
            var srcRoomEquipment = transfer.TransferLocationInfo.SourceRoom.Equipment.First(e => e.Id == transfer.TransferEquipmentInfo.EquipmentId);
            srcRoomEquipment.Quantity -= transfer.TransferEquipmentInfo.Quantity;
            srcRoomEquipment.ReservedQuantity -= transfer.TransferEquipmentInfo.Quantity;
            await _equipmentRepository.UpdateAsync(srcRoomEquipment);
        }

        private async Task CreateNewEquipmentInDstRoom(EquipmentTransfer transfer)
        {
            var equipment = new Equipment()
            {
                RoomId = transfer.TransferLocationInfo.DestinationRoomId,
                Room = transfer.TransferLocationInfo.DestinationRoom,
                EquipmentItemId = transfer.TransferEquipmentInfo.Equipment.EquipmentItemId,
                EquipmentItem = transfer.TransferEquipmentInfo.Equipment.EquipmentItem,
                Quantity = transfer.TransferEquipmentInfo.Quantity,
                ReservedQuantity = 0
            };
            await _equipmentRepository.CreateAsync(equipment);
        }

        private async Task UpdateDstRoomEquipment(Equipment dstRoomEquipment, EquipmentTransfer transfer)
        {
            dstRoomEquipment.Quantity += transfer.TransferEquipmentInfo.Quantity;
            await _equipmentRepository.UpdateAsync(dstRoomEquipment);
        }
    }
}

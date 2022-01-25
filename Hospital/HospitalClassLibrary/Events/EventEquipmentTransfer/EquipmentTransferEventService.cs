using HospitalClassLibrary.Events.LogEvent;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalClassLibrary.Events.EventEquipmentTransfer
{
    public class EquipmentTransferEventService : ILogEventService<EquipmentTransferEventParams>
    {
        private readonly IEquipmentTransferEventRepository _equipmentTransferEventRepository;

        public EquipmentTransferEventService(IEquipmentTransferEventRepository equipmentTransferEventRepository)
        {
            _equipmentTransferEventRepository = equipmentTransferEventRepository;
        }

        public void LogEvent(EquipmentTransferEventParams eventParams)
        {
            var buildingSelectionEvent = new EquipmentTransferEvent
            { TimeStamp = DateTime.Now,
              DestinationRoomId = eventParams.DestinationRoomId,
              SourceRoomId = eventParams.SourceRoomId,
              Quantity = eventParams.Quantity.Amount,
              EquipmentId = eventParams.EquipmentId,
              TransferDate = eventParams.TransferDate,
              TransferDuration = eventParams.TransferDuration
            };

            _equipmentTransferEventRepository.LogEvent(buildingSelectionEvent);
        }

        public List<EquipmentTransferEvent> GetAll()
        {
            return _equipmentTransferEventRepository.GetAll();
        }
    }
}

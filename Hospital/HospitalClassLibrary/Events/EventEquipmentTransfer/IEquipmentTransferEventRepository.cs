using HospitalClassLibrary.Events.LogEvent;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLibrary.Events.EventEquipmentTransfer
{
    public interface IEquipmentTransferEventRepository : IEventRepository<EquipmentTransferEvent>
    {
        List<EquipmentTransferEvent> GetAll();
        Task<IEnumerable<EquipmentTransferEvent>> GetAllEvents();
    }
}

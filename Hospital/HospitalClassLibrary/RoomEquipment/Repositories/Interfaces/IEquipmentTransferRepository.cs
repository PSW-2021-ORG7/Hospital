using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HospitalClassLibrary.RoomEquipment.Models;
using HospitalClassLibrary.Shared.Models;
using HospitalClassLibrary.Shared.Repositories;

namespace HospitalClassLibrary.RoomEquipment.Repositories.Interfaces
{
    public interface IEquipmentTransferRepository : IGenericRepository<EquipmentTransfer>
    {
        IEnumerable<EquipmentTransfer> GetAll(DateTimeRange dateTimeRange);
    }
}

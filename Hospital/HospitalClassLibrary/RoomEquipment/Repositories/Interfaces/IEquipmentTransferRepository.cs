﻿using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalClassLibrary.RoomEquipment.Models;
using HospitalClassLibrary.Shared.Models;
using HospitalClassLibrary.Shared.Repositories;

namespace HospitalClassLibrary.RoomEquipment.Repositories.Interfaces
{
    public interface IEquipmentTransferRepository : IGenericRepository<EquipmentTransfer>
    {
        Task<IEnumerable<EquipmentTransfer>> GetAllByRoomIdAsync(int roomId);
        Task<IEnumerable<DateTimeRange>> GetAllDates(DateTimeRange dateTimeRange, int firstRoomId, int secondRoomId);
    }
}

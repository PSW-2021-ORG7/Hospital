using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalClassLibrary.Data;
using HospitalClassLibrary.RoomEquipment.Models;
using HospitalClassLibrary.RoomEquipment.Repositories.Interfaces;
using HospitalClassLibrary.Shared.Models;
using HospitalClassLibrary.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HospitalClassLibrary.RoomEquipment.Repositories
{
    public class EquipmentTransferRepository : GenericRepository<EquipmentTransfer>, IEquipmentTransferRepository
    {
        public EquipmentTransferRepository(AppDbContext context) : base(context)
        {
        }

        public new async Task<IEnumerable<EquipmentTransfer>> GetAllAsync()
        {
            return await Context.EquipmentTransfer.Include(t => t.TransferLocationInfo.SourceRoom).ThenInclude(src => src.Equipment)
                .Include(t => t.TransferLocationInfo.DestinationRoom).ThenInclude(dst => dst.Equipment).ThenInclude(e => e.EquipmentItem)
                .Include(t => t.TransferEquipmentInfo.Equipment).ThenInclude(e => e.EquipmentItem)
                .ToListAsync();
        }

        public async Task<IEnumerable<DateTimeRange>> GetAllDates(DateTimeRange dateTimeRange, int firstRoomId, int secondRoomId)
        {
            return await Context.EquipmentTransfer.Where(t =>
                t.TransferDateInfo.TransferDate >= dateTimeRange.Start &&
                t.TransferDateInfo.TransferDate.AddMinutes(t.TransferDateInfo.TransferDuration) <= dateTimeRange.End &&
                (t.TransferLocationInfo.SourceRoomId == firstRoomId || t.TransferLocationInfo.DestinationRoomId == firstRoomId ||
                t.TransferLocationInfo.SourceRoomId == secondRoomId || t.TransferLocationInfo.DestinationRoomId == secondRoomId))
                .Select(t => new DateTimeRange() {Start = t.TransferDateInfo.TransferDate, End = t.TransferDateInfo.TransferDate.AddMinutes(t.TransferDateInfo.TransferDuration)})
                .ToListAsync();
        }

        public async Task<IEnumerable<EquipmentTransfer>> GetAllByRoomIdAsync(int roomId)
        {
            return await Context.EquipmentTransfer.Where(t =>
                t.TransferLocationInfo.SourceRoomId == roomId || t.TransferLocationInfo.DestinationRoomId == roomId).
                Include(t => t.TransferLocationInfo.SourceRoom).Include(t => t.TransferLocationInfo.DestinationRoom).ToListAsync();
        }
    }
}

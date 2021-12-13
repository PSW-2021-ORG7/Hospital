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
            return await Context.EquipmentTransfer.Include(t => t.SourceRoom).ThenInclude(src => src.Equipment)
                .Include(t => t.DestinationRoom).ThenInclude(dst => dst.Equipment).ThenInclude(e => e.EquipmentItem)
                .Include(t => t.Equipment).ThenInclude(e => e.EquipmentItem)
                .ToListAsync();
        }

        public IEnumerable<EquipmentTransfer> GetAll(DateTimeRange dateTimeRange)
        {
            return Context.EquipmentTransfer.Where(t =>
                t.TransferDate >= dateTimeRange.Start &&
                t.TransferDate.AddMinutes(t.TransferDuration) <= dateTimeRange.End).ToList();
        }

        public async Task<IEnumerable<EquipmentTransfer>> GetAllByRoomIdAsync(int roomId)
        {
            return await Context.EquipmentTransfer.Where(t =>
                t.SourceRoomId == roomId ||
                t.DestinationRoomId == roomId).Include(t => t.SourceRoom).Include(t => t.DestinationRoom).ToListAsync();
        }
    }
}

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

        public IEnumerable<EquipmentTransfer> GetAll(DateTimeRange dateTimeRange)
        {
            return Context.EquipmentTransfer.Where(t =>
                t.TransferDate >= dateTimeRange.Start &&
                t.TransferDate.AddMinutes(t.TransferDuration) <= dateTimeRange.End).ToList();
        }
    }
}

using HospitalClassLibrary.Data;
using HospitalClassLibrary.Events.LogEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalClassLibrary.Events.EventEquipmentTransfer
{
    public class EquipmentTransferEventDatabase : EventDatabase<EquipmentTransferEvent>, IEquipmentTransferEventRepository
    {
        public EquipmentTransferEventDatabase(AppDbContext dbContext) : base(dbContext)
        {
        }

        public override void LogEvent(EquipmentTransferEvent @event)
        {
            DbContext.EquipmentTransferEvent.Add(@event);
            DbContext.SaveChanges();
        }

        public List<EquipmentTransferEvent> GetAll()
        {
            foreach (EquipmentTransferEvent building in DbContext.EquipmentTransferEvent.ToList())
                DbContext.Entry(building).Reload();
            return DbContext.EquipmentTransferEvent.ToList();
        }
    }
}

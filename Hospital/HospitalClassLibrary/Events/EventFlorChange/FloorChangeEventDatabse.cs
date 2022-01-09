using HospitalClassLibrary.Data;
using HospitalClassLibrary.Events.LogEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalClassLibrary.Events.EventFlorChange
{
    class FloorChangeEventDatabase : EventDatabase<FloorChange>, IFloorChangeEventRepository
    {
        public FloorChangeEventDatabase(AppDbContext dbContext) : base(dbContext)
        {
        }

        public override void LogEvent(FloorChange @event)
        {
            DbContext.FloorChange.Add(@event);
            DbContext.SaveChanges();
        }

        public List<FloorChange> GetAll()
        {
            foreach (FloorChange building in DbContext.FloorChange.ToList())
                DbContext.Entry(building).Reload();
            return DbContext.FloorChange.ToList();
        }
    }
}

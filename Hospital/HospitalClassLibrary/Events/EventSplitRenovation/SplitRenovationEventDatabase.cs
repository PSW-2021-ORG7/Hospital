using HospitalClassLibrary.Data;
using HospitalClassLibrary.Events.LogEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalClassLibrary.Events.EventSplitRenovation
{
    public class SplitRenovationEventDatabase : EventDatabase<SplitRenovationEvent>, ISplitRenovationEventRepository
    {
        public SplitRenovationEventDatabase(AppDbContext dbContext) : base(dbContext)
        {
        }

        public override void LogEvent(SplitRenovationEvent @event)
        {
            DbContext.SplitRenovation1.Add(@event);
            DbContext.SaveChanges();
        }

        public List<SplitRenovationEvent> GetAll()
        {
            foreach (SplitRenovationEvent room in DbContext.SplitRenovation1.ToList())
                DbContext.Entry(room).Reload();
            return DbContext.SplitRenovation1.ToList();
        }
    }

}

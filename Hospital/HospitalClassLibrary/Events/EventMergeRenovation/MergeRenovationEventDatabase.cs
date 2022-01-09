using HospitalClassLibrary.Data;
using HospitalClassLibrary.Events.LogEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalClassLibrary.Events.EventMergeRenovation
{
    public class MergeRenovationEventDatabase : EventDatabase<MergeRenovationEvent>, IMergeRenovationEventRepository
    {
            public MergeRenovationEventDatabase(AppDbContext dbContext) : base(dbContext)
            {
            }

            public override void LogEvent(MergeRenovationEvent @event)
            {
                DbContext.MergeRenovation1.Add(@event);
                DbContext.SaveChanges();
            }

            public List<MergeRenovationEvent> GetAll()
            {
                foreach (MergeRenovationEvent room in DbContext.MergeRenovation1.ToList())
                    DbContext.Entry(room).Reload();
                return DbContext.MergeRenovation1.ToList();
            }
        }
    }


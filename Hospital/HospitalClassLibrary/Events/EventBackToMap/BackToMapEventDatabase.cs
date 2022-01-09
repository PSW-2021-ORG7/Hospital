using HospitalClassLibrary.Data;
using HospitalClassLibrary.Events.LogEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalClassLibrary.Events.EventBackToMap
{
    class BackToMapEventDatabase : EventDatabase<BackToMap>, IBackToMapEventRepository
    {
        public BackToMapEventDatabase(AppDbContext dbContext) : base(dbContext)
        {
        }

        public override void LogEvent(BackToMap @event)
        {
            DbContext.BackToMap.Add(@event);
            DbContext.SaveChanges();
        }

        public List<BackToMap> GetAll()
        {
            foreach (BackToMap building in DbContext.BackToMap.ToList())
                DbContext.Entry(building).Reload();
            return DbContext.BackToMap.ToList();
        }
    }
  
}

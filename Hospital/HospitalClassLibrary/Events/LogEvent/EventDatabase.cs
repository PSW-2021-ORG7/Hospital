using HospitalClassLibrary.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalClassLibrary.Events.LogEvent
{
    public abstract class EventDatabase<T> : IEventRepository<T> where T : Event
    {
        protected readonly AppDbContext DbContext;

        protected EventDatabase(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public abstract void LogEvent(T @event);
    }
}

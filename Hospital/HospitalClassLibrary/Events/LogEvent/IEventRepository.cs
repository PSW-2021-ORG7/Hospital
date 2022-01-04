using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalClassLibrary.Events.LogEvent
{
    public interface IEventRepository<in T> where T : Event
    {
        void LogEvent(T @event);
    }
}

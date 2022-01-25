using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalClassLibrary.Events.LogEvent
{
    public interface ILogEventService<in T> where T : EventParams
    {
        void LogEvent(T eventParams);

    }
}

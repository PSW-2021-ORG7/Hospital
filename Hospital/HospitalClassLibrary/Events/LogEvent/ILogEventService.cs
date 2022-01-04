using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalClassLibrary.Events.LogEvent
{
    interface ILogEventService<in T> where T : EventParams
    {
        void LogEvent(T eventParams);
    }
}

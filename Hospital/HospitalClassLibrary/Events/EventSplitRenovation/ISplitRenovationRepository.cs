using HospitalClassLibrary.Events.LogEvent;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalClassLibrary.Events.EventSplitRenovation
{
    public interface ISplitRenovationEventRepository : IEventRepository<SplitRenovationEvent>
    {
        List<SplitRenovationEvent> GetAll();

    }
}

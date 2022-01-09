using HospitalClassLibrary.Events.LogEvent;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalClassLibrary.Events.EventMergeRenovation
{
    public interface IMergeRenovationEventRepository : IEventRepository<MergeRenovationEvent>
   {      List<MergeRenovationEvent> GetAll();
    
    }
}

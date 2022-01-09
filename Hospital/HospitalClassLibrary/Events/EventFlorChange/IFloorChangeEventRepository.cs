using HospitalClassLibrary.Events.LogEvent;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalClassLibrary.Events.EventFlorChange
{
    public interface IFloorChangeEventRepository : IEventRepository<FloorChange>
    {
        List<FloorChange> GetAll();
    }
}

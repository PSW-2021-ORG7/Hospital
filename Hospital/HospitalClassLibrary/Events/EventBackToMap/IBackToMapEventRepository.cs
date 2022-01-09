using HospitalClassLibrary.Events.LogEvent;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalClassLibrary.Events.EventBackToMap
{
    public interface IBackToMapEventRepository : IEventRepository<BackToMap>
    {
        List<BackToMap> GetAll();
    }
}

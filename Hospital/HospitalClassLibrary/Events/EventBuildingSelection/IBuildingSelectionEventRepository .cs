using HospitalClassLibrary.Events.LogEvent;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalClassLibrary.Events.EventBuildingSelection
{
    public interface IBuildingSelectionEventRepository : IEventRepository<BuildingSelection>
    {
        List<BuildingSelection> GetAll();
    }
}

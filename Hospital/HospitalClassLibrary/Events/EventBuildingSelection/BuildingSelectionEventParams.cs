using HospitalClassLibrary.Events.LogEvent;
using HospitalClassLibrary.GraphicalEditor.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalClassLibrary.Events.EventBuildingSelection
{
    public class BuildingSelectionEventParams : EventParams
    {
        public int buildingId { get; set; }

        public BuildingSelectionEventParams(int buildingId)
        {
            this.buildingId = buildingId;
        }
    }
}

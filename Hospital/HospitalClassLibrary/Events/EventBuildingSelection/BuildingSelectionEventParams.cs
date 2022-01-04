using HospitalClassLibrary.Events.LogEvent;
using HospitalClassLibrary.GraphicalEditor.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalClassLibrary.Events.EventBuildingSelection
{
    public class BuildingSelectionEventParams : EventParams
    {
        public Building Building { get; set; }
    }
}

using HospitalClassLibrary.Events.LogEvent;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalClassLibrary.Events.EventBackToMap
{
    public class BackToMapEventParams : EventParams
    {
        public int fromBuildingId { get; set; }

        public BackToMapEventParams(int buildingId)
        {
            this.fromBuildingId = buildingId;
        }
    }
}

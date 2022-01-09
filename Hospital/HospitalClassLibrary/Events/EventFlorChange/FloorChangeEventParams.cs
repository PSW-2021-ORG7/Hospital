using HospitalClassLibrary.Events.LogEvent;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalClassLibrary.Events.EventFlorChange
{
    public class FloorChangeEventParams : EventParams
    {
        public int buildingId { get; set; }
        public int fromFloor { get; set; }
        public int toFloor { get; set; }

        public FloorChangeEventParams(int buildingId, int fromFloor, int toFloor)
        {
            this.buildingId = buildingId;
            this.fromFloor = fromFloor;
            this.toFloor = toFloor;
        }
    }
}

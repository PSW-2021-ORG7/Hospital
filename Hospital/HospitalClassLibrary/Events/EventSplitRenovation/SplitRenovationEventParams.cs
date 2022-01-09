using HospitalClassLibrary.Events.LogEvent;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalClassLibrary.Events.EventSplitRenovation
{
    public class SplitRenovationEventParams : EventParams
    {
        public int RoomId { get; set; }
        public string FirstNewRoomName { get; set; }
        public string SecondNewRoomName { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string EquipmentDestination { get; set; }

        public SplitRenovationEventParams(int rid, string fname, string sname, DateTime start, DateTime end, string equipmentDestination)
        {
            this.RoomId = rid;
            this.FirstNewRoomName = fname;
            this.SecondNewRoomName = sname;
            this.Start = start;
            this.End = end;
            this.EquipmentDestination = equipmentDestination;
        }

    }
}

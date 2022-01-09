using HospitalClassLibrary.Events.LogEvent;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalClassLibrary.Events.EventMergeRenovation
{
    public class MergeRenovationEventParams : EventParams
    {
        public int FirstOldRoomId { get; set; }
        public int SecondOldRoomId { get; set; }
        public string NewRoomName { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public MergeRenovationEventParams(int fid, int sid, string newRoomName, DateTime start, DateTime end)
        {
            this.FirstOldRoomId = fid;
                this.SecondOldRoomId = sid;
                this.NewRoomName = newRoomName;
            this.Start = start;
            this.End = end;
        }
        
    }
}

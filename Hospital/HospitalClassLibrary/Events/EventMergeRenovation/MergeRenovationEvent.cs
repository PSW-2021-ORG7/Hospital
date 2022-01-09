using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HospitalClassLibrary.Events.EventMergeRenovation
{
    [Table(nameof(MergeRenovationEvent), Schema = "Events")]
    public class MergeRenovationEvent : Event
    {
        public int FirstOldRoomId { get; set; }
        public int SecondOldRoomId { get; set; }
        public string NewRoomName { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}

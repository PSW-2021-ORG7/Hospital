using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HospitalClassLibrary.Events.EventSplitRenovation
{
    [Table(nameof(SplitRenovationEvent), Schema = "Events")]
    public class SplitRenovationEvent : Event
    {
        
        public int RoomId { get; set; }
        public string FirstNewRoomName{ get; set; }
        public string SecondNewRoomName { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string EquipmentDestination { get; set; }
    }
}

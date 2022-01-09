using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HospitalClassLibrary.Events.EventFlorChange
{
    [Table(nameof(FloorChange), Schema = "Events")]
    public class FloorChange : Event
    {
        public int buildingId { get; set; }
        public int fromFloor { get; set; }
        public int toFloor { get; set; }
    }
}

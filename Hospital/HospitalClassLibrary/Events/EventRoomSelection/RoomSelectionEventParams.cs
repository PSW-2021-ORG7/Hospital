using HospitalClassLibrary.Events.LogEvent;
using HospitalClassLibrary.RoomEquipment.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalClassLibrary.Events.EventRoomSelection
{
    public class RoomSelectionEventParams : EventParams
    {
        public Room Room { get; set; }
    }
}

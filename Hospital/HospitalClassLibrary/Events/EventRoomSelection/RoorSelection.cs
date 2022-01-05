using HospitalClassLibrary.RoomEquipment.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HospitalClassLibrary.Events.EventRoomSelection
{
    [Table(nameof(RoomSelection), Schema = "Events")]
    public class RoomSelection : Event
    {
        public int RoomId { get; set; }
    }
}

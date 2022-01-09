using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HospitalClassLibrary.Events.EventBackToMap
{
    [Table(nameof(BackToMap), Schema = "Events")]
    public class BackToMap : Event
    {
        public int fromBouldingId { get; set; }
    }
}

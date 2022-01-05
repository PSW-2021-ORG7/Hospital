using HospitalClassLibrary.GraphicalEditor.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HospitalClassLibrary.Events
{
    [Table(nameof(BuildingSelection), Schema = "Events")]
    public class BuildingSelection : Event
    {
        public int buildingId { get; set; }
    }
}

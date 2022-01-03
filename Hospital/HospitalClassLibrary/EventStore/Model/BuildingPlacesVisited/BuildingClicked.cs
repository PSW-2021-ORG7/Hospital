using HospitalClassLibrary.EventStore.Infrastucture;
using HospitalClassLibrary.GraphicalEditor.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalClassLibrary.EventStore.Model.BuildingPlacesVisited
{
    public class BuildingClicked : DomainEvent
    {
        public BuildingClicked(int aggregateId, Building building)
            : base(aggregateId)
        {
            Building = building;
        }

        public Building Building { get; private set; }
    }
}

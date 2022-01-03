using HospitalClassLibrary.EventStore.Infrastucture;
using HospitalClassLibrary.GraphicalEditor.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalClassLibrary.EventStore.Model.BuildingPlacesVisited
{
    public class BuildingPlacesVisited : EventSourcedAggregate
    {
        private Building building;
        private BuildingPlacesVisitedSnapshot snapshot;

        public int InitialVersion { get; private set; }

        public BuildingPlacesVisited()
        { }

        public BuildingPlacesVisited(int id, Building building)
        {
            Causes(new BuildingClicked(id, building));
        }

        public BuildingPlacesVisited(BuildingPlacesVisitedSnapshot snapshot)
        {
            Version = snapshot.Version;
            InitialVersion = snapshot.Version;
        }

        public BuildingPlacesVisitedSnapshot GetBuildingPlacesVisitedSnapshot()
        {
            return new BuildingPlacesVisitedSnapshot
            {
                Version = Version
            };
        }

        public override void Apply(DomainEvent @event)
        {
            When((dynamic)@event);
            Version = Version++;
        }

        private void Causes(DomainEvent @event)
        {
            Changes.Add(@event);
            Apply(@event);
        }

        private void When(BuildingClicked buildingClicked)
        {
            Id = buildingClicked.Id;
            building = buildingClicked.Building;
        }
    }
}

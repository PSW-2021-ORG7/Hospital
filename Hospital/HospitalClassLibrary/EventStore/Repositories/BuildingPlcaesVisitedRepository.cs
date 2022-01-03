using HospitalClassLibrary.EventStore.Infrastucture;
using HospitalClassLibrary.EventStore.Model.BuildingPlacesVisited;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalClassLibrary.EventStore.Repositories
{
    public class BuildingPlcaesVisitedRepository
    {
        private readonly IEventStore _eventStore;

        public BuildingPlcaesVisitedRepository(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public BuildingPlacesVisited FindBy(int id)
        {
            var streamName = StreamNameFor(id);

            var fromEventNumber = 0;
            var toEventNumber = int.MaxValue;

            var snapshot = _eventStore.GetLatestSnapshot<BuildingPlacesVisitedSnapshot>(streamName);
            if (snapshot != null)
            {
                fromEventNumber = snapshot.Version + 1; // load only events after snapshot
            }

            var stream = _eventStore.GetStream(streamName, fromEventNumber, toEventNumber);

            BuildingPlacesVisited payAsYouGoAccount = null;
            if (snapshot != null)
            {
                payAsYouGoAccount = new BuildingPlacesVisited(snapshot);
            }
            else
            {
                payAsYouGoAccount = new BuildingPlacesVisited();
            }


            foreach (var @event in stream)
            {
                payAsYouGoAccount.Apply(@event);
            }

            return payAsYouGoAccount;
        }


        public void Add(BuildingPlacesVisited payAsYouGoAccount)
        {
            var streamName = StreamNameFor(payAsYouGoAccount.Id);

            _eventStore.CreateNewStream(streamName, payAsYouGoAccount.Changes);
        }

        public void Save(BuildingPlacesVisited payAsYouGoAccount)
        {
            var streamName = StreamNameFor(payAsYouGoAccount.Id);

            var expectedVersion = GetExpectedVersion(payAsYouGoAccount.InitialVersion);
            _eventStore.AppendEventsToStream(streamName, payAsYouGoAccount.Changes, expectedVersion);
        }

        private int? GetExpectedVersion(int expectedVersion)
        {
            if (expectedVersion == 0)
            {
                // first time the aggregate is stored there is no expected version
                return null;
            }
            else
            {
                return expectedVersion;
            }
        }

        public void SaveSnapshot(BuildingPlacesVisitedSnapshot snapshot, BuildingPlacesVisited buildingPlacesVisited)
        {
            var streamName = StreamNameFor(buildingPlacesVisited.Id);

            _eventStore.AddSnapshot<BuildingPlacesVisitedSnapshot>(streamName, snapshot);
        }

        private string StreamNameFor(int id)
        {
            // Stream per-aggregate: {AggregateType}-{AggregateId}
            return string.Format("{0}-{1}", typeof(BuildingPlacesVisited).Name, id);
        }
    }
}


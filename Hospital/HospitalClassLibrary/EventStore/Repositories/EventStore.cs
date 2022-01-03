using HospitalClassLibrary.Data;
using HospitalClassLibrary.EventStore.Infrastucture;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalClassLibrary.EventStore.Repositories
{
    public class EventStore : IEventStore
    {
        private readonly AppDbContext db;

        public EventStore(AppDbContext context)
        {
            db = context;
        }

        public void AppendEventsToStream(string streamName, IEnumerable<DomainEvent> domainEvents, int? expectedVersion=null)
        {
            //var stream = _documentSession.Load<EventStream>(streamName);

            //if (expectedVersion != null)
            //{
            //    CheckForConcurrencyError(expectedVersion, stream);
            //}

            //foreach (var @event in domainEvents)
            //{
            //    _documentSession.Store(stream.RegisterEvent(@event));
            //}
        }

        public void CreateNewStream(string streamName, IEnumerable<DomainEvent> domainEvents)
        {
            //var eventStream = new EventStream(streamName);
            //_documentSession.Store(eventStream);

            //AppendEventsToStream(streamName, domainEvents);
        }


        public IEnumerable<DomainEvent> GetStream(string streamName, int fromVersion, int toVersion)
        {
            //var eventWrappers = (from stream in _documentSession.Query<EventWrapper>()
            //                     .Customize(x => x.WaitForNonStaleResultsAsOfNow())
            //                     where stream.EventStreamId.Equals(streamName)
            //                     && stream.EventNumber <= toVersion
            //                     && stream.EventNumber >= fromVersion
            //                     orderby stream.EventNumber
            //                     select stream).ToList();

            //if (eventWrappers.Count() == 0) return null;

            //var events = new List<DomainEvent>();

            //foreach (var @event in eventWrappers)
            //{
            //    events.Add(@event.Event);
            //}

            //return events;
            return null;
        }

        public void AddSnapshot<T>(string streamName, T snapshot)
        {
            //var wrapper = new SnapshotWrapper
            //{
            //    StreamName = streamName,
            //    Snapshot = snapshot,
            //    Created = DateTime.Now
            //};

            //_documentSession.Store(snapshot);
        }

        public T GetLatestSnapshot<T>(string streamName) where T : class
        {
            //var latestSnapshot = _documentSession.Query<SnapshotWrapper>()
            //                .Customize(x => x.WaitForNonStaleResultsAsOfNow())
            //                .Where(x => x.StreamName == streamName)
            //                .OrderByDescending(x => x.Created)
            //                .FirstOrDefault();

            //if (latestSnapshot == null)
            //{
              return null;
            //}
            //else
            //{
            //    return (T)latestSnapshot.Snapshot;
            //}
        }


        private static void CheckForConcurrencyError(int? expectedVersion, EventStream stream)
        {
            var lastUpdatedVersion = stream.Version;
            if (lastUpdatedVersion != expectedVersion)
            {
                var error = string.Format("Expected: {0}. Found: {1}", expectedVersion, lastUpdatedVersion);
                throw new OptimsticConcurrencyException(error);
            }
        }


        public class SnapshotWrapper
        {
            public string StreamName { get; set; }

            public Object Snapshot { get; set; }

            public DateTime Created { get; set; }
        }

        public class OptimsticConcurrencyException : Exception
        {
            public OptimsticConcurrencyException(string message) : base(message) { }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalClassLibrary.EventStore.Infrastucture
{
    public abstract class DomainEvent
    {
        public DomainEvent(int aggregateId)
        {
            Id = aggregateId;
        }

        public int Id { get; private set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalClassLibrary.EventStore.Infrastucture
{
    public class EventStream
    {
        public string Id { get; private set; } //aggregate type + id
        public int Version { get; private set; }

        private EventStream() { }

        public EventStream(string id)
        {
            Id = id;
            Version = 0;
        }

        public EventWrapper RegisterEvent(DomainEvent @event)
        {
            Version++;

            return new EventWrapper(@event, Version, Id);
        }
    }
}

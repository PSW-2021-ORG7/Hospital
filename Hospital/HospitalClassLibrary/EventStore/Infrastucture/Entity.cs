using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalClassLibrary.EventStore.Infrastucture
{
    public abstract class Entity
    {
        public int Id { get; protected set; }
    }
}

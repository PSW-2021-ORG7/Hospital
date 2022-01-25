using System;
using System.Collections.Generic;
using HospitalClassLibrary.Shared.Models;

namespace HospitalClassLibrary.Schedule.Models
{
    public class Appointment : ValueObject
    {
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }

        public Appointment() { }

        public Appointment(DateTime startTime, DateTime endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
            Validate();
        }

        private void Validate()
        {
            if (StartTime > EndTime)
            {
                throw new ArgumentException("Not valid");
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return StartTime;
            yield return EndTime;
        }
    }
}

using HospitalClassLibrary.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalClassLibrary.RoomEquipment.Models
{
    public class TransferDateInfo : ValueObject
    {
        public TransferDateInfo(DateTime transferDate, int transferDuration)
        {
            TransferDate = transferDate;
            TransferDuration = transferDuration;
        }

        public DateTime TransferDate { get; private set; }
        public int TransferDuration { get; private set; }

        public bool Validate()
        {
            if(TransferDate.AddMinutes(TransferDuration).DayOfYear > TransferDate.DayOfYear)
                return false;
            return true;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return TransferDate;
            yield return TransferDuration;
        }
    }
}

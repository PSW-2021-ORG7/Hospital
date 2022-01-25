using HospitalClassLibrary.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalClassLibrary.RoomEquipment.Models
{
    public class TransferEquipmentInfo : ValueObject
    {
        public TransferEquipmentInfo(int equipmentId, int quantity)
        {
            EquipmentId = equipmentId;
            Quantity = quantity;
        }

        public int EquipmentId { get; private set; }
        public Equipment Equipment { get; private set; }

        public int Quantity { get; private set; }

        public bool Validate()
        {
            //if (Quantity <= Equipment.ReservedQuantity && Quantity >= 0)
            //   return false;
            return true;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return EquipmentId;
            yield return Quantity;
        }
    }
}

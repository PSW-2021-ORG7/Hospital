using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalClassLibrary.Shared.Models
{
    public class Quantity : ValueObject
    {
        public int Amount { get; private set; }

        public Quantity() {}

        public Quantity(int amount)
        {
            Amount = amount;
        }

        public void Add(int amountToAdd)
        {
            if(amountToAdd > 0)
                Amount += amountToAdd;
        }

        public void Subtract(int amountToSubtract)
        {
            if (Amount - amountToSubtract > 0)
                Amount -= amountToSubtract;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
        }

        public bool Validate()
        {
            if (Amount > 0)
                return true;
            return false;
        }
    }
}

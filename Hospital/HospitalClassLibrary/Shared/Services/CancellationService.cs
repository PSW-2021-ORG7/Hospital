using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HospitalClassLibrary.Shared.Services.Interfaces;

namespace HospitalClassLibrary.Shared.Services
{
    public class CancellationService : ICancellationService
    {
        public Task<bool> CanBeCancelled(DateTime dateTime)
        {
            return Task.FromResult(dateTime.Subtract(DateTime.Now).Days >= 1);
        }
    }
}

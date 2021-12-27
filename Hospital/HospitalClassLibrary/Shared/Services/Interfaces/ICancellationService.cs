using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLibrary.Shared.Services.Interfaces
{
    public interface ICancellationService
    {
        Task<bool> CanBeCancelled(DateTime dateTime);
    }
}

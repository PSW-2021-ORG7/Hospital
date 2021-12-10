using System.Threading;
using System.Threading.Tasks;

namespace HospitalClassLibrary.Renovations.Services.Interfaces
{
    public interface IRenovationCheckerService
    {
        Task DoWork(CancellationToken stoppingToken);
        Task CheckRenovations();
    }
}

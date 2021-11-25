using System.Threading;
using System.Threading.Tasks;

namespace HospitalClassLibrary.RoomEquipment.Services.Interfaces
{
    public interface ITransferCheckerService
    {
        Task DoWork(CancellationToken cancellationToken);
    }
}

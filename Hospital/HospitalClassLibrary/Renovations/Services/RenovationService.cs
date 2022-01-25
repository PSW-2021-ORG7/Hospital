using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalClassLibrary.Events.EventMergeRenovation;
using HospitalClassLibrary.Events.EventSplitRenovation;
using HospitalClassLibrary.Events.LogEvent;
using HospitalClassLibrary.GraphicalEditor.Models;
using HospitalClassLibrary.Renovations.Models;
using HospitalClassLibrary.Renovations.Repositories.Interfaces;
using HospitalClassLibrary.Renovations.Services.Interfaces;
using HospitalClassLibrary.RoomEquipment.Models;
using HospitalClassLibrary.RoomEquipment.Repositories.Interfaces;

namespace HospitalClassLibrary.Renovations.Services
{
    public class RenovationService : IRenovationService
    {
        private readonly ISplitRenovationRepository _splitRenovationRepository;
        private readonly IMergeRenovationRepository _mergeRenovationRepository;
        private readonly ILogEventService<SplitRenovationEventParams> _logSplitRenovationEventService;
        private readonly ILogEventService<MergeRenovationEventParams> _logMergeRenovationEventService;

        private readonly IRoomRepository _roomRepository;
        bool fromFront;

        public RenovationService(ISplitRenovationRepository splitRenovationRepository, IMergeRenovationRepository mergeRenovationRepository, IRoomRepository roomRepository, ILogEventService<MergeRenovationEventParams> logMergeRenovationEventService, ILogEventService<SplitRenovationEventParams> logSplitRenovationEventService)
        {
            _splitRenovationRepository = splitRenovationRepository;
            _mergeRenovationRepository = mergeRenovationRepository;
            _roomRepository = roomRepository;
            _logMergeRenovationEventService = logMergeRenovationEventService;
            _logSplitRenovationEventService = logSplitRenovationEventService;
            fromFront = true;
        }

        public RenovationService(ISplitRenovationRepository object1, IMergeRenovationRepository object2, IRoomRepository object3)
        {
            this._splitRenovationRepository = object1;
            this._mergeRenovationRepository = object2;
            this._roomRepository = object3;
            fromFront = false;

        }

        public async Task<IEnumerable<SplitRenovation>> GetAllSplitRenovations()
        {
            return await _splitRenovationRepository.GetAllAsync();
        }

        public async Task Create(SplitRenovation r)
        {
            if (fromFront)
            {
                var eventparams = new SplitRenovationEventParams(r.RoomId, r.FirstNewRoomInfo.RoomName, r.SecondNewRoomInfo.RoomName, r.Start, r.End, r.EquipmentDestination);
                _logSplitRenovationEventService.LogEvent(eventparams);
            }       
            await _splitRenovationRepository.CreateAsync(r);
        }

        public async Task Delete(SplitRenovation r)
        {
            await _splitRenovationRepository.DeleteAsync(r);
        }

        public async Task<IEnumerable<MergeRenovation>> GetAllMergeRenovations()
        {
            return await _mergeRenovationRepository.GetAllAsync();
        }

        public async Task Create(MergeRenovation r)
        {
            if (fromFront)
            {
                var eventparams = new MergeRenovationEventParams(r.FirstOldRoomId, r.SecondOldRoomId, r.NewRoomInfo.RoomName, r.Start, r.End);
                _logMergeRenovationEventService.LogEvent(eventparams);
            }
            
            await _mergeRenovationRepository.CreateAsync(r);
        }

        public async Task Delete(MergeRenovation r)
        {
            await _mergeRenovationRepository.DeleteAsync(r);
        }

        public async Task<bool> CanBeMerged(MergeRenovation r)
        {
            Room room1 = await _roomRepository.GetByIdAsync(r.FirstOldRoomId);
            Room room2 = await _roomRepository.GetByIdAsync(r.SecondOldRoomId);
            bool canMergeVertically = CheckVerticalMerge(room1.RoomDimensions, room2.RoomDimensions);
            bool canMergeHorizontally = CheckHorizontalMerge(room1.RoomDimensions, room2.RoomDimensions);
            return canMergeVertically || canMergeHorizontally;
        }

        private bool CheckVerticalMerge(RoomDimensions roomDimensions1, RoomDimensions roomDimensions2)
        {
            if (roomDimensions1.AreVerticallyAligned(roomDimensions2) &&
                roomDimensions1.Width.Equals(roomDimensions2.Width))
            {
                double distance1 = (roomDimensions1.Y + roomDimensions1.Height + 5) - roomDimensions2.Y;
                double distance2 = (roomDimensions2.Y + roomDimensions2.Height + 5) - roomDimensions1.Y;
                if (distance1 > 0 && distance1 < 10 || distance2 > 0 && distance2 < 10)
                    return true;
            }

            return false;
        }

        private bool CheckHorizontalMerge(RoomDimensions roomDimensions1, RoomDimensions roomDimensions2)
        {
            if (roomDimensions1.AreHorizontallyAligned(roomDimensions2) &&
                roomDimensions2.Height.Equals(roomDimensions2.Height))
            {
                double distance1 = (roomDimensions1.X + roomDimensions1.Width + 5) - roomDimensions2.X;
                double distance2 = (roomDimensions2.X + roomDimensions2.Width + 5) - roomDimensions1.X;
                if (distance1 > 0 && distance1 < 10 || distance2 > 0 && distance2 < 10)
                    return true;
            }

            return false;
        }

        public async Task<IEnumerable<SplitRenovation>> GetAllSplitRenovationsByRoomId(int id)
        {
            return await _splitRenovationRepository.GetAllByRoomIdAsync(id);
        }

        public async Task<IEnumerable<MergeRenovation>> GetAllMergeRenovationsByRoomId(int id)
        {
            return await _mergeRenovationRepository.GetAllByRoomIdAsync(id);
        }

        public async Task<bool> HasScheduledRenovations(int roomId)
        {
            var splitRenovations = await _splitRenovationRepository.GetAllByRoomIdAsync(roomId);
            var mergeRenovations = await _mergeRenovationRepository.GetAllByRoomIdAsync(roomId);

            return splitRenovations.ToList().Count > 0 || mergeRenovations.ToList().Count > 0;
        }

    }
}

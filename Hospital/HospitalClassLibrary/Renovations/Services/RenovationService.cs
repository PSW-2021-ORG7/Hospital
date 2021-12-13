using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        private readonly IRoomRepository _roomRepository;

        public RenovationService(ISplitRenovationRepository splitRenovationRepository, IMergeRenovationRepository mergeRenovationRepository, IRoomRepository roomRepository)
        {
            _splitRenovationRepository = splitRenovationRepository;
            _mergeRenovationRepository = mergeRenovationRepository;
            _roomRepository = roomRepository;
        }

        public async Task<IEnumerable<SplitRenovation>> GetAllSplitRenovations()
        {
            return await _splitRenovationRepository.GetAllAsync();
        }

        public async Task Create(SplitRenovation r)
        {
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
            await _mergeRenovationRepository.CreateAsync(r);
        }

        public async Task Delete(MergeRenovation r)
        {
            await _mergeRenovationRepository.CreateAsync(r);
        }

        public async Task<bool> CanBeMerged(MergeRenovation r)
        {
            Room room1 = await _roomRepository.GetByIdAsync(r.FirstOldRoomId);
            Room room2 = await _roomRepository.GetByIdAsync(r.SecondOldRoomId);
            bool canMergeVertically = checkVerticalMerge(room1.RoomDimensions, room2.RoomDimensions);
            bool canMergeHorizontally = checkHorizontalMerge(room1.RoomDimensions, room2.RoomDimensions);
            return canMergeVertically || canMergeHorizontally;
        }

        private bool checkVerticalMerge(RoomDimensions roomDimensions1, RoomDimensions roomDimensions2)
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

        private bool checkHorizontalMerge(RoomDimensions roomDimensions1, RoomDimensions roomDimensions2)
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

    }
}

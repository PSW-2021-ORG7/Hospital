using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HospitalClassLibrary.GraphicalEditor.Models;
using HospitalClassLibrary.Renovations.Models;
using HospitalClassLibrary.Renovations.Repositories.Interfaces;
using HospitalClassLibrary.Renovations.Services.Interfaces;
using HospitalClassLibrary.RoomEquipment.Models;
using HospitalClassLibrary.RoomEquipment.Repositories.Interfaces;
using HospitalClassLibrary.Schedule.Repositories.Interfaces;
using static HospitalClassLibrary.Shared.Constants;

namespace HospitalClassLibrary.Renovations.Services
{
    public class RenovationCheckerService : IRenovationCheckerService
    {
        private readonly ISplitRenovationRepository _splitRenovationRepository;
        private readonly IMergeRenovationRepository _mergeRenovationRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IDoctorRepository _doctorRepository;

        public RenovationCheckerService(ISplitRenovationRepository splitRenovationRepository, IMergeRenovationRepository mergeRenovationRepository, IRoomRepository roomRepository, IDoctorRepository doctorRepository)
        {
            _splitRenovationRepository = splitRenovationRepository;
            _mergeRenovationRepository = mergeRenovationRepository;
            _roomRepository = roomRepository;
            _doctorRepository = doctorRepository;
        }

        public async Task DoWork(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await CheckRenovations();

                await Task.Delay(TwoHours, stoppingToken);
            }
        }

        public async Task CheckRenovations()
        {
            await CheckSplitRenovations();
            await CheckMergeRenovations();
        }

        private async Task CheckSplitRenovations()
        {
            foreach (var splitRenovation in _splitRenovationRepository.GetAllAsync().Result)
            {
                if(splitRenovation.Start > DateTime.Now) continue;

                var room = await _roomRepository.GetByIdAsync(splitRenovation.RoomId);

                if (!IsUpdated(room))
                {
                    await Update(room);
                }

                if(splitRenovation.End > DateTime.Now) continue;

                await CreateFirstNewRoom(splitRenovation, room);

                await CreateSecondNewRoom(splitRenovation, room);

                await UpdateEquipment(room, splitRenovation);

                await UpdateDoctorsRoom(room, splitRenovation.FirstNewRoomInfo.RoomName);

                await _roomRepository.DeleteAsync(room);
                await _splitRenovationRepository.DeleteAsync(splitRenovation);
            }
        }

        private async Task CreateFirstNewRoom(SplitRenovation splitRenovation, Room room)
        {
            var firstNewRoom = new Room()
            {
                Name = splitRenovation.FirstNewRoomInfo.RoomName,
                Status = splitRenovation.FirstNewRoomInfo.RoomStatus,
                Type = splitRenovation.FirstNewRoomInfo.RoomType,
                Floor = room.Floor,
                RoomDimensions = new RoomDimensions()
                {
                    X = room.RoomDimensions.X,
                    Y = room.RoomDimensions.Y,
                    Width = room.RoomDimensions.Width,
                    Height = room.RoomDimensions.Height / 2
                },
                BuildingId = room.BuildingId
            };
            await _roomRepository.CreateAsync(firstNewRoom);
        }

        private async Task CreateSecondNewRoom(SplitRenovation splitRenovation, Room room)
        {
            var secondNewRoom = new Room()
            {
                Name = splitRenovation.SecondNewRoomInfo.RoomName,
                Status = splitRenovation.SecondNewRoomInfo.RoomStatus,
                Type = splitRenovation.SecondNewRoomInfo.RoomType,
                Floor = room.Floor,
                RoomDimensions = new RoomDimensions()
                {
                    X = room.RoomDimensions.X,
                    Y = room.RoomDimensions.Y + room.RoomDimensions.Height / 2,
                    Width = room.RoomDimensions.Width,
                    Height = room.RoomDimensions.Height / 2
                },
                BuildingId = room.BuildingId
            };
            await _roomRepository.CreateAsync(secondNewRoom);
        }

        private async Task UpdateEquipment(Room room, SplitRenovation splitRenovation)
        {
            if (room.Equipment.Count > 0)
            {
                var roomId = await GetEquipmentDestination(splitRenovation);

                foreach (var equipment in room.Equipment)
                {
                    equipment.RoomId = roomId;
                }

                await _roomRepository.UpdateAsync(room);
            }
        }

        private async Task<int> GetEquipmentDestination(SplitRenovation splitRenovation)
        {
            if (splitRenovation.EquipmentDestination == splitRenovation.FirstNewRoomInfo.RoomName)
            {
                return await _roomRepository.GetRoomId(splitRenovation.FirstNewRoomInfo.RoomName);
            }

            return await _roomRepository.GetRoomId(splitRenovation.SecondNewRoomInfo.RoomName);
        }

        private async Task UpdateDoctorsRoom(Room room, string roomName)
        {
            var doctorId = _roomRepository.GetDoctorId(room.Id);
            if (doctorId != -1)
            {
                var doctor = await _doctorRepository.GetByIdAsync(doctorId);
                doctor.RoomId = await _roomRepository.GetRoomId(roomName);
                await _doctorRepository.UpdateAsync(doctor);
            }
        }

        private async Task CheckMergeRenovations()
        {
            foreach (var mergeRenovation in _mergeRenovationRepository.GetAllAsync().Result)
            {
                if (mergeRenovation.Start > DateTime.Now) continue;

                var firstOldRoom = await _roomRepository.GetByIdAsync(mergeRenovation.FirstOldRoomId);
                var secondOldRoom = await _roomRepository.GetByIdAsync(mergeRenovation.SecondOldRoomId);

                if (!IsUpdated(firstOldRoom))
                {
                    await Update(firstOldRoom);
                }

                if (!IsUpdated(secondOldRoom))
                {
                    await Update(secondOldRoom);
                }

                if (mergeRenovation.End > DateTime.Now) continue;

                await CreateNewRoom(mergeRenovation, firstOldRoom, secondOldRoom);

                await UpdateEquipment(firstOldRoom, mergeRenovation);
                await UpdateEquipment(secondOldRoom, mergeRenovation);

                await RemoveDoctor(firstOldRoom);
                await RemoveDoctor(secondOldRoom);

                await _roomRepository.DeleteAsync(firstOldRoom);
                await _roomRepository.DeleteAsync(secondOldRoom);
                await _mergeRenovationRepository.DeleteAsync(mergeRenovation);
            }
        }

        private static bool IsUpdated(Room room)
        {
            return room.Status == RoomStatus.IS_BEING_RENOVATED;
        }

        private async Task Update(Room room)
        {
            room.Status = RoomStatus.IS_BEING_RENOVATED;
            await _roomRepository.UpdateAsync(room);
        }

        private async Task CreateNewRoom(MergeRenovation mergeRenovation, Room firstOldRoom, Room secondOldRoom)
        {
            var dimensions = new List<RoomDimensions> {firstOldRoom.RoomDimensions, secondOldRoom.RoomDimensions};
            var x = dimensions.OrderBy(d => d.X).First().X;
            var y = dimensions.OrderBy(d => d.Y).First().Y;
            var width = firstOldRoom.RoomDimensions.AreHorizontallyAligned(secondOldRoom.RoomDimensions)
                ? firstOldRoom.RoomDimensions.Width + secondOldRoom.RoomDimensions.Width
                : firstOldRoom.RoomDimensions.Width;
            var height = firstOldRoom.RoomDimensions.AreVerticallyAligned(secondOldRoom.RoomDimensions)
                ? firstOldRoom.RoomDimensions.Height + secondOldRoom.RoomDimensions.Height
                : firstOldRoom.RoomDimensions.Height;

            var newRoom = new Room()
            {
                Name = mergeRenovation.NewRoomInfo.RoomName,
                Type = mergeRenovation.NewRoomInfo.RoomType,
                Status = mergeRenovation.NewRoomInfo.RoomStatus,
                Floor = firstOldRoom.Floor,
                RoomDimensions = new RoomDimensions()
                {
                    X = x,
                    Y = y,
                    Width = width,
                    Height = height
                },
                BuildingId = firstOldRoom.BuildingId
            };
            await _roomRepository.CreateAsync(newRoom);
        }

        private async Task UpdateEquipment(Room room, MergeRenovation mergeRenovation)
        {
            if (room.Equipment.Count > 0)
            {
                var roomId = await _roomRepository.GetRoomId(mergeRenovation.NewRoomInfo.RoomName);

                foreach (var equipment in room.Equipment)
                {
                    equipment.RoomId = roomId;
                }

                await _roomRepository.UpdateAsync(room);
            }
        }

        private async Task RemoveDoctor(Room room)
        {
            var doctorId = _roomRepository.GetDoctorId(room.Id);
            if (doctorId != -1)
            {
                var doctor = await _doctorRepository.GetByIdAsync(doctorId);
                doctor.RoomId = null;
                await _doctorRepository.UpdateAsync(doctor);
            }
        }

    }
}

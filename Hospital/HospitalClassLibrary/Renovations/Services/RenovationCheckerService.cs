using System;
using System.Collections.Generic;
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
        private readonly IRoomRepository _roomRepository;
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IDoctorRepository _doctorRepository;

        public RenovationCheckerService(ISplitRenovationRepository splitRenovationRepository, IRoomRepository roomRepository, IEquipmentRepository equipmentRepository, IDoctorRepository doctorRepository)
        {
            _splitRenovationRepository = splitRenovationRepository;
            _roomRepository = roomRepository;
            _equipmentRepository = equipmentRepository;
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

                await UpdateDoctorsRoom(room, splitRenovation);

                await _roomRepository.DeleteAsync(room);
                await _splitRenovationRepository.DeleteAsync(splitRenovation);
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

        private async Task UpdateDoctorsRoom(Room room, SplitRenovation splitRenovation)
        {
            var doctorId = _roomRepository.GetDoctorId(room.Id);
            if (doctorId != -1)
            {
                var doctor = await _doctorRepository.GetByIdAsync(doctorId);
                doctor.RoomId = await _roomRepository.GetRoomId(splitRenovation.FirstNewRoomInfo.RoomName);
            }
        }

    }
}

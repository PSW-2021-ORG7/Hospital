using System;
using System.Collections.Generic;
using System.Text;
using HospitalClassLibrary.GraphicalEditor.Models;
using HospitalClassLibrary.Renovations.Models;
using HospitalClassLibrary.Renovations.Repositories.Interfaces;
using HospitalClassLibrary.Renovations.Services;
using HospitalClassLibrary.RoomEquipment.Models;
using HospitalClassLibrary.RoomEquipment.Repositories.Interfaces;
using Moq;
using Shouldly;
using Xunit;

namespace HospitalUnitTests
{
    public class RoomRenovationTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void Checks_if_rooms_can_be_merged(MergeRenovation mergeRenovation, bool result)
        {
            var service = CreateRenovationService();

            var canBeMerged = service.CanBeMerged(mergeRenovation);

            canBeMerged.Result.ShouldBe(result);
        }
        
        private static RenovationService CreateRenovationService()
        {
            var splitRenovationStubRepository = new Mock<ISplitRenovationRepository>();
            var mergeRenovationStubRepository = new Mock<IMergeRenovationRepository>();
            var roomStubRepository = new Mock<IRoomRepository>();

            Room room1 = new Room()
            {
                RoomDimensions = new RoomDimensions()
                {
                    X = 861,
                    Y = 237,
                    Height = 170,
                    Width = 322
                }
            };

            Room room2 = new Room()
            {
                RoomDimensions = new RoomDimensions()
                {
                    X = 650,
                    Y = 237,
                    Height = 170,
                    Width = 210
                }
            };

            Room room3 = new Room()
            {
                RoomDimensions = new RoomDimensions()
                {
                    X = 422,
                    Y = 544,
                    Height = 138,
                    Width = 106
                }
            };

            Room room4 = new Room()
            {
                RoomDimensions = new RoomDimensions()
                {
                    X = 422,
                    Y = 407,
                    Height = 138,
                    Width = 106
                }
            };
            roomStubRepository.Setup(m => m.GetByIdAsync(1)).ReturnsAsync(room1);
            roomStubRepository.Setup(m => m.GetByIdAsync(2)).ReturnsAsync(room2);
            roomStubRepository.Setup(m => m.GetByIdAsync(3)).ReturnsAsync(room3);
            roomStubRepository.Setup(m => m.GetByIdAsync(4)).ReturnsAsync(room4);

            RenovationService service = new RenovationService(splitRenovationStubRepository.Object,
                mergeRenovationStubRepository.Object, roomStubRepository.Object);
            return service;
        }

        public static IEnumerable<object[]> Data()
        {
            var retVal = new List<object[]>
            {
                new object[]
            {
                new MergeRenovation()
                {
                    Id = 1,
                    FirstOldRoomId = 1,
                    SecondOldRoomId = 2,
                    NewRoomInfo = new NewRoomInfo()
                    {
                        Id = 1,
                        RoomName = "MergedRoom",
                        RoomType = RoomType.SURGERY_ROOM,
                        RoomStatus = RoomStatus.NOT_ACITVE
                    },

                    Start = new DateTime(2021, 12, 6),
                    End = new DateTime(2021, 12, 7)
                },
                true
            },

                new object[]
            {
                new MergeRenovation()
                {
                    Id = 1,
                    FirstOldRoomId = 2,
                    SecondOldRoomId = 1,
                    NewRoomInfo = new NewRoomInfo()
                    {
                        Id = 2,
                        RoomName = "MergedRoom",
                        RoomType = RoomType.SURGERY_ROOM,
                        RoomStatus = RoomStatus.NOT_ACITVE
                    },

                    Start = new DateTime(2021, 12, 6),
                    End = new DateTime(2021, 12, 7)
                },
                true
            },

                new object[]
            {
                new MergeRenovation()
                {
                    Id = 1,
                    FirstOldRoomId = 3,
                    SecondOldRoomId = 4,
                    NewRoomInfo = new NewRoomInfo()
                    {
                        Id = 2,
                        RoomName = "MergedRoom",
                        RoomType = RoomType.SURGERY_ROOM,
                        RoomStatus = RoomStatus.NOT_ACITVE
                    },

                    Start = new DateTime(2021, 12, 6),
                    End = new DateTime(2021, 12, 7)
                },
                true
            },

                new object[]
            {
                new MergeRenovation()
                {
                    Id = 1,
                    FirstOldRoomId = 4,
                    SecondOldRoomId = 3,
                    NewRoomInfo = new NewRoomInfo()
                    {
                        Id = 2,
                        RoomName = "MergedRoom",
                        RoomType = RoomType.SURGERY_ROOM,
                        RoomStatus = RoomStatus.NOT_ACITVE
                    },

                    Start = new DateTime(2021, 12, 6),
                    End = new DateTime(2021, 12, 7)
                },
                true
            },

                new object[]
            {
                new MergeRenovation()
                {
                    Id = 1,
                    FirstOldRoomId = 1,
                    SecondOldRoomId = 4,
                    NewRoomInfo = new NewRoomInfo()
                    {
                        Id = 2,
                        RoomName = "MergedRoom",
                        RoomType = RoomType.SURGERY_ROOM,
                        RoomStatus = RoomStatus.NOT_ACITVE
                    },

                    Start = new DateTime(2021, 12, 6),
                    End = new DateTime(2021, 12, 7)
                },
                false
            }
            };

            return retVal;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using HospitalClassLibrary.Renovations.Models;
using HospitalClassLibrary.Renovations.Repositories.Interfaces;
using HospitalClassLibrary.RoomEquipment.Models;
using HospitalClassLibrary.RoomEquipment.Repositories.Interfaces;
using HospitalClassLibrary.Schedule.Models;
using HospitalClassLibrary.Schedule.Repositories.Interfaces;
using HospitalClassLibrary.Schedule.Services;
using HospitalClassLibrary.Shared.Models;
using Moq;
using Shouldly;
using Xunit;
using static HospitalClassLibrary.Shared.Constants;

namespace HospitalUnitTests
{
    public class AvailableTimeSlotsTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void Checks_available_time_slots_count(TimeSlotsRequirements requirements, int count)
        {
            var service = CreateWorkdayService(requirements);

            var timeSlots = service.GetAvailableTimeSlots(requirements);

            timeSlots.Count.ShouldBe(count);
        }

        [Fact]
        public void Checks_if_time_slots_fit_date_range()
        {
            var requirements = GetEquipmentTransferRequirements();
            var service = CreateWorkdayService(requirements);

            var timeSlots = service.GetAvailableTimeSlots(requirements);

            timeSlots.All(ts => ts.Start >= requirements.Start && ts.End <= requirements.End.AddHours(WorkHoursEnd)).ShouldBe(true);
        }

        [Fact]
        public void Checks_if_time_slots_overlap_appointment()
        {
            var requirements = GetEquipmentTransferRequirements();
            var appointment = GetAppointment();
            var service = CreateWorkdayService(requirements);

            var timeSlots = service.GetAvailableTimeSlots(requirements);

            timeSlots.All(ts => !ts.Overlaps(appointment.StartTime, appointment.EndTime)).ShouldBe(true);
        }

        [Fact]
        public void Checks_if_time_slots_overlap_transfer()
        {
            var requirements = GetEquipmentTransferRequirements();
            var transfer = GetTransfer();
            var service = CreateWorkdayService(requirements);

            var timeSlots = service.GetAvailableTimeSlots(requirements);

            timeSlots.All(ts => !ts.Overlaps(transfer.TransferDateInfo.TransferDate, transfer.TransferDateInfo.TransferDate.AddMinutes(transfer.TransferDateInfo.TransferDuration))).ShouldBe(true);
        }

        [Fact]
        public void Checks_if_time_slots_overlap_renovation()
        {
            var requirements = GetRenovationRequirements();
            var splitRenovation = GetRenovation();
            var service = CreateWorkdayService(requirements);

            var timeSlots = service.GetAvailableTimeSlots(requirements);

            timeSlots.All(ts => ts.End < splitRenovation.Start).ShouldBe(true);
        }

        private static WorkdayService CreateWorkdayService(TimeSlotsRequirements requirements)
        {
            var roomStubRepository = new Mock<IRoomRepository>();
            roomStubRepository.Setup(m => m.GetDoctorId(1)).Returns(1);
            roomStubRepository.Setup(m => m.GetDoctorId(2)).Returns(2);
            var dateRange = new DateTimeRange() { Start = requirements.Start, End = requirements.End.AddHours(WorkHoursEnd) };
            var appointments = new List<Appointment>
            {
                new Appointment()
                {
                    Id = 0,
                    StartTime = new DateTime(2021, 11, 26, 9, 0, 0),
                    EndTime = new DateTime(2021, 11, 26, 9, 30, 0)
                },
                new Appointment()
                {
                    Id = 1,
                    StartTime = new DateTime(2021, 11, 26, 13, 30, 0),
                    EndTime = new DateTime(2021, 11, 26, 14, 0, 0)
                }
            };
            var transfers = new List<DateTimeRange>
            {
                new DateTimeRange()
                {
                    Start = new DateTime(2021, 11, 29, 18, 0, 0),
                    End = new DateTime(2021, 11, 29, 19, 0, 0)
                }
            };
            var splitRenovationDates = new List<DateTimeRange>
            {
                new DateTimeRange()
                {
                    Start = new DateTime(2021, 12, 23, 0, 0, 0),
                    End = new DateTime(2021, 12, 23, 21, 0, 0)
                }
            };

            var workdayStubRepository = new Mock<IWorkdayRepository>();
            workdayStubRepository.Setup(m => m.GetAppointments(It.IsAny<DateTimeRange>(), 1, 2)).ReturnsAsync(appointments);
            var transferStubRepository = new Mock<IEquipmentTransferRepository>();
            transferStubRepository.Setup(m => m.GetAllDates(It.IsAny<DateTimeRange>(), 1, 2)).ReturnsAsync(transfers);
            var splitRenovationStubRepository = new Mock<ISplitRenovationRepository>();
            splitRenovationStubRepository.Setup(m => m.GetAllDates(4, 0)).ReturnsAsync(splitRenovationDates);
            var mergeRenovationStubRepository = new Mock<IMergeRenovationRepository>();
            
            WorkdayService service = new WorkdayService(workdayStubRepository.Object, transferStubRepository.Object, roomStubRepository.Object, splitRenovationStubRepository.Object, mergeRenovationStubRepository.Object);
            return service;
        }

        private static TimeSlotsRequirements GetEquipmentTransferRequirements()
        {
            var requirements = new TimeSlotsRequirements()
            {
                Start = new DateTime(2021, 11, 26, 0, 0, 0),
                End = new DateTime(2021, 11, 30, 0, 0, 0),
                Duration = new TimeSpan(0, 60 ,0),
                FirstRoomId = 1,
                SecondRoomId = 2
            };
            return requirements;
        }

        private static TimeSlotsRequirements GetRenovationRequirements()
        {
            var requirements = new TimeSlotsRequirements()
            {
                Start = new DateTime(2021, 12, 19, 0, 0, 0),
                End = new DateTime(2021, 12, 25, 0, 0, 0),
                Duration = new TimeSpan(0, 60, 0),
                FirstRoomId = 4,
                SecondRoomId = 0
            };
            return requirements;
        }

        private static Appointment GetAppointment()
        {
            var appointment = new Appointment()
                { StartTime = new DateTime(2021, 11, 26, 9, 0, 0), EndTime = new DateTime(2021, 11, 26, 9, 30, 0) };
            return appointment;
        }

        private static EquipmentTransfer GetTransfer()
        {
            var transfer = new EquipmentTransfer(0, 1, 2, new DateTime(2021, 11, 29, 18, 0, 0), 60, 12, 17);

            return transfer;
        }

        private static SplitRenovation GetRenovation()
        {
            var renovation = new SplitRenovation()
            {
                RoomId = 4,
                Start = new DateTime(2021, 12, 23, 0, 0, 0),
                End = new DateTime(2021, 12, 23, 21, 0, 0)
            };
            return renovation;
        }

        public static IEnumerable<object[]> Data()
        {
            var retVal = new List<object[]>();

            retVal.Add(new object[] { new TimeSlotsRequirements() { Start = new DateTime(2021, 11, 27, 0, 0, 0), End = new DateTime(2021, 11, 28, 0, 0, 0), Duration = new TimeSpan(0, 60, 0), FirstRoomId = 1, SecondRoomId = 2 }, 30 });
            retVal.Add(new object[] { new TimeSlotsRequirements() { Start = new DateTime(2021, 11, 27, 0, 0, 0), End = new DateTime(2021, 11, 26, 0, 0, 0), Duration = new TimeSpan(0, 60, 0), FirstRoomId = 1, SecondRoomId = 2 }, 0 });

            return retVal;
        }
    }
}
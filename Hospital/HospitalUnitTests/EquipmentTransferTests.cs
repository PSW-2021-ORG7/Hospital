using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using HospitalClassLibrary.GraphicalEditor.Repositories.Interfaces;
using HospitalClassLibrary.RoomEquipment.Models;
using HospitalClassLibrary.RoomEquipment.Repositories;
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
    public class EquipmentTransferTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void Checks_available_time_slots_count(EquipmentTransferRequirements requirements, int count)
        {
            var service = CreateWorkdayService(requirements);

            var timeSlots = service.GetAvailableTimeSlots(requirements);

            timeSlots.Count.ShouldBe(count);
        }

        [Fact]
        public void Checks_if_time_slots_fit_date_range()
        {
            var requirements = new EquipmentTransferRequirements(){ Start = new DateTime(2021, 11, 26, 0, 0, 0), End = new DateTime(2021, 11, 30, 0,0,0), Duration = 60, SrcRoomId = 1, DstRoomId = 2};
            var service = CreateWorkdayService(requirements);

            var timeSlots = service.GetAvailableTimeSlots(requirements);

            timeSlots.All(ts => ts.Start >= requirements.Start && ts.End <= requirements.End.AddHours(WorkHoursEnd)).ShouldBe(true);
        }

        [Fact]
        public void Checks_if_time_slots_overlap_appointment()
        {
            var requirements = new EquipmentTransferRequirements() { Start = new DateTime(2021, 11, 26, 0, 0, 0), End = new DateTime(2021, 11, 30, 0, 0, 0), Duration = 60, SrcRoomId = 1, DstRoomId = 2 };
            var appointment = new Appointment(){StartTime = new DateTime(2021, 11, 26, 9, 0, 0), EndTime = new DateTime(2021, 11, 26, 9, 30, 0)};
            var service = CreateWorkdayService(requirements);

            var timeSlots = service.GetAvailableTimeSlots(requirements);

            timeSlots.All(ts => ts.Start < appointment.EndTime && appointment.StartTime < ts.End).ShouldBe(false);
        }

        [Fact]
        public void Checks_if_time_slots_overlap_transfer()
        {
            var requirements = new EquipmentTransferRequirements() { Start = new DateTime(2021, 11, 26, 0, 0, 0), End = new DateTime(2021, 11, 30, 0, 0, 0), Duration = 60, SrcRoomId = 1, DstRoomId = 2 };
            var transfer = new EquipmentTransfer()
            {
                DestinationRoomId = 7, SourceRoomId = 17, EquipmentId = 12, Id = 1, Quantity = 17,
                TransferDate = new DateTime(2021, 11, 29, 18, 0, 0), TransferDuration = 60
            };
            var service = CreateWorkdayService(requirements);

            var timeSlots = service.GetAvailableTimeSlots(requirements);

            timeSlots.All(ts =>
                ts.Start < transfer.TransferDate.AddMinutes(transfer.TransferDuration) &&
                transfer.TransferDate < ts.End).ShouldBe(false);
        }

        public static IEnumerable<object[]> Data()
        {
            var retVal = new List<object[]>();

            retVal.Add(new object[] {new EquipmentTransferRequirements() { Start = new DateTime(2021, 11, 27, 0, 0, 0), End = new DateTime(2021, 11, 28, 0, 0, 0), Duration = 60, SrcRoomId = 1, DstRoomId = 2 }, 30});
            //retVal.Add(new object[] { new EquipmentTransferRequirements() { Start = new DateTime(2021, 11, 27, 0, 0, 0), End = new DateTime(2021, 11, 30, 0, 0, 0), Duration = 60, SrcRoomId = 1, DstRoomId = 2}, 0 });

            return retVal;
        }

        private static WorkdayService CreateWorkdayService(EquipmentTransferRequirements requirements)
        {
            var roomStubRepository = new Mock<IRoomRepository>();
            roomStubRepository.Setup(m => m.GetDoctorId(1)).Returns(1);
            roomStubRepository.Setup(m => m.GetDoctorId(2)).Returns(2);
            var dateRange = new DateTimeRange() { Start = requirements.Start, End = requirements.End.AddHours(WorkHoursEnd) };
            var appointments = new List<Appointment>();
            appointments.Add(new Appointment()
            {
                Id = 0,
                StartTime = new DateTime(2021, 11, 26, 9, 0, 0),
                EndTime = new DateTime(2021, 11, 26, 9, 30, 0)
            });
            appointments.Add(new Appointment()
            {
                Id = 1,
                StartTime = new DateTime(2021, 11, 26, 13, 30, 0),
                EndTime = new DateTime(2021, 11, 26, 14, 0, 0)
            });
            var transfers = new List<EquipmentTransfer>();
            transfers.Add(new EquipmentTransfer()
            {
                Id = 0,
                SourceRoomId = 7,
                DestinationRoomId = 17,
                EquipmentId = 12,
                Quantity = 17,
                TransferDate = new DateTime(2021, 11, 29, 18, 0, 0),
                TransferDuration = 60
            });

            var workdayStubRepository = new Mock<IWorkdayRepository>();
            workdayStubRepository.Setup(m => m.GetAppointments(It.IsAny<DateTimeRange>(), 1, 2)).Returns(appointments);
            var transferStubRepository = new Mock<IEquipmentTransferRepository>();
            transferStubRepository.Setup(m => m.GetAll(It.IsAny<DateTimeRange>())).Returns(transfers);
            
            WorkdayService service = new WorkdayService(workdayStubRepository.Object, transferStubRepository.Object, roomStubRepository.Object);
            return service;
        }
    }
}
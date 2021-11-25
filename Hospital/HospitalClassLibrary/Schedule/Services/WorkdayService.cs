using System;
using HospitalClassLibrary.RoomEquipment.Models;
using HospitalClassLibrary.Schedule.Repositories.Interfaces;
using HospitalClassLibrary.Schedule.Services.Interfaces;
using HospitalClassLibrary.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using HospitalClassLibrary.GraphicalEditor.Repositories.Interfaces;
using HospitalClassLibrary.RoomEquipment.Repositories.Interfaces;
using HospitalClassLibrary.Schedule.Models;
using static HospitalClassLibrary.Shared.Constants;

namespace HospitalClassLibrary.Schedule.Services
{
    public class WorkdayService : IWorkdayService
    {
        private readonly IWorkdayRepository _workdayRepository;
        private readonly IEquipmentTransferRepository _equipmentTransferRepository;
        private readonly IRoomRepository _roomRepository;

        public WorkdayService(IWorkdayRepository workdayRepository, IEquipmentTransferRepository equipmentTransferRepository, IRoomRepository roomRepository)
        {
            _workdayRepository = workdayRepository;
            _equipmentTransferRepository = equipmentTransferRepository;
            _roomRepository = roomRepository;
        }

        public ICollection<DateTimeRange> GetAvailableTimeSlots(EquipmentTransferRequirements requirements)
        {
            var appointments = GetAppointments(requirements);
            var transfers = GetTransfers(requirements);

            return GenerateTimeSlots(requirements, appointments, transfers);
        }

        private List<DateTimeRange> GenerateTimeSlots(EquipmentTransferRequirements requirements, List<Appointment> appointments, List<EquipmentTransfer> transfers)
        {
            var availableTimeSlots = new List<DateTimeRange>();
            var start = requirements.Start + new TimeSpan(WorkHoursStart, 0, 0);
            var end = requirements.End + new TimeSpan(WorkHoursEnd, 0, 0);

            while (start < end && availableTimeSlots.Count <= MaxNumOfTimeSlots)
            {
                if (HasReachedEndOfWorkHours(start))
                {
                    start = start.AddHours(NonWorkingHours);
                }
                var timeSlot = new DateTimeRange() {Start = start, End = start.AddMinutes(requirements.Duration)};
                start = timeSlot.End;

                if (Overlaps(timeSlot, appointments, transfers)) continue;

                availableTimeSlots.Add(timeSlot);
            }

            return availableTimeSlots;
        }

        private static bool HasReachedEndOfWorkHours(DateTime start)
        {
            return start.Hour == WorkHoursEnd;
        }

        private static bool Overlaps(DateTimeRange timeSlot, IEnumerable<Appointment> appointments, IEnumerable<EquipmentTransfer> transfers)
        {
            return appointments.Any(a => timeSlot.OverlapsWith(a)) || transfers.Any(t => timeSlot.OverlapsWith(t));
        }

        private List<EquipmentTransfer> GetTransfers(EquipmentTransferRequirements requirements)
        {
            var dateRange = new DateTimeRange() {Start = requirements.Start, End = requirements.End.AddHours(WorkHoursEnd)};

            return _equipmentTransferRepository.GetAll(dateRange).ToList();
        }

        private List<Appointment> GetAppointments(EquipmentTransferRequirements requirements)
        {
            var dateRange = new DateTimeRange() { Start = requirements.Start, End = requirements.End.AddHours(WorkHoursEnd) };
            var srcRoomDoctorId = _roomRepository.GetDoctorId(requirements.SrcRoomId);
            var dstRoomDoctorId = _roomRepository.GetDoctorId(requirements.DstRoomId);
            
            return _workdayRepository.GetAppointments(dateRange, srcRoomDoctorId, dstRoomDoctorId).ToList();
        }
    }
}

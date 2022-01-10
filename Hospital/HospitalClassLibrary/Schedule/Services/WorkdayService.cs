using System;
using HospitalClassLibrary.Schedule.Repositories.Interfaces;
using HospitalClassLibrary.Schedule.Services.Interfaces;
using HospitalClassLibrary.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using HospitalClassLibrary.Renovations.Repositories.Interfaces;
using HospitalClassLibrary.RoomEquipment.Repositories.Interfaces;
using HospitalClassLibrary.Schedule.Models;
using static HospitalClassLibrary.Shared.Constants;
using System.Threading.Tasks;

namespace HospitalClassLibrary.Schedule.Services
{
    public class WorkdayService : IWorkdayService
    {
        private readonly IWorkdayRepository _workdayRepository;
        private readonly IEquipmentTransferRepository _equipmentTransferRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly ISplitRenovationRepository _splitRenovationRepository;
        private readonly IMergeRenovationRepository _mergeRenovationRepository;

        public WorkdayService(IWorkdayRepository workdayRepository, IEquipmentTransferRepository equipmentTransferRepository, IRoomRepository roomRepository, ISplitRenovationRepository splitRenovationRepository, IMergeRenovationRepository mergeRenovationRepository)
        {
            _workdayRepository = workdayRepository;
            _equipmentTransferRepository = equipmentTransferRepository;
            _roomRepository = roomRepository;
            _splitRenovationRepository = splitRenovationRepository;
            _mergeRenovationRepository = mergeRenovationRepository;
        }

        public ICollection<DateTimeRange> GetAvailableTimeSlots(TimeSlotsRequirements requirements)
        {
            var appointments = GetAppointments(requirements).ToList();
            var transfers = GetTransfers(requirements).ToList();
            var splitRenovations = _splitRenovationRepository.GetAllDates(requirements.FirstRoomId, requirements.SecondRoomId).Result;
            var mergeRenovations = _mergeRenovationRepository.GetAllDates(requirements.FirstRoomId, requirements.SecondRoomId).Result;
            var renovations = (mergeRenovations ?? Enumerable.Empty<DateTimeRange>()).Concat(splitRenovations ?? Enumerable.Empty<DateTimeRange>()).OrderBy(d => d.Start).ToList();

            return GenerateTimeSlots(requirements, appointments, transfers, renovations.Count == 0 ? DateTime.MaxValue : renovations.First().Start);
        }

        private List<DateTimeRange> GenerateTimeSlots(TimeSlotsRequirements requirements, List<Appointment> appointments, List<DateTimeRange> transfers, DateTime startOfFirstRenovation)
        {
            var availableTimeSlots = new List<DateTimeRange>();
            var start = requirements.Start + new TimeSpan(WorkHoursStart, 0, 0);
            var end = start.Add(requirements.Duration);
            var finalDateTime = requirements.End + new TimeSpan(WorkHoursEnd, 0, 0);
            var dayLongDuration = requirements.Duration >= new TimeSpan(1, 0, 0, 0);

            while (end <= finalDateTime && availableTimeSlots.Count <= MaxNumOfTimeSlots)
            {
                if (HasReachedEndOfWorkHours(start, requirements.Duration) && !dayLongDuration)
                {
                    start = start.AddHours(NonWorkingHours + WorkHoursEnd - start.Hour);
                    end = start.Add(requirements.Duration);
                }
                var timeSlot = new DateTimeRange() {Start = start, End = end};
                start = dayLongDuration ? start.AddDays(1) : timeSlot.End;
                end = start.Add(requirements.Duration);

                if (start >= startOfFirstRenovation) break;

                if (Overlaps(timeSlot, appointments, transfers)) continue;

                availableTimeSlots.Add(timeSlot);
            }

            return availableTimeSlots;
        }

        private static bool HasReachedEndOfWorkHours(DateTime start, TimeSpan duration)
        {
            return start.Add(duration) > new DateTime(start.Year, start.Month, start.Day).Add(new TimeSpan(WorkHoursEnd, 0, 0));
        }

        private static bool Overlaps(DateTimeRange timeSlot, IEnumerable<Appointment> appointments, IEnumerable<DateTimeRange> transfers)
        {
            return transfers.Any(t => timeSlot.Overlaps(t.Start, t.End)) || appointments.Any(a => timeSlot.Overlaps(a.StartTime, a.EndTime));
        }

        private IEnumerable<DateTimeRange> GetTransfers(TimeSlotsRequirements requirements)
        {
            var dateRange = new DateTimeRange() {Start = requirements.Start, End = requirements.End.AddHours(WorkHoursEnd)};

            return _equipmentTransferRepository.GetAllDates(dateRange, requirements.FirstRoomId, requirements.SecondRoomId).Result;
        }

        private IEnumerable<Appointment> GetAppointments(TimeSlotsRequirements requirements)
        {
            var dateRange = new DateTimeRange() { Start = requirements.Start, End = requirements.End.AddHours(WorkHoursEnd) };
            var srcRoomDoctorId = _roomRepository.GetDoctorId(requirements.FirstRoomId);
            var dstRoomDoctorId = _roomRepository.GetDoctorId(requirements.SecondRoomId);
            
            return _workdayRepository.GetAppointments(dateRange, srcRoomDoctorId, dstRoomDoctorId).Result;
        }

        public async Task<IEnumerable<Workday>> GetWorkdays(DateTimeRange dateRange, int doctorId)
        {
            return await _workdayRepository.GetWorkdays(dateRange, doctorId);
        }
        public async Task Create(Workday workday)
        {
            await _workdayRepository.CreateAsync(workday);
        }

        public async Task Update(Workday workday)
        {
            await _workdayRepository.UpdateAsync(workday);
        }
    }
}

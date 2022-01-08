using System;
using System.Collections.Generic;
using HospitalClassLibrary.Schedule.Models;
using HospitalClassLibrary.Schedule.Repositories.Interfaces;
using HospitalClassLibrary.Schedule.Services;
using Moq;
using Shouldly;
using Xunit;

namespace HospitalUnitTests
{
    public class HolidayTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void Checks_if_doctor_has_overlapping_holiday(Holiday holiday, bool hasOverlappingHoliday)
        {
            var service = CreateHolidayService();

            var retVal = service.HasOverlappingHoliday(holiday).Result;

            retVal.ShouldBe(hasOverlappingHoliday);
        }


        private static HolidayService CreateHolidayService()
        {
            var holidayStubRepository = new Mock<IHolidayRepository>();
            var scheduledHolidays = new List<Holiday>()
            {
                new Holiday(1, new DateTime(2021, 12, 25), new DateTime(2021, 12, 30), 1, new Doctor(), "")
            };
            holidayStubRepository.Setup(m => m.GetAllByDoctorId(1)).ReturnsAsync(scheduledHolidays);

            var workdayStubRepository = new Mock<IWorkdayRepository>();

            return new HolidayService(holidayStubRepository.Object, workdayStubRepository.Object);
        }

        public static IEnumerable<object[]> Data()
        {
            var retVal = new List<object[]>
            {
                new object[] { new Holiday(1, new DateTime(2021, 12, 22), new DateTime(2021, 12, 30), 1, new Doctor(), ""), true },
                new object[] { new Holiday(1, new DateTime(2021, 12, 1), new DateTime(2021, 12, 15), 1, new Doctor(), ""), false }
            };

            return retVal;
        }
    }
}

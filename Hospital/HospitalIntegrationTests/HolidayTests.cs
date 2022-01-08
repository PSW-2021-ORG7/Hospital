using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using HospitalAPI;
using HospitalAPI.DTOs;
using HospitalClassLibrary.Schedule.Models;
using Newtonsoft.Json;
using Shouldly;
using Xunit;

namespace HospitalIntegrationTests
{
    public class HolidayTests : IClassFixture<IntegrationTestsFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly IntegrationTestsFactory<Startup> _factory;

        public HolidayTests(IntegrationTestsFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async void Checks_if_workday_is_deleted()
        {
            var holiday = new HolidayDto()
            {
                Id = 1, Start = new DateTime(2021, 12, 1), End = new DateTime(2021, 12, 15), DoctorId = 1,
                Description = ""
            };

            await _client.PostAsync("/api/holiday", new StringContent(JsonConvert.SerializeObject(holiday), Encoding.UTF8, "application/json"));

            var workdays = await _client.GetAsync("/api/workdays?start=2021-11-30T09:00:00&end=2021-12-2T23:00:00&doctorId=1");
            var workdaysAsString = await workdays.Content.ReadAsStringAsync();
            var workdaysAsJson = JsonConvert.DeserializeObject<IEnumerable<Workday>>(workdaysAsString);
            workdaysAsJson.ShouldBeEmpty();
        }
    }
}

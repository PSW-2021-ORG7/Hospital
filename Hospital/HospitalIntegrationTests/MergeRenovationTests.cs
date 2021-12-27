using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HospitalAPI;
using HospitalAPI.DTOs;
using HospitalClassLibrary.Renovations.Models;
using HospitalClassLibrary.Renovations.Services.Interfaces;
using HospitalClassLibrary.RoomEquipment.Models;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Shouldly;
using Xunit;

namespace HospitalIntegrationTests
{
    public class MergeRenovationTests : IClassFixture<IntegrationTestsFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly IntegrationTestsFactory<Startup> _factory;

        public MergeRenovationTests(IntegrationTestsFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Theory]
        [MemberData(nameof(Data))]
        public async Task Checks_if_merge_renovation_is_succesful(MergeRenovation mergeRenovation)
        {
            await _client.PostAsync("/api/mergeRenovations", new StringContent(JsonConvert.SerializeObject(mergeRenovation), Encoding.UTF8, "application/json"));

            using (var scope = _factory.Services.CreateScope())
            {
                var scopedProcessingService =
                    scope.ServiceProvider
                        .GetRequiredService<IRenovationCheckerService>();

                await scopedProcessingService.CheckRenovations();
            }

            var actualMergeRenovations = await _client.GetAsync("/api/mergeRenovations");
            var actualMergeRenovationsAsString = await actualMergeRenovations.Content.ReadAsStringAsync();
            var actualMergeRenovationsAsJson = JsonConvert.DeserializeObject<IEnumerable<SplitRenovation>>(actualMergeRenovationsAsString);

            var actualFirstOldRoom = await _client.GetAsync($"/api/rooms/{mergeRenovation.FirstOldRoomId}");
            var actualFirstOldRoomAsString = await actualFirstOldRoom.Content.ReadAsStringAsync();
            var actualFirstOldRoomAsJson = JsonConvert.DeserializeObject<RoomDto>(actualFirstOldRoomAsString);

            var actualSecondOldRoom = await _client.GetAsync($"/api/rooms/{mergeRenovation.SecondOldRoomId}");
            var actualSecondOldRoomAsString = await actualSecondOldRoom.Content.ReadAsStringAsync();
            var actualSecondOldRoomAsJson = JsonConvert.DeserializeObject<RoomDto>(actualSecondOldRoomAsString);

            var actualNewRoom = await _client.GetAsync($"/api/rooms/12");
            var actualNewRoomAsString = await actualNewRoom.Content.ReadAsStringAsync();
            var actualNewRoomAsJson = JsonConvert.DeserializeObject<RoomDto>(actualNewRoomAsString);

            var actualNewRoomEquipment = await _client.GetAsync($"/api/rooms/12/equipment");
            var actualNewRoomEquipmentAsString = await actualNewRoomEquipment.Content.ReadAsStringAsync();
            var actualNewRoomEquipmentAsJson = JsonConvert.DeserializeObject<RoomDto>(actualNewRoomEquipmentAsString);

            actualMergeRenovationsAsJson.ShouldBeEmpty();

            actualFirstOldRoomAsJson.ShouldBeNull();
            actualSecondOldRoomAsJson.ShouldBeNull();

            actualNewRoomAsJson.Id.ShouldBe(mergeRenovation.NewRoomInfo.Id);
            actualNewRoomAsJson.X.ShouldBe(861);
            actualNewRoomAsJson.Y.ShouldBe(237);
            actualNewRoomAsJson.Height.ShouldBe(170);
            actualNewRoomAsJson.Width.ShouldBe(532);

            actualNewRoomEquipmentAsJson.Equipment.First().ReservedQuantity.ShouldBe(0);
            actualNewRoomEquipmentAsJson.Equipment.First().Quantity.ShouldBe(50);
            actualNewRoomEquipmentAsJson.Equipment.First().EquipmentItemId.ShouldBe(3);
            actualNewRoomEquipmentAsJson.Equipment.Count.ShouldBe(2);
        }

        public static IEnumerable<object[]> Data()
        {
            var retVal = new List<object[]>();
            
            retVal.Add(new object[]
            {
                new MergeRenovation()
                {
                    Id = 1,
                    FirstOldRoomId = 10,
                    SecondOldRoomId = 11,
                    NewRoomInfo = new NewRoomInfo()
                    {
                        Id = 12,
                        RoomName = "MergedRoom",
                        RoomType = RoomType.SURGERY_ROOM,
                        RoomStatus = RoomStatus.NOT_ACITVE
                    },

                    Start = new DateTime(2021, 12, 6),
                    End = new DateTime(2021, 12, 7)
                }
            });

            return retVal;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using Xunit;
using HospitalAPI;
using HospitalAPI.DTOs;
using HospitalClassLibrary.Renovations.Models;
using HospitalClassLibrary.Renovations.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Shouldly;





namespace HospitalIntegrationTests
{
    public class SplitRenovationTests : IClassFixture<IntegrationTestsFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly IntegrationTestsFactory<Startup> _factory;

        public SplitRenovationTests(IntegrationTestsFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Theory]
        [MemberData(nameof(Data))]
        public async Task Checks_if_split_renovation_is_successful(SplitRenovation splitRenovation)
        {
            await _client.PostAsync("/api/splitRenovations", new StringContent(JsonConvert.SerializeObject(splitRenovation), Encoding.UTF8, "application/json"));

            using (var scope = _factory.Services.CreateScope())
            {
                var scopedProcessingService =
                    scope.ServiceProvider
                        .GetRequiredService<IRenovationCheckerService>();

                await scopedProcessingService.CheckRenovations();
            }

            var actualSplitRenovations = await _client.GetAsync("/api/splitRenovations");
            var actualSplitRenovationsAsString = await actualSplitRenovations.Content.ReadAsStringAsync();
            var actualSplitRenovationsAsJson = JsonConvert.DeserializeObject<IEnumerable<SplitRenovation>>(actualSplitRenovationsAsString);

            var actualOriginRoom = await _client.GetAsync($"/api/rooms/{splitRenovation.RoomId}");
            var actualOriginRoomAsString = await actualOriginRoom.Content.ReadAsStringAsync();
            var actualOriginRoomAsJson = JsonConvert.DeserializeObject<RoomDto>(actualOriginRoomAsString);

            var actualFirstNewRoom = await _client.GetAsync($"/api/rooms/{splitRenovation.FirstNewRoomInfo.Id}");
            var actualFirstNewRoomAsString = await actualFirstNewRoom.Content.ReadAsStringAsync();
            var actualFirstNewRoomAsJson = JsonConvert.DeserializeObject<RoomDto>(actualFirstNewRoomAsString);

            var actualSecondNewRoom = await _client.GetAsync($"/api/rooms/{splitRenovation.SecondNewRoomInfo.Id}");
            var actualSecondNewRoomAsString = await actualSecondNewRoom.Content.ReadAsStringAsync();
            var actualSecondNewRoomIAsJson = JsonConvert.DeserializeObject<RoomDto>(actualSecondNewRoomAsString);
           
            var actualFirstNewRoomEquipment = await _client.GetAsync($"/api/rooms/{splitRenovation.FirstNewRoomInfo.Id}/equipment");
            var actualFirstNewRoomEquipmentAsString = await actualFirstNewRoomEquipment.Content.ReadAsStringAsync();
            var actualFirstNewRoomEquipmentAsJson = JsonConvert.DeserializeObject<RoomDto>(actualFirstNewRoomEquipmentAsString);

            var actualSecondNewRoomEquipment = await _client.GetAsync($"/api/rooms/{splitRenovation.SecondNewRoomInfo.Id}/equipment");
            var actualSecondNewRoomEquipmentAsString = await actualSecondNewRoomEquipment.Content.ReadAsStringAsync();
            var actualSecondNewRoomEquipmentAsJson = JsonConvert.DeserializeObject<RoomDto>(actualSecondNewRoomEquipmentAsString);
         
            actualSplitRenovationsAsJson.ShouldBeEmpty();

            actualOriginRoomAsJson.ShouldBeNull();

            actualFirstNewRoomAsJson.Id.ShouldBe(splitRenovation.FirstNewRoomInfo.Id);
            actualSecondNewRoomIAsJson.Id.ShouldBe(splitRenovation.SecondNewRoomInfo.Id);

            actualFirstNewRoomAsJson.Width.ShouldBe(210);
            actualFirstNewRoomAsJson.Height.ShouldBe(85);
            actualSecondNewRoomIAsJson.Width.ShouldBe(210);
            actualSecondNewRoomIAsJson.Height.ShouldBe(85);
            
            actualFirstNewRoomEquipmentAsJson.Equipment.First().ReservedQuantity.ShouldBe(0);
            actualFirstNewRoomEquipmentAsJson.Equipment.First().Quantity.ShouldBe(22);
            actualFirstNewRoomEquipmentAsJson.Equipment.First().EquipmentItemId.ShouldBe(2);
            actualSecondNewRoomEquipmentAsJson.Equipment.ShouldBeEmpty();

        }

        public static IEnumerable<object[]> Data()
        {
            var retVal = new List<object[]>();

            retVal.Add(new object[]
            {
                new SplitRenovation()
                {
                    Id = 1,
                    RoomId = 5,
                    FirstNewRoomInfo = new NewRoomInfo()
                    {
                        Id = 6,
                        RoomName = "SplitRoom-1",
                        RoomType = HospitalClassLibrary.RoomEquipment.Models.RoomType.EMERGENCY_ROOM,
                        RoomStatus = HospitalClassLibrary.RoomEquipment.Models.RoomStatus.NOT_ACITVE
                    },

                    SecondNewRoomInfo = new NewRoomInfo()
                    {
                        Id = 7,
                        RoomName = "SplitRoom-2",
                        RoomType = HospitalClassLibrary.RoomEquipment.Models.RoomType.EMERGENCY_ROOM,
                        RoomStatus = HospitalClassLibrary.RoomEquipment.Models.RoomStatus.NOT_ACITVE
                    },

                    Start = new DateTime(2021, 12, 6),
                    End = new DateTime(2021, 12, 7),
                    EquipmentDestination = "SplitRoom-1"
                }

            });

            return retVal;
        }
    }
}

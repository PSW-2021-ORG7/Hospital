using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HospitalAPI;
using HospitalAPI.DTOs;
using HospitalClassLibrary.RoomEquipment.Models;
using HospitalClassLibrary.RoomEquipment.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Shouldly;
using Xunit;

namespace HospitalIntegrationTests
{
    public class EquipmentTransferTests : IClassFixture<IntegrationTestsFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly IntegrationTestsFactory<Startup> _factory;

        public EquipmentTransferTests(IntegrationTestsFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Theory]
        [MemberData(nameof(Data))]
        public async Task Checks_if_transfer_is_successful(EquipmentTransfer transfer, int expectedSrcRoomEquipmentQuantity, int expectedDstRoomEquipmentQuantity)     
        {
            await _client.PostAsync("/api/transfers", new StringContent(JsonConvert.SerializeObject(transfer), Encoding.UTF8, "application/json"));

            using (var scope = _factory.Services.CreateScope())
            {
                var scopedProcessingService =
                    scope.ServiceProvider
                        .GetRequiredService<ITransferCheckerService>();

                await scopedProcessingService.CheckTransfers();
            }

            var actualTransfers = await _client.GetAsync("/api/transfers");
            var actualTransfersAsString = await actualTransfers.Content.ReadAsStringAsync();
            var actualTransfersAsJson = JsonConvert.DeserializeObject<IEnumerable<EquipmentTransferDto>>(actualTransfersAsString);

            var actualSrcRoomEquipment = await _client.GetAsync($"/api/rooms/{transfer.SourceRoomId}/equipment");
            var actualSrcRoomEquipmentAsString = await actualSrcRoomEquipment.Content.ReadAsStringAsync();
            var actualSrcRoomEquipmentAsJson = JsonConvert.DeserializeObject<RoomDto>(actualSrcRoomEquipmentAsString);

            var actualDstRoomEquipment = await _client.GetAsync($"/api/rooms/{transfer.DestinationRoomId}/equipment");
            var actualDstRoomEquipmentAsString = await actualDstRoomEquipment.Content.ReadAsStringAsync();
            var actualDstRoomEquipmentAsJson = JsonConvert.DeserializeObject<RoomDto>(actualDstRoomEquipmentAsString);

            actualTransfersAsJson.ShouldBeEmpty();
            actualSrcRoomEquipmentAsJson.Equipment.First().ReservedQuantity.ShouldBe(0);
            actualSrcRoomEquipmentAsJson.Equipment.First().Quantity.ShouldBe(expectedSrcRoomEquipmentQuantity);
            actualDstRoomEquipmentAsJson.Equipment.First().Quantity.ShouldBe(expectedDstRoomEquipmentQuantity);
            actualDstRoomEquipmentAsJson.Equipment.First().EquipmentItemId.ShouldBe(1);
        }

        public static IEnumerable<object[]> Data()
        {
            var retVal = new List<object[]>();

            retVal.Add(new object[]
            {
                new EquipmentTransfer()
                {
                    SourceRoomId = 1,
                    DestinationRoomId = 4,
                    TransferDate = new DateTime(2021, 12, 4),
                    TransferDuration = 15,
                    EquipmentId = 1,
                    Quantity = 10
                },
                90, 10
            });
            retVal.Add(new object[]
            {
                new EquipmentTransfer()
                {
                    SourceRoomId = 2,
                    DestinationRoomId = 3,
                    TransferDate = new DateTime(2021, 12, 4),
                    TransferDuration = 15,
                    EquipmentId = 2,
                    Quantity = 10
                },
                90, 110
            });

            return retVal;
        }

    }
}

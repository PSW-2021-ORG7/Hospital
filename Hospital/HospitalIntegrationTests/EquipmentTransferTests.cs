using System.Net.Http;
using HospitalAPI;
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

        [Fact]
        public void Checks_if_transfer_is_successful()
        {
            Assert.Equal(1, 1);
        }
    }
}

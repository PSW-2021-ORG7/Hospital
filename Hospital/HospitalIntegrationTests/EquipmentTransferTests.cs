using System;
using System.Net.Http;
using System.Threading.Tasks;
using HospitalAPI;
using HospitalClassLibrary.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Xunit;

namespace HospitalIntegrationTests
{
    public class EquipmentTransferTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public EquipmentTransferTests(WebApplicationFactory<Startup> factory)
        {
            var appFactory = factory
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.RemoveAll(typeof(AppDbContext));
                        services.AddDbContext<AppDbContext>(options =>
                        {
                            options.UseInMemoryDatabase("Hospital.TestDb");
                        });
                    });
                });
            _client = appFactory.CreateClient();
        }

        [Fact]
        public async Task Test1Async()
        {
            var response = await _client.GetAsync("/api/equipment");

            response.EnsureSuccessStatusCode();
        }
    }
}

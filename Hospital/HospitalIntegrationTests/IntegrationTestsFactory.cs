using System;
using System.Collections.Generic;
using System.Linq;
using HospitalAPI;
using HospitalClassLibrary.Data;
using HospitalClassLibrary.GraphicalEditor.Models;
using HospitalClassLibrary.RoomEquipment.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalIntegrationTests
{
    public class IntegrationTestsFactory<TStartup> : WebApplicationFactory<Startup>
    {
        private readonly string _dbName = $"testDb{Guid.NewGuid()}";

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                         typeof(DbContextOptions<AppDbContext>));

                if(descriptor != null)
                    services.Remove(descriptor);

                var serviceProvider = new ServiceCollection().AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();

                services.AddDbContext<AppDbContext>(options =>
                {
                    options.UseInMemoryDatabase(_dbName);
                    options.UseInternalServiceProvider(serviceProvider);
                });

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var context = scopedServices.GetRequiredService<AppDbContext>();

                    try
                    {
                        context.Database.EnsureCreated();

                        SeedData(context);
                        context.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
            });
        }

        private void SeedData(AppDbContext context)
        {
            context.Database.EnsureDeleted();
            var equipmentItem = new EquipmentItem()
            {
                Id = 1,
                Name = "Syringe"
            };
            var equipment = new Equipment()
            {
                Id = 1,
                RoomId = 1,
                EquipmentItemId = 1,
                EquipmentItem = equipmentItem,
                Quantity = 100,
                ReservedQuantity = 0
            };
            var sourceRoom = new Room()
            {
                Id = 1,
                BuildingId = 1,
                Name = "0A",
                Status = RoomStatus.UNOCCUPIED,
                Type = RoomType.DOCTOR_OFFICE,
                FreeBeds = 0,
                Floor = 0,
                Equipment = new List<Equipment> { equipment }
            };
            var destinationRoom = new Room()
            {
                Id = 2,
                BuildingId = 1,
                Name = "0B",
                Status = RoomStatus.UNOCCUPIED,
                Type = RoomType.DOCTOR_OFFICE,
                FreeBeds = 0,
                Floor = 0
            };

            context.Room.Add(sourceRoom);
            context.Room.Add(destinationRoom);
            context.Equipment.Add(equipment);
        }

    }
}

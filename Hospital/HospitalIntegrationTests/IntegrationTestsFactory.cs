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
            var srcRoomEquipment1 = new Equipment()
            {
                Id = 1,
                RoomId = 1,
                EquipmentItemId = 1,
                EquipmentItem = equipmentItem,
                Quantity = 100,
                ReservedQuantity = 0
            };
            var srcRoomEquipment2 = new Equipment()
            {
                Id = 2,
                RoomId = 2,
                EquipmentItemId = 1,
                EquipmentItem = equipmentItem,
                Quantity = 100,
                ReservedQuantity = 0
            };
            var srcRoom1 = new Room()
            {
                Id = 1,
                BuildingId = 1,
                Name = "0A",
                Status = RoomStatus.UNOCCUPIED,
                Type = RoomType.DOCTOR_OFFICE,
                FreeBeds = 0,
                Floor = 0,
                Equipment = new List<Equipment> { srcRoomEquipment1 }
            };
            var srcRoom2 = new Room()
            {
                Id = 2,
                BuildingId = 1,
                Name = "0D",
                Status = RoomStatus.UNOCCUPIED,
                Type = RoomType.DOCTOR_OFFICE,
                FreeBeds = 0,
                Floor = 0,
                Equipment = new List<Equipment> { srcRoomEquipment2 }
            };
            var dstRoomEquipment = new Equipment()
            {
                Id = 3,
                RoomId = 3,
                EquipmentItemId = 1,
                EquipmentItem = equipmentItem,
                Quantity = 100,
                ReservedQuantity = 0
            };
            var dstRoomWithEquipment = new Room()
            {
                Id = 3,
                BuildingId = 1,
                Name = "0C",
                Status = RoomStatus.UNOCCUPIED,
                Type = RoomType.DOCTOR_OFFICE,
                FreeBeds = 0,
                Floor = 0,
                Equipment = new List<Equipment> { dstRoomEquipment }
            };
            var dstRoomWithNoEquipment = new Room()
            {
                Id = 4,
                BuildingId = 1,
                Name = "0B",
                Status = RoomStatus.UNOCCUPIED,
                Type = RoomType.DOCTOR_OFFICE,
                FreeBeds = 0,
                Floor = 0
            };

            context.Room.Add(srcRoom1);
            context.Room.Add(srcRoom2);
            context.Room.Add(dstRoomWithEquipment);
            context.Room.Add(dstRoomWithNoEquipment);
            context.Equipment.Add(srcRoomEquipment1);
            context.Equipment.Add(srcRoomEquipment2);
            context.Equipment.Add(dstRoomEquipment);
        }

    }
}

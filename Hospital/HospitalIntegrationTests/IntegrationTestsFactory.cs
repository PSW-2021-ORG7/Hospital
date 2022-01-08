using System;
using System.Collections.Generic;
using System.Linq;
using HospitalAPI;
using HospitalClassLibrary.Data;
using HospitalClassLibrary.GraphicalEditor.Models;
using HospitalClassLibrary.RoomEquipment.Models;
using HospitalClassLibrary.Schedule.Models;
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
                Floor = 0
            };

            var equipmentItemForSplitRenovation = new EquipmentItem()
            {
                Id = 2,
                Name = "Thermometer"
            };

            var equipmentForSplitRenovation = new Equipment()
            {
                Id = 5,
                RoomId = 5,
                EquipmentItemId = 2,
                EquipmentItem  = equipmentItemForSplitRenovation,
                Quantity = 22,
                ReservedQuantity = 0
                
            };

            var roomForSplitRenovation = new Room()
            {
                Id = 5,
                BuildingId = 1,
                Name = "SplitRoom",
                RoomDimensionsId = 5,
                Status = RoomStatus.UNOCCUPIED,
                Type = RoomType.DOCTOR_OFFICE,
                Floor = 0,
                Equipment = new List<Equipment> { equipmentForSplitRenovation }

            };

            var roomDimensionForSplitRenovation = new RoomDimensions()
            {
                Id = 5,
                X = 650,
                Y = 237,
                Width = 210,
                Height = 170
            };

            var equipmentItemForMergeRenovation1 = new EquipmentItem()
            {
                Id = 3,
                Name = "Infusion pump",
                Description = "An external infusion pump is a medical device used to deliver fluids into a patient’s body in a controlled manner."
            };

            var equipmentItemForMergeRenovation2 = new EquipmentItem()
            {
                Id = 4,
                Name = "Gauze",
                Description = "Gauze is a thin, translucent fabric with a loose open weave."
            };

            var equipmentForMergeRenovation1 = new Equipment()
            {
                Id = 6,
                RoomId = 10,
                EquipmentItemId = 3,
                EquipmentItem = equipmentItemForMergeRenovation1,
                Quantity = 50,
                ReservedQuantity = 0
            };

            var equipmentForMergeRenovation2 = new Equipment()
            {
                Id = 7,
                RoomId = 11,
                EquipmentItemId = 4,
                EquipmentItem = equipmentItemForMergeRenovation2,
                Quantity = 100,
                ReservedQuantity = 0
            };

            var roomForMergeRenovation1 = new Room()
            {
                Id = 10,
                BuildingId = 1,
                Name = "MergeRoom1",
                RoomDimensionsId = 6,
                Status = RoomStatus.UNOCCUPIED,
                Type = RoomType.SURGERY_ROOM,
                Floor = 0,
                Equipment = new List<Equipment> { equipmentForMergeRenovation1 }
            };

            var roomForMergeRenovation2 = new Room()
            {
                Id = 11,
                BuildingId = 1,
                Name = "MergeRoom2",
                RoomDimensionsId = 7,
                Status = RoomStatus.UNOCCUPIED,
                Type = RoomType.OPERATING_ROOM,
                Floor = 0,
                Equipment = new List<Equipment> { equipmentForMergeRenovation2 }
            };

            var roomDimensionForMergeRenovation1 = new RoomDimensions()
            {
                Id = 6,
                X = 861,
                Y = 237,
                Width = 322,
                Height = 170
            };

            var roomDimensionForMergeRenovation2 = new RoomDimensions()
            {
                Id = 7,
                X = 1182,
                Y = 237,
                Width = 210,
                Height = 170
            };

            var workday = new Workday()
            {
                Id = 1,
                Appointments = new List<Appointment>(),
                Doctor = new Doctor(),
                DoctorId = 1,
                Shift = new Shift() {Id = 1, Start = new DateTime(2021, 12, 1, 8, 0, 0), End = new DateTime(2021, 12, 1, 23, 0, 0)},
                ShiftId = 1
            };

            context.Room.Add(srcRoom1);
            context.Room.Add(srcRoom2);
            context.Room.Add(dstRoomWithEquipment);
            context.Room.Add(dstRoomWithNoEquipment);
            context.Equipment.Add(srcRoomEquipment1);
            context.Equipment.Add(srcRoomEquipment2);
            context.Equipment.Add(dstRoomEquipment);

            context.Room.Add(roomForSplitRenovation);
            context.RoomDimension.Add(roomDimensionForSplitRenovation);
            context.Equipment.Add(equipmentForSplitRenovation);

            context.Room.Add(roomForMergeRenovation1);
            context.Room.Add(roomForMergeRenovation2);
            context.RoomDimension.Add(roomDimensionForMergeRenovation1);
            context.RoomDimension.Add(roomDimensionForMergeRenovation2);
            context.Equipment.Add(equipmentForMergeRenovation1);
            context.Equipment.Add(equipmentForMergeRenovation2);

            context.Workday.Add(workday);
        }

    }
}

﻿using HospitalClassLibrary.GraphicalEditor.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalClassLibrary.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Building> Buildings { get; set; }
        public DbSet<Room> Rooms { get; set; }


        // only for testing purposes
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Building>().HasData(
                new Building
                {
                    Id = 1, Name = "Oasis Main Building",
                    Description = "The administrative center of Oasis Healthcare"
                },
                new Building
                {
                    Id = 2, Name = "Oasis Treatment Center",
                    Description = "The treatment facility of Oasis Healthcare"
                }
            );
            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    Id = 1,
                    BuildingId = 1, Name = "0A",
                    Status = RoomStatus.UNOCCUPIED,
                    Type = RoomType.DOCTOR_OFFICE,
                    FreeBeds = 0,
                    Floor = 0,
                    X = 422, Y = 187, Width = 228, Height = 220
                },
                new Room
                {
                    Id = 2,
                    BuildingId = 1, Name = "0B",
                    Status = RoomStatus.UNOCCUPIED,
                    Type = RoomType.DOCTOR_OFFICE,
                    FreeBeds = 0,
                    Floor = 0,
                    X = 422, Y = 683, Width = 229, Height = 217
                },
                new Room
                {
                    Id = 3,
                    BuildingId = 1, Name = "0C",
                    Status = RoomStatus.UNOCCUPIED,
                    Type = RoomType.DOCTOR_OFFICE,
                    FreeBeds = 0,
                    Floor = 0,
                    X = 651, Y = 596, Width = 209, Height = 254
                },
                new Room
                {
                    Id = 4,
                    BuildingId = 1, Name = "0A",
                    Status = RoomStatus.UNOCCUPIED,
                    Type = RoomType.OPERATING_ROOM,
                    FreeBeds = 1,
                    Floor = 0,
                    X = 1182, Y = 237, Width = 210, Height = 170
                },
                new Room
                {
                    Id = 5,
                    BuildingId = 1, Name = "0B",
                    Status = RoomStatus.UNOCCUPIED,
                    Type = RoomType.OPERATING_ROOM,
                    FreeBeds = 1,
                    Floor = 0,
                    X = 650, Y = 237, Width = 210, Height = 170
                },
                new Room
                {
                    Id = 6,
                    BuildingId = 1, Name = "0A",
                    Status = RoomStatus.UNOCCUPIED,
                    Type = RoomType.SURGERY_ROOM,
                    FreeBeds = 1,
                    Floor = 0,
                    X = 861, Y = 237, Width = 322, Height = 170
                },
                new Room
                {
                    Id = 7,
                    BuildingId = 1, Name = "0A",
                    Status = RoomStatus.UNOCCUPIED,
                    Type = RoomType.EMERGENCY_ROOM,
                    FreeBeds = 1,
                    Floor = 0,
                    X = 1190, Y = 696, Width = 202, Height = 154
                },
                new Room
                {
                    Id = 8,
                    BuildingId = 1, Name = "0B",
                    Status = RoomStatus.UNOCCUPIED,
                    Type = RoomType.EMERGENCY_ROOM,
                    FreeBeds = 1,
                    Floor = 0,
                    X = 1190, Y = 541, Width = 202, Height = 154
                },
                new Room
                {
                    Id = 9,
                    BuildingId = 1, Name = "Men's",
                    Status = RoomStatus.UNOCCUPIED,
                    Type = RoomType.RESTROOM,
                    FreeBeds = 0,
                    Floor = 0,
                    X = 422, Y = 407, Width = 106, Height = 138
                },
                new Room
                {
                    Id = 10,
                    BuildingId = 1, Name = "Women's",
                    Status = RoomStatus.UNOCCUPIED,
                    Type = RoomType.RESTROOM,
                    FreeBeds = 0,
                    Floor = 0,
                    X = 422, Y = 544, Width = 106, Height = 138
                },
                new Room
                {
                    Id = 11,
                    BuildingId = 1, Name = "L",
                    Status = RoomStatus.UNOCCUPIED,
                    Type = RoomType.LIFT,
                    FreeBeds = 0,
                    Floor = 0,
                    X = 581, Y = 407, Width = 69, Height = 69
                },
                new Room
                {
                    Id = 12,
                    BuildingId = 1, Name = "S1",
                    Status = RoomStatus.UNOCCUPIED,
                    Type = RoomType.STAIRS,
                    FreeBeds = 0,
                    Floor = 0,
                    X = 581, Y = 548, Width = 69, Height = 134
                },

                //FLOOR - 1
                new Room
                {
                    Id = 13,
                    BuildingId = 1, Name = "1A",
                    Status = RoomStatus.UNOCCUPIED,
                    Type = RoomType.DOCTOR_OFFICE,
                    FreeBeds = 0,
                    Floor = 1,
                    X = 422,
                    Y = 187,
                    Width = 228,
                    Height = 220
                },
                new Room
                {
                    Id = 14,
                    BuildingId = 1, Name = "1B",
                    Status = RoomStatus.UNOCCUPIED,
                    Type = RoomType.DOCTOR_OFFICE,
                    FreeBeds = 0,
                    Floor = 1,
                    X = 422,
                    Y = 683,
                    Width = 229,
                    Height = 217
                },
                new Room
                {
                    Id = 15,
                    BuildingId = 1, Name = "1C",
                    Status = RoomStatus.UNOCCUPIED,
                    Type = RoomType.DOCTOR_OFFICE,
                    FreeBeds = 0,
                    Floor = 1,
                    X = 651,
                    Y = 596,
                    Width = 209,
                    Height = 254
                },
                new Room
                {
                    Id = 16,
                    BuildingId = 1, Name = "1A",
                    Status = RoomStatus.UNOCCUPIED,
                    Type = RoomType.OPERATING_ROOM,
                    FreeBeds = 1,
                    Floor = 1,
                    X = 1182,
                    Y = 237,
                    Width = 210,
                    Height = 170
                },
                new Room
                {
                    Id = 17,
                    BuildingId = 1, Name = "1B",
                    Status = RoomStatus.UNOCCUPIED,
                    Type = RoomType.OPERATING_ROOM,
                    FreeBeds = 1,
                    Floor = 1,
                    X = 650,
                    Y = 237,
                    Width = 210,
                    Height = 170
                },
                new Room
                {
                    Id = 18,
                    BuildingId = 1, Name = "1A",
                    Status = RoomStatus.UNOCCUPIED,
                    Type = RoomType.SURGERY_ROOM,
                    FreeBeds = 1,
                    Floor = 1,
                    X = 861,
                    Y = 237,
                    Width = 322,
                    Height = 170
                },
                new Room
                {
                    Id = 19,
                    BuildingId = 1, Name = "1A",
                    Status = RoomStatus.UNOCCUPIED,
                    Type = RoomType.EMERGENCY_ROOM,
                    FreeBeds = 1,
                    Floor = 1,
                    X = 1190,
                    Y = 696,
                    Width = 202,
                    Height = 154
                },
                new Room
                {
                    Id = 20,
                    BuildingId = 1, Name = "1B",
                    Status = RoomStatus.UNOCCUPIED,
                    Type = RoomType.EMERGENCY_ROOM,
                    FreeBeds = 1,
                    Floor = 1,
                    X = 1190,
                    Y = 541,
                    Width = 202,
                    Height = 154
                },
                new Room
                {
                    Id = 21,
                    BuildingId = 1, Name = "Men's",
                    Status = RoomStatus.UNOCCUPIED,
                    Type = RoomType.RESTROOM,
                    FreeBeds = 0,
                    Floor = 1,
                    X = 422,
                    Y = 407,
                    Width = 106,
                    Height = 138
                },
                new Room
                {
                    Id = 22,
                    BuildingId = 1, Name = "Women's",
                    Status = RoomStatus.UNOCCUPIED,
                    Type = RoomType.RESTROOM,
                    FreeBeds = 0,
                    Floor = 1,
                    X = 422,
                    Y = 544,
                    Width = 106,
                    Height = 138
                },
                new Room
                {
                    Id = 23,
                    BuildingId = 1, Name = "L",
                    Status = RoomStatus.UNOCCUPIED,
                    Type = RoomType.LIFT,
                    FreeBeds = 0,
                    Floor = 1,
                    X = 581,
                    Y = 407,
                    Width = 69,
                    Height = 69
                },
                new Room
                {
                    Id = 24,
                    BuildingId = 1, Name = "S1",
                    Status = RoomStatus.UNOCCUPIED,
                    Type = RoomType.STAIRS,
                    FreeBeds = 0,
                    Floor = 1,
                    X = 581,
                    Y = 548,
                    Width = 69,
                    Height = 134
                }
            );
        }
    }
}
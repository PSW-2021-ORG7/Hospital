using HospitalClassLibrary.GraphicalEditor.Models;
using HospitalClassLibrary.RoomEquipment.Models;
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
        public DbSet<Equipment> Equipment { get; set; }


        // only for testing purposes
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EquipmentItem>().HasData(
                new EquipmentItem
                {
                    Id = 1,
                    Name = "Syringe",
                    Description = "A syringe is a simple reciprocating pump consisting of a plunger that fits tightly within a cylindrical tube called a barrel."
                },
                new EquipmentItem
                {
                    Id = 2,
                    Name = "Thermometer",
                    Description = "A thermometer is a device that measures temperature or a temperature gradient."
                },
                new EquipmentItem
                {
                    Id = 3,
                    Name = "Infusion pump",
                    Description = "An external infusion pump is a medical device used to deliver fluids into a patient’s body in a controlled manner."
                },
                new EquipmentItem
                {
                    Id = 4,
                    Name = "Gauze",
                    Description = "Gauze is a thin, translucent fabric with a loose open weave."
                },
                new EquipmentItem
                {
                    Id = 5,
                    Name = "Operating table",
                    Description = "An operating table, sometimes called operating room table, is the table on which the patient lies during a surgical operation."
                },
                new EquipmentItem
                {
                    Id = 6,
                    Name = "Otoscope",
                    Description = "An otoscope or auriscope is a medical device which is used to look into the ears."
                },
                new EquipmentItem
                {
                    Id = 7,
                    Name = "Inhaler",
                    Description = "An inhaler is a medical device used for delivering medicines into the lungs through the work of a person's breathing."
                },
                new EquipmentItem
                {
                    Id = 8,
                    Name = "Scalpel",
                    Description = "A scalpel is a small and extremely sharp bladed instrument used for surgery, anatomical dissection, podiatry and various arts and crafts."
                },
                new EquipmentItem
                {
                    Id = 9,
                    Name = "Adhesive Plaster",
                    Description = "An adhesive bandage is a small medical dressing used for injuries not serious enough to require a full-size bandage."
                },
                new EquipmentItem
                {
                    Id = 10,
                    Name = "Curette",
                    Description = "A curette is a surgical instrument designed for scraping or debriding biological tissue or debris in a biopsy, excision, or cleaning procedure."
                },
                new EquipmentItem
                {
                    Id = 11,
                    Name = "Medical glove",
                    Description = "Medical gloves are disposable gloves used during medical examinations and procedures to help prevent cross-contamination between caregivers and patients."
                },
                new EquipmentItem
                {
                    Id = 12,
                    Name = "Oxygen tank",
                    Description = "An oxygen tank is an oxygen storage vessel, which is either held under pressure in gas cylinders, or as liquid oxygen in a cryogenic storage tank."
                },
                new EquipmentItem
                {
                    Id = 13,
                    Name = "Miller–Abbott tube",
                    Description = "A Miller–Abbott tube is a tube used to treat obstructions in the small intestine through intubation."
                },
                new EquipmentItem
                {
                    Id = 14,
                    Name = "Trach tube",
                    Description = "The tube is inserted through a cut in the neck below the vocal cords. This allows air to enter the lungs."
                },
                new EquipmentItem
                {
                    Id = 15,
                    Name = "Surgical suture",
                    Description = "Surgical suture is a medical device used to hold body tissues together after an injury or surgery."
                }
            );
            modelBuilder.Entity<Equipment>().HasData(
                new Equipment
                {
                    Id = 1,
                    RoomId = 4,
                    EquipmentItemId = 1,
                    Quantity = 100
                },
                new Equipment
                {
                    Id = 2,
                    RoomId = 4,
                    EquipmentItemId = 2,
                    Quantity = 2
                },
                new Equipment
                {
                    Id = 3,
                    RoomId = 4,
                    EquipmentItemId = 3,
                    Quantity = 4
                },
                new Equipment
                {
                    Id = 4,
                    RoomId = 4,
                    EquipmentItemId = 4,
                    Quantity = 200
                },
                new Equipment
                {
                    Id = 5,
                    RoomId = 4,
                    EquipmentItemId = 8,
                    Quantity = 6
                },
                new Equipment
                {
                    Id = 6,
                    RoomId = 4,
                    EquipmentItemId = 5,
                    Quantity = 1
                }, 
                new Equipment
                {
                    Id = 13,
                    RoomId = 4,
                    EquipmentItemId = 14,
                    Quantity = 4
                }, 
                new Equipment
                {
                    Id = 14,
                    RoomId = 4,
                    EquipmentItemId = 15,
                    Quantity = 1
                },
                ///////////////////////////
                new Equipment
                {
                    Id = 7,
                    RoomId = 5,
                    EquipmentItemId = 1,
                    Quantity = 104
                },
                new Equipment
                {
                    Id = 8,
                    RoomId = 5,
                    EquipmentItemId = 2,
                    Quantity = 5
                },
                new Equipment
                {
                    Id = 9,
                    RoomId = 5,
                    EquipmentItemId = 3,
                    Quantity = 6
                },
                new Equipment
                {
                    Id = 10,
                    RoomId = 5,
                    EquipmentItemId = 4,
                    Quantity = 150
                },
                new Equipment
                {
                    Id = 11,
                    RoomId = 5,
                    EquipmentItemId = 8,
                    Quantity = 10
                },
                new Equipment
                {
                    Id = 12,
                    RoomId = 5,
                    EquipmentItemId = 5,
                    Quantity = 1
                },
                new Equipment
                {
                    Id = 15,
                    RoomId = 4,
                    EquipmentItemId = 14,
                    Quantity = 3
                },
                new Equipment
                {
                    Id = 16,
                    RoomId = 4,
                    EquipmentItemId = 15,
                    Quantity = 1
                },
                ///////////////////////////////
                new Equipment
                {
                    Id = 17,
                    RoomId = 16,
                    EquipmentItemId = 1,
                    Quantity = 100
                },
                new Equipment
                {
                    Id = 18,
                    RoomId = 16,
                    EquipmentItemId = 2,
                    Quantity = 2
                },
                new Equipment
                {
                    Id = 19,
                    RoomId = 16,
                    EquipmentItemId = 3,
                    Quantity = 4
                },
                new Equipment
                {
                    Id = 20,
                    RoomId = 16,
                    EquipmentItemId = 4,
                    Quantity = 200
                },
                new Equipment
                {
                    Id = 21,
                    RoomId = 16,
                    EquipmentItemId = 8,
                    Quantity = 6
                },
                new Equipment
                {
                    Id = 22,
                    RoomId = 16,
                    EquipmentItemId = 5,
                    Quantity = 1
                },
                new Equipment
                {
                    Id = 23,
                    RoomId = 16,
                    EquipmentItemId = 14,
                    Quantity = 4
                },
                new Equipment
                {
                    Id = 24,
                    RoomId = 16,
                    EquipmentItemId = 15,
                    Quantity = 1
                },
                //////////////////////////
                new Equipment
                {
                    Id = 25,
                    RoomId = 17,
                    EquipmentItemId = 1,
                    Quantity = 104
                },
                new Equipment
                {
                    Id = 26,
                    RoomId = 17,
                    EquipmentItemId = 2,
                    Quantity = 5
                },
                new Equipment
                {
                    Id = 27,
                    RoomId = 17,
                    EquipmentItemId = 3,
                    Quantity = 6
                },
                new Equipment
                {
                    Id = 28,
                    RoomId = 17,
                    EquipmentItemId = 4,
                    Quantity = 150
                },
                new Equipment
                {
                    Id = 29,
                    RoomId = 17,
                    EquipmentItemId = 8,
                    Quantity = 10
                },
                new Equipment
                {
                    Id = 30,
                    RoomId = 17,
                    EquipmentItemId = 5,
                    Quantity = 1
                },
                new Equipment
                {
                    Id = 31,
                    RoomId = 17,
                    EquipmentItemId = 14,
                    Quantity = 3
                },
                new Equipment
                {
                    Id = 32,
                    RoomId = 17,
                    EquipmentItemId = 15,
                    Quantity = 1
                },
                ////////////////////////////
                new Equipment
                {
                    Id = 33,
                    RoomId = 17,
                    EquipmentItemId = 11,
                    Quantity = 230
                },
                new Equipment
                {
                    Id = 34,
                    RoomId = 1,
                    EquipmentItemId = 11,
                    Quantity = 200
                },
                new Equipment
                {
                    Id = 35,
                    RoomId = 2,
                    EquipmentItemId = 11,
                    Quantity = 110
                },
                new Equipment
                {
                    Id = 36,
                    RoomId = 3,
                    EquipmentItemId = 11,
                    Quantity = 235
                }

            );
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
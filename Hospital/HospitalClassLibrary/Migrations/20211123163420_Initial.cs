using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalClassLibrary.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Building",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Building", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shift",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shift", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    FreeBeds = table.Column<int>(nullable: false),
                    Floor = table.Column<int>(nullable: false),
                    X = table.Column<double>(nullable: false),
                    Y = table.Column<double>(nullable: false),
                    Width = table.Column<double>(nullable: false),
                    Height = table.Column<double>(nullable: false),
                    BuildingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_Building_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Building",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    Specialization = table.Column<int>(nullable: false),
                    RoomId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctor_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoomId = table.Column<int>(nullable: false),
                    EquipmentItemId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipment_EquipmentItem_EquipmentItemId",
                        column: x => x.EquipmentItemId,
                        principalTable: "EquipmentItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipment_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Workday",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DoctorId = table.Column<int>(nullable: false),
                    ShiftId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workday", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workday_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Workday_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Shift",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    WorkdayId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointment_Workday_WorkdayId",
                        column: x => x.WorkdayId,
                        principalTable: "Workday",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Building",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "The administrative center of Oasis Healthcare", "Oasis Main Building" },
                    { 2, "The treatment facility of Oasis Healthcare", "Oasis Treatment Center" }
                });

            migrationBuilder.InsertData(
                table: "EquipmentItem",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 14, "The tube is inserted through a cut in the neck below the vocal cords. This allows air to enter the lungs.", "Trach tube" },
                    { 13, "A Miller–Abbott tube is a tube used to treat obstructions in the small intestine through intubation.", "Miller–Abbott tube" },
                    { 12, "An oxygen tank is an oxygen storage vessel, which is either held under pressure in gas cylinders, or as liquid oxygen in a cryogenic storage tank.", "Oxygen tank" },
                    { 11, "Medical gloves are disposable gloves used during medical examinations and procedures to help prevent cross-contamination between caregivers and patients.", "Medical glove" },
                    { 10, "A curette is a surgical instrument designed for scraping or debriding biological tissue or debris in a biopsy, excision, or cleaning procedure.", "Curette" },
                    { 9, "An adhesive bandage is a small medical dressing used for injuries not serious enough to require a full-size bandage.", "Adhesive Plaster" },
                    { 8, "A scalpel is a small and extremely sharp bladed instrument used for surgery, anatomical dissection, podiatry and various arts and crafts.", "Scalpel" },
                    { 15, "Surgical suture is a medical device used to hold body tissues together after an injury or surgery.", "Surgical suture" },
                    { 6, "An otoscope or auriscope is a medical device which is used to look into the ears.", "Otoscope" },
                    { 5, "An operating table, sometimes called operating room table, is the table on which the patient lies during a surgical operation.", "Operating table" },
                    { 4, "Gauze is a thin, translucent fabric with a loose open weave.", "Gauze" },
                    { 3, "An external infusion pump is a medical device used to deliver fluids into a patient’s body in a controlled manner.", "Infusion pump" },
                    { 2, "A thermometer is a device that measures temperature or a temperature gradient.", "Thermometer" },
                    { 1, "A syringe is a simple reciprocating pump consisting of a plunger that fits tightly within a cylindrical tube called a barrel.", "Syringe" },
                    { 7, "An inhaler is a medical device used for delivering medicines into the lungs through the work of a person's breathing.", "Inhaler" }
                });

            migrationBuilder.InsertData(
                table: "Shift",
                columns: new[] { "Id", "End", "Start" },
                values: new object[,]
                {
                    { 14, new DateTime(2021, 11, 29, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 29, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, new DateTime(2021, 11, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 29, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, new DateTime(2021, 11, 28, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 28, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, new DateTime(2021, 11, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 28, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(2021, 11, 27, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 27, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2021, 11, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 27, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2021, 11, 23, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 26, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2021, 11, 25, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 25, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2021, 11, 25, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 25, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2021, 11, 24, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 24, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2021, 11, 24, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 24, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2021, 11, 23, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 23, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, new DateTime(2021, 11, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 23, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, new DateTime(2021, 11, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 30, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2021, 11, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 26, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, new DateTime(2021, 11, 30, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 30, 17, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "Id", "BuildingId", "Floor", "FreeBeds", "Height", "Name", "Status", "Type", "Width", "X", "Y" },
                values: new object[,]
                {
                    { 1, 1, 0, 0, 220.0, "0A", 1, 4, 228.0, 422.0, 187.0 },
                    { 22, 1, 1, 0, 138.0, "Women's", 1, 5, 106.0, 422.0, 544.0 },
                    { 21, 1, 1, 0, 138.0, "Men's", 1, 5, 106.0, 422.0, 407.0 },
                    { 20, 1, 1, 1, 154.0, "1B", 1, 3, 202.0, 1190.0, 541.0 },
                    { 19, 1, 1, 1, 154.0, "1A", 1, 3, 202.0, 1190.0, 696.0 },
                    { 18, 1, 1, 1, 170.0, "1A", 1, 1, 322.0, 861.0, 237.0 },
                    { 17, 1, 1, 1, 170.0, "1B", 1, 0, 210.0, 650.0, 237.0 },
                    { 16, 1, 1, 1, 170.0, "1A", 1, 0, 210.0, 1182.0, 237.0 },
                    { 15, 1, 1, 0, 254.0, "1C", 1, 4, 209.0, 651.0, 596.0 },
                    { 14, 1, 1, 0, 217.0, "1B", 1, 4, 229.0, 422.0, 683.0 },
                    { 13, 1, 1, 0, 220.0, "1A", 1, 4, 228.0, 422.0, 187.0 },
                    { 12, 1, 0, 0, 134.0, "S1", 1, 7, 69.0, 581.0, 548.0 },
                    { 11, 1, 0, 0, 69.0, "L", 1, 6, 69.0, 581.0, 407.0 },
                    { 10, 1, 0, 0, 138.0, "Women's", 1, 5, 106.0, 422.0, 544.0 },
                    { 9, 1, 0, 0, 138.0, "Men's", 1, 5, 106.0, 422.0, 407.0 },
                    { 8, 1, 0, 1, 154.0, "0B", 1, 3, 202.0, 1190.0, 541.0 },
                    { 7, 1, 0, 1, 154.0, "0A", 1, 3, 202.0, 1190.0, 696.0 },
                    { 6, 1, 0, 1, 170.0, "0A", 1, 1, 322.0, 861.0, 237.0 },
                    { 5, 1, 0, 1, 170.0, "0B", 1, 0, 210.0, 650.0, 237.0 },
                    { 4, 1, 0, 1, 170.0, "0A", 1, 0, 210.0, 1182.0, 237.0 },
                    { 3, 1, 0, 0, 254.0, "0C", 1, 4, 209.0, 651.0, 596.0 },
                    { 2, 1, 0, 0, 217.0, "0B", 1, 4, 229.0, 422.0, 683.0 },
                    { 23, 1, 1, 0, 69.0, "L", 1, 6, 69.0, 581.0, 407.0 },
                    { 24, 1, 1, 0, 134.0, "S1", 1, 7, 69.0, 581.0, 548.0 }
                });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "Id", "DateOfBirth", "Email", "Gender", "Name", "Phone", "RoomId", "Specialization", "Surname" },
                values: new object[,]
                {
                    { 5, new DateTime(1968, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "melanie@gmail.com", 1, "Melanie", "066144141", 5, 3, "Remi" },
                    { 1, new DateTime(1959, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "georgeross@gmail.com", 0, "George", "0618384494", 1, 0, "Ross" },
                    { 2, new DateTime(1965, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "jonnydepp@gmail.com", 0, "Jonny", "0628345664", 2, 3, "Depp" },
                    { 3, new DateTime(1963, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "luigidomino@gmail.com", 0, "Luigi", "0618331884", 3, 1, "Domino" },
                    { 4, new DateTime(1987, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "monnica13@gmail.com", 1, "Monnica", "0633415156", 4, 2, "Beckham" },
                    { 6, new DateTime(1988, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "latcika@gmail.com", 0, "Latcika", "066165642", 6, 3, "Uri" }
                });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "EquipmentItemId", "Quantity", "RoomId" },
                values: new object[,]
                {
                    { 17, 1, 100, 16 },
                    { 18, 2, 2, 16 },
                    { 19, 3, 4, 16 },
                    { 20, 4, 200, 16 },
                    { 21, 8, 6, 16 },
                    { 22, 5, 1, 16 },
                    { 25, 1, 104, 17 },
                    { 24, 15, 1, 16 },
                    { 26, 2, 5, 17 },
                    { 27, 3, 6, 17 },
                    { 28, 4, 150, 17 },
                    { 29, 8, 10, 17 },
                    { 30, 5, 1, 17 },
                    { 31, 14, 3, 17 },
                    { 23, 14, 4, 16 },
                    { 34, 11, 200, 1 },
                    { 10, 4, 150, 5 },
                    { 11, 8, 10, 5 },
                    { 35, 11, 110, 2 },
                    { 36, 11, 235, 3 },
                    { 1, 1, 100, 4 },
                    { 2, 2, 2, 4 },
                    { 3, 3, 4, 4 },
                    { 4, 4, 200, 4 },
                    { 5, 8, 6, 4 },
                    { 12, 5, 1, 5 },
                    { 6, 5, 1, 4 },
                    { 14, 15, 1, 4 },
                    { 15, 14, 3, 4 },
                    { 16, 15, 1, 4 },
                    { 7, 1, 104, 5 },
                    { 8, 2, 5, 5 },
                    { 9, 3, 6, 5 },
                    { 32, 15, 1, 17 },
                    { 13, 14, 4, 4 },
                    { 33, 11, 230, 17 }
                });

            migrationBuilder.InsertData(
                table: "Workday",
                columns: new[] { "Id", "DoctorId", "ShiftId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 16, 4, 4 },
                    { 15, 4, 2 },
                    { 14, 3, 9 },
                    { 13, 3, 7 },
                    { 12, 3, 5 },
                    { 11, 3, 3 },
                    { 10, 3, 1 },
                    { 9, 2, 8 },
                    { 8, 2, 6 },
                    { 7, 2, 4 },
                    { 6, 2, 2 },
                    { 5, 1, 9 },
                    { 4, 1, 7 },
                    { 3, 1, 5 },
                    { 2, 1, 3 },
                    { 17, 4, 6 },
                    { 18, 4, 8 }
                });

            migrationBuilder.InsertData(
                table: "Appointment",
                columns: new[] { "Id", "EndTime", "StartTime", "WorkdayId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 11, 23, 8, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 26, new DateTime(2021, 11, 25, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 25, 20, 0, 0, 0, DateTimeKind.Unspecified), 17 },
                    { 14, new DateTime(2021, 11, 24, 18, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 24, 18, 0, 0, 0, DateTimeKind.Unspecified), 16 },
                    { 7, new DateTime(2021, 11, 23, 18, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 23, 18, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 31, new DateTime(2021, 11, 26, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 26, 13, 30, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 28, new DateTime(2021, 11, 26, 11, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 26, 11, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 27, new DateTime(2021, 11, 26, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 26, 10, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 22, new DateTime(2021, 11, 25, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 25, 13, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 21, new DateTime(2021, 11, 25, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 25, 12, 30, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 19, new DateTime(2021, 11, 25, 11, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 25, 11, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 18, new DateTime(2021, 11, 25, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 16, new DateTime(2021, 11, 25, 9, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 11, new DateTime(2021, 11, 24, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 24, 13, 0, 0, 0, DateTimeKind.Unspecified), 11 },
                    { 10, new DateTime(2021, 11, 24, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 24, 12, 0, 0, 0, DateTimeKind.Unspecified), 11 },
                    { 5, new DateTime(2021, 11, 23, 14, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 23, 14, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 32, new DateTime(2021, 11, 26, 17, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), 18 },
                    { 4, new DateTime(2021, 11, 23, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 23, 12, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 25, new DateTime(2021, 11, 23, 19, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 25, 19, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 24, new DateTime(2021, 11, 25, 17, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 25, 17, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 13, new DateTime(2021, 11, 24, 17, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 24, 17, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 6, new DateTime(2021, 11, 23, 17, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 30, new DateTime(2021, 11, 26, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 26, 13, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 29, new DateTime(2021, 11, 26, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 26, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 23, new DateTime(2021, 11, 25, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 25, 15, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 20, new DateTime(2021, 11, 25, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 25, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 17, new DateTime(2021, 11, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 25, 9, 30, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 15, new DateTime(2021, 11, 25, 8, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 25, 8, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 12, new DateTime(2021, 11, 24, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 24, 13, 30, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 9, new DateTime(2021, 11, 24, 11, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 24, 11, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 8, new DateTime(2021, 11, 24, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 24, 10, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, new DateTime(2021, 11, 23, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 23, 11, 30, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2021, 11, 23, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 23, 10, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 33, new DateTime(2021, 11, 26, 18, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 26, 18, 0, 0, 0, DateTimeKind.Unspecified), 18 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_WorkdayId",
                table: "Appointment",
                column: "WorkdayId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_RoomId",
                table: "Doctor",
                column: "RoomId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_EquipmentItemId",
                table: "Equipment",
                column: "EquipmentItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_RoomId",
                table: "Equipment",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_BuildingId",
                table: "Room",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Workday_DoctorId",
                table: "Workday",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Workday_ShiftId",
                table: "Workday",
                column: "ShiftId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Workday");

            migrationBuilder.DropTable(
                name: "EquipmentItem");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Shift");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Building");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalClassLibrary.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Events");

            migrationBuilder.CreateTable(
                name: "Building",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'3', '1', '', '', 'False', '1'")
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
                        .Annotation("Npgsql:IdentitySequenceOptions", "'16', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewRoomInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoomName = table.Column<string>(nullable: true),
                    RoomType = table.Column<int>(nullable: false),
                    RoomStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewRoomInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomDimension",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'25', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    X = table.Column<double>(nullable: false),
                    Y = table.Column<double>(nullable: false),
                    Width = table.Column<double>(nullable: false),
                    Height = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomDimension", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shift",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'17', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shift", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BackToMap",
                schema: "Events",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    fromBouldingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackToMap", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BuildingSelection",
                schema: "Events",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    buildingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingSelection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentTransferEvent",
                schema: "Events",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    SourceRoomId = table.Column<int>(nullable: false),
                    DestinationRoomId = table.Column<int>(nullable: false),
                    TransferDate = table.Column<DateTime>(nullable: false),
                    TransferDuration = table.Column<int>(nullable: false),
                    EquipmentId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentTransferEvent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FloorChange",
                schema: "Events",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    buildingId = table.Column<int>(nullable: false),
                    fromFloor = table.Column<int>(nullable: false),
                    toFloor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FloorChange", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MergeRenovationEvent",
                schema: "Events",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    FirstOldRoomId = table.Column<int>(nullable: false),
                    SecondOldRoomId = table.Column<int>(nullable: false),
                    NewRoomName = table.Column<string>(nullable: true),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MergeRenovationEvent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomSelection",
                schema: "Events",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    RoomId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomSelection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SplitRenovationEvent",
                schema: "Events",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    RoomId = table.Column<int>(nullable: false),
                    FirstNewRoomName = table.Column<string>(nullable: true),
                    SecondNewRoomName = table.Column<string>(nullable: true),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false),
                    EquipmentDestination = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SplitRenovationEvent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MergeRenovation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstOldRoomId = table.Column<int>(nullable: false),
                    SecondOldRoomId = table.Column<int>(nullable: false),
                    NewRoomInfoId = table.Column<int>(nullable: true),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MergeRenovation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MergeRenovation_NewRoomInfo_NewRoomInfoId",
                        column: x => x.NewRoomInfoId,
                        principalTable: "NewRoomInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SplitRenovation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoomId = table.Column<int>(nullable: false),
                    FirstNewRoomInfoId = table.Column<int>(nullable: true),
                    SecondNewRoomInfoId = table.Column<int>(nullable: true),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false),
                    EquipmentDestination = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SplitRenovation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SplitRenovation_NewRoomInfo_FirstNewRoomInfoId",
                        column: x => x.FirstNewRoomInfoId,
                        principalTable: "NewRoomInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SplitRenovation_NewRoomInfo_SecondNewRoomInfoId",
                        column: x => x.SecondNewRoomInfoId,
                        principalTable: "NewRoomInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'25', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Floor = table.Column<int>(nullable: false),
                    RoomDimensionsId = table.Column<int>(nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Room_RoomDimension_RoomDimensionsId",
                        column: x => x.RoomDimensionsId,
                        principalTable: "RoomDimension",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'7', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    Specialization = table.Column<int>(nullable: false),
                    UsedOffDays = table.Column<int>(nullable: false),
                    RoomId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctor_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'37', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoomId = table.Column<int>(nullable: false),
                    EquipmentItemId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    ReservedQuantity = table.Column<int>(nullable: false)
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
                name: "Holiday",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false),
                    DoctorId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holiday", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Holiday_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Workday",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'19', '1', '', '', 'False', '1'")
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
                name: "EquipmentTransfer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SourceRoomId = table.Column<int>(nullable: false),
                    DestinationRoomId = table.Column<int>(nullable: false),
                    TransferDate = table.Column<DateTime>(nullable: false),
                    TransferDuration = table.Column<int>(nullable: false),
                    EquipmentId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentTransfer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentTransfer_Room_DestinationRoomId",
                        column: x => x.DestinationRoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentTransfer_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentTransfer_Room_SourceRoomId",
                        column: x => x.SourceRoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'34', '1', '', '', 'False', '1'")
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
                    { 15, "Surgical suture is a medical device used to hold body tissues together after an injury or surgery.", "Surgical suture" },
                    { 14, "The tube is inserted through a cut in the neck below the vocal cords. This allows air to enter the lungs.", "Trach tube" },
                    { 13, "A Miller–Abbott tube is a tube used to treat obstructions in the small intestine through intubation.", "Miller–Abbott tube" },
                    { 12, "An oxygen tank is an oxygen storage vessel, which is either held under pressure in gas cylinders, or as liquid oxygen in a cryogenic storage tank.", "Oxygen tank" },
                    { 11, "Medical gloves are disposable gloves used during medical examinations and procedures to help prevent cross-contamination between caregivers and patients.", "Medical glove" },
                    { 10, "A curette is a surgical instrument designed for scraping or debriding biological tissue or debris in a biopsy, excision, or cleaning procedure.", "Curette" },
                    { 9, "An adhesive bandage is a small medical dressing used for injuries not serious enough to require a full-size bandage.", "Adhesive Plaster" },
                    { 8, "A scalpel is a small and extremely sharp bladed instrument used for surgery, anatomical dissection, podiatry and various arts and crafts.", "Scalpel" },
                    { 7, "An inhaler is a medical device used for delivering medicines into the lungs through the work of a person's breathing.", "Inhaler" },
                    { 6, "An otoscope or auriscope is a medical device which is used to look into the ears.", "Otoscope" },
                    { 5, "An operating table, sometimes called operating room table, is the table on which the patient lies during a surgical operation.", "Operating table" },
                    { 4, "Gauze is a thin, translucent fabric with a loose open weave.", "Gauze" },
                    { 2, "A thermometer is a device that measures temperature or a temperature gradient.", "Thermometer" },
                    { 1, "A syringe is a simple reciprocating pump consisting of a plunger that fits tightly within a cylindrical tube called a barrel.", "Syringe" },
                    { 3, "An external infusion pump is a medical device used to deliver fluids into a patient’s body in a controlled manner.", "Infusion pump" }
                });

            migrationBuilder.InsertData(
                table: "RoomDimension",
                columns: new[] { "Id", "Height", "Width", "X", "Y" },
                values: new object[,]
                {
                    { 16, 170.0, 210.0, 1182.0, 237.0 },
                    { 1, 220.0, 228.0, 422.0, 187.0 },
                    { 2, 217.0, 229.0, 422.0, 683.0 },
                    { 3, 254.0, 209.0, 651.0, 596.0 },
                    { 4, 170.0, 210.0, 1182.0, 237.0 },
                    { 15, 254.0, 209.0, 651.0, 596.0 },
                    { 6, 170.0, 322.0, 861.0, 237.0 },
                    { 7, 154.0, 202.0, 1190.0, 696.0 },
                    { 8, 154.0, 202.0, 1190.0, 541.0 },
                    { 9, 138.0, 106.0, 422.0, 407.0 },
                    { 10, 138.0, 106.0, 422.0, 544.0 },
                    { 11, 69.0, 69.0, 581.0, 407.0 },
                    { 5, 170.0, 210.0, 650.0, 237.0 },
                    { 19, 154.0, 202.0, 1190.0, 696.0 },
                    { 13, 220.0, 228.0, 422.0, 187.0 },
                    { 14, 217.0, 229.0, 422.0, 683.0 },
                    { 24, 134.0, 69.0, 581.0, 548.0 },
                    { 23, 69.0, 69.0, 581.0, 407.0 },
                    { 22, 138.0, 106.0, 422.0, 544.0 },
                    { 21, 138.0, 106.0, 422.0, 407.0 },
                    { 20, 154.0, 202.0, 1190.0, 541.0 },
                    { 18, 170.0, 322.0, 861.0, 237.0 },
                    { 17, 170.0, 210.0, 650.0, 237.0 },
                    { 12, 134.0, 69.0, 581.0, 548.0 }
                });

            migrationBuilder.InsertData(
                table: "Shift",
                columns: new[] { "Id", "End", "Name", "Start" },
                values: new object[,]
                {
                    { 11, new DateTime(2021, 11, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), "Morning shift", new DateTime(2021, 11, 28, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, new DateTime(2021, 11, 28, 23, 0, 0, 0, DateTimeKind.Unspecified), "Afternoon shift", new DateTime(2021, 11, 28, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, new DateTime(2021, 11, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), "Morning shift", new DateTime(2021, 11, 30, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, new DateTime(2021, 11, 29, 23, 0, 0, 0, DateTimeKind.Unspecified), "Afternoon shift", new DateTime(2021, 11, 29, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(2021, 11, 27, 23, 0, 0, 0, DateTimeKind.Unspecified), "Afternoon shift", new DateTime(2021, 11, 27, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, new DateTime(2021, 11, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), "Morning shift", new DateTime(2021, 11, 29, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2021, 11, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), "Morning shift", new DateTime(2021, 11, 27, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2021, 11, 24, 17, 0, 0, 0, DateTimeKind.Unspecified), "Morning shift", new DateTime(2021, 11, 24, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2021, 11, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), "Morning shift", new DateTime(2021, 11, 26, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2021, 11, 25, 23, 0, 0, 0, DateTimeKind.Unspecified), "Afternoon shift", new DateTime(2021, 11, 25, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2021, 11, 25, 17, 0, 0, 0, DateTimeKind.Unspecified), "Morning shift", new DateTime(2021, 11, 25, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2021, 11, 24, 23, 0, 0, 0, DateTimeKind.Unspecified), "Afternoon shift", new DateTime(2021, 11, 24, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2021, 11, 23, 23, 0, 0, 0, DateTimeKind.Unspecified), "Afternoon shift", new DateTime(2021, 11, 23, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, new DateTime(2021, 11, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), "Morning shift", new DateTime(2021, 11, 23, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2021, 11, 23, 23, 0, 0, 0, DateTimeKind.Unspecified), "Afternoon shift", new DateTime(2021, 11, 26, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, new DateTime(2021, 11, 30, 23, 0, 0, 0, DateTimeKind.Unspecified), "Afternoon shift", new DateTime(2021, 11, 30, 17, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "Id", "BuildingId", "Floor", "Name", "RoomDimensionsId", "Status", "Type" },
                values: new object[,]
                {
                    { 1, 1, 0, "0A", 1, 1, 4 },
                    { 22, 1, 1, "Women's", 22, 1, 5 },
                    { 21, 1, 1, "Men's", 21, 1, 5 },
                    { 20, 1, 1, "1B", 20, 1, 3 },
                    { 19, 1, 1, "1A", 19, 1, 3 },
                    { 18, 1, 1, "1A", 18, 1, 1 },
                    { 17, 1, 1, "1B", 17, 1, 0 },
                    { 16, 1, 1, "1A", 16, 1, 0 },
                    { 15, 1, 1, "1C", 15, 1, 4 },
                    { 14, 1, 1, "1B", 14, 1, 4 },
                    { 13, 1, 1, "1A", 13, 1, 4 },
                    { 12, 1, 0, "S1", 12, 1, 7 },
                    { 11, 1, 0, "L", 11, 1, 6 },
                    { 10, 1, 0, "Women's", 10, 1, 5 },
                    { 9, 1, 0, "Men's", 9, 1, 5 },
                    { 8, 1, 0, "0B", 8, 1, 3 },
                    { 7, 1, 0, "0A", 7, 1, 3 },
                    { 6, 1, 0, "0A", 6, 1, 1 },
                    { 5, 1, 0, "0B", 5, 1, 0 },
                    { 4, 1, 0, "0A", 4, 1, 0 },
                    { 3, 1, 0, "0C", 3, 1, 4 },
                    { 2, 1, 0, "0B", 2, 1, 4 },
                    { 23, 1, 1, "L", 23, 1, 6 },
                    { 24, 1, 1, "S1", 24, 1, 7 }
                });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "Id", "DateOfBirth", "Email", "Gender", "Name", "Phone", "RoomId", "Specialization", "Surname", "UsedOffDays" },
                values: new object[,]
                {
                    { 5, new DateTime(1968, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "melanie@gmail.com", 1, "Melanie", "066144141", 5, 3, "Remi", 0 },
                    { 1, new DateTime(1959, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "georgeross@gmail.com", 0, "George", "0618384494", 1, 0, "Ross", 0 },
                    { 2, new DateTime(1965, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "jonnydepp@gmail.com", 0, "Jonny", "0628345664", 2, 3, "Depp", 0 },
                    { 3, new DateTime(1963, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "luigidomino@gmail.com", 0, "Luigi", "0618331884", 3, 1, "Domino", 0 },
                    { 4, new DateTime(1987, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "monnica13@gmail.com", 1, "Monnica", "0633415156", 4, 2, "Beckham", 0 },
                    { 6, new DateTime(1988, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "latcika@gmail.com", 0, "Latcika", "066165642", 6, 3, "Uri", 0 }
                });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "EquipmentItemId", "Quantity", "ReservedQuantity", "RoomId" },
                values: new object[,]
                {
                    { 17, 1, 100, 0, 16 },
                    { 18, 2, 2, 0, 16 },
                    { 19, 3, 4, 0, 16 },
                    { 20, 4, 200, 0, 16 },
                    { 21, 8, 6, 0, 16 },
                    { 22, 5, 1, 0, 16 },
                    { 25, 1, 104, 0, 17 },
                    { 24, 15, 1, 0, 16 },
                    { 26, 2, 5, 0, 17 },
                    { 27, 3, 6, 0, 17 },
                    { 28, 4, 150, 0, 17 },
                    { 29, 8, 10, 0, 17 },
                    { 30, 5, 1, 0, 17 },
                    { 31, 14, 3, 0, 17 },
                    { 23, 14, 4, 0, 16 },
                    { 34, 11, 200, 0, 1 },
                    { 10, 4, 150, 0, 5 },
                    { 11, 8, 10, 0, 5 },
                    { 35, 11, 110, 0, 2 },
                    { 36, 11, 235, 0, 3 },
                    { 1, 1, 100, 0, 4 },
                    { 2, 2, 2, 0, 4 },
                    { 3, 3, 4, 0, 4 },
                    { 4, 4, 200, 0, 4 },
                    { 5, 8, 6, 0, 4 },
                    { 12, 5, 1, 0, 5 },
                    { 6, 5, 1, 0, 4 },
                    { 14, 15, 1, 0, 4 },
                    { 15, 14, 3, 0, 4 },
                    { 16, 15, 1, 0, 4 },
                    { 7, 1, 104, 0, 5 },
                    { 8, 2, 5, 0, 5 },
                    { 9, 3, 6, 0, 5 },
                    { 32, 15, 1, 0, 17 },
                    { 13, 14, 4, 0, 4 },
                    { 33, 11, 230, 0, 17 }
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
                name: "IX_EquipmentTransfer_DestinationRoomId",
                table: "EquipmentTransfer",
                column: "DestinationRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentTransfer_EquipmentId",
                table: "EquipmentTransfer",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentTransfer_SourceRoomId",
                table: "EquipmentTransfer",
                column: "SourceRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Holiday_DoctorId",
                table: "Holiday",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_MergeRenovation_NewRoomInfoId",
                table: "MergeRenovation",
                column: "NewRoomInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_BuildingId",
                table: "Room",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_RoomDimensionsId",
                table: "Room",
                column: "RoomDimensionsId");

            migrationBuilder.CreateIndex(
                name: "IX_SplitRenovation_FirstNewRoomInfoId",
                table: "SplitRenovation",
                column: "FirstNewRoomInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_SplitRenovation_SecondNewRoomInfoId",
                table: "SplitRenovation",
                column: "SecondNewRoomInfoId");

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
                name: "EquipmentTransfer");

            migrationBuilder.DropTable(
                name: "Holiday");

            migrationBuilder.DropTable(
                name: "MergeRenovation");

            migrationBuilder.DropTable(
                name: "SplitRenovation");

            migrationBuilder.DropTable(
                name: "BackToMap",
                schema: "Events");

            migrationBuilder.DropTable(
                name: "BuildingSelection",
                schema: "Events");

            migrationBuilder.DropTable(
                name: "EquipmentTransferEvent",
                schema: "Events");

            migrationBuilder.DropTable(
                name: "FloorChange",
                schema: "Events");

            migrationBuilder.DropTable(
                name: "MergeRenovationEvent",
                schema: "Events");

            migrationBuilder.DropTable(
                name: "RoomSelection",
                schema: "Events");

            migrationBuilder.DropTable(
                name: "SplitRenovationEvent",
                schema: "Events");

            migrationBuilder.DropTable(
                name: "Workday");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "NewRoomInfo");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Shift");

            migrationBuilder.DropTable(
                name: "EquipmentItem");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Building");

            migrationBuilder.DropTable(
                name: "RoomDimension");
        }
    }
}

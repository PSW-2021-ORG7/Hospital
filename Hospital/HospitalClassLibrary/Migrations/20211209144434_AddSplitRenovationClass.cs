using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalClassLibrary.Migrations
{
    public partial class AddSplitRenovationClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_SplitRenovation_FirstNewRoomInfoId",
                table: "SplitRenovation",
                column: "FirstNewRoomInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_SplitRenovation_SecondNewRoomInfoId",
                table: "SplitRenovation",
                column: "SecondNewRoomInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SplitRenovation");

            migrationBuilder.DropTable(
                name: "NewRoomInfo");
        }
    }
}

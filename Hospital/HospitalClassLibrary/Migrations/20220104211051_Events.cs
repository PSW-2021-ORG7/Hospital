using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalClassLibrary.Migrations
{
    public partial class Events : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildingSelection_Building_buildingId",
                schema: "Events",
                table: "BuildingSelection");

            migrationBuilder.DropColumn(
                name: "userId",
                schema: "Events",
                table: "BuildingSelection");

            migrationBuilder.RenameColumn(
                name: "buildingId",
                schema: "Events",
                table: "BuildingSelection",
                newName: "BuildingId");

            migrationBuilder.RenameIndex(
                name: "IX_BuildingSelection_buildingId",
                schema: "Events",
                table: "BuildingSelection",
                newName: "IX_BuildingSelection_BuildingId");

            migrationBuilder.CreateTable(
                name: "RoomSelection",
                schema: "Events",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    RoomId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomSelection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomSelection_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomSelection_RoomId",
                schema: "Events",
                table: "RoomSelection",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingSelection_Building_BuildingId",
                schema: "Events",
                table: "BuildingSelection",
                column: "BuildingId",
                principalTable: "Building",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildingSelection_Building_BuildingId",
                schema: "Events",
                table: "BuildingSelection");

            migrationBuilder.DropTable(
                name: "RoomSelection",
                schema: "Events");

            migrationBuilder.RenameColumn(
                name: "BuildingId",
                schema: "Events",
                table: "BuildingSelection",
                newName: "buildingId");

            migrationBuilder.RenameIndex(
                name: "IX_BuildingSelection_BuildingId",
                schema: "Events",
                table: "BuildingSelection",
                newName: "IX_BuildingSelection_buildingId");

            migrationBuilder.AddColumn<string>(
                name: "userId",
                schema: "Events",
                table: "BuildingSelection",
                type: "text",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingSelection_Building_buildingId",
                schema: "Events",
                table: "BuildingSelection",
                column: "buildingId",
                principalTable: "Building",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalClassLibrary.Migrations
{
    public partial class CreateEquipmentTransfer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentTransfer");
        }
    }
}

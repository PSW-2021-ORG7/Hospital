using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalClassLibrary.Migrations
{
    public partial class Events : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentTransferEvent_Room_DestinationRoomId",
                schema: "Events",
                table: "EquipmentTransferEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentTransferEvent_Equipment_EquipmentId",
                schema: "Events",
                table: "EquipmentTransferEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentTransferEvent_Room_SourceRoomId",
                schema: "Events",
                table: "EquipmentTransferEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomSelection_Room_RoomId",
                schema: "Events",
                table: "RoomSelection");

            migrationBuilder.DropIndex(
                name: "IX_RoomSelection_RoomId",
                schema: "Events",
                table: "RoomSelection");

            migrationBuilder.DropIndex(
                name: "IX_EquipmentTransferEvent_DestinationRoomId",
                schema: "Events",
                table: "EquipmentTransferEvent");

            migrationBuilder.DropIndex(
                name: "IX_EquipmentTransferEvent_EquipmentId",
                schema: "Events",
                table: "EquipmentTransferEvent");

            migrationBuilder.DropIndex(
                name: "IX_EquipmentTransferEvent_SourceRoomId",
                schema: "Events",
                table: "EquipmentTransferEvent");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                schema: "Events",
                table: "RoomSelection",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                schema: "Events",
                table: "RoomSelection",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_RoomSelection_RoomId",
                schema: "Events",
                table: "RoomSelection",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentTransferEvent_DestinationRoomId",
                schema: "Events",
                table: "EquipmentTransferEvent",
                column: "DestinationRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentTransferEvent_EquipmentId",
                schema: "Events",
                table: "EquipmentTransferEvent",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentTransferEvent_SourceRoomId",
                schema: "Events",
                table: "EquipmentTransferEvent",
                column: "SourceRoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentTransferEvent_Room_DestinationRoomId",
                schema: "Events",
                table: "EquipmentTransferEvent",
                column: "DestinationRoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentTransferEvent_Equipment_EquipmentId",
                schema: "Events",
                table: "EquipmentTransferEvent",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentTransferEvent_Room_SourceRoomId",
                schema: "Events",
                table: "EquipmentTransferEvent",
                column: "SourceRoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomSelection_Room_RoomId",
                schema: "Events",
                table: "RoomSelection",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalClassLibrary.Migrations
{
    public partial class RefactorRoomDimensions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_Room_RoomId",
                table: "Doctor");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_Room_RoomId",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentTransfer_Room_DestinationRoomId",
                table: "EquipmentTransfer");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentTransfer_Room_SourceRoomId",
                table: "EquipmentTransfer");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_Building_BuildingId",
                table: "Room");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_RoomDimension_RoomDimensionsId",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomDimension",
                table: "RoomDimension");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Room",
                table: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Room_RoomDimensionsId",
                table: "Room");

            migrationBuilder.DeleteData(
                table: "RoomDimension",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RoomDimension",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RoomDimension",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RoomDimension",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RoomDimension",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RoomDimension",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "RoomDimension",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "RoomDimension",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "RoomDimension",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "RoomDimension",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "RoomDimension",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "RoomDimension",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "RoomDimension",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "RoomDimension",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "RoomDimension",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "RoomDimension",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "RoomDimension",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "RoomDimension",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "RoomDimension",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "RoomDimension",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "RoomDimension",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "RoomDimension",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "RoomDimension",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "RoomDimension",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "RoomDimension");

            migrationBuilder.DropColumn(
                name: "RoomDimensionsId",
                table: "Room");

            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.RenameTable(
                name: "RoomDimension",
                newName: "RoomDimension",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Room",
                newName: "Rooms",
                newSchema: "public");

            migrationBuilder.RenameIndex(
                name: "IX_Room_BuildingId",
                schema: "public",
                table: "Rooms",
                newName: "IX_Rooms_BuildingId");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                schema: "public",
                table: "RoomDimension",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomDimension",
                schema: "public",
                table: "RoomDimension",
                column: "RoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                schema: "public",
                table: "Rooms",
                column: "Id");

            migrationBuilder.InsertData(
                schema: "public",
                table: "RoomDimension",
                columns: new[] { "RoomId", "Height", "Width", "X", "Y" },
                values: new object[,]
                {
                    { 1, 220.0, 228.0, 422.0, 187.0 },
                    { 22, 138.0, 106.0, 422.0, 544.0 },
                    { 21, 138.0, 106.0, 422.0, 407.0 },
                    { 20, 154.0, 202.0, 1190.0, 541.0 },
                    { 19, 154.0, 202.0, 1190.0, 696.0 },
                    { 18, 170.0, 322.0, 861.0, 237.0 },
                    { 17, 170.0, 210.0, 650.0, 237.0 },
                    { 16, 170.0, 210.0, 1182.0, 237.0 },
                    { 15, 254.0, 209.0, 651.0, 596.0 },
                    { 14, 217.0, 229.0, 422.0, 683.0 },
                    { 13, 220.0, 228.0, 422.0, 187.0 },
                    { 12, 134.0, 69.0, 581.0, 548.0 },
                    { 11, 69.0, 69.0, 581.0, 407.0 },
                    { 10, 138.0, 106.0, 422.0, 544.0 },
                    { 9, 138.0, 106.0, 422.0, 407.0 },
                    { 8, 154.0, 202.0, 1190.0, 541.0 },
                    { 7, 154.0, 202.0, 1190.0, 696.0 },
                    { 6, 170.0, 322.0, 861.0, 237.0 },
                    { 5, 170.0, 210.0, 650.0, 237.0 },
                    { 4, 170.0, 210.0, 1182.0, 237.0 },
                    { 3, 254.0, 209.0, 651.0, 596.0 },
                    { 2, 217.0, 229.0, 422.0, 683.0 },
                    { 23, 69.0, 69.0, 581.0, 407.0 },
                    { 24, 134.0, 69.0, 581.0, 548.0 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_Rooms_RoomId",
                table: "Doctor",
                column: "RoomId",
                principalSchema: "public",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_Rooms_RoomId",
                table: "Equipment",
                column: "RoomId",
                principalSchema: "public",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentTransfer_Rooms_DestinationRoomId",
                table: "EquipmentTransfer",
                column: "DestinationRoomId",
                principalSchema: "public",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentTransfer_Rooms_SourceRoomId",
                table: "EquipmentTransfer",
                column: "SourceRoomId",
                principalSchema: "public",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomDimension_Rooms_RoomId",
                schema: "public",
                table: "RoomDimension",
                column: "RoomId",
                principalSchema: "public",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Building_BuildingId",
                schema: "public",
                table: "Rooms",
                column: "BuildingId",
                principalTable: "Building",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_Rooms_RoomId",
                table: "Doctor");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_Rooms_RoomId",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentTransfer_Rooms_DestinationRoomId",
                table: "EquipmentTransfer");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentTransfer_Rooms_SourceRoomId",
                table: "EquipmentTransfer");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomDimension_Rooms_RoomId",
                schema: "public",
                table: "RoomDimension");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Building_BuildingId",
                schema: "public",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomDimension",
                schema: "public",
                table: "RoomDimension");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                schema: "public",
                table: "Rooms");

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RoomDimension",
                keyColumn: "RoomId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RoomDimension",
                keyColumn: "RoomId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RoomDimension",
                keyColumn: "RoomId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RoomDimension",
                keyColumn: "RoomId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RoomDimension",
                keyColumn: "RoomId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RoomDimension",
                keyColumn: "RoomId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RoomDimension",
                keyColumn: "RoomId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RoomDimension",
                keyColumn: "RoomId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RoomDimension",
                keyColumn: "RoomId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RoomDimension",
                keyColumn: "RoomId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RoomDimension",
                keyColumn: "RoomId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RoomDimension",
                keyColumn: "RoomId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RoomDimension",
                keyColumn: "RoomId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RoomDimension",
                keyColumn: "RoomId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RoomDimension",
                keyColumn: "RoomId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RoomDimension",
                keyColumn: "RoomId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RoomDimension",
                keyColumn: "RoomId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RoomDimension",
                keyColumn: "RoomId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RoomDimension",
                keyColumn: "RoomId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RoomDimension",
                keyColumn: "RoomId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RoomDimension",
                keyColumn: "RoomId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RoomDimension",
                keyColumn: "RoomId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RoomDimension",
                keyColumn: "RoomId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RoomDimension",
                keyColumn: "RoomId",
                keyValue: 24);

            migrationBuilder.DropColumn(
                name: "RoomId",
                schema: "public",
                table: "RoomDimension");

            migrationBuilder.RenameTable(
                name: "RoomDimension",
                schema: "public",
                newName: "RoomDimension");

            migrationBuilder.RenameTable(
                name: "Rooms",
                schema: "public",
                newName: "Room");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_BuildingId",
                table: "Room",
                newName: "IX_Room_BuildingId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "RoomDimension",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:IdentitySequenceOptions", "'25', '1', '', '', 'False', '1'")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "RoomDimensionsId",
                table: "Room",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomDimension",
                table: "RoomDimension",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Room",
                table: "Room",
                column: "Id");

            migrationBuilder.InsertData(
                table: "RoomDimension",
                columns: new[] { "Id", "Height", "Width", "X", "Y" },
                values: new object[,]
                {
                    { 1, 220.0, 228.0, 422.0, 187.0 },
                    { 22, 138.0, 106.0, 422.0, 544.0 },
                    { 21, 138.0, 106.0, 422.0, 407.0 },
                    { 20, 154.0, 202.0, 1190.0, 541.0 },
                    { 19, 154.0, 202.0, 1190.0, 696.0 },
                    { 18, 170.0, 322.0, 861.0, 237.0 },
                    { 17, 170.0, 210.0, 650.0, 237.0 },
                    { 16, 170.0, 210.0, 1182.0, 237.0 },
                    { 15, 254.0, 209.0, 651.0, 596.0 },
                    { 14, 217.0, 229.0, 422.0, 683.0 },
                    { 13, 220.0, 228.0, 422.0, 187.0 },
                    { 12, 134.0, 69.0, 581.0, 548.0 },
                    { 11, 69.0, 69.0, 581.0, 407.0 },
                    { 10, 138.0, 106.0, 422.0, 544.0 },
                    { 9, 138.0, 106.0, 422.0, 407.0 },
                    { 8, 154.0, 202.0, 1190.0, 541.0 },
                    { 7, 154.0, 202.0, 1190.0, 696.0 },
                    { 6, 170.0, 322.0, 861.0, 237.0 },
                    { 5, 170.0, 210.0, 650.0, 237.0 },
                    { 4, 170.0, 210.0, 1182.0, 237.0 },
                    { 3, 254.0, 209.0, 651.0, 596.0 },
                    { 2, 217.0, 229.0, 422.0, 683.0 },
                    { 23, 69.0, 69.0, 581.0, 407.0 },
                    { 24, 134.0, 69.0, 581.0, 548.0 }
                });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 1,
                column: "RoomDimensionsId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 2,
                column: "RoomDimensionsId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 3,
                column: "RoomDimensionsId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 4,
                column: "RoomDimensionsId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 5,
                column: "RoomDimensionsId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 6,
                column: "RoomDimensionsId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 7,
                column: "RoomDimensionsId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 8,
                column: "RoomDimensionsId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 9,
                column: "RoomDimensionsId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 10,
                column: "RoomDimensionsId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 11,
                column: "RoomDimensionsId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 12,
                column: "RoomDimensionsId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 13,
                column: "RoomDimensionsId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 14,
                column: "RoomDimensionsId",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 15,
                column: "RoomDimensionsId",
                value: 15);

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 16,
                column: "RoomDimensionsId",
                value: 16);

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 17,
                column: "RoomDimensionsId",
                value: 17);

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 18,
                column: "RoomDimensionsId",
                value: 18);

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 19,
                column: "RoomDimensionsId",
                value: 19);

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 20,
                column: "RoomDimensionsId",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 21,
                column: "RoomDimensionsId",
                value: 21);

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 22,
                column: "RoomDimensionsId",
                value: 22);

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 23,
                column: "RoomDimensionsId",
                value: 23);

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 24,
                column: "RoomDimensionsId",
                value: 24);

            migrationBuilder.CreateIndex(
                name: "IX_Room_RoomDimensionsId",
                table: "Room",
                column: "RoomDimensionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_Room_RoomId",
                table: "Doctor",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_Room_RoomId",
                table: "Equipment",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentTransfer_Room_DestinationRoomId",
                table: "EquipmentTransfer",
                column: "DestinationRoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentTransfer_Room_SourceRoomId",
                table: "EquipmentTransfer",
                column: "SourceRoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Building_BuildingId",
                table: "Room",
                column: "BuildingId",
                principalTable: "Building",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Room_RoomDimension_RoomDimensionsId",
                table: "Room",
                column: "RoomDimensionsId",
                principalTable: "RoomDimension",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

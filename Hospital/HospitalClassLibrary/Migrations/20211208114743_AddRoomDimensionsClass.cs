using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalClassLibrary.Migrations
{
    public partial class AddRoomDimensionsClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FreeBeds",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "X",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "Y",
                table: "Room");

            migrationBuilder.AddColumn<int>(
                name: "RoomDimensionsId",
                table: "Room",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RoomDimension",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
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
                name: "FK_Room_RoomDimension_RoomDimensionsId",
                table: "Room",
                column: "RoomDimensionsId",
                principalTable: "RoomDimension",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_RoomDimension_RoomDimensionsId",
                table: "Room");

            migrationBuilder.DropTable(
                name: "RoomDimension");

            migrationBuilder.DropIndex(
                name: "IX_Room_RoomDimensionsId",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "RoomDimensionsId",
                table: "Room");

            migrationBuilder.AddColumn<int>(
                name: "FreeBeds",
                table: "Room",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Height",
                table: "Room",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Width",
                table: "Room",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "X",
                table: "Room",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Y",
                table: "Room",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 220.0, 228.0, 422.0, 187.0 });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 217.0, 229.0, 422.0, 683.0 });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 254.0, 209.0, 651.0, 596.0 });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FreeBeds", "Height", "Width", "X", "Y" },
                values: new object[] { 1, 170.0, 210.0, 1182.0, 237.0 });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FreeBeds", "Height", "Width", "X", "Y" },
                values: new object[] { 1, 170.0, 210.0, 650.0, 237.0 });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "FreeBeds", "Height", "Width", "X", "Y" },
                values: new object[] { 1, 170.0, 322.0, 861.0, 237.0 });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "FreeBeds", "Height", "Width", "X", "Y" },
                values: new object[] { 1, 154.0, 202.0, 1190.0, 696.0 });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "FreeBeds", "Height", "Width", "X", "Y" },
                values: new object[] { 1, 154.0, 202.0, 1190.0, 541.0 });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 138.0, 106.0, 422.0, 407.0 });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 138.0, 106.0, 422.0, 544.0 });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 69.0, 69.0, 581.0, 407.0 });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 134.0, 69.0, 581.0, 548.0 });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 220.0, 228.0, 422.0, 187.0 });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 217.0, 229.0, 422.0, 683.0 });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 254.0, 209.0, 651.0, 596.0 });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "FreeBeds", "Height", "Width", "X", "Y" },
                values: new object[] { 1, 170.0, 210.0, 1182.0, 237.0 });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "FreeBeds", "Height", "Width", "X", "Y" },
                values: new object[] { 1, 170.0, 210.0, 650.0, 237.0 });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "FreeBeds", "Height", "Width", "X", "Y" },
                values: new object[] { 1, 170.0, 322.0, 861.0, 237.0 });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "FreeBeds", "Height", "Width", "X", "Y" },
                values: new object[] { 1, 154.0, 202.0, 1190.0, 696.0 });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "FreeBeds", "Height", "Width", "X", "Y" },
                values: new object[] { 1, 154.0, 202.0, 1190.0, 541.0 });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 138.0, 106.0, 422.0, 407.0 });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 138.0, 106.0, 422.0, 544.0 });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 69.0, 69.0, 581.0, 407.0 });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 134.0, 69.0, 581.0, 548.0 });
        }
    }
}

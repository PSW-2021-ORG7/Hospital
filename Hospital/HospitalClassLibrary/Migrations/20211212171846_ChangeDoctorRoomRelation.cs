using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalClassLibrary.Migrations
{
    public partial class ChangeDoctorRoomRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_Room_RoomId",
                table: "Doctor");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "Doctor",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_Room_RoomId",
                table: "Doctor",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_Room_RoomId",
                table: "Doctor");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "Doctor",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_Room_RoomId",
                table: "Doctor",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

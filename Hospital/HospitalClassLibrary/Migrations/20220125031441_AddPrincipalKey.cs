using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalClassLibrary.Migrations
{
    public partial class AddPrincipalKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnCallShift_DoctorSchedule_DoctorScheduleId",
                table: "OnCallShift");

            migrationBuilder.DropForeignKey(
                name: "FK_Workday_Doctor_DoctorId",
                schema: "public",
                table: "Workday");

            migrationBuilder.DropForeignKey(
                name: "FK_Workday_DoctorSchedule_DoctorScheduleId",
                schema: "public",
                table: "Workday");

            migrationBuilder.DropIndex(
                name: "IX_Workday_DoctorScheduleId",
                schema: "public",
                table: "Workday");

            migrationBuilder.DropIndex(
                name: "IX_OnCallShift_DoctorScheduleId",
                table: "OnCallShift");

            migrationBuilder.DropColumn(
                name: "DoctorScheduleId",
                schema: "public",
                table: "Workday");

            migrationBuilder.DropColumn(
                name: "DoctorScheduleId",
                table: "OnCallShift");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_DoctorSchedule_DoctorId",
                table: "DoctorSchedule",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_OnCallShift_DoctorId",
                table: "OnCallShift",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_OnCallShift_DoctorSchedule_DoctorId",
                table: "OnCallShift",
                column: "DoctorId",
                principalTable: "DoctorSchedule",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workday_DoctorSchedule_DoctorId",
                schema: "public",
                table: "Workday",
                column: "DoctorId",
                principalTable: "DoctorSchedule",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnCallShift_DoctorSchedule_DoctorId",
                table: "OnCallShift");

            migrationBuilder.DropForeignKey(
                name: "FK_Workday_DoctorSchedule_DoctorId",
                schema: "public",
                table: "Workday");

            migrationBuilder.DropIndex(
                name: "IX_OnCallShift_DoctorId",
                table: "OnCallShift");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_DoctorSchedule_DoctorId",
                table: "DoctorSchedule");

            migrationBuilder.AddColumn<int>(
                name: "DoctorScheduleId",
                schema: "public",
                table: "Workday",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoctorScheduleId",
                table: "OnCallShift",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workday_DoctorScheduleId",
                schema: "public",
                table: "Workday",
                column: "DoctorScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_OnCallShift_DoctorScheduleId",
                table: "OnCallShift",
                column: "DoctorScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_OnCallShift_DoctorSchedule_DoctorScheduleId",
                table: "OnCallShift",
                column: "DoctorScheduleId",
                principalTable: "DoctorSchedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Workday_Doctor_DoctorId",
                schema: "public",
                table: "Workday",
                column: "DoctorId",
                principalTable: "Doctor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workday_DoctorSchedule_DoctorScheduleId",
                schema: "public",
                table: "Workday",
                column: "DoctorScheduleId",
                principalTable: "DoctorSchedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

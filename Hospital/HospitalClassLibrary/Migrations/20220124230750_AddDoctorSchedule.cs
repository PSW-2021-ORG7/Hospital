using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalClassLibrary.Migrations
{
    public partial class AddDoctorSchedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorScheduleId",
                schema: "public",
                table: "Workday",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoctorScheduleId",
                table: "OnCallShift",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoctorScheduleId",
                table: "Holiday",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DoctorSchedule",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'7', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DoctorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorSchedule", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DoctorSchedule",
                columns: new[] { "Id", "DoctorId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workday_DoctorScheduleId",
                schema: "public",
                table: "Workday",
                column: "DoctorScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_OnCallShift_DoctorScheduleId",
                table: "OnCallShift",
                column: "DoctorScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Holiday_DoctorScheduleId",
                table: "Holiday",
                column: "DoctorScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Holiday_DoctorSchedule_DoctorScheduleId",
                table: "Holiday",
                column: "DoctorScheduleId",
                principalTable: "DoctorSchedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OnCallShift_DoctorSchedule_DoctorScheduleId",
                table: "OnCallShift",
                column: "DoctorScheduleId",
                principalTable: "DoctorSchedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Workday_DoctorSchedule_DoctorScheduleId",
                schema: "public",
                table: "Workday",
                column: "DoctorScheduleId",
                principalTable: "DoctorSchedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Holiday_DoctorSchedule_DoctorScheduleId",
                table: "Holiday");

            migrationBuilder.DropForeignKey(
                name: "FK_OnCallShift_DoctorSchedule_DoctorScheduleId",
                table: "OnCallShift");

            migrationBuilder.DropForeignKey(
                name: "FK_Workday_DoctorSchedule_DoctorScheduleId",
                schema: "public",
                table: "Workday");

            migrationBuilder.DropTable(
                name: "DoctorSchedule");

            migrationBuilder.DropIndex(
                name: "IX_Workday_DoctorScheduleId",
                schema: "public",
                table: "Workday");

            migrationBuilder.DropIndex(
                name: "IX_OnCallShift_DoctorScheduleId",
                table: "OnCallShift");

            migrationBuilder.DropIndex(
                name: "IX_Holiday_DoctorScheduleId",
                table: "Holiday");

            migrationBuilder.DropColumn(
                name: "DoctorScheduleId",
                schema: "public",
                table: "Workday");

            migrationBuilder.DropColumn(
                name: "DoctorScheduleId",
                table: "OnCallShift");

            migrationBuilder.DropColumn(
                name: "DoctorScheduleId",
                table: "Holiday");
        }
    }
}

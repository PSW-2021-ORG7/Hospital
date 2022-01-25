using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalClassLibrary.Migrations
{
    public partial class RefactorAppointments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Workday_WorkdayId",
                table: "Appointment");

            migrationBuilder.RenameTable(
                name: "Workday",
                newName: "Workday",
                newSchema: "public");

            migrationBuilder.AlterColumn<int>(
                name: "WorkdayId",
                table: "Appointment",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Appointment",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:IdentitySequenceOptions", "'34', '1', '', '', 'False', '1'")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Workday_WorkdayId",
                table: "Appointment",
                column: "WorkdayId",
                principalSchema: "public",
                principalTable: "Workday",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Workday_WorkdayId",
                table: "Appointment");

            migrationBuilder.RenameTable(
                name: "Workday",
                schema: "public",
                newName: "Workday");

            migrationBuilder.AlterColumn<int>(
                name: "WorkdayId",
                table: "Appointment",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Appointment",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("Npgsql:IdentitySequenceOptions", "'34', '1', '', '', 'False', '1'")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Workday_WorkdayId",
                table: "Appointment",
                column: "WorkdayId",
                principalTable: "Workday",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

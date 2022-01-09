using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalClassLibrary.Migrations
{
    public partial class AddShiftNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Shift",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Shift",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Morning shift");

            migrationBuilder.UpdateData(
                table: "Shift",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Afternoon shift");

            migrationBuilder.UpdateData(
                table: "Shift",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Morning shift");

            migrationBuilder.UpdateData(
                table: "Shift",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Afternoon shift");

            migrationBuilder.UpdateData(
                table: "Shift",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Morning shift");

            migrationBuilder.UpdateData(
                table: "Shift",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Afternoon shift");

            migrationBuilder.UpdateData(
                table: "Shift",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Morning shift");

            migrationBuilder.UpdateData(
                table: "Shift",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Afternoon shift");

            migrationBuilder.UpdateData(
                table: "Shift",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Morning shift");

            migrationBuilder.UpdateData(
                table: "Shift",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Afternoon shift");

            migrationBuilder.UpdateData(
                table: "Shift",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "Morning shift");

            migrationBuilder.UpdateData(
                table: "Shift",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: "Afternoon shift");

            migrationBuilder.UpdateData(
                table: "Shift",
                keyColumn: "Id",
                keyValue: 13,
                column: "Name",
                value: "Morning shift");

            migrationBuilder.UpdateData(
                table: "Shift",
                keyColumn: "Id",
                keyValue: 14,
                column: "Name",
                value: "Afternoon shift");

            migrationBuilder.UpdateData(
                table: "Shift",
                keyColumn: "Id",
                keyValue: 15,
                column: "Name",
                value: "Morning shift");

            migrationBuilder.UpdateData(
                table: "Shift",
                keyColumn: "Id",
                keyValue: 16,
                column: "Name",
                value: "Afternoon shift");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Shift");
        }
    }
}

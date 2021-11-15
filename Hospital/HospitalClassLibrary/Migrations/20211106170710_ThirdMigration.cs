using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital_Class_Library.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 220.0, 228.0, 422.0, 187.0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "10",
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 138.0, 106.0, 422.0, 544.0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "11",
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 69.0, 69.0, 581.0, 407.0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "12",
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 134.0, 69.0, 581.0, 548.0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "13",
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 220.0, 228.0, 422.0, 187.0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "14",
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 217.0, 229.0, 422.0, 683.0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "15",
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 254.0, 209.0, 651.0, 596.0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "16",
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 170.0, 210.0, 1182.0, 237.0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "17",
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 170.0, 210.0, 650.0, 237.0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "18",
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 170.0, 322.0, 861.0, 237.0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "19",
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 154.0, 202.0, 1190.0, 696.0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 217.0, 229.0, 422.0, 683.0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "20",
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 154.0, 202.0, 1190.0, 541.0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "21",
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 138.0, 106.0, 422.0, 407.0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "22",
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 138.0, 106.0, 422.0, 544.0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "23",
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 69.0, 69.0, 581.0, 407.0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "24",
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 134.0, 69.0, 581.0, 548.0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 254.0, 209.0, 651.0, 596.0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 170.0, 210.0, 1182.0, 237.0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 170.0, 210.0, 650.0, 237.0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 170.0, 322.0, 861.0, 237.0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "7",
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 154.0, 202.0, 1190.0, 696.0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "8",
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 154.0, 202.0, 1190.0, 541.0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "9",
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 138.0, 106.0, 422.0, 407.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 246.0, 255.0, 9.0, 9.0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "10",
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 154.0, 119.0, 9.0, 409.0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "11",
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 77.0, 77.0, 187.0, 255.0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "12",
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 150.0, 77.0, 187.0, 413.0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "13",
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 246.0, 255.0, 9.0, 9.0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "14",
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 243.0, 256.0, 9.0, 563.0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "15",
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 284.0, 234.0, 265.0, 466.0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "16",
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 190.0, 235.0, 264.0, 65.0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "17",
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 190.0, 235.0, 859.0, 65.0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "18",
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 190.0, 360.0, 499.0, 65.0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "19",
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 172.37, 226.0, 868.0, 577.63 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 243.0, 256.0, 9.0, 563.0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "20",
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 172.37, 226.0, 868.0, 405.0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "21",
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 154.0, 119.0, 9.0, 255.0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "22",
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 154.0, 119.0, 9.0, 409.0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "23",
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 77.0, 77.0, 187.0, 255.0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "24",
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 150.0, 77.0, 187.0, 413.0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 284.0, 234.0, 265.0, 466.0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 190.0, 235.0, 264.0, 65.0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 190.0, 235.0, 859.0, 65.0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 190.0, 360.0, 499.0, 65.0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "7",
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 172.37, 226.0, 868.0, 577.63 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "8",
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 172.37, 226.0, 868.0, 405.0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "9",
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 154.0, 119.0, 9.0, 255.0 });
        }
    }
}

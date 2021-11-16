using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital_Class_Library.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    BuildingId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    FreeBeds = table.Column<int>(nullable: false),
                    Floor = table.Column<int>(nullable: false),
                    X = table.Column<double>(nullable: false),
                    Y = table.Column<double>(nullable: false),
                    Width = table.Column<double>(nullable: false),
                    Height = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BuildingId", "Floor", "FreeBeds", "Height", "Name", "Status", "Type", "Width", "X", "Y" },
                values: new object[,]
                {
                    { 1, 1, 0, 0, 246.0, "0A", 1, 4, 255.0, 9.0, 9.0 },
                    { 22, 1, 1, 0, 154.0, "Women Restroom", 1, 5, 119.0, 9.0, 409.0 },
                    { 21, 1, 1, 0, 154.0, "Men Restroom", 1, 5, 119.0, 9.0, 255.0 },
                    { 20, 1, 1, 1, 172.37, "1B", 1, 3, 226.0, 868.0, 405.0 },
                    { 19, 1, 1, 1, 172.37, "1A", 1, 3, 226.0, 868.0, 577.63 },
                    { 18, 1, 1, 1, 190.0, "1A", 1, 1, 360.0, 499.0, 65.0 },
                    { 17, 1, 1, 1, 190.0, "1B", 1, 0, 235.0, 859.0, 65.0 },
                    { 16, 1, 1, 1, 190.0, "1A", 1, 0, 235.0, 264.0, 65.0 },
                    { 15, 1, 1, 0, 284.0, "1C", 1, 4, 234.0, 265.0, 466.0 },
                    { 14, 1, 1, 0, 243.0, "1B", 1, 4, 256.0, 9.0, 563.0 },
                    { 13, 1, 1, 0, 246.0, "1A", 1, 4, 255.0, 9.0, 9.0 },
                    { 12, 1, 0, 0, 150.0, "S1", 1, 7, 77.0, 187.0, 413.0 },
                    { 11, 1, 0, 0, 77.0, "L", 1, 6, 77.0, 187.0, 255.0 },
                    { 10, 1, 0, 0, 154.0, "Women Restroom", 1, 5, 119.0, 9.0, 409.0 },
                    { 9, 1, 0, 0, 154.0, "Men Restroom", 1, 5, 119.0, 9.0, 255.0 },
                    { 8, 1, 0, 1, 172.37, "0B", 1, 3, 226.0, 868.0, 405.0 },
                    { 7, 1, 0, 1, 172.37, "0A", 1, 3, 226.0, 868.0, 577.63 },
                    { 6, 1, 0, 1, 190.0, "0A", 1, 1, 360.0, 499.0, 65.0 },
                    { 5, 1, 0, 1, 190.0, "0B", 1, 0, 235.0, 859.0, 65.0 },
                    { 4, 1, 0, 1, 190.0, "0A", 1, 0, 235.0, 264.0, 65.0 },
                    { 3, 1, 0, 0, 284.0, "0C", 1, 4, 234.0, 265.0, 466.0 },
                    { 2, 1, 0, 0, 243.0, "0B", 1, 4, 256.0, 9.0, 563.0 },
                    { 23, 1, 1, 0, 77.0, "L", 1, 6, 77.0, 187.0, 255.0 },
                    { 24, 1, 1, 0, 150.0, "S1", 1, 7, 77.0, 187.0, 413.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}

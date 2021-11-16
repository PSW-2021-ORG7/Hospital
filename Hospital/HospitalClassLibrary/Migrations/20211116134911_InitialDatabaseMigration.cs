using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalClassLibrary.Migrations
{
    public partial class InitialDatabaseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    FreeBeds = table.Column<int>(nullable: false),
                    Floor = table.Column<int>(nullable: false),
                    X = table.Column<double>(nullable: false),
                    Y = table.Column<double>(nullable: false),
                    Width = table.Column<double>(nullable: false),
                    Height = table.Column<double>(nullable: false),
                    BuildingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "The administrative center of Oasis Healthcare", "Oasis Main Building" },
                    { 2, "The treatment facility of Oasis Healthcare", "Oasis Treatment Center" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BuildingId", "Floor", "FreeBeds", "Height", "Name", "Status", "Type", "Width", "X", "Y" },
                values: new object[,]
                {
                    { 1, 1, 0, 0, 220.0, "0A", 1, 4, 228.0, 422.0, 187.0 },
                    { 22, 1, 1, 0, 138.0, "Women Restroom", 1, 5, 106.0, 422.0, 544.0 },
                    { 21, 1, 1, 0, 138.0, "Men Restroom", 1, 5, 106.0, 422.0, 407.0 },
                    { 20, 1, 1, 1, 154.0, "1B", 1, 3, 202.0, 1190.0, 541.0 },
                    { 19, 1, 1, 1, 154.0, "1A", 1, 3, 202.0, 1190.0, 696.0 },
                    { 18, 1, 1, 1, 170.0, "1A", 1, 1, 322.0, 861.0, 237.0 },
                    { 17, 1, 1, 1, 170.0, "1B", 1, 0, 210.0, 650.0, 237.0 },
                    { 16, 1, 1, 1, 170.0, "1A", 1, 0, 210.0, 1182.0, 237.0 },
                    { 15, 1, 1, 0, 254.0, "1C", 1, 4, 209.0, 651.0, 596.0 },
                    { 14, 1, 1, 0, 217.0, "1B", 1, 4, 229.0, 422.0, 683.0 },
                    { 13, 1, 1, 0, 220.0, "1A", 1, 4, 228.0, 422.0, 187.0 },
                    { 12, 1, 0, 0, 134.0, "S1", 1, 7, 69.0, 581.0, 548.0 },
                    { 11, 1, 0, 0, 69.0, "L", 1, 6, 69.0, 581.0, 407.0 },
                    { 10, 1, 0, 0, 138.0, "Women Restroom", 1, 5, 106.0, 422.0, 544.0 },
                    { 9, 1, 0, 0, 138.0, "Men Restroom", 1, 5, 106.0, 422.0, 407.0 },
                    { 8, 1, 0, 1, 154.0, "0B", 1, 3, 202.0, 1190.0, 541.0 },
                    { 7, 1, 0, 1, 154.0, "0A", 1, 3, 202.0, 1190.0, 696.0 },
                    { 6, 1, 0, 1, 170.0, "0A", 1, 1, 322.0, 861.0, 237.0 },
                    { 5, 1, 0, 1, 170.0, "0B", 1, 0, 210.0, 650.0, 237.0 },
                    { 4, 1, 0, 1, 170.0, "0A", 1, 0, 210.0, 1182.0, 237.0 },
                    { 3, 1, 0, 0, 254.0, "0C", 1, 4, 209.0, 651.0, 596.0 },
                    { 2, 1, 0, 0, 217.0, "0B", 1, 4, 229.0, 422.0, 683.0 },
                    { 23, 1, 1, 0, 69.0, "L", 1, 6, 69.0, 581.0, 407.0 },
                    { 24, 1, 1, 0, 134.0, "S1", 1, 7, 69.0, 581.0, 548.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_BuildingId",
                table: "Rooms",
                column: "BuildingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Buildings");
        }
    }
}

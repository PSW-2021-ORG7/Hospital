using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalClassLibrary.Migrations
{
    public partial class EquipmentDataFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EquipmentItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoomId = table.Column<int>(nullable: false),
                    EquipmentItemId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipment_EquipmentItem_EquipmentItemId",
                        column: x => x.EquipmentItemId,
                        principalTable: "EquipmentItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipment_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EquipmentItem",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Syringe" },
                    { 2, "Thermometer" },
                    { 3, "Infusion pump" },
                    { 4, "Gauze" },
                    { 5, "Operating table" },
                    { 6, "Otoscope" },
                    { 7, "Inhaler" },
                    { 8, "Scalpel" },
                    { 9, "Adhesive Plaster" },
                    { 10, "Curette" }
                });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "EquipmentItemId", "Quantity", "RoomId" },
                values: new object[,]
                {
                    { 1, 1, 100, 4 },
                    { 7, 1, 104, 5 },
                    { 2, 2, 2, 4 },
                    { 8, 2, 5, 5 },
                    { 3, 3, 4, 4 },
                    { 9, 3, 6, 5 },
                    { 4, 4, 200, 4 },
                    { 10, 4, 150, 5 },
                    { 6, 5, 1, 4 },
                    { 12, 5, 1, 5 },
                    { 5, 8, 6, 4 },
                    { 11, 8, 10, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_EquipmentItemId",
                table: "Equipment",
                column: "EquipmentItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_RoomId",
                table: "Equipment",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "EquipmentItem");
        }
    }
}

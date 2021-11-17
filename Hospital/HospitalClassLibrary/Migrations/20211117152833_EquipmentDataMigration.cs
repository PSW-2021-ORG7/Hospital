using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalClassLibrary.Migrations
{
    public partial class EquipmentDataMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EquipmentItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
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
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "A syringe is a simple reciprocating pump consisting of a plunger that fits tightly within a cylindrical tube called a barrel.", "Syringe" },
                    { 2, "A thermometer is a device that measures temperature or a temperature gradient.", "Thermometer" },
                    { 3, "An external infusion pump is a medical device used to deliver fluids into a patient’s body in a controlled manner.", "Infusion pump" },
                    { 4, "Gauze is a thin, translucent fabric with a loose open weave.", "Gauze" },
                    { 5, "An operating table, sometimes called operating room table, is the table on which the patient lies during a surgical operation.", "Operating table" },
                    { 6, "An otoscope or auriscope is a medical device which is used to look into the ears.", "Otoscope" },
                    { 7, "An inhaler is a medical device used for delivering medicines into the lungs through the work of a person's breathing.", "Inhaler" },
                    { 8, "A scalpel is a small and extremely sharp bladed instrument used for surgery, anatomical dissection, podiatry and various arts and crafts.", "Scalpel" },
                    { 9, "An adhesive bandage is a small medical dressing used for injuries not serious enough to require a full-size bandage.", "Adhesive Plaster" },
                    { 10, "A curette is a surgical instrument designed for scraping or debriding biological tissue or debris in a biopsy, excision, or cleaning procedure.", "Curette" },
                    { 11, "Medical gloves are disposable gloves used during medical examinations and procedures to help prevent cross-contamination between caregivers and patients.", "Medical glove" },
                    { 12, "An oxygen tank is an oxygen storage vessel, which is either held under pressure in gas cylinders, or as liquid oxygen in a cryogenic storage tank.", "Oxygen tank" },
                    { 13, "A Miller–Abbott tube is a tube used to treat obstructions in the small intestine through intubation.", "Miller–Abbott tube" },
                    { 14, "The tube is inserted through a cut in the neck below the vocal cords. This allows air to enter the lungs.", "Trach tube" },
                    { 15, "Surgical suture is a medical device used to hold body tissues together after an injury or surgery.", "Surgical suture" }
                });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "EquipmentItemId", "Quantity", "RoomId" },
                values: new object[,]
                {
                    { 1, 1, 100, 4 },
                    { 5, 8, 6, 4 },
                    { 11, 8, 10, 5 },
                    { 21, 8, 6, 16 },
                    { 29, 8, 10, 17 },
                    { 33, 11, 230, 17 },
                    { 34, 11, 200, 1 },
                    { 30, 5, 1, 17 },
                    { 35, 11, 110, 2 },
                    { 13, 14, 4, 4 },
                    { 15, 14, 3, 4 },
                    { 23, 14, 4, 16 },
                    { 31, 14, 3, 17 },
                    { 14, 15, 1, 4 },
                    { 16, 15, 1, 4 },
                    { 36, 11, 235, 3 },
                    { 22, 5, 1, 16 },
                    { 12, 5, 1, 5 },
                    { 6, 5, 1, 4 },
                    { 7, 1, 104, 5 },
                    { 17, 1, 100, 16 },
                    { 25, 1, 104, 17 },
                    { 2, 2, 2, 4 },
                    { 8, 2, 5, 5 },
                    { 18, 2, 2, 16 },
                    { 26, 2, 5, 17 },
                    { 3, 3, 4, 4 },
                    { 9, 3, 6, 5 },
                    { 19, 3, 4, 16 },
                    { 27, 3, 6, 17 },
                    { 4, 4, 200, 4 },
                    { 10, 4, 150, 5 },
                    { 20, 4, 200, 16 },
                    { 28, 4, 150, 17 },
                    { 24, 15, 1, 16 },
                    { 32, 15, 1, 17 }
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

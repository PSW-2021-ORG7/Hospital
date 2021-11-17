using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalClassLibrary.Migrations
{
    public partial class EquipmentDataSecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "EquipmentItem",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "EquipmentItemId", "Quantity", "RoomId" },
                values: new object[,]
                {
                    { 17, 1, 100, 16 },
                    { 30, 5, 1, 17 },
                    { 28, 4, 150, 17 },
                    { 27, 3, 6, 17 },
                    { 26, 2, 5, 17 },
                    { 25, 1, 104, 17 },
                    { 29, 8, 10, 17 },
                    { 21, 8, 6, 16 },
                    { 20, 4, 200, 16 },
                    { 19, 3, 4, 16 },
                    { 18, 2, 2, 16 },
                    { 22, 5, 1, 16 }
                });

            migrationBuilder.UpdateData(
                table: "EquipmentItem",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "A syringe is a simple reciprocating pump consisting of a plunger that fits tightly within a cylindrical tube called a barrel.");

            migrationBuilder.UpdateData(
                table: "EquipmentItem",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "A thermometer is a device that measures temperature or a temperature gradient.");

            migrationBuilder.UpdateData(
                table: "EquipmentItem",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "An external infusion pump is a medical device used to deliver fluids into a patient’s body in a controlled manner.");

            migrationBuilder.UpdateData(
                table: "EquipmentItem",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "Gauze is a thin, translucent fabric with a loose open weave.");

            migrationBuilder.UpdateData(
                table: "EquipmentItem",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "An operating table, sometimes called operating room table, is the table on which the patient lies during a surgical operation.");

            migrationBuilder.UpdateData(
                table: "EquipmentItem",
                keyColumn: "Id",
                keyValue: 6,
                column: "Description",
                value: "An otoscope or auriscope is a medical device which is used to look into the ears.");

            migrationBuilder.UpdateData(
                table: "EquipmentItem",
                keyColumn: "Id",
                keyValue: 7,
                column: "Description",
                value: "An inhaler is a medical device used for delivering medicines into the lungs through the work of a person's breathing.");

            migrationBuilder.UpdateData(
                table: "EquipmentItem",
                keyColumn: "Id",
                keyValue: 8,
                column: "Description",
                value: "A scalpel is a small and extremely sharp bladed instrument used for surgery, anatomical dissection, podiatry and various arts and crafts.");

            migrationBuilder.UpdateData(
                table: "EquipmentItem",
                keyColumn: "Id",
                keyValue: 9,
                column: "Description",
                value: "An adhesive bandage is a small medical dressing used for injuries not serious enough to require a full-size bandage.");

            migrationBuilder.UpdateData(
                table: "EquipmentItem",
                keyColumn: "Id",
                keyValue: 10,
                column: "Description",
                value: "A curette is a surgical instrument designed for scraping or debriding biological tissue or debris in a biopsy, excision, or cleaning procedure.");

            migrationBuilder.InsertData(
                table: "EquipmentItem",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 14, "The tube is inserted through a cut in the neck below the vocal cords. This allows air to enter the lungs.", "Trach tube" },
                    { 13, "A Miller–Abbott tube is a tube used to treat obstructions in the small intestine through intubation.", "Miller–Abbott tube" },
                    { 11, "Medical gloves are disposable gloves used during medical examinations and procedures to help prevent cross-contamination between caregivers and patients.", "Medical glove" },
                    { 15, "Surgical suture is a medical device used to hold body tissues together after an injury or surgery.", "Surgical suture" },
                    { 12, "An oxygen tank is an oxygen storage vessel, which is either held under pressure in gas cylinders, or as liquid oxygen in a cryogenic storage tank.", "Oxygen tank" }
                });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "EquipmentItemId", "Quantity", "RoomId" },
                values: new object[,]
                {
                    { 33, 11, 230, 17 },
                    { 34, 11, 200, 1 },
                    { 35, 11, 110, 2 },
                    { 36, 11, 235, 3 },
                    { 13, 14, 4, 4 },
                    { 15, 14, 3, 4 },
                    { 23, 14, 4, 16 },
                    { 31, 14, 3, 17 },
                    { 14, 15, 1, 4 },
                    { 16, 15, 1, 4 },
                    { 24, 15, 1, 16 },
                    { 32, 15, 1, 17 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "EquipmentItem",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "EquipmentItem",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "EquipmentItem",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "EquipmentItem",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "EquipmentItem",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DropColumn(
                name: "Description",
                table: "EquipmentItem");
        }
    }
}

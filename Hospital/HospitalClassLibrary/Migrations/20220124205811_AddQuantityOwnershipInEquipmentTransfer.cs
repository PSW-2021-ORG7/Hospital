using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalClassLibrary.Migrations
{
    public partial class AddQuantityOwnershipInEquipmentTransfer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "EquipmentTransfer");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                schema: "public",
                table: "EquipmentTransfer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                schema: "public",
                table: "EquipmentTransfer");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "EquipmentTransfer",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalClassLibrary.Migrations
{
    public partial class AddOnCallShifts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OnCallShift",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'13', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Start = table.Column<DateTime>(nullable: false),
                    DoctorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnCallShift", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "OnCallShift",
                columns: new[] { "Id", "DoctorId", "Start" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 1, 10, 23, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2022, 1, 10, 23, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, new DateTime(2022, 1, 11, 23, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 2, new DateTime(2022, 1, 11, 23, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 3, new DateTime(2022, 1, 12, 23, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 4, new DateTime(2022, 1, 12, 23, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 3, new DateTime(2022, 1, 13, 23, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 4, new DateTime(2022, 1, 13, 23, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 5, new DateTime(2022, 1, 14, 23, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 6, new DateTime(2022, 1, 14, 23, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 5, new DateTime(2022, 1, 15, 23, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 6, new DateTime(2022, 1, 15, 23, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OnCallShift");
        }
    }
}

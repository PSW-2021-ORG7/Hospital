using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalClassLibrary.Migrations
{
    public partial class AddMergeRenovationClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MergeRenovation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstOldRoomId = table.Column<int>(nullable: false),
                    SecondOldRoomId = table.Column<int>(nullable: false),
                    NewRoomInfoId = table.Column<int>(nullable: true),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MergeRenovation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MergeRenovation_NewRoomInfo_NewRoomInfoId",
                        column: x => x.NewRoomInfoId,
                        principalTable: "NewRoomInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MergeRenovation_NewRoomInfoId",
                table: "MergeRenovation",
                column: "NewRoomInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MergeRenovation");
        }
    }
}

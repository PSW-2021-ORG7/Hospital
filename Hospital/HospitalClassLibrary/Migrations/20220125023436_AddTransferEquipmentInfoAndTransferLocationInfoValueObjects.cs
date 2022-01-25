﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalClassLibrary.Migrations
{
    public partial class AddTransferEquipmentInfoAndTransferLocationInfoValueObjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentTransfer_Rooms_TransferLocationInfo_DestinationRoo~",
                schema: "public",
                table: "EquipmentTransfer");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentTransfer_Rooms_TransferLocationInfo_SourceRoomId",
                schema: "public",
                table: "EquipmentTransfer");

            migrationBuilder.DropColumn(
                name: "Amount",
                schema: "public",
                table: "EquipmentTransfer");

            migrationBuilder.RenameColumn(
                name: "TransferLocationInfo_SourceRoomId",
                schema: "public",
                table: "EquipmentTransfer",
                newName: "SourceRoomId");

            migrationBuilder.RenameColumn(
                name: "TransferLocationInfo_DestinationRoomId",
                schema: "public",
                table: "EquipmentTransfer",
                newName: "DestinationRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentTransfer_TransferLocationInfo_SourceRoomId",
                schema: "public",
                table: "EquipmentTransfer",
                newName: "IX_EquipmentTransfer_SourceRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentTransfer_TransferLocationInfo_DestinationRoomId",
                schema: "public",
                table: "EquipmentTransfer",
                newName: "IX_EquipmentTransfer_DestinationRoomId");

            migrationBuilder.AlterColumn<int>(
                name: "TransferDuration",
                schema: "public",
                table: "EquipmentTransfer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransferDate",
                schema: "public",
                table: "EquipmentTransfer",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<int>(
                name: "EquipmentId",
                schema: "public",
                table: "EquipmentTransfer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                schema: "public",
                table: "EquipmentTransfer",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentTransfer_Rooms_DestinationRoomId",
                schema: "public",
                table: "EquipmentTransfer",
                column: "DestinationRoomId",
                principalSchema: "public",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentTransfer_Rooms_SourceRoomId",
                schema: "public",
                table: "EquipmentTransfer",
                column: "SourceRoomId",
                principalSchema: "public",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentTransfer_Rooms_DestinationRoomId",
                schema: "public",
                table: "EquipmentTransfer");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentTransfer_Rooms_SourceRoomId",
                schema: "public",
                table: "EquipmentTransfer");

            migrationBuilder.DropColumn(
                name: "Quantity",
                schema: "public",
                table: "EquipmentTransfer");

            migrationBuilder.RenameColumn(
                name: "SourceRoomId",
                schema: "public",
                table: "EquipmentTransfer",
                newName: "TransferLocationInfo_SourceRoomId");

            migrationBuilder.RenameColumn(
                name: "DestinationRoomId",
                schema: "public",
                table: "EquipmentTransfer",
                newName: "TransferLocationInfo_DestinationRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentTransfer_SourceRoomId",
                schema: "public",
                table: "EquipmentTransfer",
                newName: "IX_EquipmentTransfer_TransferLocationInfo_SourceRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentTransfer_DestinationRoomId",
                schema: "public",
                table: "EquipmentTransfer",
                newName: "IX_EquipmentTransfer_TransferLocationInfo_DestinationRoomId");

            migrationBuilder.AlterColumn<int>(
                name: "EquipmentId",
                schema: "public",
                table: "EquipmentTransfer",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TransferDuration",
                schema: "public",
                table: "EquipmentTransfer",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransferDate",
                schema: "public",
                table: "EquipmentTransfer",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                schema: "public",
                table: "EquipmentTransfer",
                type: "integer",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentTransfer_Rooms_TransferLocationInfo_DestinationRoo~",
                schema: "public",
                table: "EquipmentTransfer",
                column: "TransferLocationInfo_DestinationRoomId",
                principalSchema: "public",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentTransfer_Rooms_TransferLocationInfo_SourceRoomId",
                schema: "public",
                table: "EquipmentTransfer",
                column: "TransferLocationInfo_SourceRoomId",
                principalSchema: "public",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
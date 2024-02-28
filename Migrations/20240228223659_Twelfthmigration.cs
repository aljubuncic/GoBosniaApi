﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoTravnikApi.Migrations
{
    /// <inheritdoc />
    public partial class Twelfthmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_TouristContent_TouristContentId",
                table: "Image");

            migrationBuilder.AlterColumn<int>(
                name: "TouristContentId",
                table: "Image",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Image_TouristContent_TouristContentId",
                table: "Image",
                column: "TouristContentId",
                principalTable: "TouristContent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_TouristContent_TouristContentId",
                table: "Image");

            migrationBuilder.AlterColumn<int>(
                name: "TouristContentId",
                table: "Image",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_TouristContent_TouristContentId",
                table: "Image",
                column: "TouristContentId",
                principalTable: "TouristContent",
                principalColumn: "Id");
        }
    }
}

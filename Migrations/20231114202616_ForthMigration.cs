using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoTravnikApi.Migrations
{
    /// <inheritdoc />
    public partial class ForthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subcategory_Accommodation_AccommodationId",
                table: "Subcategory");

            migrationBuilder.DropIndex(
                name: "IX_Subcategory_AccommodationId",
                table: "Subcategory");

            migrationBuilder.DropColumn(
                name: "AccommodationId",
                table: "Subcategory");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccommodationId",
                table: "Subcategory",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subcategory_AccommodationId",
                table: "Subcategory",
                column: "AccommodationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subcategory_Accommodation_AccommodationId",
                table: "Subcategory",
                column: "AccommodationId",
                principalTable: "Accommodation",
                principalColumn: "Id");
        }
    }
}

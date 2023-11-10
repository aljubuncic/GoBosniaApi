using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoTravnikApi.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accommodation_Rating_RatingId",
                table: "Accommodation");

            migrationBuilder.DropIndex(
                name: "IX_Accommodation_RatingId",
                table: "Accommodation");

            migrationBuilder.DropColumn(
                name: "IdRating",
                table: "Accommodation");

            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "Accommodation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdRating",
                table: "Accommodation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RatingId",
                table: "Accommodation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Accommodation_RatingId",
                table: "Accommodation",
                column: "RatingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accommodation_Rating_RatingId",
                table: "Accommodation",
                column: "RatingId",
                principalTable: "Rating",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

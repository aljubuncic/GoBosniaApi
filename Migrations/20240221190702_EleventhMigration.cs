using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoTravnikApi.Migrations
{
    /// <inheritdoc />
    public partial class EleventhMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_RatedTouristContent_TouristContentId",
                table: "Rating");

            migrationBuilder.RenameColumn(
                name: "TouristContentId",
                table: "Rating",
                newName: "RatedTouristContentId");

            migrationBuilder.RenameIndex(
                name: "IX_Rating_TouristContentId",
                table: "Rating",
                newName: "IX_Rating_RatedTouristContentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_RatedTouristContent_RatedTouristContentId",
                table: "Rating",
                column: "RatedTouristContentId",
                principalTable: "RatedTouristContent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_RatedTouristContent_RatedTouristContentId",
                table: "Rating");

            migrationBuilder.RenameColumn(
                name: "RatedTouristContentId",
                table: "Rating",
                newName: "TouristContentId");

            migrationBuilder.RenameIndex(
                name: "IX_Rating_RatedTouristContentId",
                table: "Rating",
                newName: "IX_Rating_TouristContentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_RatedTouristContent_TouristContentId",
                table: "Rating",
                column: "TouristContentId",
                principalTable: "RatedTouristContent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

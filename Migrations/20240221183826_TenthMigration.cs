using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoTravnikApi.Migrations
{
    /// <inheritdoc />
    public partial class TenthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accommodation_TouristContent_Id",
                table: "Accommodation");

            migrationBuilder.DropForeignKey(
                name: "FK_Activity_TouristContent_Id",
                table: "Activity");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodAndDrink_TouristContent_Id",
                table: "FoodAndDrink");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Accommodation_AccommodationId",
                table: "Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Activity_ActivityId",
                table: "Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_FoodAndDrink_FoodAndDrinkId",
                table: "Rating");

            migrationBuilder.DropIndex(
                name: "IX_Rating_AccommodationId",
                table: "Rating");

            migrationBuilder.DropIndex(
                name: "IX_Rating_ActivityId",
                table: "Rating");

            migrationBuilder.DropIndex(
                name: "IX_Rating_FoodAndDrinkId",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "AccommodationId",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "FoodAndDrinkId",
                table: "Rating");

            migrationBuilder.AddColumn<int>(
                name: "TouristContentId",
                table: "Rating",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RatedTouristContent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatedTouristContent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RatedTouristContent_TouristContent_Id",
                        column: x => x.Id,
                        principalTable: "TouristContent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rating_TouristContentId",
                table: "Rating",
                column: "TouristContentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accommodation_RatedTouristContent_Id",
                table: "Accommodation",
                column: "Id",
                principalTable: "RatedTouristContent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_RatedTouristContent_Id",
                table: "Activity",
                column: "Id",
                principalTable: "RatedTouristContent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodAndDrink_RatedTouristContent_Id",
                table: "FoodAndDrink",
                column: "Id",
                principalTable: "RatedTouristContent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_RatedTouristContent_TouristContentId",
                table: "Rating",
                column: "TouristContentId",
                principalTable: "RatedTouristContent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accommodation_RatedTouristContent_Id",
                table: "Accommodation");

            migrationBuilder.DropForeignKey(
                name: "FK_Activity_RatedTouristContent_Id",
                table: "Activity");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodAndDrink_RatedTouristContent_Id",
                table: "FoodAndDrink");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_RatedTouristContent_TouristContentId",
                table: "Rating");

            migrationBuilder.DropTable(
                name: "RatedTouristContent");

            migrationBuilder.DropIndex(
                name: "IX_Rating_TouristContentId",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "TouristContentId",
                table: "Rating");

            migrationBuilder.AddColumn<int>(
                name: "AccommodationId",
                table: "Rating",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ActivityId",
                table: "Rating",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FoodAndDrinkId",
                table: "Rating",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rating_AccommodationId",
                table: "Rating",
                column: "AccommodationId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_ActivityId",
                table: "Rating",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_FoodAndDrinkId",
                table: "Rating",
                column: "FoodAndDrinkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accommodation_TouristContent_Id",
                table: "Accommodation",
                column: "Id",
                principalTable: "TouristContent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_TouristContent_Id",
                table: "Activity",
                column: "Id",
                principalTable: "TouristContent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodAndDrink_TouristContent_Id",
                table: "FoodAndDrink",
                column: "Id",
                principalTable: "TouristContent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Accommodation_AccommodationId",
                table: "Rating",
                column: "AccommodationId",
                principalTable: "Accommodation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Activity_ActivityId",
                table: "Rating",
                column: "ActivityId",
                principalTable: "Activity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_FoodAndDrink_FoodAndDrinkId",
                table: "Rating",
                column: "FoodAndDrinkId",
                principalTable: "FoodAndDrink",
                principalColumn: "Id");
        }
    }
}

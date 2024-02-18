using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoTravnikApi.Migrations
{
    /// <inheritdoc />
    public partial class EighthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_TouristContent_TouristContentId",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "TouristContent");

            migrationBuilder.RenameColumn(
                name: "TouristContentId",
                table: "Rating",
                newName: "FoodAndDrinkId");

            migrationBuilder.RenameIndex(
                name: "IX_Rating_TouristContentId",
                table: "Rating",
                newName: "IX_Rating_FoodAndDrinkId");

            migrationBuilder.RenameColumn(
                name: "startDate",
                table: "Event",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "endDate",
                table: "Event",
                newName: "EndDate");

            migrationBuilder.AlterColumn<string>(
                name: "TextComment",
                table: "Rating",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Location",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Website",
                table: "FoodAndDrink",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Website",
                table: "Accommodation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TouristContentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_TouristContent_TouristContentId",
                        column: x => x.TouristContentId,
                        principalTable: "TouristContent",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rating_AccommodationId",
                table: "Rating",
                column: "AccommodationId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_ActivityId",
                table: "Rating",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_TouristContentId",
                table: "Image",
                column: "TouristContentId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Accommodation_AccommodationId",
                table: "Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Activity_ActivityId",
                table: "Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_FoodAndDrink_FoodAndDrinkId",
                table: "Rating");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Rating_AccommodationId",
                table: "Rating");

            migrationBuilder.DropIndex(
                name: "IX_Rating_ActivityId",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "AccommodationId",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Location");

            migrationBuilder.RenameColumn(
                name: "FoodAndDrinkId",
                table: "Rating",
                newName: "TouristContentId");

            migrationBuilder.RenameIndex(
                name: "IX_Rating_FoodAndDrinkId",
                table: "Rating",
                newName: "IX_Rating_TouristContentId");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Event",
                newName: "startDate");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Event",
                newName: "endDate");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "TouristContent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "TextComment",
                table: "Rating",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Website",
                table: "FoodAndDrink",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Website",
                table: "Accommodation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_TouristContent_TouristContentId",
                table: "Rating",
                column: "TouristContentId",
                principalTable: "TouristContent",
                principalColumn: "Id");
        }
    }
}

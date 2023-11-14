using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoTravnikApi.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TouristContentSubcategory");

            migrationBuilder.AddColumn<int>(
                name: "AccommodationId",
                table: "Subcategory",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SubcategoryTouristContent",
                columns: table => new
                {
                    SubcategoriesId = table.Column<int>(type: "int", nullable: false),
                    TouristContentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubcategoryTouristContent", x => new { x.SubcategoriesId, x.TouristContentsId });
                    table.ForeignKey(
                        name: "FK_SubcategoryTouristContent_Subcategory_SubcategoriesId",
                        column: x => x.SubcategoriesId,
                        principalTable: "Subcategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubcategoryTouristContent_TouristContent_TouristContentsId",
                        column: x => x.TouristContentsId,
                        principalTable: "TouristContent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subcategory_AccommodationId",
                table: "Subcategory",
                column: "AccommodationId");

            migrationBuilder.CreateIndex(
                name: "IX_SubcategoryTouristContent_TouristContentsId",
                table: "SubcategoryTouristContent",
                column: "TouristContentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subcategory_Accommodation_AccommodationId",
                table: "Subcategory",
                column: "AccommodationId",
                principalTable: "Accommodation",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subcategory_Accommodation_AccommodationId",
                table: "Subcategory");

            migrationBuilder.DropTable(
                name: "SubcategoryTouristContent");

            migrationBuilder.DropIndex(
                name: "IX_Subcategory_AccommodationId",
                table: "Subcategory");

            migrationBuilder.DropColumn(
                name: "AccommodationId",
                table: "Subcategory");

            migrationBuilder.CreateTable(
                name: "TouristContentSubcategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubcategoryId = table.Column<int>(type: "int", nullable: false),
                    TouristContentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TouristContentSubcategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TouristContentSubcategory_Subcategory_SubcategoryId",
                        column: x => x.SubcategoryId,
                        principalTable: "Subcategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TouristContentSubcategory_TouristContent_TouristContentId",
                        column: x => x.TouristContentId,
                        principalTable: "TouristContent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TouristContentSubcategory_SubcategoryId",
                table: "TouristContentSubcategory",
                column: "SubcategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TouristContentSubcategory_TouristContentId",
                table: "TouristContentSubcategory",
                column: "TouristContentId");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace ProiectMedii.Migrations
{
    public partial class PaintingCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExhibitionID",
                table: "Painting",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Exhibition",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExhibitionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exhibition", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PaintingCategory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaintingID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaintingCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PaintingCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaintingCategory_Painting_PaintingID",
                        column: x => x.PaintingID,
                        principalTable: "Painting",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Painting_ExhibitionID",
                table: "Painting",
                column: "ExhibitionID");

            migrationBuilder.CreateIndex(
                name: "IX_PaintingCategory_CategoryID",
                table: "PaintingCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_PaintingCategory_PaintingID",
                table: "PaintingCategory",
                column: "PaintingID");

            migrationBuilder.AddForeignKey(
                name: "FK_Painting_Exhibition_ExhibitionID",
                table: "Painting",
                column: "ExhibitionID",
                principalTable: "Exhibition",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Painting_Exhibition_ExhibitionID",
                table: "Painting");

            migrationBuilder.DropTable(
                name: "Exhibition");

            migrationBuilder.DropTable(
                name: "PaintingCategory");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Painting_ExhibitionID",
                table: "Painting");

            migrationBuilder.DropColumn(
                name: "ExhibitionID",
                table: "Painting");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP_project.Migrations
{
    public partial class AddedIngredientList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IngredientListId",
                table: "Ingredients",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IngredientList",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientList", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_IngredientListId",
                table: "Ingredients",
                column: "IngredientListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_IngredientList_IngredientListId",
                table: "Ingredients",
                column: "IngredientListId",
                principalTable: "IngredientList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_IngredientList_IngredientListId",
                table: "Ingredients");

            migrationBuilder.DropTable(
                name: "IngredientList");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_IngredientListId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "IngredientListId",
                table: "Ingredients");
        }
    }
}

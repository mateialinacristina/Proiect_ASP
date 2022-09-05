using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP_project.Migrations
{
    public partial class AddedRecipeList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RecipeListId",
                table: "Recipes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RecipeList",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeList", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_RecipeListId",
                table: "Recipes",
                column: "RecipeListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_RecipeList_RecipeListId",
                table: "Recipes",
                column: "RecipeListId",
                principalTable: "RecipeList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_RecipeList_RecipeListId",
                table: "Recipes");

            migrationBuilder.DropTable(
                name: "RecipeList");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_RecipeListId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "RecipeListId",
                table: "Recipes");
        }
    }
}

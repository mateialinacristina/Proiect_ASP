using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP_project.Migrations
{
    public partial class AddedIngredientShoppingList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShoppingLists",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LimitDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IngredientShoppingLists",
                columns: table => new
                {
                    IngredientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ShoppingListId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientShoppingLists", x => new { x.IngredientId, x.ShoppingListId });
                    table.ForeignKey(
                        name: "FK_IngredientShoppingLists_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientShoppingLists_ShoppingLists_ShoppingListId",
                        column: x => x.ShoppingListId,
                        principalTable: "ShoppingLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientShoppingLists_ShoppingListId",
                table: "IngredientShoppingLists",
                column: "ShoppingListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientShoppingLists");

            migrationBuilder.DropTable(
                name: "ShoppingLists");
        }
    }
}

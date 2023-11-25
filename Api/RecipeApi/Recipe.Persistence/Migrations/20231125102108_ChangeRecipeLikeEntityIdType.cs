using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recipe.Persistence.Migrations
{
    public partial class ChangeRecipeLikeEntityIdType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auth_AppUsers_Recipes_RecipeEntityId",
                table: "Auth_AppUsers");

            migrationBuilder.DropIndex(
                name: "IX_Auth_AppUsers_RecipeEntityId",
                table: "Auth_AppUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeLikes",
                table: "RecipeLikes");

            migrationBuilder.DropColumn(
                name: "RecipeEntityId",
                table: "Auth_AppUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "RecipeLikes");

            migrationBuilder.RenameTable(
                name: "RecipeLikes",
                newName: "RecipesLikes");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "RecipesLikes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipesLikes",
                table: "RecipesLikes",
                columns: new[] { "RecipeId", "AppUserId" });

            migrationBuilder.CreateIndex(
                name: "IX_RecipesLikes_AppUserId",
                table: "RecipesLikes",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipesLikes_Auth_AppUsers_AppUserId",
                table: "RecipesLikes",
                column: "AppUserId",
                principalTable: "Auth_AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipesLikes_Recipes_RecipeId",
                table: "RecipesLikes",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipesLikes_Auth_AppUsers_AppUserId",
                table: "RecipesLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipesLikes_Recipes_RecipeId",
                table: "RecipesLikes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipesLikes",
                table: "RecipesLikes");

            migrationBuilder.DropIndex(
                name: "IX_RecipesLikes_AppUserId",
                table: "RecipesLikes");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "RecipesLikes");

            migrationBuilder.RenameTable(
                name: "RecipesLikes",
                newName: "RecipeLikes");

            migrationBuilder.AddColumn<int>(
                name: "RecipeEntityId",
                table: "Auth_AppUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "RecipeLikes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeLikes",
                table: "RecipeLikes",
                columns: new[] { "RecipeId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_Auth_AppUsers_RecipeEntityId",
                table: "Auth_AppUsers",
                column: "RecipeEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Auth_AppUsers_Recipes_RecipeEntityId",
                table: "Auth_AppUsers",
                column: "RecipeEntityId",
                principalTable: "Recipes",
                principalColumn: "Id");
        }
    }
}

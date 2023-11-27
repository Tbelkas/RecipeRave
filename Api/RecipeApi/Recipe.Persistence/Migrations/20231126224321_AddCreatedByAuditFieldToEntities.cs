using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recipe.Persistence.Migrations
{
    public partial class AddCreatedByAuditFieldToEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "RecipesLikes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Ingredients",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "RecipesLikes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Ingredients");
        }
    }
}
